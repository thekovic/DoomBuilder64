
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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CodeImp.DoomBuilder.Map;

#endregion

namespace CodeImp.DoomBuilder.Geometry
{
    public sealed class SidedefAngleSorter : IComparer<Sidedef>
    {
        // Variables
        private Sidedef baseside;
        private Vertex basevertex;

        // Constructor
        public SidedefAngleSorter(Sidedef baseside, Vertex fromvertex)
        {
            // Initialize
            this.baseside = baseside;
            this.basevertex = fromvertex;

            // We have no destructor
            GC.SuppressFinalize(this);
        }

        // This calculates the relative angle between two sides
        private float CalculateRelativeAngle(Sidedef a, Sidedef b)
        {
            float s, n, ana, anb;
            Vector2D va, vb;
            bool dir;

            // Determine angles
            ana = a.Line.Angle; if (a.Line.End == basevertex) ana += Angle2D.PI;
            anb = b.Line.Angle; if (b.Line.End == basevertex) anb += Angle2D.PI;

            // Take the difference from angles
            n = Angle2D.Difference(ana, anb);

            // Get line end vertices a and b that are not connected to basevertex
            if (a.Line.Start == basevertex) va = a.Line.End.Position; else va = a.Line.Start.Position;
            if (b.Line.Start == basevertex) vb = b.Line.End.Position; else vb = b.Line.Start.Position;

            // Determine rotation direction
            dir = baseside.IsFront;
            if (baseside.Line.End == basevertex) dir = !dir;

            // Check to which side the angle goes and adjust angle as needed
            s = Line2D.GetSideOfLine(va, vb, basevertex.Position);
            if ((s < 0) && dir) n = Angle2D.PI2 - n;
            if ((s > 0) && !dir) n = Angle2D.PI2 - n;

            // Return result
            return n;
        }

        // Comparer
        public int Compare(Sidedef x, Sidedef y)
        {
            // Somehow, in a release build without debugger attached,
            // the code above is not always the same when x == y... don't ask.
            if (x == y)
                return 0;

            // Calculate angles
            float ax = CalculateRelativeAngle(baseside, x);
            float ay = CalculateRelativeAngle(baseside, y);

            // Compare results
            return Math.Sign(ay - ax);
        }
    }
}
