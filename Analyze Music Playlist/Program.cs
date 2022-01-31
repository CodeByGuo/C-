
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Analyze_Music_Playlist
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = ("SampleMusicPlaylist.csv");
            List<Music> musicList = new List<Music>(); //Create list (namespace has to be = to name of the class)

            //read the file
            try
            {
                using (var musicReader = new StreamReader(filename))
                {
                    int lineNum = 1;
                    int dataNum = 8;
                    var lines = musicReader.ReadLine();
                    while (!musicReader.EndOfStream)
                    {
                        lineNum++;
                        lines = musicReader.ReadLine();


                        //Split the data with /t
                        var values = lines.Split('\t');
                        if (values.Length != dataNum)
                        {
                            throw new Exception($"Row {lineNum} contains {values.Length} pieces of data. It should have {dataNum}");
                        }

                        try
                        {
                            //Create objects for the music (Name    Artist	Album	Genre	Size	Time	Year	Plays)
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);

                            Music music = new Music(name, artist, album, genre, size, time, year, plays);
                            musicList.Add(music);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Row {lineNum} contains invalid data. ({e.Message})");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"There was an error reading the file {e.Message}");
            }




            //Create Linqs for each Scenario

            // Music with over 200 plays
            var NumOfPlays = from music in musicList where music.Plays >= 200 select music;
            Console.WriteLine("\n------------------\n\nSongs that received 200 or more plays: \n");
            foreach (var PlayNumbers in NumOfPlays)
            {
                Console.WriteLine(PlayNumbers.ToString());
            }


            //Alternative Genre
            var AlternativeGenre = from music in musicList where music.Genre.Contains("Alternative") select music.ToString();
            int altNum = 0;
            foreach (var AltMusic in AlternativeGenre)
            {
                altNum++;
            }
            Console.WriteLine(($"\n\nNumber of Alternative songs: {altNum}"));

            //Hip-Hop/Rap
            var HipHopGenre = from music in musicList where music.Genre.Contains("Hip-Hop/Rap") select music.ToString();
            int hipNum = 0;
            foreach (var HipHopSong in HipHopGenre)
            {
                hipNum++;
            }
            Console.WriteLine(($"\n\nNumber of Hip-Hop/Rap songs: {hipNum}"));

            //Songs From Welcome to the fishbowl
            var FishbowlPlaylist = from music in musicList where music.Album.Contains("Welcome to the Fishbowl") select music;
            Console.WriteLine("\n\nSongs from the album Welcome to the Fishbowl:\n");
            foreach (var Fishbowl in FishbowlPlaylist)
            {
                Console.WriteLine(Fishbowl.ToString());
            }

            //What are the songs in the playlist from before 1970?
            var SongsInPlaylist = from music in musicList where music.Year < 1970 select music;
            Console.WriteLine("\n\nSongs from before 1970:\n");
            foreach (var SongsBefore1970 in SongsInPlaylist)
            {
                Console.WriteLine(SongsBefore1970);
            }

            //What are the song names that are more than 85 characters long?
            Console.WriteLine("\n\nSong names longer than 85 characters:\n");
            var SongNameOver85 = from music in musicList where music.Name.Length > 85 select music;

            foreach (var Over84 in SongNameOver85)
            {
                Console.WriteLine(Over84);
            }

            //What is the longest song? (longest in Time)


            var longestSong = musicList.OrderByDescending(music => music.Time).First();
            Console.WriteLine($"\n\nLongest song:\n{longestSong}\n\n-------------\n\n");

        }





    }
}



