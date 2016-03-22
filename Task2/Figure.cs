
using System;
using System.Drawing;
using System.Linq;


namespace Task2 {
    public interface IShape {
        double GetPerimetr();
        double GetArea();
    }

    public class Ellipse : IShape {
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

        public Ellipse(double height, double width) {
            Height = height;
            Width = width;
        }

        
        public double GetPerimetr() {
            return 4*(Math.PI*Height*Width + Math.Abs(Width - Height))/(Width + Height);
        }

        public double GetArea() {
            return Math.PI*Height*Width;
        }

        private bool Valide(double x) {
            return (x > 0);
        }
    }

    public class Circle : Ellipse {
        public Circle(double height) : base(height,height) {}
    }


    public class Rectangle : IShape {
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

        public Rectangle(double heigth, double width) {
            Heigth = heigth;
            Width = width;
        }


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
        public Square(double heigth) : base(heigth, heigth) {}
    }


    public class Triangle : IShape {
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

        public Triangle(params double[] sides) {
            Sides = sides;
        }


        public double GetPerimetr() {
            return sides.Sum();
        }

        public double GetArea() {
            double p = GetPerimetr()/2;
            return Math.Pow(p*(p - sides[0])*(p - sides[1])*(p - sides[2]), 0.5);
        }

        private bool Valide(double[] s) {
            if (s.Length != 3 || s.Any(x => x <= 0))
                return false;
            
            double a = s[0];
            double b = s[1];
            double c = s[2];
            return a < b + c && a > b - c && b < a + c && b > a - c && c < a + b && c > a - b;
        }
    }
}
