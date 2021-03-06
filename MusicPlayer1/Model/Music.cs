using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer1.Model
{
    public class Music
    {
        public string FileName { get; set; }
        public string SongName { get; set; }
        public string ImageFile { get; set; }
        public Music(string fileName, string songName)
        {
            FileName = fileName;
            SongName = songName;
            ImageFile = $"/Assets/Icons/MusicIcon.png";
        }
    }
}
