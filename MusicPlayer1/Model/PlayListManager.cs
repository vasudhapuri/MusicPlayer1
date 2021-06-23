using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private static List<PlayList> GetPlayLists()
        {
            var playlist = new List<PlayList>();
            playlist.Add(new PlayList("PlayList1", "/Assets/Icons/MyMusic.jfif"));
            playlist.Add(new PlayList("PlayList2", "/Assets/Icons/MyMusic.jfif"));
            playlist.Add(new PlayList("PlayList3", "/Assets/Icons/MyMusic.jfif"));
            return playlist;
        }
    }
}
