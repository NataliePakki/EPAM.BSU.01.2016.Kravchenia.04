using System;
using NUnit.Framework;

namespace Task2.Tests
{
    
    public class FigureTests {
        public IShape figure;

        
        [Test]
        [TestCase(35,13,Result = 4*(Math.PI*35*13 + 22)/48)]
        [TestCase(-35, 13, ExpectedException = typeof(ArgumentException))]
        public double EllipseTest_Perimetr(double h, double w) {
            figure = new Ellipse(h,w);
            return figure.GetPerimetr();
        }
        [Test]
        [TestCase(35, 13, Result = Math.PI * 35 * 13)]
        public double EllipseTest_Area(double h, double w)
        {
            figure = new Ellipse(h, w);
            return figure.GetArea();
        }


        [Test]
        [TestCase(48, Result = 2 * (Math.PI * 48))]
        [TestCase(-35,ExpectedException = typeof(ArgumentException))]
        public double CircleTest_Perimetr(double h)
        {
            figure = new Circle(h);
            return figure.GetPerimetr();
        }
        [Test]
        [TestCase(35, Result = Math.PI * 35 * 35)]
        public double CircleTest_Area(double h)
        {
            figure = new Circle(h);
            return figure.GetArea();
        }

        [Test]
        [TestCase(35, 13, Result = 96)]
        [TestCase(-35, 13, ExpectedException = typeof(ArgumentException))]
        public double RectangleTest_Perimetr(double h, double w)
        {
            figure = new Rectangle(h, w);
            return figure.GetPerimetr();
        }
        [Test]
        [TestCase(35, 13, Result = 455)]
        public double RectangleTest_Area(double h, double w)
        {
            figure = new Rectangle(h, w);
            return figure.GetArea();
        }
        [Test]
        [TestCase(35, Result = 140)]
        [TestCase(-35,  ExpectedException = typeof(ArgumentException))]
        public double SquareTest_Perimetr(double h)
        {
            figure = new Square(h);
            return figure.GetPerimetr();
        }
        [Test]
        [TestCase(35,  Result = 1225)]
        public double SquareTest_Area(double h)
        {
            figure = new Square(h);
            return figure.GetArea();
        }
        [Test]
        [TestCase(3, 4, 5,Result = 12)]
        [TestCase(35, 1, 45, ExpectedException = typeof(ArgumentException))]
        [TestCase(-35, 13, 45, ExpectedException = typeof(ArgumentException))]
        [TestCase(-35, 13, ExpectedException = typeof(ArgumentException))]
        [TestCase(-35, 13,15,23, ExpectedException = typeof(ArgumentException))]
        public double TriangleTest_Perimetr(params double[] sides)
        {
            figure = new Triangle(sides);
            return figure.GetPerimetr();
        }
        [Test]
        [TestCase(3, 4, 5, Result = 6)]
        public double TriangleTest_Area(params double[] sides)
        {
            figure = new Triangle(sides);
            return figure.GetArea();
        }
    }
}
