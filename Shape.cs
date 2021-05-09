using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Laba3
{
    class Shape
    {
        public Shape(Point[] p, string type)
        {
            this._vertex = new Point[p.Length];
            this.CountVertex = p.Length;
            for(int i = 0; i < p.Length; i++)
            {
                this._vertex[i] = new Point(p[i]);
            }
            this.Square = this._square();
            this.Perimetr = this._perimetr();
            this.Type = type;
        }

        public Shape(Shape s)
        {
            this._vertex = new Point[s.CountVertex];
            for (int i = 0; i < s.CountVertex; i++)
            {
                this._vertex[i] = new Point(s._vertex[i]);
            }
            this.Square = s.Square;
            this.Perimetr = s.Perimetr;

            this.Type = s.Type;
        }

        protected Point[] _vertex;

        public string Type { get; }

        public int CountVertex { get; }

        public double Square { get; }

        public double Perimetr { get; }

        virtual protected double _square()
        {
            double result = 0;
            for(int i = 1; i < this._vertex.Length - 1; i++)
            {
                Point vector1 = this._vertex[0] - this._vertex[i];
                Point vector2 = this._vertex[0] - this._vertex[i + 1];

                double s = (vector1.X * vector2.Y - vector1.Y * vector2.X) / 2;
                result += (s >= 0) ? s : -s;
            }
            return result;
        }

        virtual protected double _perimetr()
        {
            double result = 0;
            for (int i = 0; i < this._vertex.Length; i++)
            {
                result += (this._vertex[i % this._vertex.Length] - this._vertex[(i + 1) % this._vertex.Length]).Radius();
            }
            return result;
        }

        public Point this[int i]
        {
            get
            {
                return this._vertex[i];
            }
        }
    }
}
