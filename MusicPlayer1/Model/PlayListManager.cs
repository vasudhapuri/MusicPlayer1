using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.FileProperties;


namespace MusicPlayer1.Model
{

    class PlayListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(PlayList));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string name = (string)jo["PlayListName"];
            string otherdetails = (string)jo["PlayListOtherDetails"];
            //StorageItemThumbnail image = (StorageItemThumbnail)jo["PlayListImage"];
            string image = jo["PlayListImage"].ToObject<string>();
            return new PlayList(name, otherdetails, image);
        }
        
        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


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

                
            }
            return playlist;
        }

    }

}

