using Booking.Commands;
using Booking.Model;
using Booking.Model.Images;
using Booking.WPF.Views.Guest2;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
    public class ShowTourImagesViewModel : INotifyPropertyChanged
    {
        private readonly Window _window;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<TourImage> Images { get; set; }
        public Tour Tour { get; set; }
        public string Location { get; set; }

        private int _index;
        private int _listSize;

        private string _image;
        public string ImageSource
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand Button_Click_Close { get; set; }
        public RelayCommand Button_Click_Next { get; set; }
        public RelayCommand Button_Click_Prev { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public ShowTourImagesViewModel(Window window, Tour tour)
        {
            _window = window;
            Tour = tour;
            Location = tour.Location.State + ", " + tour.Location.City;
            Images = tour.Images;

            _index = 0;
            _listSize = Images.Count;

            UpdateImage();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            Button_Click_Close = new RelayCommand(ButtonClose);
            Button_Click_Next = new RelayCommand(ButtonNext);
            Button_Click_Prev = new RelayCommand(ButtonPrev);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/TourImages.mp4");
            view.ShowDialog();
        }

        private void ButtonClose(object param)
        {
            _window.Close();
        }

        private void ButtonNext(object param)
        {
            _index = (_index + 1) % _listSize;
            UpdateImage();
        }

        private void ButtonPrev(object param)
        {
            _index = (_listSize + _index - 1) % _listSize;
            UpdateImage();
        }

        private void UpdateImage()
        {
            ImageSource = Images[_index].Url;
            Text = _index + 1 + "/" + _listSize;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
