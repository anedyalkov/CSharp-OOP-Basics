namespace _01.ClassBox
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public double GetVolume()
        {
            var result = Length * Width * Height;
            return result;
        }

        public double GetLateralSurfaceArea()
        {
            var result = 2 *Length * Height + 2 * Width * Height;
            return result;
        }

        public double GetSurfaceArea()
        {
            var result = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
            return result;
        }
    }
}
