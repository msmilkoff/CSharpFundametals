namespace _05.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        private const string InvalidSongLengthMessage = "Invalid song length.";

        public InvalidSongLengthException()
            :base(InvalidSongLengthMessage)
        {
        }

        public InvalidSongLengthException(string message)
            :base(message)
        {
        }
    }
}