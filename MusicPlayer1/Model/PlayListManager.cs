using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer1.Model
{
    public static class PlayListManager
    {
        public static void GetPlayList(ObservableCollection<PlayList> play)
        {
            var allplaylists = GetPlayLists();
            allplaylists.ForEach(song => play.Add(song));
        }
        public static string[] PlayListsPath()
        {
            var result = new List<PlayList>();
            var location = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string playListDirectory = $@"{location}\Assets\PlayLists";
            string[] playlistfilename = Directory.GetFiles(playListDirectory);
                //($@"{location}\Assets\PlayLists");
            return playlistfilename;
        }

        public static List<PlayList> GetPlayLists()
        {
            var playlist = new List<PlayList>(); //stores filenames
            string[] playlistpath = PlayListsPath();  // this returns all files(names) in the directory local/assets/playlist
            foreach (var ele in playlistpath)
            {
                string Text = System.IO.File.ReadAllText(ele);
                playlist.Add(JsonConvert.DeserializeObject<PlayList>(Text));

                //playlist.Add(new PlayList(Path.GetFileName(ele).Split(".")[0]));
            }
            return playlist;
        }

    }

}

