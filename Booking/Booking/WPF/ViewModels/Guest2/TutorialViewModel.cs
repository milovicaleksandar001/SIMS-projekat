using Booking.Commands;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
    public class TutorialViewModel
    {
        private readonly Window _window;
        private bool _playOrPause;

        public string Url { get; set; }

        public RelayCommand Button_Click_Close { get; set; }
        public RelayCommand Button_Click_PlayPause { get; set; }

        public TutorialViewModel(Window window, string url)        {
            _window = window;

            Url = url;
            _playOrPause = true;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            Button_Click_Close = new RelayCommand(ButtonClose);
            Button_Click_PlayPause = new RelayCommand(PlayPause);
        }

        private void ButtonClose(object param)
        {
            _window.Close();
        }

        private void PlayPause(object param)
        {
            if (_playOrPause)
            {
                //play
                _playOrPause = false;
            }
            else
            {
                //pause
                _playOrPause = true;
            }
        }
    }
}
