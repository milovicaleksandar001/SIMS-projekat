using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Util;
using Booking.View;
using Booking.WPF.Views.Guide;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;
namespace Booking.WPF.ViewModels.Guide
{
    public class GuideFollowTourLiveViewModel : IObserver, INotifyPropertyChanged
    {
        public ObservableCollection<Tour> Tours { get; set; }
        public ITourService TourService { get; set; }
        public ITourImageService TourImageService { get; set; }
        public Tour SelectedTour { get; set; }
        int Pomid { get; set; }
        List<string> imagePaths = new List<string>();
        int currentImageIndex = -1;

        private BitmapImage _imageSlideshowSource;
        public BitmapImage ImageSlideshowSource
        {
            get { return _imageSlideshowSource; }
            set
            {
                _imageSlideshowSource = value;
                OnPropertyChanged(nameof(ImageSlideshowSource));
            }
        }
        private Visibility _buttonNextVisibility = Visibility.Visible;
        public Visibility ButtonNextVisibility
        {
            get { return _buttonNextVisibility; }
            set { _buttonNextVisibility = value; OnPropertyChanged(); }
        }

        private Visibility _buttonPreviousVisibility = Visibility.Visible;
        public Visibility ButtonPreviousVisibility
        {
            get { return _buttonPreviousVisibility; }
            set { _buttonPreviousVisibility = value; OnPropertyChanged(); }
        }


        public RelayCommand Close { get; set; }
        public RelayCommand StartTour { get; set; }
        public RelayCommand EndTour { get; set; }
        public RelayCommand ShowOnGoingTour { get; set; }
        public RelayCommand ShowDescriptionText { get; set; }
        public RelayCommand PreviousPicture { get; set; }
        public RelayCommand NextPicture { get; set; }
        
            
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Window _window;
        public GuideFollowTourLiveViewModel(Window window) 
        {
            _window = window;
            TourService = InjectorService.CreateInstance<ITourService>();
            TourImageService = InjectorService.CreateInstance<ITourImageService>();

            TourService.Subscribe(this);

            Pomid = -1;
            Tours = new ObservableCollection<Tour>(TourService.GetTodayTours());

            LoadImages();
            SetCommands();
        }

        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            StartTour = new RelayCommand(ButtonStartTour);
            EndTour = new RelayCommand(ButtonEndTour);
            ShowOnGoingTour = new RelayCommand(ButtonShowOnGoingTour);
            ShowDescriptionText = new RelayCommand(ButtonShowDescriptionText);
            PreviousPicture = new RelayCommand(buttonPrevious_Click);
            NextPicture = new RelayCommand(buttonNext_Click);
        }

            private void LoadImages()
        {
            imagePaths.Clear();
            List<TourImage> tourImages = TourImageService.GetImagesFromStartedTourId();

            foreach (TourImage image in tourImages)
            {
                string imagePath = image.Url;
                imagePaths.Add(imagePath);
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
            }
            if (tourImages.Count == 0)
            {
                ImageSlideshowSource = null;
                ButtonNextVisibility = Visibility.Collapsed;
                ButtonPreviousVisibility = Visibility.Collapsed;
            }
            else
            {
                ButtonNextVisibility = Visibility.Visible;
                ButtonPreviousVisibility = Visibility.Visible;
            }
        }

        private void ButtonStartTour(object param)
        {

            int startedTours = 0;
            startedTours = CheckNumberOfStartedTours(startedTours);

            if (startedTours < 1)
            {
                StartSelectedTour();
            }
            else
            {
                System.Windows.MessageBox.Show("You can start maximum 1 tour in same time!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }


        private void ButtonEndTour(object param)
        {
            if (SelectedTour != null && SelectedTour.IsStarted == true)
            {
                SelectedTour.IsStarted = false;
                SelectedTour.IsEnded = true;
                TourService.UpdateTour(SelectedTour);
                System.Windows.MessageBox.Show(SelectedTour.Name.ToString() + " is ended!", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                TourService.NotifyObservers();
            }
            else
            {
                System.Windows.MessageBox.Show("In order to end the tour, you first need to select started tour!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void ButtonShowOnGoingTour(object param)
        {
            int pomid1 = -1;
            foreach (var t in Tours)
            {
                if (t.IsStarted == true)
                    pomid1 = t.Id;
                else Pomid = -1;
            }

            Pomid = pomid1;

            Tour tour = TourService.GetById(Pomid);
            if (tour != null)
            {
                GuideKeyPointsCheck guideKeyPointsCheck = new GuideKeyPointsCheck(tour.Id);
                guideKeyPointsCheck.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("You don't have ongoing tour!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void StartSelectedTour()
        {
            if (SelectedTour != null)
            {
                GuideKeyPointsCheck guideKeyPointsCheck = new GuideKeyPointsCheck(SelectedTour.Id);
                Pomid = SelectedTour.Id;
                if (SelectedTour.IsEnded)
                {
                    System.Windows.MessageBox.Show("You cant start ended tour!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
                else
                {
                    SelectedTour.IsStarted = true;
                    TourService.UpdateTour(SelectedTour);
                    System.Windows.MessageBox.Show(SelectedTour.Name.ToString() + " is started!", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    TourService.NotifyObservers();

                    guideKeyPointsCheck.ShowDialog();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("In order to start the tour, you first need to select it!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private int CheckNumberOfStartedTours(int startedTours)
        {
            foreach (var tour in Tours)
            {
                if (tour.IsStarted == true)
                {
                    startedTours++;
                    Pomid = tour.Id;
                }

            }

            return startedTours;
        }
        private void ButtonClose(object param)
        {
            CloseWindow();
        }
        private void CloseWindow()
        {
            _window.Close();
        }

        private void ButtonShowDescriptionText(object param)
        {
            ShowDescription showDescriptionText = new ShowDescription(SelectedTour.Id);
            showDescriptionText.Show();
        }

        private void buttonPrevious_Click(object param)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                string imagePath = imagePaths[currentImageIndex];
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
            }
        }

        private void buttonNext_Click(object param)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                string imagePath = imagePaths[currentImageIndex];
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
            }
        }

        public void Update()
        {
            Tours.Clear();
            foreach (Tour t in TourService.GetTodayTours())
            {
                Tours.Add(t);
            }
            LoadImages();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
