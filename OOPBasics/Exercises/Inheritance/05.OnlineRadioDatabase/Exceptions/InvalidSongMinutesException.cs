namespace _05.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongLengthException
    {
        private const string InvalidMinutesMessage = "Song minutes should be between 0 and 14.";

        public InvalidSongMinutesException()
            : base(InvalidMinutesMessage)
        {
        }
    }
}