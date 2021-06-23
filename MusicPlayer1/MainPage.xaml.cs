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
        public string ImageFile { get; set; }
        public string SongName { get; set; }
        private List<MenuItems> menuitems;
      

        public MainPage()
        {
            this.InitializeComponent();
            music = new ObservableCollection<Music>();
            MusicManager.GetMusics(music);

            playlist=  new ObservableCollection<PlayList>();
            PlayListManager.GetPlayList(playlist);

          

            menuitems = new List<MenuItems>();
            var m1 = new MenuItems();
            m1.category = "My Music";
            m1.icon = $"Assets/Icons/MyMusic.jfif";
            menuitems.Add(m1);

            
            var m2 = new MenuItems();
            m2.category = "Playlists";
            m2.icon = $"Assets/Icons/Playlist.png";
            menuitems.Add(m2);
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
            //ViewManager.Initialize(SongList, playLists);
            //AllSongsListView.Visibility = Visibility.Collapsed;
            //PlayListView.Visibility = Visibility.Collapsed;
            //CreateNewPlaylistView.Visibility = Visibility.Collapsed;
            //p.GetPlayList(playlist);


        }
    }
}
