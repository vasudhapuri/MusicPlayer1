using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer1.Model
{
    public class MenuItem1
    {
        public string icon { get; set; }

        public string category { get; set; }

        public MenuItem1()
        {
            icon = $"Assets/Icons/MyMusic.jfif";
            category = "My Music";

        }
    }
}
