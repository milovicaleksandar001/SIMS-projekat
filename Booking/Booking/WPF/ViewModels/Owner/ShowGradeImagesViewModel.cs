using Booking.Commands;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class ShowGradeImagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AccommodationAndOwnerGrade selectedGrade { get; set; }
        public String ReviewLabel { get; set; } = String.Empty;

        private List<string> pictureUrls;

        private int currentPictureIndex;

        public String _currentImageUrl;
        public String CurrentImageUrl
        {
            get => _currentImageUrl;
            set
            {
                if (_currentImageUrl != value)
                {
                    _currentImageUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool _isNextEnabled;

        public bool IsNextEnabled
        {
            get => _isNextEnabled;
            set
            {
                if (_isNextEnabled != value)
                {
                    _isNextEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool _isPreviousEnabled;

        public bool IsPreviousEnabled
        {
            get => _isPreviousEnabled;
            set
            {
                if (_isPreviousEnabled != value)
                {
                    _isPreviousEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand PreviousButton_Click { get; set; }
        public RelayCommand NextButton_Click { get; set; }
        public RelayCommand CloseWindow { get; set; }
        private readonly Window _window;

        public ShowGradeImagesViewModel(AccommodationAndOwnerGrade SelectedGrade, Window window)
        {
            _window = window;
            selectedGrade = SelectedGrade;
            ReviewLabel = SetReviewLabel(SelectedGrade);
            pictureUrls = new List<string>();
            currentPictureIndex = 0;

            setUrls();

            PreviousButton_Click = new RelayCommand(PreviousButton);
            NextButton_Click = new RelayCommand(NextButton);
            CloseWindow = new RelayCommand(Close);
            IsPreviousEnabled = false;


            if (currentPictureIndex == pictureUrls.Count - 1)
            {
                IsNextEnabled = false;
            }
            else
            {
                IsNextEnabled = true;
            }
        }
        private void Close(object param)
        {
            _window.Close();
        }
        public void setUrls()
        {
            foreach (var image in selectedGrade.Images)
            {
                pictureUrls.Add(image.Url);
            }
            SetCurrentImage();
        }
        private String SetReviewLabel(AccommodationAndOwnerGrade grade)
        {
            return "Guest: " + grade.AccommodationReservation.Guest.Username + " ,for accommodation: " + grade.AccommodationReservation.Accommodation.Name;
        }
        private void PreviousButton(object param)
        {
            if (currentPictureIndex > 0)
            {
                currentPictureIndex--;
                SetCurrentImage();
                IsNextEnabled = true;
            }

            if (currentPictureIndex == 0)
            {
                IsPreviousEnabled = false;
            }
        }
        private void NextButton(object param)
        {
            if (currentPictureIndex < pictureUrls.Count - 1)
            {
                currentPictureIndex++;
                SetCurrentImage();
                IsPreviousEnabled = true;
            }

            if (currentPictureIndex == pictureUrls.Count - 1)
            {
                IsNextEnabled = false;
            }
        }
        private void SetCurrentImage()
        {
            CurrentImageUrl = pictureUrls[currentPictureIndex];
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
