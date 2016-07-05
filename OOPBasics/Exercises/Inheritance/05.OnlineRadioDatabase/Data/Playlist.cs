namespace _05.OnlineRadioDatabase.Data
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Playlist
    {
        private ICollection<Song> songs;

        public Playlist()
        {
            this.songs = new List<Song>();
            this.SongsCount = 0;
        }

        public Playlist(ICollection<Song> songsCollection)
        {
            this.songs = new List<Song>(songsCollection);
            this.SongsCount = songsCollection.Count;
        }

        public int SongsCount { get; private set; }
        
        public void AddSong(Song song)
        {
            this.songs.Add(song);
            this.SongsCount++;
        }

        public string ViewTotalLength()
        {
            TimeSpan span = this.GetLength();
            string output = $"Playlist length: {span.Hours}h {span.Minutes}m {span.Seconds}s";

            return output;
        }

        private TimeSpan GetLength()
        {
            var span = new TimeSpan(0, 0, 0);
            foreach (var song in this.songs)
            {
                span = span.Add(new TimeSpan(0, song.Minutes, song.Seconds));
            }

            return span;
        }
    }
}