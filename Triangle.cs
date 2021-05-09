using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Laba3
{
    class Triangle : Shape
    {
        public Triangle(Point[] p, string type) : base(p, type) { }

        protected override double _perimetr()
        {
            double result = 0;
            for(int i = 0; i < this._vertex.Length; i++)
            {
                result += (this._vertex[i % this._vertex.Length] - this._vertex[(i + 1) % this._vertex.Length]).Radius();
            }
            return result;
        }

        protected override double _square()
        {
            Point vector1 = this._vertex[0] - this._vertex[1];
            Point vector2 = this._vertex[0] - this._vertex[2];

            double result = (vector1.X * vector2.Y - vector1.Y * vector2.X) / 2;
            return (result >= 0) ? result : -result;
        }
    }
}
