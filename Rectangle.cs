using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3
{
    class Rectangle : Parallelogram
    {
        public Rectangle(Point[] p, string type) : base(p, type) { }

        protected override double _square()
        {
            return (this._vertex[0] - this._vertex[1]).Radius() * (this._vertex[0] - this._vertex[3]).Radius();
        }
    }
}
