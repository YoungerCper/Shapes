using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Laba3
{
    class Parallelogram : Shape
    {
        public Parallelogram(Point[] p, string type) : base(p, type) { }

        protected override double _perimetr()
        {
            return ((this._vertex[0] - this._vertex[1]).Radius() + (this._vertex[0] - this._vertex[3]).Radius()) * 2;
        }

        protected override double _square()
        {
            Point vector1 = this._vertex[0] - this._vertex[1];
            Point vector2 = this._vertex[0] - this._vertex[3];

            double result = vector1.X * vector2.Y - vector1.Y * vector2.X;
            return (result >= 0) ? result : -result;
        }
    }
}
