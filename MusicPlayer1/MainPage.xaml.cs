﻿using MusicPlayer1.Model;
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


namespace MusicPlayer1
{

    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> music;
        private ObservableCollection<PlayList> playlist;


        //public string ImageFile { get; set; }
        //public string SongName { get; set; }
        private Music CurrentMusic { get; set; }



        public MainPage()
        {
            this.InitializeComponent();
            music = new ObservableCollection<Music>();
            MusicManager.GetMusics(music);

            playlist = new ObservableCollection<PlayList>();
            PlayListManager.GetPlayList(playlist);

            MusicListView.Visibility = Visibility.Visible;

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


        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Play();

        }


        private void PlayListListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            PlayList userClickedPlayList = (PlayList)e.ClickedItem;


            music.Clear();
            foreach (var song in userClickedPlayList.songs)
            {
                music.Add(song);
            }


        }



        private void MyMusic_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetMusics(music);
            MusicListView.Visibility = Visibility.Visible;



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
                string playListOtherDetails = OtherDetailsInput.Text;
                var playList = new PlayList(playListName, playListOtherDetails);
                playList.Add(CurrentMusic);
            }

            playlist.Clear();
            PlayListManager.GetPlayList(playlist);
        }


    }
}
