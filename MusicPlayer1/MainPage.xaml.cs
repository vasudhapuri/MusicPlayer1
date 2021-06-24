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
//using Microsoft.UI.Xaml.Controls.Primitives.Popup;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicPlayer1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> music;
        private ObservableCollection<PlayList> playlist;
        private List<PlayList> playlistnames;


        public string ImageFile { get; set; }
        public string SongName { get; set; }
        private Music CurrentMusic { get; set; }
        private List<MenuItem1> menuitem1;
        private List<MenuItem2> menuitem2;


        public MainPage()
        {
            this.InitializeComponent();
            music = new ObservableCollection<Music>();
            MusicManager.GetMusics(music);

            playlist=  new ObservableCollection<PlayList>();
            PlayListManager.GetPlayList(playlist);            

           menuitem1 = new List<MenuItem1>();
           menuitem2 = new List<MenuItem2>();
            //menuitem1.Add()
            var m1 = new MenuItem1();
             m1.category = "My Music";
             m1.icon = $"Assets/Icons/MyMusic.jfif";
            menuitem1.Add(m1);

             var m2 = new MenuItem2();
             m2.category = "Playlists";
             m2.icon = $"Assets/Icons/Playlist.png";
             menuitem2.Add(m2);

            PlayListView.Visibility = Visibility.Collapsed;
            MusicListView.Visibility = Visibility.Visible;

            playlistnames = new List<PlayList>();
            foreach (var element in PlayListManager.GetPlayLists())
            {
                playlistnames.Add(element);
            }





        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySpiltView.IsPaneOpen = !MySpiltView.IsPaneOpen;

        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

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

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {
            
            MyMediaElement.Position = TimeSpan.Zero;
            MyMediaElement.Play();
        }
        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            {
                

            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Play();
            
        }

        private void MenuItemsListView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            {
               
            }
        }

        private void PlayListListView_ItemClick(object sender, ItemClickEventArgs e)
        {
      
            
            
            


        }

        private void MenuItem1ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Music userClickedItem = (Music)e.ClickedItem;
            
            string extension = Path.GetExtension(userClickedItem.FileName);
            if (extension == ".mp3")
            {
                MyMediaElement.Source = new Uri(this.BaseUri, userClickedItem.FileName);
                MyMediaElement.Play();
               // NowPlaying.Text = userClickedItem.SongName;
                //BitmapImage bitmapImage = new BitmapImage();
                //bitmapImage.UriSource = userClickedItem.ImageFile;
                //CoverImage.Source = bitmapImage;
            }

        }

        private void MyMusic_Click(object sender, RoutedEventArgs e)
        {
            PlayListView.Visibility = Visibility.Collapsed;
            MusicListView.Visibility = Visibility.Visible;
     
           

        }

        private void MyPlayLists_Click(object sender, RoutedEventArgs e)
        {
            MusicListView.Visibility = Visibility.Collapsed;
            PlayListView.Visibility = Visibility.Visible;            
             //DisplayPlayList.PlayListsNames();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMusic != null)
            {
                string playListName = Input.Text;
                var playList = new SavePlayList(playListName);
                playList.Add(CurrentMusic);
            }
        }

        private void ViewMyPlayListHeaders_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
