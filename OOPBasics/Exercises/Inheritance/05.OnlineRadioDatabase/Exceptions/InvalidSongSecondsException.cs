namespace _05.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        private const string InvalidSecondsmessage = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException()
            : base(InvalidSecondsmessage)
        {
        }
    }
}