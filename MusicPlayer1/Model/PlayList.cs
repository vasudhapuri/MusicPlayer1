using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer1.Model
{
   public  class PlayList
    {
        public string PlayListName { get; set; }
        public string PlayListSong { get; set; }
        public string PlayListImage { get; set; }

        public PlayList (string playlistname, string image)
        {
            PlayListName = playlistname;
            PlayListImage = image;
                }

    }
}
