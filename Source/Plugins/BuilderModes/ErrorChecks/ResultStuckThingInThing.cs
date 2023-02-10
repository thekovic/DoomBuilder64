
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
using System.Net.NetworkInformation;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.Rendering;

#endregion

namespace CodeImp.DoomBuilder.BuilderModes
{
    public class ResultStuckThingInThing : ErrorResult
    {
        #region ================== Variables

        private readonly Thing thing1;
        private readonly Thing thing2; //mxd

        #endregion

        #region ================== Properties

        public override int Buttons { get { return 2; } }
        public override string Button1Text { get { return "Delete 1st Thing"; } }
        public override string Button2Text { get { return "Delete 2nd Thing"; } } //mxd

        #endregion

        #region ================== Constructor / Destructor

        // Constructor
        public ResultStuckThingInThing(Thing t1, Thing t2)
        {
            // Initialize
            this.thing1 = t1;
            this.thing2 = t2; //mxd
            this.viewobjects.Add(t1);
            this.description = "This thing is stuck in another thing. The other thing will fail to spawn.";
        }

        #endregion

        #region ================== Methods

        // This must return the string that is displayed in the listbox
        public override string ToString()
        {
            return "Thing " + thing1.Index + " (" + General.Map.Data.GetThingInfo(thing1.Type).Title + ") is stuck in thing " + thing2.Index + " (" + General.Map.Data.GetThingInfo(thing2.Type).Title + ") at " + thing1.Position.x + ", " + thing1.Position.y;
        }

        // Rendering
        public override void RenderOverlaySelection(IRenderer2D renderer)
        {
            renderer.RenderThing(thing1, renderer.DetermineThingColor(thing1), 1.0f);
            renderer.RenderThing(thing2, renderer.DetermineThingColor(thing2), 1.0f);
        }

        // This removes the first thing
        public override bool Button1Click()
        {
            General.Map.UndoRedo.CreateUndo("Delete thing");
            thing1.Dispose();
            General.Map.IsChanged = true;
            General.Map.ThingsFilter.Update();
            return true;
        }

        // This removes the thing
        public override bool Button2Click()
        {
            General.Map.UndoRedo.CreateUndo("Delete thing");
            thing2.Dispose();
            General.Map.IsChanged = true;
            General.Map.ThingsFilter.Update();
            return true;
        }

        #endregion
    }
}
