namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public override double CalculateArea()
        {
            double area = this.Height * this.Width;
            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Height + this.Width);
            return perimeter;
        }

        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }
    }
}
