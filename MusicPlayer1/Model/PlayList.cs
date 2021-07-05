using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.FileProperties;

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

        public PlayList()
        {

        }
        public PlayList(string playlistname, string playlistotherdetails,string browsedimage) : this(playlistname)
        {

            PlayListOtherDetails = playlistotherdetails;
            //PlayListImage = browsedimage;
            PlayListImage = $"Assets/Icons/Playlist.png";
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

