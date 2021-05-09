using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3
{
    class Point
    {
        public Point(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public Point(Point p)
        {
            this._x = p.X;
            this._y = p.Y;
        }

        public double X { get { return this._x; } }
        public double Y { get { return this._y; } }

        private double _x { get; }
        private double _y { get; }

        public static Point operator -(Point a, Point b)
        {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            return new Point(x, y);
        }

        public double Radius()
        {
            return Math.Sqrt(this._x * this._x + this._y * this._y);
        }
    }

    

}
