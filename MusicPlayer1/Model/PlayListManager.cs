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
        public static void GetPlayList(ObservableCollection<PlayList> playlist)
        {
            var allplaylists = GetPlayLists();
            foreach (var element in allplaylists)
            {
                playlist.Add(element);

            }

        }
        public static string[] PlayListsPath()
        {
            string[] playlistfilename = Directory.GetFiles("C:\\Users\\parulp\\AppData\\Local\\Packages\\48ce0e45-e2e4-4d79-bb60-6cff185029e1_nv98t81mhz8jj\\LocalState\\Assets\\PlayLists");
            //"C:\\Users\\parulp\\AppData\\Local\\Packages\\48ce0e45-e2e4-4d79-bb60-6cff185029e1_nv98t81mhz8jj\\LocalState\\Assets\\PlayLists"
            return playlistfilename;

        }

        public static List<PlayList> GetPlayLists()
        {
            var playlist = new List<PlayList>();
            var myplaylistnames = new List<string>();
           
             string[] playlistpath = PlayListsPath();
            foreach (var ele in playlistpath)
            {
                myplaylistnames.Add(Path.GetFileName(ele));
            }


            foreach (var ele1 in myplaylistnames)
            {
                playlist.Add(new PlayList(ele1.Split(".")[0], "/Assets/Icons/MyMusic.jfif"));
            }
            return playlist;
        }
    }
}
