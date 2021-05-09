using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Laba3
{
    class ShapeFactory
    {

        public static List<Shape> vectorOfShape = new List<Shape>();
        public static int countOfShape = 0;

        public ShapeFactory(Point[] vertex) 
        {
            this._countVertex = vertex.Length;
            this._vertex = new Point[this._countVertex];
            for(int i = 0; i < this._countVertex; i++)
            {
                this._vertex[i] = new Point(vertex[i]);
            }

            ShapeFactory.vectorOfShape.Add(this.CreateObject());
            ShapeFactory.countOfShape++;
        }

        public Shape CreateObject()
        {
            Shape s = new Shape(this._vertex, "Shape");
            if(this._countVertex == 3)
            {
                if (this._IsTriangle(this._vertex[0] - this._vertex[1], this._vertex[0] - this._vertex[2]))
                {
                    s = new Triangle(this._vertex, "Triangle");
                }
            }
            if (this._countVertex == 4)
            {
                bool shapeCreate = false;
                if (this._IsParallelogram() && !this._IsRectangle() && !shapeCreate) { s = new Parallelogram(this._vertex, "Parallelogram"); shapeCreate = true; }
                if (this._IsRectangle() && !shapeCreate) { s = new Rectangle(this._vertex, "Rectangle"); shapeCreate = true; }
                if (this._IsTrapezoid() && !shapeCreate) { s = new Trapezoid(this._vertex, "Trapezoid"); shapeCreate = true; }
            }
            return s;
        }

        private Point[] _vertex;    
        private int _countVertex;

        private bool _IsRectangle()
        {
            if (this._IsParallelogram())
            {
                return this._IsRightAngle(this._vertex[0] - this._vertex[1], this._vertex[0] - this._vertex[3])
                    || this._IsRightAngle(this._vertex[0] - this._vertex[1], this._vertex[0] - this._vertex[2])
                    || this._IsRightAngle(this._vertex[0] - this._vertex[2], this._vertex[0] - this._vertex[3]);
            }
            else
            {
                return false;
            }
        }

        private bool _IsParallelogram()
        {          
            return (this._IsParallel(this._vertex[1] - this._vertex[0], this._vertex[2] - this._vertex[3]) && this._IsParallel(this._vertex[3] - this._vertex[0], this._vertex[1] - this._vertex[2]))
                || (this._IsParallel(this._vertex[0] - this._vertex[2], this._vertex[1] - this._vertex[3]) && this._IsParallel(this._vertex[1] - this._vertex[0], this._vertex[2] - this._vertex[3]))
                || (this._IsParallel(this._vertex[0] - this._vertex[2], this._vertex[1] - this._vertex[3]) && this._IsParallel(this._vertex[2] - this._vertex[1], this._vertex[0] - this._vertex[3]));
        }

        private bool _IsParallel(Point vector1, Point vector2)
        {
            return (vector1.X * vector2.Y - vector2.X * vector1.Y) == 0;
        }

        private bool _IsRightAngle(Point vector1, Point vector2)
        {
            return (vector1.X * vector2.X + vector1.Y * vector2.Y) == 0;
        }

        private bool _IsTriangle(Point vector1, Point vector2)
        {
            return (vector1.X * vector2.Y - vector2.X * vector1.Y) != 0;
        }

        private bool _IsTrapezoid()
        {
            return (this._IsParallel(this._vertex[1] - this._vertex[0], this._vertex[2] - this._vertex[3]) && !this._IsParallel(this._vertex[3] - this._vertex[0], this._vertex[1] - this._vertex[2]))
                || (this._IsParallel(this._vertex[0] - this._vertex[2], this._vertex[1] - this._vertex[3]) && !this._IsParallel(this._vertex[1] - this._vertex[0], this._vertex[2] - this._vertex[3]))
                || (this._IsParallel(this._vertex[0] - this._vertex[2], this._vertex[1] - this._vertex[3]) && !this._IsParallel(this._vertex[2] - this._vertex[1], this._vertex[0] - this._vertex[3]))
                || (!this._IsParallel(this._vertex[1] - this._vertex[0], this._vertex[2] - this._vertex[3]) && this._IsParallel(this._vertex[3] - this._vertex[0], this._vertex[1] - this._vertex[2]))
                || (!this._IsParallel(this._vertex[0] - this._vertex[2], this._vertex[1] - this._vertex[3]) && this._IsParallel(this._vertex[1] - this._vertex[0], this._vertex[2] - this._vertex[3]))
                || (!this._IsParallel(this._vertex[0] - this._vertex[2], this._vertex[1] - this._vertex[3]) && this._IsParallel(this._vertex[2] - this._vertex[1], this._vertex[0] - this._vertex[3]));
        }
    }
}
