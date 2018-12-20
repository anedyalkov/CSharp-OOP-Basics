namespace _02.ClassBoxDataValidation
{
    using System;

    public class Box
    {
        const string ErrorMessage = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
     
        public double Length
        {
            get { return length; }
            private set
            {
                if (IsValidParameter(value, "Length"))
                {
                    length = value;
                }             
            }
        }    

        public double Width
        {
            get { return width; }
            private set
            {
                if (IsValidParameter(value, "Width"))
                {
                    width = value;
                }
            }
        }     

        public double Height
        {
            get { return height; }
            private set
            {
                if (IsValidParameter(value, "Height"))
                {
                    height = value;
                }
            }
        }

        public bool IsValidParameter(double value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(ErrorMessage, name));
            }
            return true;
        }
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
