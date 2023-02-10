
#region ================== Copyright (c) 2007 Pascal vd Heiden

/*
 * Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com
 * This program is released under GNU General Public License
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

#endregion

#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.IO;
using System.IO;
using CodeImp.DoomBuilder.Config;
using CodeImp.DoomBuilder.Editing;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Controls;

#endregion

namespace CodeImp.DoomBuilder.Windows
{
    /// <summary>
    /// Dialog window that allows viewing and editing of Thing properties.
    /// </summary>
    public partial class ThingEditForm : DelayedForm
    {
        #region ================== Variables

        private ICollection<Thing> things;
        private List<TreeNode> nodes;
        private ThingTypeInfo thinginfo;

        #endregion

        #region ================== Properties

        #endregion

        #region ================== Constructor

        // Constructor
        public ThingEditForm()
        {
            // Initialize
            InitializeComponent();

            // Fill flags list
            foreach (KeyValuePair<string, string> tf in General.Map.Config.ThingFlags)
                flags.Add(tf.Value, tf.Key);

            // villsa - hide thing tag if specified false
            if (!General.Map.FormatInterface.HasThingTag)
                groupBox3.Hide();

            // Thing height?
            height.Visible = General.Map.FormatInterface.HasThingHeight;
            heightlabel.Visible = General.Map.FormatInterface.HasThingHeight;

            // Setup types list
            thingtype.Setup();
        }

        // This sets up the form to edit the given things
        public void Setup(ICollection<Thing> things)
        {
            Thing ft;

            // Keep this list
            this.things = things;
            if (things.Count > 1) this.Text = "Edit Things (" + things.Count + ")";

            ////////////////////////////////////////////////////////////////////////
            // Set all options to the first thing properties
            ////////////////////////////////////////////////////////////////////////

            ft = General.GetByIndex(things, 0);

            // Set type
            thingtype.SelectType(ft.Type);

            // Flags
            foreach (CheckBox c in flags.Checkboxes)
                if (ft.Flags.ContainsKey(c.Tag.ToString())) c.Checked = ft.Flags[c.Tag.ToString()];

            // Coordination
            angle.Text = Angle2D.RealToDoom(ft.Angle).ToString();
            height.Text = ((int)ft.Position.z).ToString();

            // Tag
            tag.Text = ft.Tag.ToString();

            ////////////////////////////////////////////////////////////////////////
            // Now go for all lines and change the options when a setting is different
            ////////////////////////////////////////////////////////////////////////

            // Go for all things
            foreach (Thing t in things)
            {
                // Type does not match?
                if ((thingtype.GetSelectedInfo() != null) &&
                   (thingtype.GetSelectedInfo().Index != t.Type))
                    thingtype.ClearSelectedType();

                // Flags
                foreach (CheckBox c in flags.Checkboxes)
                {
                    if (t.Flags.ContainsKey(c.Tag.ToString()))
                    {
                        if (t.Flags[c.Tag.ToString()] != c.Checked)
                        {
                            c.ThreeState = true;
                            c.CheckState = CheckState.Indeterminate;
                        }
                    }
                }

                // Coordination
                int angledeg = Angle2D.RealToDoom(t.Angle);
                if (angledeg.ToString() != angle.Text) angle.Text = "";
                if (((int)t.Position.z).ToString() != height.Text) height.Text = "";

                // Tag
                if (t.Tag.ToString() != tag.Text) tag.Text = "";
            }
        }

        #endregion

        #region ================== Interface

        // This finds a new (unused) tag
        private void newtag_Click(object sender, EventArgs e)
        {
            tag.Text = General.Map.Map.GetNewTag().ToString();
        }

        // Selected type changes
        private void thingtype_OnTypeChanged(ThingTypeInfo value)
        {
            thinginfo = value;

            // Update preview image
            if (thinginfo != null)
            {
                if (thinginfo.Title == "Camera") // villsa 9/11/11
                {
                    General.DisplayZoomedImage(spritetex, General.Map.Data.ThingCamera.GetBitmap());
                }
                else if (thinginfo.Title == "Trigger") // villsa 9/11/11
                {
                    General.DisplayZoomedImage(spritetex, General.Map.Data.ThingTrigger.GetBitmap());
                }
                else if (thinginfo.Sprite.ToLowerInvariant().StartsWith(DataManager.INTERNAL_PREFIX) &&
                   (thinginfo.Sprite.Length > DataManager.INTERNAL_PREFIX.Length))
                {
                    General.DisplayZoomedImage(spritetex, General.Map.Data.GetSpriteImage(thinginfo.Sprite).GetBitmap());
                }
                else if ((thinginfo.Sprite.Length <= 8) && (thinginfo.Sprite.Length > 0))
                {
                    General.DisplayZoomedImage(spritetex, General.Map.Data.GetSpriteImage(thinginfo.Sprite).GetPreview());
                }
                else
                {
                    spritetex.BackgroundImage = null;
                }
            }
            else
            {
                spritetex.BackgroundImage = null;
            }
        }

        // Angle text changes
        private void angle_TextChanged(object sender, EventArgs e)
        {
            anglecontrol.Value = angle.GetResult(int.MinValue);
        }

        // Angle control clicked
        private void anglecontrol_ButtonClicked(object sender, EventArgs e)
        {
            angle.Text = anglecontrol.Value.ToString();
        }

        // Apply clicked
        private void apply_Click(object sender, EventArgs e)
        {
            List<string> defaultflags = new List<string>();
            string undodesc = "thing";

            // Verify the tag
            if (General.Map.FormatInterface.HasThingTag && ((tag.GetResult(0) < General.Map.FormatInterface.MinTag) || (tag.GetResult(0) > General.Map.FormatInterface.MaxTag)))
            {
                General.ShowWarningMessage("Thing tag must be between " + General.Map.FormatInterface.MinTag + " and " + General.Map.FormatInterface.MaxTag + ".", MessageBoxButtons.OK);
                return;
            }

            // Verify the type
            if (((thingtype.GetResult(0) < General.Map.FormatInterface.MinThingType) || (thingtype.GetResult(0) > General.Map.FormatInterface.MaxThingType)))
            {
                General.ShowWarningMessage("Thing type must be between " + General.Map.FormatInterface.MinThingType + " and " + General.Map.FormatInterface.MaxThingType + ".", MessageBoxButtons.OK);
                return;
            }

            // Make undo
            if (things.Count > 1) undodesc = things.Count + " things";
            General.Map.UndoRedo.CreateUndo("Edit " + undodesc);

            // Go for all the things
            foreach (Thing t in things)
            {
                // Thing type index
                t.Type = General.Clamp(thingtype.GetResult(t.Type), General.Map.FormatInterface.MinThingType, General.Map.FormatInterface.MaxThingType);

                // Coordination
                t.Rotate(Angle2D.DoomToReal(angle.GetResult(Angle2D.RealToDoom(t.Angle))));
                t.Move(t.Position.x, t.Position.y, (float)height.GetResult((int)t.Position.z));

                // Apply all flags
                foreach (CheckBox c in flags.Checkboxes)
                {
                    if (c.CheckState == CheckState.Checked) t.SetFlag(c.Tag.ToString(), true);
                    else if (c.CheckState == CheckState.Unchecked) t.SetFlag(c.Tag.ToString(), false);
                }

                // Tag
                t.Tag = tag.GetResult(t.Tag);

                // Update settings
                t.UpdateConfiguration();
            }

            // Set as defaults
            foreach (CheckBox c in flags.Checkboxes)
                if (c.CheckState == CheckState.Checked) defaultflags.Add(c.Tag.ToString());
            General.Settings.DefaultThingType = thingtype.GetResult(General.Settings.DefaultThingType);
            General.Settings.DefaultThingAngle = Angle2D.DegToRad((float)angle.GetResult((int)Angle2D.RadToDeg(General.Settings.DefaultThingAngle) - 90) + 90);
            General.Settings.SetDefaultThingFlags(defaultflags);

            // Done
            General.Map.IsChanged = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cancel clicked
        private void cancel_Click(object sender, EventArgs e)
        {
            // Be gone
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Help
        private void ThingEditForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            General.ShowHelp("w_thingeditor.html");
            hlpevent.Handled = true;
        }

        #endregion
    }
}
