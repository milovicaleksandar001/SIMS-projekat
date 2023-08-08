using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Booking.Application;
using HarfBuzzSharp;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideCreateTourViewModel : IObserver, INotifyPropertyChanged, IDataErrorInfo
    {
        public ITourService tourService { get; set; }
        public ILocationService locationService { get; set; }
        public ITourImageService tourImageService { get; set; }
        
        private TourKeyPoint _selectedTourKeyPoint;
        public TourKeyPoint SelectedTourKeyPoint
        {
            get { return _selectedTourKeyPoint; }
            set
            {
                _selectedTourKeyPoint = value;
                OnPropertyChanged("SelectedTourKeyPoint");
            }
        }

        public Tour tour = new Tour();
        
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> imagePaths = new List<string>();
        int currentImageIndex = -1;

        public RelayCommand Close { get; set; }
        public RelayCommand AddTourKeyPoint { get; set; }
        public RelayCommand RemoveTourKeyPoint { get; set; }
        public RelayCommand AddPicture { get; set; }
        public RelayCommand RemovePicture { get; set; }
        public RelayCommand NextPicture { get; set; }
        public RelayCommand PreviousPicture { get; set; }
        public RelayCommand IncreaseMaxGuests { get; set; }
        public RelayCommand DecreaseMaxGuests { get; set; }
        public RelayCommand IncreaseDuration { get; set; }
        public RelayCommand DecreaseDuration { get; set; }

        public ICommand FillCityCommand { get; set; }
        private ICommand _saveTourCommand;

        private string _selectedCountry;
        public string SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedCity;
        public string SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedKeyPoint;
        public string SelectedKeyPoint
        {
            get { return _selectedKeyPoint; }
            set
            {
                if (_selectedKeyPoint != value)
                {
                    _selectedKeyPoint = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> CityCollection { get; set; }
        public ObservableCollection<string> CountryCollection { get; set; }
        public ObservableCollection<string> KeyPointsCollection { get; set; }
        public ObservableCollection<TourKeyPoint> tourKeyPoints1 { get; set; }


        private bool _cityComboBoxEnabled;
        public bool CityComboboxEnabled
        {
            get => _cityComboBoxEnabled;
            set
            {
                if (_cityComboBoxEnabled != value)
                {
                    _cityComboBoxEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _selectedIndexKeyPoint;
        public int SelectedIndexKeyPoint
        {
            get { return _selectedIndexKeyPoint; }
            set
            {
                _selectedIndexKeyPoint = value;
                OnPropertyChanged("SelectedIndexKeyPoint");
            }
        }

        public string _name;
        public string TourName
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _city;
        public string City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _country;
        public string Country
        {
            get => _country;
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _description;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _language;
        public string TourLanguage
        {
            get => _language;
            set
            {
                if (_language != value)
                {
                    _language = value;
                    OnPropertyChanged();
                }
            }
        }

        public int _maxguestnumber;
        public int MaxGuestNumber
        {
            get => _maxguestnumber;
            set
            {
                if (_maxguestnumber != value)
                {
                    _maxguestnumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Location> _destinations;
        public List<Location> Destinations
        {
            get => _destinations;
            set
            {
                if (_destinations != value)
                {
                    _destinations = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _startTime;
        public string StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public int _duration;
        public int Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> _pictures;
        public List<string> Pictures
        {
            get => _pictures;
            set
            {
                if (_pictures != value)
                {
                    _pictures = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _tbPictures;
        public string TbPictures
        {
            get => _tbPictures;
            set
            {
                if (_tbPictures != value)
                {
                    _tbPictures = value;
                    OnPropertyChanged();
                }
            }
        }

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

        private bool _isDemoMode;
        public bool IsDemoMode
        {
            get { return _isDemoMode; }
            set
            {
                _isDemoMode = value;
                OnPropertyChanged(nameof(IsDemoMode));
            }
        }

        private bool _isCountryComboBoxOpen;
        public bool IsCountryComboBoxOpen
        {
            get { return _isCountryComboBoxOpen; }
            set
            {
                _isCountryComboBoxOpen = value;
                OnPropertyChanged(nameof(IsCountryComboBoxOpen));
            }
        }

        private bool _isCityComboBoxOpen;
        public bool IsCityComboBoxOpen
        {
            get { return _isCityComboBoxOpen; }
            set
            {
                _isCityComboBoxOpen = value;
                OnPropertyChanged(nameof(IsCityComboBoxOpen));
            }
        }

        private bool _isKeyPointsComboBoxOpen;
        public bool IsKeyPointsComboBoxOpen
        {
            get { return _isKeyPointsComboBoxOpen; }
            set
            {
                _isKeyPointsComboBoxOpen = value;
                OnPropertyChanged(nameof(IsKeyPointsComboBoxOpen));
            }
        }


        public static bool demoPom = false;

        private readonly Window _window;

        public GuideCreateTourViewModel(Window window)
        {
            _window = window;
            tourService = InjectorService.CreateInstance<ITourService>();
            locationService = InjectorService.CreateInstance<ILocationService>();
            tourImageService = InjectorService.CreateInstance<ITourImageService>();

            CityCollection = new ObservableCollection<string>();
            CountryCollection = new ObservableCollection<string>();
            KeyPointsCollection = new ObservableCollection<string>();

            tourKeyPoints1 = new ObservableCollection<TourKeyPoint>(tourService.GetTourKeyPoints());

            TourName = "";
            Description = "";
            MaxGuestNumber = 0;
            StartTime = "";
            Duration = 0;
            SelectedCountry = "";
            SelectedCity = "";
            TourLanguage = "";
            TbPictures = "";
            //SelectedKeyPoint = "";

            SetCommands();
            FillComboBox();
            NextPreviousPhotoButtonsVisibility();

            if(demoPom)
            {
                RunDemoMode();
            }

        }
        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            AddTourKeyPoint = new RelayCommand(ButtonAddTourKeyPoint);
            RemoveTourKeyPoint = new RelayCommand(ButtonRemoveKeyPoint);
            AddPicture = new RelayCommand(ButtonAddPicture);
            RemovePicture = new RelayCommand(ButtonRemovePicture);

            NextPicture = new RelayCommand(buttonNext_Click);
            PreviousPicture = new RelayCommand(buttonPrevious_Click);
            IncreaseMaxGuests = new RelayCommand(ButtonIncreaseMaxGuests);
            DecreaseMaxGuests = new RelayCommand(ButtonDecreaseMaxGuests);
            IncreaseDuration = new RelayCommand(ButtonIncreaseDuration);
            DecreaseDuration = new RelayCommand(ButtonDecreaseDuration);

            FillCityCommand = new RelayCommand(FillCity);
        }
        public void FillCity(object param)
        {
            CityCollection.Clear();

            var locations = locationService.GetAll().Where(l => l.State.Equals(SelectedCountry));

            foreach (Location c in locations)
            {
                CityCollection.Add(c.City);
            }

            CityComboboxEnabled = true;
        }

        public void FillComboBox()
        {
            List<string> items = new List<string>();

            using (StreamReader reader = new StreamReader("../../Resources/Data/locations.csv"))
            {
                while (!reader.EndOfStream)
                {

                    string[] fields = reader.ReadLine().Split(',');
                    foreach (var field in fields)
                    {
                        string[] Countries = field.Split('|');
                        items.Add(Countries[1]);
                    }
                }
            }
            var distinctItems = items.Distinct().ToList();

            UpdateCountryCollection(distinctItems);

            if (SelectedCountry == null)
            {
                CityComboboxEnabled = false;
            }
            SelectedIndexKeyPoint = -1;
            FillKeyPointsComboBox();
        }

        public void UpdateCountryCollection(List<string> coutries)
        {
            CountryCollection.Clear();
            foreach (string str in coutries)
            {
                CountryCollection.Add(str);
            }
        }

        private void FillKeyPointsComboBox()
        {
            List<string> items = new List<string>();

            using (StreamReader reader = new StreamReader("../../Resources/Data/locations.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(',');
                    foreach (var field in fields)
                    {
                        string[] pom = field.Split('|');
                        items.Add(pom[1] + ", " + pom[2]);
                    }
                }
            }

            KeyPointsCollection.Clear();
            foreach(string str in items)
            {
                KeyPointsCollection.Add(str);
            }
        }

        public string Error => null;
        private readonly string[] _validatedProperties = { "TourName" };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "TourName")
                {
                    if (TourName == String.Empty)
                    {

                        return "This filed is required!";
                    }
                }
                else if (columnName == "Description")
                {
                    if (Description == String.Empty)
                    {

                        return "This filed is required!";
                    }
                }
                else if (columnName == "MaxGuestNumber")
                {
                    if (MaxGuestNumber <= 0)
                    {

                        return "Max guest number should be > 0";
                    }
                }
                else if (columnName == "StartTime")
                {
                    if (StartTime == String.Empty)
                    {

                        return "This filed is required!";
                    }
                }
                else if (columnName == "Duration")
                {
                    if (Duration <= 0)
                    {

                        return "Duration should be > 0";
                    }
                }
                else if (columnName == "SelectedCountry")
                {
                    if (SelectedCountry == "")
                    {
                        return "This filed is required!";
                    }
                }
                else if (columnName == "SelectedCity")
                {
                    if (SelectedCity == "")
                    {
                        return "This filed is required!";
                    }
                }
                else if (columnName == "TourLanguage")
                {
                    if (TourLanguage == "")
                    {
                        return "This filed is required!";
                    }
                }
                else if (columnName == "TbPictures")
                {
                    if (TbPictures == "")
                    {
                        return "This filed is required!";
                    }
                }
                else if (columnName == "SelectedKeyPoint")
                {
                    if (SelectedKeyPoint == "")
                    {
                        return "This filed is required!";
                    }
                }

                return null;
            }
        }

        private void ButtonClose(object param)
        {
            CloseWindow();
        }
        private void ButtonAddTourKeyPoint(object param)
        {

            if (SelectedKeyPoint != null)
            { 
                string pom = SelectedKeyPoint.ToString();
                string[] CountryCity = pom.Split(',');
                string Country = CountryCity[0];
                string City = CountryCity[1].Trim();

                int locationId = locationService.GetIdByCountryAndCity(Country, City);
                Location location = locationService.GetById(locationId);

                TourKeyPoint tourKeyPoint = new TourKeyPoint();
                tourKeyPoints1.Add(tourKeyPoint);
                tourKeyPoint.Location = location;
                tour.Destinations.Add(tourKeyPoint);

            }   
            SelectedIndexKeyPoint = -1;

        }
        private void ButtonRemoveKeyPoint(object param)
        {
            if(SelectedTourKeyPoint != null) 
            {
                tour.Destinations.RemoveAll(d => d.Location.City == SelectedTourKeyPoint.Location.City && d.Location.State == SelectedTourKeyPoint.Location.State);
                tourKeyPoints1.Remove(SelectedTourKeyPoint);
            }
            else
            {
                System.Windows.MessageBox.Show("You need to select keypoint if you want to remove it!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

        }
        private void CloseWindow()
        {
            _window.Close();
        }

        private void NextPreviousPhotoButtonsVisibility()
         {
             if (imagePaths.Count == 0)
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
          
        
        public ICommand SaveTourCommand
        {
            get
            {
                if (_saveTourCommand == null)
                {
                    _saveTourCommand = new RelayCommand(
                        param => SaveTour()
                    );
                }
                return _saveTourCommand;
            }
        }

        private bool CanSaveTour()
        {         
            return !string.IsNullOrEmpty(TourName) && !string.IsNullOrEmpty(SelectedCountry) &&
             !string.IsNullOrEmpty(SelectedCity) && !string.IsNullOrEmpty(Description) &&
             !string.IsNullOrEmpty(TourLanguage) && MaxGuestNumber > 0 &&
             StartTime != null && Duration > 0; 
        }

        private void SaveTour()
        {
            if (CanSaveTour())
            {
                Location location = new Location
                {
                    State = SelectedCountry,
                    City = SelectedCity
                };
                int LocationID = locationService.GetIdByCountryAndCity(SelectedCountry, SelectedCity);
                tour.Location.Id = LocationID;
                tour.Location = locationService.GetById(LocationID);
                tour.Name = TourName;
                tour.Description = Description;
                tour.Language = TourLanguage;
                tour.MaxVisitors = MaxGuestNumber;
                tour.StartTime = DateTime.Parse(StartTime);
                tour.Duration = Duration;

                if (tour.Destinations.Count < 2)
                {
                    System.Windows.MessageBox.Show("Tour need to have 2 'KEY POINTS' at least", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }
                if (tour.Images.Count == 0)
                {
                    System.Windows.MessageBox.Show("Tour need to have 1 'PICTURE' at least", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(SelectedCountry))
                {
                    System.Windows.MessageBox.Show("'COUNTRY' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(tour.Location.City))
                {
                    System.Windows.MessageBox.Show("'CITY' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }
                if (tour.MaxVisitors < 1)
                {
                    System.Windows.MessageBox.Show("'MAX GUESTS NUMBER' should be greater than 0", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }
                if (tour.Duration < 1)
                {
                    System.Windows.MessageBox.Show("'DURATION' should be greater than 0", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }
                if(tour.Images.Count < 1)
                {
                    System.Windows.MessageBox.Show("Tour need to have 1 'IMAGE' at least", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return;
                }

                tourService.Create(tour);
                System.Windows.MessageBox.Show("Tour successfully created", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

                CloseWindow();
            }
            else
            {
                System.Windows.MessageBox.Show("Please fill in all required fields.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void ButtonAddPicture(object param)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentDirectory, "../../Resources/Images/ToursPhotos"));

            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.InitialDirectory = folderPath;


            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = dialog.FileName;
                imagePaths.Add(imagePath);
                currentImageIndex = imagePaths.Count - 1;
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures = imagePath;
            }

            if (TbPictures != "")
            {
                TourImage Images = new TourImage();
                Images.Url = TbPictures;
                tour.Images.Add(Images);
                NextPreviousPhotoButtonsVisibility();
            }
            else
            {
                MessageBox.Show("Photo URL can't be empty!");
            }
        }

        private void ButtonDemoAddPicture(object param)
        {
            string folderPath = "../../Resources/Images/ToursPhotos";
            string[] imageFiles = Directory.GetFiles(folderPath, "*.png")
                                           .Concat(Directory.GetFiles(folderPath, "*.jpeg"))
                                           .Concat(Directory.GetFiles(folderPath, "*.jpg"))
                                           .ToArray();


            if (imageFiles.Length > 0)
            {
                string imagePath = imageFiles[0];
                imagePaths.Add(imagePath);
                currentImageIndex = imagePaths.Count - 1;

                if (!Path.IsPathRooted(imagePath))
                {       
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    imagePath = Path.Combine(baseDirectory, imagePath);
                }

                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures = imagePath;

                if (TbPictures != "")
                {
                    TourImage Images = new TourImage();
                    Images.Url = TbPictures;
                    tour.Images.Add(Images);
                    NextPreviousPhotoButtonsVisibility();
                }
                else
                {
                    MessageBox.Show("Photo URL can't be empty!");
                }
            }
        }

        private void ButtonRemovePicture(object param)
        {
            TourImage image = new TourImage
            {
                Url = TbPictures
            };
            ImageSlideshowSource = null;
            imagePaths.Remove(image.Url);

            int indexToRemove = -1;
            for (int i = 0; i < tour.Images.Count; i++)
            {
                if (tour.Images[i].Url == image.Url)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                tour.Images.RemoveAt(indexToRemove);

                if (tour.Images.Count == 0)
                {
                    currentImageIndex = -1;
                    TbPictures = "";
                    ImageSlideshowSource = null;
                }
                else
                {
                    currentImageIndex = (currentImageIndex - 1 + tour.Images.Count) % tour.Images.Count;

                    ImageSlideshowSource = new BitmapImage(new Uri(tour.Images[currentImageIndex].Url));
                    TbPictures = tour.Images[currentImageIndex].Url;
                }
            }

            NextPreviousPhotoButtonsVisibility();
        }


        private void buttonPrevious_Click(object param)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                string imagePath = imagePaths[currentImageIndex];
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures = imagePath;
            }
        }

        private void buttonNext_Click(object param)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                string imagePath = imagePaths[currentImageIndex];
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures= imagePath;
            }
        }


        private void ButtonIncreaseMaxGuests(object param)
        {
            int currentValue;
            if (int.TryParse(MaxGuestNumber.ToString(), out currentValue))
            {
                MaxGuestNumber = (currentValue + 10);
            }
        }

        private void ButtonDecreaseMaxGuests(object param)
        {
            int currentValue;
            if (int.TryParse(MaxGuestNumber.ToString(), out currentValue) && currentValue > 0)
            {
                MaxGuestNumber = (currentValue - 10);
            }
            if (currentValue < 9)
            {
                MaxGuestNumber = 0;
            }
        }

        private void ButtonIncreaseDuration(object param)
        {
            int currentValue;
            if (int.TryParse(Duration.ToString(), out currentValue))
            {
                Duration = (currentValue + 1);
            }
        }
        private void ButtonDecreaseDuration(object param)
        {
            int currentValue;
            if (int.TryParse(Duration.ToString(), out currentValue) && currentValue > 0)
            {
                Duration = (currentValue - 1);
            }
        }

        public async void RunDemoMode()
        {
            await Task.Delay(350);
            const string tourName = "Demo Tour";
            foreach (char c in tourName)
            {
                TourName += c.ToString();
                await Task.Delay(10);
            }

            await Task.Delay(1000); 


            const string description = "This is a demo tour description. This tour will be automatically removed after demo mode.";
            foreach (char c in description)
            {
                Description += c.ToString();
                await Task.Delay(10);
            }

            await Task.Delay(1000);

            ButtonIncreaseMaxGuests(this); await Task.Delay(500); ButtonIncreaseMaxGuests(this); await Task.Delay(500); ButtonIncreaseMaxGuests(this);

            await Task.Delay(1000);

            DateTime demoDate = DateTime.Now.AddDays(10); 
            StartTime = demoDate.ToString();

            await Task.Delay(1000);
            
            ButtonIncreaseDuration(this); await Task.Delay(500); ButtonIncreaseDuration(this); await Task.Delay(500); ButtonIncreaseDuration(this);

            await Task.Delay(1000);

            IsCountryComboBoxOpen = true;
            await Task.Delay(400);
            SelectedCountry = CountryCollection[0];
            IsCountryComboBoxOpen = false;
            await Task.Delay(1000);
            
            IsCityComboBoxOpen = true;
            await Task.Delay(400);
            SelectedCity = CityCollection[0];
            IsCityComboBoxOpen= false;

            await Task.Delay(1000);

            const string language = "Serbian";
            foreach (char c in language)
            {
                TourLanguage += c.ToString();
                await Task.Delay(10);
            }

            await Task.Delay(1000);
            
            ButtonDemoAddPicture(this);

            await Task.Delay(2000);

            IsKeyPointsComboBoxOpen = true;
            await Task.Delay(400);
            SelectedKeyPoint = KeyPointsCollection[0];
            IsKeyPointsComboBoxOpen= false;

            await Task.Delay(500);
            ButtonAddTourKeyPoint(this);

            await Task.Delay(1000);

            IsKeyPointsComboBoxOpen = true;
            await Task.Delay(400);
            SelectedKeyPoint = KeyPointsCollection[1];
            IsKeyPointsComboBoxOpen= false;

            await Task.Delay(500);
            ButtonAddTourKeyPoint(this);

            await Task.Delay(2000);

            SaveTour();
            System.Windows.MessageBox.Show("Now Demo Mode will cancel demo tour!", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        public void Update()
        {
            tourKeyPoints1.Clear();

            foreach (TourKeyPoint t in tourService.GetTourKeyPoints())
            {
                tourKeyPoints1.Add(t);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
