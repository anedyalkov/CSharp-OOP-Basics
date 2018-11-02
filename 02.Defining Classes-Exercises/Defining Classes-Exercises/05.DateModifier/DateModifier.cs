namespace DefiningClasses
{
    using System;
    public class DateModifier
    {
        public double TakeTwoDaysDifference(string firstDateAsString, string secondDateAsString)
        {
            var firstDate = DateTime.Parse(firstDateAsString);
            var secondDate = DateTime.Parse(secondDateAsString);

            TimeSpan difference = firstDate - secondDate;

            var result = Math.Abs(difference.TotalDays);

            return result;
        }
    }
}
