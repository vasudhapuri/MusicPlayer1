using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MusicPlayer1.Model
{
    public static class MusicManager
    {
        private static string extension { get; set; }
        private static string ImageFile { get; set; }

        //Getting Music (mp3 files only) from special folder path
        public static void GetMusics(ObservableCollection<Music> music)
        {
            string path = Windows.ApplicationModel.Package.Current.InstalledLocation.Path + @"\Assets\Music";
            music.Clear();
            string[] files = Directory.GetFiles(path, "*.mp3*", SearchOption.AllDirectories);
            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    string MusicName = Path.GetFileNameWithoutExtension(file); //refers to songname in Music class constructor
                    music.Add(new Music(file, MusicName));
                }
                
            }
        }

    }
}

