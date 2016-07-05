namespace _05.OnlineRadioDatabase.Models
{
    using Exceptions;

    public class Song
    {
        private string name;
        private string artist;
        private int minutes;
        private int seconds;

        public Song(string artist, string name, int minutes, int seconds)
        {
            this.Name = name;
            this.Artist = artist;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }

                this.name = value;
            }
        }

        public string Artist
        {
            get
            {
                return this.artist;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }

                this.artist = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }
    }
}