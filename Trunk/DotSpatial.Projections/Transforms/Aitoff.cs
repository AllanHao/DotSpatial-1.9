// ********************************************************************************************************
// Product Name: DotSpatial.Projection
// Description:  The basic module for MapWindow version 6.0
// ********************************************************************************************************
// The contents of this file are subject to the MIT License (MIT)
// you may not use this file except in compliance with the License. You may obtain a copy of the License at
// http://dotspatial.codeplex.com/license
//
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF
// ANY KIND, either expressed or implied. See the License for the specific language governing rights and
// limitations under the License.
//
// The original content was ported from the C language from the 4.6 version of Proj4 libraries.
// Frank Warmerdam has released the full content of that version under the MIT license which is
// recognized as being approximately equivalent to public domain.  The original work was done
// mostly by Gerald Evenden.  The latest versions of the C libraries can be obtained here:
// http://trac.osgeo.org/proj/
//
// The Initial Developer of this Original Code is Ted Dunsford. Created 8/12/2009 2:17:40 PM
//
// Contributor(s): (Open source contributors should list themselves and their modifications here).
//        Name         |    Date    |        Comment
// --------------------|------------|------------------------------------------------------------
// Ted Dunsford        |   5/3/2010 |  Updated project to DotSpatial.Projection and license to LGPL
// ********************************************************************************************************

using System;

namespace DotSpatial.Projections.Transforms
{
    /// <summary>
    /// Aitoff
    /// </summary>
    public class Aitoff : Transform
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of Aitoff
        /// </summary>
        public Aitoff()
        {
            Proj4Name = "aitoff";
            Name = "Aitoff";
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void OnForward(double[] lp, double[] xy, int startIndex, int numPoints)
        {
            for (int i = startIndex; i < startIndex + numPoints; i++)
            {
                int phi = i * 2 + PHI;
                int lam = i * 2 + LAMBDA;
                int x = i * 2 + X;
                int y = i * 2 + Y;
                double c;
                double d;
                if ((d = Math.Acos(Math.Cos(lp[phi]) * Math.Cos(c = 0.5 * lp[lam]))) != 0)
                {
                    xy[x] = 2 * d * Math.Cos(lp[phi]) * Math.Sin(c) * (xy[y] = 1 / Math.Sin(d));
                    xy[y] *= d * Math.Sin(lp[phi]);
                }
                else
                    xy[x] = xy[y] = 0;
            }
        }

        #endregion
    }
}