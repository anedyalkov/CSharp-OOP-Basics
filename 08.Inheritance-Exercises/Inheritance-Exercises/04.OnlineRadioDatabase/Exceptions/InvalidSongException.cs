namespace _04.OnlineRadioDatabase.Exceptions
{
    using System;

    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message = "Invalid song") : base(message)
        {
        }
    }
}
