using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Model.Enums;
using Booking.Model.Images;
using Booking.Observer;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VirtualKeyboard.Wpf;

namespace Booking.WPF.ViewModels.Owner
{
    public class OwnerRegisterAccommodationViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public IAccommodationService AccommodationService { get; set; }
        public ILocationService LocationService { get; set; }
        public IAccommodationImageService accommodationImageService { get; set; }

        public Accommodation accommodation = new Accommodation();
        public event PropertyChangedEventHandler PropertyChanged;

        List<string> imagePaths = new List<string>();
        int currentImageIndex = -1;
        public RelayCommand AddPicture { get; set; }
        public RelayCommand RemovePicture { get; set; }
        public RelayCommand PreviousPicture { get; set; }
        public RelayCommand NextPicture { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand IncreaseMaxGuests { get; set; }
        public RelayCommand DecreaseMaxGuests { get; set; }
        public RelayCommand IncreaseMinDays { get; set; }
        public RelayCommand DecreaseMinDays { get; set; }
        public RelayCommand Wizard { get; set; }
        public RelayCommand IncreaseCancelationPeriod { get; set; }
        public RelayCommand DecreaseCancelationPeriod { get; set; }
        public ICommand FillCityCommand { get; set; }
        private ICommand _create;
        public string SelectedCountry { get; set; }
        public string SelectedCity { get; set; }
        public ObservableCollection<string> CityCollection { get; set; }
        public ObservableCollection<string> CountryCollection { get; set; }
        public ObservableCollection<AccommodationType> comboBoxType { get; set; }

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

        private string _name;

        public string AccommodationName
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
                    OnPropertyChanged("Country");
                }
            }
        }



        public AccommodationType _type;
        public AccommodationType Type
        {
            get => _type;
            set
            {

                _type = value;
                OnPropertyChanged();

            }
        }

        public int _capacity;
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (_capacity != value)
                {
                    _capacity = value;
                    OnPropertyChanged();
                }
            }
        }

        public int _minNumberOfDays;
        public int MinNumberOfDays
        {
            get => _minNumberOfDays;
            set
            {
                if (_minNumberOfDays != value)
                {
                    _minNumberOfDays = value;
                    OnPropertyChanged();
                }
            }
        }

        public int _cancelationPeriod;
        public int CancelationPeriod
        {
            get => _cancelationPeriod;
            set
            {
                if (_cancelationPeriod != value)
                {
                    _cancelationPeriod = value;
                    OnPropertyChanged();
                }
            }
        }

        /*public List<AccommodationImage> _pictures;
        public List<AccommodationImage> Pictures
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
        }*/
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
        private readonly Window _window;
        public OwnerRegisterAccommodationViewModel(Window window)
        {
            _window = window;
            //TypecomboBox.ItemsSource = new List<string>() { "APARTMENT", "HOUSE", "COTTAGE" };
            AccommodationService = InjectorService.CreateInstance<IAccommodationService>();
            LocationService = InjectorService.CreateInstance<ILocationService>();
            accommodationImageService = InjectorService.CreateInstance<IAccommodationImageService>();

            CityCollection = new ObservableCollection<string>();
            CountryCollection = new ObservableCollection<string>();
            List<AccommodationType> theList = Enum.GetValues(typeof(AccommodationType)).Cast<AccommodationType>().ToList();

            comboBoxType = new ObservableCollection<AccommodationType>(theList);
            SetCommands();
            FillComboBox();
            NextPreviousPhotoButtonsVisibility();

            AccommodationName = "";
            SelectedCountry = "";
            SelectedCity = "";
            TbPictures = "";

            Type = AccommodationType.APARTMENT;

        }
        public void SetCommands()
        {
            Close = new RelayCommand(CloseWindow);
            AddPicture = new RelayCommand(ButtonAddPicture);
            RemovePicture = new RelayCommand(ButtonRemovePicture);

            NextPicture = new RelayCommand(buttonNext_Click);
            PreviousPicture = new RelayCommand(buttonPrevious_Click);

            IncreaseMaxGuests = new RelayCommand(ButtonIncreaseMaxGuests);
            DecreaseMaxGuests = new RelayCommand(ButtonDecreaseMaxGuests);
            IncreaseMinDays = new RelayCommand(ButtonIncreaseMinDays);
            DecreaseMinDays = new RelayCommand(ButtonDecreaseMinDays);
            IncreaseCancelationPeriod = new RelayCommand(ButtonIncreaseCancelationPeriod);
            DecreaseCancelationPeriod = new RelayCommand(ButtonDecreaseCancelationPeriod);
            Wizard = new RelayCommand(OpenWizard);

            FillCityCommand = new RelayCommand(FillCity);
        }

        public string Error => null;
        private Regex _numberOfGuestsRegex = new Regex("^[1-9][0-9]?$");

        private readonly string[] _validatedProperties = { "AccommodationName", "SelectedCountry", "SelectedCity", "TbPictures" };
        public string this[string columnName]
        {
            get
            {
                if (columnName == "AccommodationName")
                {
                    if (AccommodationName == String.Empty)
                    {

                        return "This filed is required!";
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
                else if (columnName == "TbPictures")
                {
                    if (TbPictures == "")
                    {
                        return "This filed is required!";
                    }
                }


                return null;
            }
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(1);
            wizard.Show();
        }

        public void FillCity(object param)
        {
            CityCollection.Clear();

            var locations = LocationService.GetAll().Where(l => l.State.Equals(SelectedCountry));

            foreach (Location c in locations)
            {
                CityCollection.Add(c.City);
            }

            CityComboboxEnabled = true;

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

        }

        public void UpdateCountryCollection(List<string> coutries)
        {
            CountryCollection.Clear();
            foreach (string str in coutries)
            {
                CountryCollection.Add(str);
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void CloseWindow(object param)
        {
            _window.Close();
        }
        public ICommand Create
        {
            get
            {
                if (_create == null)
                {
                    _create = new RelayCommand(
                        param => CreateAccommodation()
                    );
                }
                return _create;
            }
        }
        private bool CanSaveAccommodation()
        {
            return !string.IsNullOrEmpty(AccommodationName) && !string.IsNullOrEmpty(SelectedCountry) &&
             !string.IsNullOrEmpty(SelectedCity) && Capacity > 0 && MinNumberOfDays > 0 && CancelationPeriod >= 0;
        }

        private void CreateAccommodation()
        {
            if (CanSaveAccommodation())
            {
                accommodation.Name = AccommodationName;

                Location location = new Location
                {
                State = SelectedCountry,
                City = SelectedCity
                };

                int LocationID = LocationService.GetIdByCountryAndCity(SelectedCountry, SelectedCity);
                accommodation.Location.Id = LocationID;
                accommodation.Location = LocationService.GetById(LocationID);

                accommodation.Type = Type;
                accommodation.Capacity = Capacity;
                accommodation.MinNumberOfDays = MinNumberOfDays;
                accommodation.CancelationPeriod = CancelationPeriod;

                if (accommodation.Name.Equals(""))
                {
                    System.Windows.MessageBox.Show("'NAME' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.Location.City == null)
                {
                    System.Windows.MessageBox.Show("'CITY' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.Location.State == null)
                {
                    System.Windows.MessageBox.Show("'COUNTRY' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.Type.Equals(""))
                {
                    System.Windows.MessageBox.Show("'TYPE' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.Capacity == 0)
                {
                    System.Windows.MessageBox.Show("'CAPACITY' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.Capacity < 0)
                {
                    System.Windows.MessageBox.Show("'CAPACITY' should be greater than 0", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.MinNumberOfDays == 0)
                {
                    System.Windows.MessageBox.Show("'MIN NUMBER OF DAYS' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.MinNumberOfDays < 0)
                {
                    System.Windows.MessageBox.Show("'MIN NUMBER OF DAYS' should be greater than 0", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.CancelationPeriod < 0)
                {
                    System.Windows.MessageBox.Show("'CANCELATION PERIOD' should be greater or equal than 0", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                if (accommodation.Images.Count == 0)
                {
                    System.Windows.MessageBox.Show("'PICTURES URL' not entered", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                    
                    return;
                }
                AccommodationService.AddAccommodation(accommodation);
                System.Windows.MessageBox.Show("Accommodation successfully created", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);                
                _window.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Please fill in all required fields.", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                
            }
        }

        private void ButtonAddPicture(object param)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentDirectory, "../../Resources/Images/AccommodationPhotos"));

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
                AccommodationImage Pictures = new AccommodationImage();
                Pictures.Url = TbPictures;
                accommodation.Images.Add(Pictures);
                NextPreviousPhotoButtonsVisibility();
            }
            else
            {
                System.Windows.MessageBox.Show("Photo url can not be empty", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                
            }
        }
        private void ButtonRemovePicture(object param)
        {
            AccommodationImage Images = new AccommodationImage();
            Images.Url = TbPictures;
            ImageSlideshowSource = null;
            imagePaths.Remove(Images.Url);

            int indexToRemove = -1;
            for (int i = 0; i < accommodation.Images.Count; i++)
            {
                if (accommodation.Images[i].Url == Images.Url)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                accommodation.Images.RemoveAt(indexToRemove);

                if (accommodation.Images.Count == 0)
                {
                    currentImageIndex = -1;
                    TbPictures = "";
                    ImageSlideshowSource = null;
                }
                else
                {
                    currentImageIndex = (currentImageIndex - 1 + accommodation.Images.Count) % accommodation.Images.Count;

                    ImageSlideshowSource = new BitmapImage(new Uri(accommodation.Images[currentImageIndex].Url));
                    TbPictures = accommodation.Images[currentImageIndex].Url;
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
                TbPictures = imagePath;
            }
        }
        private void ButtonIncreaseMaxGuests(object param)
        {
            int currentValue;
            if (int.TryParse(Capacity.ToString(), out currentValue))
            {
                Capacity = (currentValue + 1);
            }
        }

        private void ButtonDecreaseMaxGuests(object param)
        {
            int currentValue;
            if (int.TryParse(Capacity.ToString(), out currentValue) && currentValue > 0)
            {
                Capacity = (currentValue - 1);
            }
        }
        private void ButtonIncreaseMinDays(object param)
        {
            int currentValue;
            if (int.TryParse(MinNumberOfDays.ToString(), out currentValue))
            {
                MinNumberOfDays = (currentValue + 1);
            }
        }

        private void ButtonDecreaseMinDays(object param)
        {
            int currentValue;
            if (int.TryParse(MinNumberOfDays.ToString(), out currentValue) && currentValue > 0)
            {
                MinNumberOfDays = (currentValue - 1);
            }
        }
        private void ButtonIncreaseCancelationPeriod(object param)
        {
            int currentValue;
            if (int.TryParse(CancelationPeriod.ToString(), out currentValue))
            {
                CancelationPeriod = (currentValue + 1);
            }
        }

        private void ButtonDecreaseCancelationPeriod(object param)
        {
            int currentValue;
            if (int.TryParse(CancelationPeriod.ToString(), out currentValue) && currentValue > 0)
            {
                CancelationPeriod = (currentValue - 1);
            }
        }
    }
}
