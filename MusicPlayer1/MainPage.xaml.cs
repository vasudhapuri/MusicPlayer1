using MusicPlayer1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using System.Windows;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.FileProperties;
using System.Threading.Tasks;

namespace MusicPlayer1
{

    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> music;
        private ObservableCollection<PlayList> playlist;
        private string nextButtonText { get; set; }

        private Music CurrentMusic { get; set; }
        public string browsedImage { get; set; }

        PlayList userClickedPlayListCurr;

        public MainPage()
        {
            this.InitializeComponent();
            music = new ObservableCollection<Music>();
            MusicManager.GetMusics(music);
            playlist = new ObservableCollection<PlayList>();
            PlayListManager.GetPlayList(playlist);
            MusicListView.Visibility = Visibility.Visible;
            textBlock.Text = string.Empty;

        


        }


        private void MusicListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Music userClickedItem = (Music)e.ClickedItem;
            CurrentMusic = userClickedItem;
            string extension = Path.GetExtension(userClickedItem.FileName);
            if (extension == ".mp3")
            {
                MyMediaElement.Source = new Uri(this.BaseUri, userClickedItem.FileName);
                MyMediaElement.Play();
            }
        }
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Pause();
        }
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {

            MyMediaElement.Position = TimeSpan.Zero;
            MyMediaElement.Play();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Play();

        }
        private void PlayListListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            PlayList userClickedPlayList = (PlayList)e.ClickedItem;
            userClickedPlayListCurr = userClickedPlayList;
            music.Clear();
            foreach (var song in userClickedPlayList.songs)
            {
                music.Add(song);
            }
            textBlock.Text = userClickedPlayList.PlayListOtherDetails;
        }
        private void MyMusic_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetMusics(music);
            MusicListView.Visibility = Visibility.Visible;
            textBlock.Text = string.Empty;
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Stop();
        }
        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMusic != null)
            {
                string playListName = Input.Text;
                string playListOtherDetails = string.Empty;
                if (!String.IsNullOrEmpty(OtherDetailsInput.Text))
                {
                    playListOtherDetails = OtherDetailsInput.Text;
                }
                else if (userClickedPlayListCurr != null && !String.IsNullOrEmpty(userClickedPlayListCurr.PlayListOtherDetails))
                {
                    playListOtherDetails = userClickedPlayListCurr.PlayListOtherDetails;
                }
                    

                
                var location = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string playListImageDirectory = $@"{location}\Assets\PlayListsImage";
                string imageDestination = $@"{playListImageDirectory}\{playListName}{Path.GetExtension(browsedImage)}";

                //File.Copy(browsedImage, imageDestination);

                var playList = new PlayList(playListName, playListOtherDetails, browsedImage);
                playList.Add(CurrentMusic);
            }
            playlist.Clear();
            PlayListManager.GetPlayList(playlist);
            PlayListAddFlyout.Hide();
            Input.Text = String.Empty;
            OtherDetailsInput.Text = String.Empty;
            Browse_path.Text = String.Empty;

        }


        private  async void Browse_Click(object sender, RoutedEventArgs e)
        {
            //StorageItemThumbnail browsedImage = null; ;
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                Browse_path.Text =  file.Name;
                 browsedImage =  file.Path;
            }
            
            

        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


