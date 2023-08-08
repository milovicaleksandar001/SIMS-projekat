using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guide;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideAcceptingTourRequestViewModel : IObserver, INotifyPropertyChanged
    {

        public RelayCommand Close { get; set; }
        public RelayCommand Filter { get; set; }
        public RelayCommand ResetFilter { get; set; }
        public RelayCommand Accept { get; set; }
        
        public ICommand FillCityCommand { get; set; }

        public ITourService tourService { get; set; }
        public ITourRequestService tourRequestService { get; set; }
        public ILocationService locationService { get; set; }
        public string _selectedCountry;
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    OnPropertyChanged(nameof(SelectedCountry));
                }
            }
        }


        public string _selectedCity;
        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                if (_selectedCity!= value)
                {
                    _selectedCity= value;
                    OnPropertyChanged(nameof(SelectedCity));
                }
            }
        }

        public string _selectedNumberOfGuests;
        public string SelectedNumberOfGuests
        {
            get => _selectedNumberOfGuests;
            set
            {
                if (_selectedNumberOfGuests!= value)
                {
                    _selectedNumberOfGuests= value;
                    OnPropertyChanged(nameof(SelectedNumberOfGuests));
                }
            }
        }

        public string _selectedLanguage;
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage!= value)
                {
                    _selectedLanguage= value;
                    OnPropertyChanged(nameof(SelectedLanguage));
                }
            }
        }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set { _endDate = value; OnPropertyChanged(nameof(EndDate)); }
        }


        private TourRequest _selectedTourRequest;
        public TourRequest SelectedTourRequest
        {
            get { return _selectedTourRequest; }
            set
            {
                _selectedTourRequest = value;
                OnPropertyChanged("SelectedTourRequest");
            }
        }
        public ObservableCollection<TourRequest> TourRequests { get; set; }
        public ObservableCollection<string> CityCollection { get; set; }
        public ObservableCollection<string> CountryCollection { get; set; }

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


        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Window _window;
        public GuideAcceptingTourRequestViewModel(Window window)
        {
            _window = window;

            tourService = InjectorService.CreateInstance<ITourService>();
            tourRequestService = InjectorService.CreateInstance<ITourRequestService>();
            locationService = InjectorService.CreateInstance<ILocationService>();

            TourRequests = new ObservableCollection<TourRequest>(tourRequestService.GetAllOnHold());

            CityCollection = new ObservableCollection<string>();
            CountryCollection = new ObservableCollection<string>();


            FillComboBox();
            SetCommands();
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
            List<string> items = new List<string>() { "All" };

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

            if (SelectedCountry == null )
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


        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            Filter = new RelayCommand(ButtonFilter);
            ResetFilter = new RelayCommand(ButtonResetFilter);
            Accept = new RelayCommand(ButtonAccept);

            FillCityCommand = new RelayCommand(FillCity);
        }
            private void ButtonClose(object param)
        {
            CloseWindow();
        }

        private void ButtonFilter(object param)
        {
            TourRequests.Clear();

            tourRequestService.Search(TourRequests, SelectedCity, SelectedCountry, SelectedNumberOfGuests, SelectedLanguage, StartDate, EndDate);

        }
        private void ButtonResetFilter(object param)
        {
            TourRequests.Clear();
            tourRequestService.ShowAll(TourRequests);
            SelectedCity = null;
            SelectedCountry = null;
            SelectedLanguage = null;
            SelectedNumberOfGuests = null;
            StartDate = null;
            EndDate = null;
        }



        public bool IsGuideAvailable(int guideId)
        {
            List<Tour> tours = tourService.GetGuideTours();

            foreach (Tour tour in tours)
            {
                DateTime tourEndTime = tour.StartTime + TimeSpan.FromDays(tour.Duration * 24);
                bool isOverlapping = SelectedTourRequest.StartTime < tourEndTime && SelectedTourRequest.EndTime > tour.StartTime;

                if (isOverlapping)
                {
                    return false; 
                }
            }

            return true;
        }
        private void ButtonAccept(object param)
        {
            if (SelectedTourRequest != null)
            {
                if (IsGuideAvailable(TourService.SignedGuideId))
                {
                    GuideCreateTourBasedOnTourRequestViewModel2.SelectedTourRequest = SelectedTourRequest;
                    GuideCreateTourBasedOnTourRequest2 guideCreateTourBasedOnTourRequest2 = new GuideCreateTourBasedOnTourRequest2();
                    guideCreateTourBasedOnTourRequest2.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("You already have a tour planned in that time period!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("First you need to select tour request!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        private void CloseWindow()
        {
            _window.Close();
        }
        public void Update()
        {
            TourRequests.Clear();
            foreach(TourRequest request in tourRequestService.GetAllOnHoldPartOfComplex()) 
            {
            TourRequests.Add(request);
            }

        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
