namespace _05.OnlineRadioDatabase.Exceptions
{
    public class InvalidArtistNameException : InvalidSongException
    {
        private const string InvalidArtistMessage = "Artist name should be between 3 and 20 symbols.";

        public InvalidArtistNameException()
            :base(InvalidArtistMessage)
        {
        }
    }
}