using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer1.Model
{
    public class PlayList
    //read and deserialize json
    {
        public string PlayListName { get; set; }
        public List<Music> songs;
        public string PlayListOtherDetails;
        public string PlayListImage { get; set; }
        public string PlayListLocation { get; set; }

        //public PlayList(string PlayListName, List<Music> songs, string playlistotherdetails, string PlayListImage, string PlayListLocation) 
        //{

        //    this.PlayListName = PlayListName;
        //    this.PlayListOtherDetails = playlistotherdetails;
        //    this.PlayListImage = PlayListImage;
        //    this.PlayListLocation = PlayListLocation;
        //    this.songs = new List<Music>();
        //    foreach (var c in songs)
        //        this.songs.Add(c);
        //}
        public PlayList()
        {

        }
        public PlayList(string playlistname, string playlistotherdetails) : this(playlistname)
        {
            PlayListOtherDetails = playlistotherdetails;
        }
        public PlayList(string playlistname)
        {
            PlayListName = playlistname;
            PlayListImage = $"Assets/Icons/Playlist.png";
            var location = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string playListDirectory = $@"{location}\Assets\PlayLists";

            if (Directory.Exists(playListDirectory))
            {
                PlayListLocation = $@"{playListDirectory}\{playlistname}.json";
                if (File.Exists(PlayListLocation))
                {
                    string Text = System.IO.File.ReadAllText(PlayListLocation);
                    songs = JsonConvert.DeserializeObject<PlayList>(Text).songs;
                    
                }
                else
                {
                    songs = new List<Music>();
                }
            }
        }

        public void Add(Music music)
        {
            songs.Add(music);
            string text = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(PlayListLocation, text);
        }

    }

}

