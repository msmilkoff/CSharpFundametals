namespace _05.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongNameException : InvalidSongException
    {
        private const string InvalidSongNameMessage = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException()
            : base(InvalidSongNameMessage)
        {
        }
    }
}