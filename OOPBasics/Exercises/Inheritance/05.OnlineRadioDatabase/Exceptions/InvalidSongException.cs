namespace _05.OnlineRadioDatabase.Exceptions
{
    using System;

    public class InvalidSongException : Exception
    {
        private const string Mesage = "Invalid song.";

        public InvalidSongException()
            :base(Mesage)
        {
        }

        public InvalidSongException(string message)
            :base(message)
        {
        }
    }
}