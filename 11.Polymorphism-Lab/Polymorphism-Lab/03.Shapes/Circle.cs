namespace Shapes
{

    using System;

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius { get; set; }
       
        public override double CalculateArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
