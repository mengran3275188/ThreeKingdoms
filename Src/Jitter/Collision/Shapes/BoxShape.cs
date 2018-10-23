﻿/* Copyright (C) <2009-2011> <Thorben Linneweber, Jitter Physics>
* 
*  This software is provided 'as-is', without any express or implied
*  warranty.  In no event will the authors be held liable for any damages
*  arising from the use of this software.
*
*  Permission is granted to anyone to use this software for any purpose,
*  including commercial applications, and to alter it and redistribute it
*  freely, subject to the following restrictions:
*
*  1. The origin of this software must not be misrepresented; you must not
*      claim that you wrote the original software. If you use this software
*      in a product, an acknowledgment in the product documentation would be
*      appreciated but is not required.
*  2. Altered source versions must be plainly marked as such, and must not be
*      misrepresented as being the original software.
*  3. This notice may not be removed or altered from any source distribution. 
*/

#region Using Statements
using System;
using System.Collections.Generic;

using Jitter.Dynamics;
using Jitter.LinearMath;
using Jitter.Collision.Shapes;
using Util.MyMath;
#endregion

namespace Jitter.Collision.Shapes
{

    /// <summary>
    /// A <see cref="Shape"/> representing a box.
    /// </summary>
    public class BoxShape : Shape
    {
        private Vector3 size = Vector3.zero;

        /// <summary>
        /// The sidelength of the box.
        /// </summary>
        public Vector3 Size { 
            get { return size; }
            set { size = value; UpdateShape(); }
        }
        
        /// <summary>
        /// Creates a new instance of the BoxShape class.
        /// </summary>
        /// <param name="size">The size of the box.</param>
        public BoxShape(Vector3 size)
        {
            this.size = size;
            this.UpdateShape();
        }

        /// <summary>
        /// Creates a new instance of the BoxShape class.
        /// </summary>
        /// <param name="length">The length of the box.</param>
        /// <param name="height">The height of the box.</param>
        /// <param name="width">The width of the box</param>
        public BoxShape(float length, float height, float width)
        {
            this.size.x = length;
            this.size.y = height;
            this.size.z = width;
            this.UpdateShape();
        }

        private Vector3 halfSize = Vector3.zero;

        /// <summary>
        /// This method uses the <see cref="ISupportMappable"/> implementation
        /// to calculate the local bounding box, the mass, geometric center and 
        /// the inertia of the shape. In custom shapes this method should be overidden
        /// to compute this values faster.
        /// </summary>
        public override void UpdateShape()
        {
            this.halfSize = size * 0.5f;
            base.UpdateShape();
        }

        /// <summary>
        /// Gets the axis aligned bounding box of the orientated shape.
        /// </summary>
        /// <param name="orientation">The orientation of the shape.</param>
        /// <param name="box">The axis aligned bounding box of the shape.</param>
        public override void GetBoundingBox(ref Matrix3x3 orientation, out BBox box)
        {
            Mathf.Abs(ref orientation, out Matrix3x3 abs);

            Vector3.Transform(ref halfSize, ref abs, out Vector3 temp);

            box.Max = temp;
            Vector3.Negate(ref temp, out box.Min);
        }

        /// <summary>
        /// This method uses the <see cref="ISupportMappable"/> implementation
        /// to calculate the local bounding box, the mass, geometric center and 
        /// the inertia of the shape. In custom shapes this method should be overidden
        /// to compute this values faster.
        /// </summary>
        public override void CalculateMassInertia()
        {
            mass = size.x * size.y * size.z;

            inertia = Matrix3x3.Identity;
            inertia.M11 = (1.0f / 12.0f) * mass * (size.y * size.y + size.z * size.z);
            inertia.M22 = (1.0f / 12.0f) * mass * (size.x * size.x + size.z * size.z);
            inertia.M33 = (1.0f / 12.0f) * mass * (size.x * size.x + size.y * size.y);

            this.geomCen = Vector3.zero;
        }

        /// <summary>
        /// SupportMapping. Finds the point in the shape furthest away from the given direction.
        /// Imagine a plane with a normal in the search direction. Now move the plane along the normal
        /// until the plane does not intersect the shape. The last intersection point is the result.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <param name="result">The result.</param>
        public override void SupportMapping(ref Vector3 direction, out Vector3 result)
        {
            result.x = (float)Math.Sign(direction.x) * halfSize.x;
            result.y = (float)Math.Sign(direction.y) * halfSize.y;
            result.z = (float)Math.Sign(direction.z) * halfSize.z;
        }
    }
}
