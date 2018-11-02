namespace DefiningClasses
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var dateModifire = new DateModifier();

            var result = dateModifire.TakeTwoDaysDifference(firstDate, secondDate);

            Console.WriteLine(result);
        }
    }
}
