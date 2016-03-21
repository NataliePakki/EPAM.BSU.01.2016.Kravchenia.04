
using System;
using System.Drawing;
using System.Linq;


namespace Task2 {
    internal interface IFigure {
        Point Center { get; set; }
        double GetPerimetr();
        double GetArea();
    }

    public class Ellipse : IFigure {
        private double width;
        private double height;

        public double Height {
            get { return height; }
            set {
                if (Valide(value))
                    height = value;
                else throw new ArgumentException();
            }
        }

        public double Width {
            get { return width; }
            set
            {
                if (Valide(value))
                    width = value;
                else throw new ArgumentException();
            }
        }
        public Point Center { get; set; }

        public Ellipse(Point center, double height, double width) {
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

        private bool Valide(double x) {
            return (x > 0);
        }
    }

    public class Circle : Ellipse {
        public Circle(Point center, double height) : base(center, height, height) {}
        public Circle(double height) : this(new Point(0, 0), height) {}
    }


    public class Rectangle : IFigure {
        private double height;
        private double width;
        public double Heigth
        {
            get { return height; }
            set
            {
                if (Valide(value))
                    height = value;
                else throw new ArgumentException();
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (Valide(value))
                    width = value;
                else throw new ArgumentException();
            }
        }
        public Point Center { get; set; }

        public Rectangle(Point center, double heigth, double width) {
            Center = center;
            Heigth = heigth;
            Width = width;
        }

        public Rectangle(double heigth, double width) : this(new Point(0, 0), heigth, width) {}

        public double GetPerimetr() {
            return 2*Heigth + 2*Width;
        }

        public double GetArea() {
            return Width*Heigth;
        }

        private bool Valide(double x) {
            return (x > 0);
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
                if (Valide(value))
                    sides = value;
                else throw new ArgumentException();
            }
        }

        public Triangle(Point center, params double[] sides) {
            Center = center;
            Sides = sides;
        }

        public Triangle(params double[] sides) : this(new Point(0, 0), sides) {}

        public double GetPerimetr() {
            return sides.Sum();
        }

        public double GetArea() {
            double p = GetPerimetr()/2;
            return Math.Pow(p*(p - sides[0])*(p - sides[1])*(p - sides[2]), 0.5);
        }

        private bool Valide(double[] sides) {
            if (sides.Length != 3 || sides.Any(x => x <= 0))
                return false;
            
            double a = sides[0];
            double b = sides[1];
            double c = sides[2];
            return a < b + c && a > b - c && b < a + c && b > a - c && c < a + b && c > a - b;
        }
    }
}
