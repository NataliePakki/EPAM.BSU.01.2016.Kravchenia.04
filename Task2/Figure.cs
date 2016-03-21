
using System;
using System.Drawing;
using System.Linq;


namespace Task2
{
     interface  IFigure {
         Point Center { get; set; }
         double GetPerimetr();
         double GetArea();
    }

    public class Ellipse : IFigure {
        private double width;
        private double height;
        public double Height { get; set; }
        public double Width { get; set; }
        public Point Center { get; set; }

        public Ellipse(Point center,double height, double width) {
            Center = center;
            Height = height;
            Width = width;
        }

        public Ellipse(double height, double width) : this(new Point(0, 0), height, width) {}
        

        public double GetPerimetr() {
            return 4*(Math.PI*Height*Width + Math.Abs(Width - Height)/(Width + Height));
        }

        public double GetArea() {
            return Math.PI*Height*Width;
        }

        public class Circle : Ellipse {
            public Circle(Point center, double height) : base(center, height, height) {}
            public Circle(double height) : this(new Point(0,0),height) {}
        } 
      }

    public class Rectangle : IFigure {
        public double Heigth { get; set; }
        public double Width { get; set; }
        public Point Center { get; set; }

        public Rectangle(Point center,double heigth, double width) {
            Center = center;
            Heigth = heigth;
            Width = width;
        }
        public Rectangle(double heigth, double width) : this(new Point(0, 0), heigth, width) { }
        public  double GetPerimetr() {
            return 2*Heigth + 2*Width;
        }

        public  double GetArea() {
            return Width*Heigth;
        }
    }

    public class Square : Rectangle {
        public Square(Point center, double heigth) : base(center, heigth, heigth) {}
        public Square(double heigth) : base(heigth, heigth) {}
    }

    public class Triangle : IFigure {
        public Point Center { get; set; }

        private double[] sides;

        public double[] Sides {
            get { return sides; }
            set {
                if(value.Length <= 3)
                    sides = value;
                else throw new ArgumentException();
            }
        }

        public Triangle(Point center,params double[] sides) {
            Center = center;
            Sides = sides;
        }

        public Triangle(params double[] sides) : this(new Point(0,0), sides){ }

        public double GetPerimetr() {
            return sides.Sum();
        }

        public double GetArea() {
            double p = GetPerimetr()/2;
            return Math.Pow(p*(p - sides[0])*(p - sides[1])*(p - sides[2]), 0.5);
        }
    }
}
