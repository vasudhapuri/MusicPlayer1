using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer1.Model
{
    public class MenuItem2
    {
        public string icon { get; set; }

        public string category { get; set; }

        public MenuItem2()
        {
            icon = $"Assets/Icons/Playlist.png";
            category = "PlayLists";

        }
    }
}
