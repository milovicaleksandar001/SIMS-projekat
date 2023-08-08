using Booking.Commands;
using Booking.WPF.Views.Guest2;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
    public class RateTourImagesViewModel : INotifyPropertyChanged
    {
        private readonly Window _window;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> Images { get; set; }

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
        public RelayCommand Button_Click_Remove { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public RateTourImagesViewModel(Window window, List<string> imgs)
        {
            _window = window;

            Images = imgs;

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
            Button_Click_Remove = new RelayCommand(RemoveImg);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/RateATourImages.mp4");
            view.ShowDialog();
        }

        private void ButtonClose(object param)
        {
            CloseWindow();
        }

        private void CloseWindow()
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
            ImageSource = Images[_index];
            Text = _index + 1 + "/" + _listSize;
        }

        private void RemoveImg(object param)
        {
            Images.Remove(Images[_index]);
            if(_index > 0)
            {
                _index -= 1;
            }
            _listSize -= 1;
            if (_listSize == 0)
            {
                CloseWindow();
            }
            else
            {
                UpdateImage();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
