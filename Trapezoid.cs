using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3
{
    class Trapezoid : Shape
    {
        public Trapezoid(Point[] p, string type): base(p, type) { }

        protected override double _perimetr()
        {
            double result = 0;
            for (int i = 0; i < this._vertex.Length; i++)
            {
                result += (this._vertex[i % this._vertex.Length] - this._vertex[(i + 1) % this._vertex.Length]).Radius();
            }
            return result;
        }

        protected override double _square()
        {
            Point vector1 = this._vertex[0] - this._vertex[1];
            Point vector2 = this._vertex[0] - this._vertex[3];

            Point vector3 = this._vertex[2] - this._vertex[1];
            Point vector4 = this._vertex[2] - this._vertex[3];

            double result1 = (vector1.X * vector2.Y - vector1.Y * vector2.X) / 2;
            double result2 = (vector3.X * vector4.Y - vector3.Y * vector4.X) / 2;

            return ((result1 >= 0) ? result1 : -result1 ) + ((result2 >= 0) ? result2 : -result2);
        }
    }
}
