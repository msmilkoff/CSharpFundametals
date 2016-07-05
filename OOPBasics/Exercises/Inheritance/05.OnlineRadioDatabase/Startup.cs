namespace _05.OnlineRadioDatabase
{
    using System;
    using Data;
    using Models;
    using Exceptions;

    public class Startup
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());
            var playlist = new Playlist();

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(new[] { ';', ':' });

                try
                {
                    var song = new Song(tokens[0], tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]));
                    playlist.AddSong(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidArtistNameException ianEx)
                {
                    Console.WriteLine(ianEx.Message);
                }
                catch (InvalidSongNameException isnEx)
                {
                    Console.WriteLine(isnEx.Message);
                }
                catch (InvalidSongMinutesException ismEx)
                {
                    Console.WriteLine(ismEx.Message);
                }
                catch (InvalidSongSecondsException issEx)
                {
                    Console.WriteLine(issEx.Message);
                }
            }

            Console.WriteLine($"Songs added: {playlist.SongsCount}");
            Console.WriteLine(playlist.ViewTotalLength());
        }
    }
}
