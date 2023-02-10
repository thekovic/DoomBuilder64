namespace CodeImp.DoomBuilder.Windows
{
    partial class SectorEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label labelTag;
            System.Windows.Forms.Label labelSpecial;
            System.Windows.Forms.GroupBox groupfloorceiling;
            System.Windows.Forms.Label labelFloorHeight;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label labelCeilingHeight;
            System.Windows.Forms.GroupBox incdecIntensity;
            System.Windows.Forms.GroupBox coloredLightingInfo;
            this.floorheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.ceilingheight = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.sectorheight = new System.Windows.Forms.Label();
            this.sectorheightlabel = new System.Windows.Forms.Label();
            this.floortex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.ceilingtex = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.floorcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.lowercolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.thingcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.topcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.ceilingcolor = new CodeImp.DoomBuilder.Controls.ColorControlSector();
            this.groupaction = new System.Windows.Forms.GroupBox();
            this.tag = new CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox();
            this.newtag = new System.Windows.Forms.Button();
            this.groupeffect = new System.Windows.Forms.GroupBox();
            this.browseeffect = new System.Windows.Forms.Button();
            this.effect = new CodeImp.DoomBuilder.Controls.ActionSelectorControl();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.sectorproperties = new System.Windows.Forms.Panel();
            this.lightsPanel = new System.Windows.Forms.Panel();
            this.settingsgroup = new System.Windows.Forms.GroupBox();
            this.flags = new CodeImp.DoomBuilder.Controls.CheckboxArrayControl();
            this.flatSelectorControl2 = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.flatSelectorControl1 = new CodeImp.DoomBuilder.Controls.FlatSelectorControl();
            this.heightpanel3 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            labelTag = new System.Windows.Forms.Label();
            labelSpecial = new System.Windows.Forms.Label();
            groupfloorceiling = new System.Windows.Forms.GroupBox();
            labelFloorHeight = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            labelCeilingHeight = new System.Windows.Forms.Label();
            incdecIntensity = new System.Windows.Forms.GroupBox();
            coloredLightingInfo = new System.Windows.Forms.GroupBox();
            groupfloorceiling.SuspendLayout();
            incdecIntensity.SuspendLayout();
            coloredLightingInfo.SuspendLayout();
            this.groupaction.SuspendLayout();
            this.groupeffect.SuspendLayout();
            this.sectorproperties.SuspendLayout();
            this.lightsPanel.SuspendLayout();
            this.settingsgroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(271, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 16);
            label1.TabIndex = 15;
            label1.Text = "Floor";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(363, 18);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 16);
            label3.TabIndex = 14;
            label3.Text = "Ceiling";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelTag
            // 
            labelTag.AutoSize = true;
            labelTag.Location = new System.Drawing.Point(55, 21);
            labelTag.Name = "labelTag";
            labelTag.Size = new System.Drawing.Size(27, 14);
            labelTag.TabIndex = 9;
            labelTag.Text = "Tag:";
            // 
            // labelSpecial
            // 
            labelSpecial.AutoSize = true;
            labelSpecial.Location = new System.Drawing.Point(38, 25);
            labelSpecial.Name = "labelSpecial";
            labelSpecial.Size = new System.Drawing.Size(45, 14);
            labelSpecial.TabIndex = 0;
            labelSpecial.Text = "Special:";
            // 
            // groupfloorceiling
            // 
            groupfloorceiling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupfloorceiling.Controls.Add(this.floorheight);
            groupfloorceiling.Controls.Add(this.ceilingheight);
            groupfloorceiling.Controls.Add(this.sectorheight);
            groupfloorceiling.Controls.Add(this.sectorheightlabel);
            groupfloorceiling.Controls.Add(labelFloorHeight);
            groupfloorceiling.Controls.Add(label2);
            groupfloorceiling.Controls.Add(label4);
            groupfloorceiling.Controls.Add(this.floortex);
            groupfloorceiling.Controls.Add(this.ceilingtex);
            groupfloorceiling.Controls.Add(labelCeilingHeight);
            groupfloorceiling.Location = new System.Drawing.Point(7, 6);
            groupfloorceiling.Name = "groupfloorceiling";
            groupfloorceiling.Size = new System.Drawing.Size(436, 143);
            groupfloorceiling.TabIndex = 0;
            groupfloorceiling.TabStop = false;
            groupfloorceiling.Text = "Floor and Ceiling ";
            // 
            // floorheight
            // 
            this.floorheight.AllowDecimal = false;
            this.floorheight.AllowNegative = true;
            this.floorheight.AllowRelative = true;
            this.floorheight.ButtonStep = 8;
            this.floorheight.Location = new System.Drawing.Point(112, 67);
            this.floorheight.Name = "floorheight";
            this.floorheight.Size = new System.Drawing.Size(88, 24);
            this.floorheight.StepValues = null;
            this.floorheight.TabIndex = 23;
            this.floorheight.WhenTextChanged += new System.EventHandler(this.floorheight_TextChanged);
            // 
            // ceilingheight
            // 
            this.ceilingheight.AllowDecimal = false;
            this.ceilingheight.AllowNegative = true;
            this.ceilingheight.AllowRelative = true;
            this.ceilingheight.ButtonStep = 8;
            this.ceilingheight.Location = new System.Drawing.Point(112, 33);
            this.ceilingheight.Name = "ceilingheight";
            this.ceilingheight.Size = new System.Drawing.Size(88, 24);
            this.ceilingheight.StepValues = null;
            this.ceilingheight.TabIndex = 22;
            this.ceilingheight.WhenTextChanged += new System.EventHandler(this.ceilingheight_TextChanged);
            // 
            // sectorheight
            // 
            this.sectorheight.AutoSize = true;
            this.sectorheight.Location = new System.Drawing.Point(113, 107);
            this.sectorheight.Name = "sectorheight";
            this.sectorheight.Size = new System.Drawing.Size(13, 14);
            this.sectorheight.TabIndex = 21;
            this.sectorheight.Text = "0";
            // 
            // sectorheightlabel
            // 
            this.sectorheightlabel.AutoSize = true;
            this.sectorheightlabel.Location = new System.Drawing.Point(32, 107);
            this.sectorheightlabel.Name = "sectorheightlabel";
            this.sectorheightlabel.Size = new System.Drawing.Size(74, 14);
            this.sectorheightlabel.TabIndex = 20;
            this.sectorheightlabel.Text = "Sector height:";
            // 
            // labelFloorHeight
            // 
            labelFloorHeight.AutoSize = true;
            labelFloorHeight.Location = new System.Drawing.Point(40, 72);
            labelFloorHeight.Name = "labelFloorHeight";
            labelFloorHeight.Size = new System.Drawing.Size(66, 14);
            labelFloorHeight.TabIndex = 17;
            labelFloorHeight.Text = "Floor height:";
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(237, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(83, 16);
            label2.TabIndex = 15;
            label2.Text = "Floor";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(332, 11);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 16);
            label4.TabIndex = 14;
            label4.Text = "Ceiling";
            label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // floortex
            // 
            this.floortex.Location = new System.Drawing.Point(237, 30);
            this.floortex.Name = "floortex";
            this.floortex.Size = new System.Drawing.Size(83, 105);
            this.floortex.TabIndex = 2;
            this.floortex.TextureName = "";
            // 
            // ceilingtex
            // 
            this.ceilingtex.Location = new System.Drawing.Point(332, 30);
            this.ceilingtex.Name = "ceilingtex";
            this.ceilingtex.Size = new System.Drawing.Size(83, 105);
            this.ceilingtex.TabIndex = 3;
            this.ceilingtex.TextureName = "";
            // 
            // labelCeilingHeight
            // 
            labelCeilingHeight.AutoSize = true;
            labelCeilingHeight.Location = new System.Drawing.Point(33, 38);
            labelCeilingHeight.Name = "labelCeilingHeight";
            labelCeilingHeight.Size = new System.Drawing.Size(73, 14);
            labelCeilingHeight.TabIndex = 19;
            labelCeilingHeight.Text = "Ceiling height:";
            // 
            // incdecIntensity
            // 
            incdecIntensity.Controls.Add(this.button19);
            incdecIntensity.Controls.Add(this.button20);
            incdecIntensity.Controls.Add(this.button17);
            incdecIntensity.Controls.Add(this.button18);
            incdecIntensity.Controls.Add(this.button5);
            incdecIntensity.Controls.Add(this.button16);
            incdecIntensity.Controls.Add(this.button3);
            incdecIntensity.Controls.Add(this.button4);
            incdecIntensity.Controls.Add(this.button2);
            incdecIntensity.Controls.Add(this.button1);
            incdecIntensity.Location = new System.Drawing.Point(324, 7);
            incdecIntensity.Name = "incdecIntensity";
            incdecIntensity.Size = new System.Drawing.Size(112, 167);
            incdecIntensity.TabIndex = 6;
            incdecIntensity.TabStop = false;
            incdecIntensity.Text = "Inc/Dec Intensity";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(59, 135);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(42, 20);
            this.button19.TabIndex = 61;
            this.button19.Text = "-";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(11, 135);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(42, 20);
            this.button20.TabIndex = 60;
            this.button20.Text = "+";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(59, 106);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(42, 20);
            this.button17.TabIndex = 59;
            this.button17.Text = "-";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(11, 106);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(42, 20);
            this.button18.TabIndex = 58;
            this.button18.Text = "+";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(59, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(42, 20);
            this.button5.TabIndex = 57;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(11, 77);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(42, 20);
            this.button16.TabIndex = 56;
            this.button16.Text = "+";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(59, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(42, 20);
            this.button3.TabIndex = 55;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 20);
            this.button4.TabIndex = 54;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 20);
            this.button2.TabIndex = 53;
            this.button2.Text = "-";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 20);
            this.button1.TabIndex = 52;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // coloredLightingInfo
            // 
            coloredLightingInfo.Controls.Add(this.floorcolor);
            coloredLightingInfo.Controls.Add(this.lowercolor);
            coloredLightingInfo.Controls.Add(this.thingcolor);
            coloredLightingInfo.Controls.Add(this.topcolor);
            coloredLightingInfo.Controls.Add(this.ceilingcolor);
            coloredLightingInfo.Location = new System.Drawing.Point(7, 162);
            coloredLightingInfo.Name = "coloredLightingInfo";
            coloredLightingInfo.Size = new System.Drawing.Size(294, 167);
            coloredLightingInfo.TabIndex = 5;
            coloredLightingInfo.TabStop = false;
            coloredLightingInfo.Text = "Colored Lighting Info";
            // 
            // floorcolor
            // 
            this.floorcolor.BackColor = System.Drawing.Color.Transparent;
            this.floorcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floorcolor.Label = "Floor:";
            this.floorcolor.Location = new System.Drawing.Point(16, 135);
            this.floorcolor.MaximumSize = new System.Drawing.Size(10000, 23);
            this.floorcolor.MinimumSize = new System.Drawing.Size(100, 23);
            this.floorcolor.Name = "floorcolor";
            this.floorcolor.Size = new System.Drawing.Size(272, 23);
            this.floorcolor.TabIndex = 6;
            // 
            // lowercolor
            // 
            this.lowercolor.BackColor = System.Drawing.Color.Transparent;
            this.lowercolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowercolor.Label = "Bottom Half Wall:";
            this.lowercolor.Location = new System.Drawing.Point(16, 106);
            this.lowercolor.MaximumSize = new System.Drawing.Size(10000, 23);
            this.lowercolor.MinimumSize = new System.Drawing.Size(100, 23);
            this.lowercolor.Name = "lowercolor";
            this.lowercolor.Size = new System.Drawing.Size(272, 23);
            this.lowercolor.TabIndex = 5;
            // 
            // thingcolor
            // 
            this.thingcolor.BackColor = System.Drawing.Color.Transparent;
            this.thingcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thingcolor.Label = "Thing:";
            this.thingcolor.Location = new System.Drawing.Point(16, 77);
            this.thingcolor.MaximumSize = new System.Drawing.Size(10000, 23);
            this.thingcolor.MinimumSize = new System.Drawing.Size(100, 23);
            this.thingcolor.Name = "thingcolor";
            this.thingcolor.Size = new System.Drawing.Size(272, 23);
            this.thingcolor.TabIndex = 4;
            // 
            // topcolor
            // 
            this.topcolor.BackColor = System.Drawing.Color.Transparent;
            this.topcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topcolor.Label = "Top Half Wall:";
            this.topcolor.Location = new System.Drawing.Point(16, 48);
            this.topcolor.MaximumSize = new System.Drawing.Size(10000, 23);
            this.topcolor.MinimumSize = new System.Drawing.Size(100, 23);
            this.topcolor.Name = "topcolor";
            this.topcolor.Size = new System.Drawing.Size(272, 23);
            this.topcolor.TabIndex = 3;
            // 
            // ceilingcolor
            // 
            this.ceilingcolor.BackColor = System.Drawing.Color.Transparent;
            this.ceilingcolor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceilingcolor.Label = "Ceiling:";
            this.ceilingcolor.Location = new System.Drawing.Point(16, 19);
            this.ceilingcolor.MaximumSize = new System.Drawing.Size(10000, 23);
            this.ceilingcolor.MinimumSize = new System.Drawing.Size(100, 23);
            this.ceilingcolor.Name = "ceilingcolor";
            this.ceilingcolor.Size = new System.Drawing.Size(272, 23);
            this.ceilingcolor.TabIndex = 2;
            // 
            // groupaction
            // 
            this.groupaction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupaction.Controls.Add(this.tag);
            this.groupaction.Controls.Add(labelTag);
            this.groupaction.Controls.Add(this.newtag);
            this.groupaction.Location = new System.Drawing.Point(7, 394);
            this.groupaction.Name = "groupaction";
            this.groupaction.Size = new System.Drawing.Size(436, 49);
            this.groupaction.TabIndex = 2;
            this.groupaction.TabStop = false;
            this.groupaction.Text = " Identification ";
            // 
            // tag
            // 
            this.tag.AllowDecimal = false;
            this.tag.AllowNegative = false;
            this.tag.AllowRelative = true;
            this.tag.ButtonStep = 1;
            this.tag.Location = new System.Drawing.Point(89, 16);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(73, 24);
            this.tag.StepValues = null;
            this.tag.TabIndex = 25;
            // 
            // newtag
            // 
            this.newtag.Location = new System.Drawing.Point(174, 17);
            this.newtag.Name = "newtag";
            this.newtag.Size = new System.Drawing.Size(76, 23);
            this.newtag.TabIndex = 1;
            this.newtag.Text = "New Tag";
            this.newtag.UseVisualStyleBackColor = true;
            this.newtag.Click += new System.EventHandler(this.newtag_Click);
            // 
            // groupeffect
            // 
            this.groupeffect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupeffect.Controls.Add(this.browseeffect);
            this.groupeffect.Controls.Add(this.effect);
            this.groupeffect.Controls.Add(labelSpecial);
            this.groupeffect.Location = new System.Drawing.Point(7, 340);
            this.groupeffect.Name = "groupeffect";
            this.groupeffect.Size = new System.Drawing.Size(436, 48);
            this.groupeffect.TabIndex = 1;
            this.groupeffect.TabStop = false;
            this.groupeffect.Text = " Effects ";
            // 
            // browseeffect
            // 
            this.browseeffect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseeffect.Image = global::CodeImp.DoomBuilder.Properties.Resources.treeview;
            this.browseeffect.Location = new System.Drawing.Point(385, 21);
            this.browseeffect.Name = "browseeffect";
            this.browseeffect.Padding = new System.Windows.Forms.Padding(0, 0, 1, 3);
            this.browseeffect.Size = new System.Drawing.Size(30, 23);
            this.browseeffect.TabIndex = 1;
            this.browseeffect.Text = " ";
            this.browseeffect.UseVisualStyleBackColor = true;
            this.browseeffect.Click += new System.EventHandler(this.browseeffect_Click);
            // 
            // effect
            // 
            this.effect.BackColor = System.Drawing.Color.Transparent;
            this.effect.Cursor = System.Windows.Forms.Cursors.Default;
            this.effect.Empty = false;
            this.effect.GeneralizedCategories = null;
            this.effect.Location = new System.Drawing.Point(89, 22);
            this.effect.Macro = false;
            this.effect.Name = "effect";
            this.effect.Size = new System.Drawing.Size(290, 21);
            this.effect.TabIndex = 0;
            this.effect.Value = 402;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(353, 652);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(112, 25);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apply.Location = new System.Drawing.Point(236, 652);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(112, 25);
            this.apply.TabIndex = 1;
            this.apply.Text = "OK";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // sectorproperties
            // 
            this.sectorproperties.Controls.Add(coloredLightingInfo);
            this.sectorproperties.Controls.Add(this.groupeffect);
            this.sectorproperties.Controls.Add(this.lightsPanel);
            this.sectorproperties.Controls.Add(this.settingsgroup);
            this.sectorproperties.Controls.Add(this.groupaction);
            this.sectorproperties.Controls.Add(groupfloorceiling);
            this.sectorproperties.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectorproperties.Location = new System.Drawing.Point(12, 12);
            this.sectorproperties.Name = "sectorproperties";
            this.sectorproperties.Padding = new System.Windows.Forms.Padding(3);
            this.sectorproperties.Size = new System.Drawing.Size(449, 592);
            this.sectorproperties.TabIndex = 0;
            this.sectorproperties.Text = "Properties";
            // 
            // lightsPanel
            // 
            this.lightsPanel.Controls.Add(incdecIntensity);
            this.lightsPanel.Location = new System.Drawing.Point(7, 155);
            this.lightsPanel.Name = "lightsPanel";
            this.lightsPanel.Size = new System.Drawing.Size(436, 179);
            this.lightsPanel.TabIndex = 4;
            // 
            // settingsgroup
            // 
            this.settingsgroup.Controls.Add(this.flags);
            this.settingsgroup.Location = new System.Drawing.Point(7, 449);
            this.settingsgroup.Name = "settingsgroup";
            this.settingsgroup.Size = new System.Drawing.Size(436, 136);
            this.settingsgroup.TabIndex = 3;
            this.settingsgroup.TabStop = false;
            this.settingsgroup.Text = "Settings";
            // 
            // flags
            // 
            this.flags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flags.AutoScroll = true;
            this.flags.Columns = 3;
            this.flags.Location = new System.Drawing.Point(6, 14);
            this.flags.Name = "flags";
            this.flags.Size = new System.Drawing.Size(424, 116);
            this.flags.TabIndex = 4;
            // 
            // flatSelectorControl2
            // 
            this.flatSelectorControl2.Location = new System.Drawing.Point(271, 37);
            this.flatSelectorControl2.Name = "flatSelectorControl2";
            this.flatSelectorControl2.Size = new System.Drawing.Size(83, 105);
            this.flatSelectorControl2.TabIndex = 13;
            this.flatSelectorControl2.TextureName = "";
            // 
            // flatSelectorControl1
            // 
            this.flatSelectorControl1.Location = new System.Drawing.Point(363, 37);
            this.flatSelectorControl1.Name = "flatSelectorControl1";
            this.flatSelectorControl1.Size = new System.Drawing.Size(83, 105);
            this.flatSelectorControl1.TabIndex = 12;
            this.flatSelectorControl1.TextureName = "";
            // 
            // heightpanel3
            // 
            this.heightpanel3.BackColor = System.Drawing.Color.Navy;
            this.heightpanel3.Location = new System.Drawing.Point(128, -19);
            this.heightpanel3.Name = "heightpanel3";
            this.heightpanel3.Size = new System.Drawing.Size(78, 677);
            this.heightpanel3.TabIndex = 5;
            this.heightpanel3.Visible = false;
            // 
            // SectorEditForm
            // 
            this.AcceptButton = this.apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(477, 685);
            this.Controls.Add(this.sectorproperties);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.heightpanel3);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SectorEditForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Sector";
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.SectorEditForm_HelpRequested);
            groupfloorceiling.ResumeLayout(false);
            groupfloorceiling.PerformLayout();
            incdecIntensity.ResumeLayout(false);
            coloredLightingInfo.ResumeLayout(false);
            this.groupaction.ResumeLayout(false);
            this.groupaction.PerformLayout();
            this.groupeffect.ResumeLayout(false);
            this.groupeffect.PerformLayout();
            this.sectorproperties.ResumeLayout(false);
            this.lightsPanel.ResumeLayout(false);
            this.settingsgroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Panel sectorproperties;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl floortex;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl ceilingtex;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl flatSelectorControl2;
        private CodeImp.DoomBuilder.Controls.FlatSelectorControl flatSelectorControl1;
        private System.Windows.Forms.Label sectorheight;
        private CodeImp.DoomBuilder.Controls.ActionSelectorControl effect;
        private System.Windows.Forms.Button newtag;
        private System.Windows.Forms.Button browseeffect;
        private System.Windows.Forms.Label sectorheightlabel;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox ceilingheight;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox floorheight;
        private CodeImp.DoomBuilder.Controls.ButtonsNumericTextbox tag;
        private System.Windows.Forms.GroupBox settingsgroup;
        private CodeImp.DoomBuilder.Controls.CheckboxArrayControl flags;
        private System.Windows.Forms.GroupBox groupeffect;
        private System.Windows.Forms.GroupBox groupaction;
        private System.Windows.Forms.Panel lightsPanel;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Controls.ColorControlSector floorcolor;
        private Controls.ColorControlSector lowercolor;
        private Controls.ColorControlSector thingcolor;
        private Controls.ColorControlSector topcolor;
        private Controls.ColorControlSector ceilingcolor;
        private System.Windows.Forms.Panel heightpanel3;    // villsa
    }
}
