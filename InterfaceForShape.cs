using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Laba3
{
    class InterfaceForShape
    {
        public InterfaceForShape()
        {
            this.Main();
        }

        public void Main()
        {
            bool onWork = true;

            Console.WriteLine("Plaese choise command");

            this._Info();

            while (onWork)
            {
                Console.Write(">>>");
                int command = this._ReaderInt();
                switch (command)
                {
                    case 0: onWork = false;
                        break;
                    case 1: this._CreateShape();
                        break;
                    case 2: this._GetPerimetr();
                        break;
                    case 3: this._GetSquare();
                        break;
                    case 4: this._PrintList();
                        break;
                    case 5: this._AboutShape();
                        break;
                }
            }

        }

        private void _Info()
        {

            Console.WriteLine("1)Create new Shape");
            Console.WriteLine("2)Get perimetr");
            Console.WriteLine("3)Get square");

            Console.WriteLine("4)Print list of Shapes");
            Console.WriteLine("5)Print information about Shape");

            Console.WriteLine("0)Exit");

        }

        private void _CreateShape()
        {
            Console.WriteLine("Print count of vertex, please : ");
            int count = this._ReaderInt();
            Point[] p = new Point[count];
            for(int i = 0; i < count; i++)
            {
                double x, y;
                Console.WriteLine("Print X{0} : ", i + 1);
                x = this._ReaderDouble();
                Console.WriteLine("Print Y{0} : ", i + 1);
                y = this._ReaderDouble();
                p[i] = new Point(x, y);
            }
            ShapeFactory f = new ShapeFactory(p);
        }

        private void _GetPerimetr()
        {
            Console.WriteLine("Print number of shape in list : ");
            int number = this._ReaderInt();
            Console.WriteLine(ShapeFactory.vectorOfShape[number].Perimetr);
        }

        private void _GetSquare()
        {
            Console.WriteLine("Print number of shape in list : ");
            int number = this._ReaderInt();
            Console.WriteLine(ShapeFactory.vectorOfShape[number].Square);
        }

        private void _PrintList()
        {
            int number = 0;
            foreach(Shape s in ShapeFactory.vectorOfShape)
            {
                Console.WriteLine("{0} {1}", number, s.Type);
                number++;
            }
        }

        private void _AboutShape()
        {
            Console.WriteLine("Print number of shape in list : ");
            int number = this._ReaderInt();
            for(int i = 0; i < ShapeFactory.vectorOfShape[number].CountVertex; i++)
            {
                Console.WriteLine("Point{0} - ({1}, {2})", i, ShapeFactory.vectorOfShape[number][i].X, ShapeFactory.vectorOfShape[number][i].Y);
            }
        }

        private int _ReaderInt()
        {
            int result = -1;
            while (result == -1)
            {
                try
                {
                    string c = Console.In.ReadLine();
                    result = int.Parse(c);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Pardon, Try again!!!");
                    result = -1;
                }

            }
            return result;
        }

        private double _ReaderDouble()
        {
            double result = -1;
            while (result == -1)
            {
                try
                {
                    string c = Console.In.ReadLine();
                    result = double.Parse(c);
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Pardon, Try again!!!");
                    result = -1;
                }

            }
            return result;
        }
    }
}
