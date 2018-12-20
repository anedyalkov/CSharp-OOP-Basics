namespace _02.ClassBoxDataValidation
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);
                Console.WriteLine($@"Surface Area - {box.GetSurfaceArea():f2}");
                Console.WriteLine($@"Lateral Surface Area - {box.GetLateralSurfaceArea():f2}");
                Console.WriteLine($@"Volume - {box.GetVolume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }
    }
}
