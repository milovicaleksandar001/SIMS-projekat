using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using Booking.View;
using Booking.WPF.Views.Guest1;
using Notifications.Wpf;
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
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class HomePageFirstGuestViewModel: INotifyPropertyChanged , IDataErrorInfo
    {
        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public Accommodation SelectedAccommodation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> accommodationTypes;
        public IAccommodationService AccommodationService { get; set; }
        public ILocationService LocationService { get; set; }
        public ISuperGuestService SuperGuestService { get; set; }

        public Boolean IsCheckedApartment { get; set; } = false;
        public Boolean IsCheckedCottage { get; set; } = false;
        public Boolean IsCheckedHouse { get; set; } = false;
        public string SearchName { get; set; } = string.Empty;
        public string SearchState { get; set; } = string.Empty;
        public string SearchCity { get; set; } = string.Empty;
        public string SerachGuests { get; set; } = string.Empty;
        public string SearchReservationDays { get; set; } = string.Empty;


        public ObservableCollection<string> CityCollection { get; set; }
        public ObservableCollection<string> CountrycomboBox { get; set; }
       
        
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

        public RelayCommand FillCityCommand { get; set; }

        public void FillCity(object param)
        {
            CityCollection.Clear();

            var locations = LocationService.GetAll().Where(l => l.State.Equals(SearchState));

            foreach (Location c in locations)
            {
                CityCollection.Add(c.City);
            }

            CityComboboxEnabled = true;

            if (SearchState.Equals("All"))
            {
                CityComboboxEnabled = false;
            }
        }

        public RelayCommand Button_Click_Book { get; set; }
        public RelayCommand Button_Click_ShowAll { get; set; }
        public RelayCommand Button_Click_ShowImages { get; set; }
        public RelayCommand Button_Click_Search { get; set; }

        public NavigationService NavigationService { get; set; }

        public string Error => null;

        private Regex _searchReservationDaysRegex = new Regex("[1-9]{1,2}");
        private Regex _searchGuestRegex = new Regex("^[1-9][0-9]?$");

        public string this[string columnName]
        {
            get
            {
                if (columnName == "SerachGuests")
                {
                    if(SerachGuests != String.Empty)
                    {
                        Match match = _searchGuestRegex.Match(SerachGuests);
                        if (!match.Success)
                            return "Number of guests is not in correct format!";
                    }
                }

                if(columnName == "SearchReservationDays")
                {
                    if(SearchReservationDays != String.Empty)
                    {
                        Match match = _searchReservationDaysRegex.Match(SearchReservationDays);
                        if (!match.Success)
                            return "Staying days is not in correct format!";
                    }
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "SerachGuests" , "SearchReservationDays" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        public HomePageFirstGuestViewModel(NavigationService navigationService)
        {

            LocationService = InjectorService.CreateInstance<ILocationService>();
            AccommodationService = InjectorService.CreateInstance<IAccommodationService>();
            SuperGuestService = InjectorService.CreateInstance<ISuperGuestService>();

            Accommodations = new ObservableCollection<Accommodation>(AccommodationService.GetAllSuper().OrderByDescending(a => a.Owner.Super));

            CityCollection = new ObservableCollection<string>();
            CountrycomboBox = new ObservableCollection<string>();
            NavigationService = navigationService;

            accommodationTypes = new List<string>();
            SetCommands();
            FillComboBox();
            SuperGuestService.CheckSuperGuest();
        }


        public void SetCommands()
        {
            Button_Click_Book = new RelayCommand(ButtonBook);
            Button_Click_ShowAll = new RelayCommand(ButtonShowAll);
            Button_Click_ShowImages = new RelayCommand(ButtonShowImages);
            Button_Click_Search = new RelayCommand(ButtonSearch);
            FillCityCommand = new RelayCommand(FillCity);
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

            UpdateCountryComboBox(distinctItems);

            if (SearchState == String.Empty)
            {
                CityComboboxEnabled = false;
            }
        }

        public void UpdateCountryComboBox(List<string> coutries)
        {
            CountrycomboBox.Clear();
            foreach(string str in coutries)
            {
                CountrycomboBox.Add(str);
            }
        }

        private void ButtonSearch(object sender)
        {
            accommodationTypes.Clear();

            if (IsCheckedApartment)
            {
                accommodationTypes.Add("APARTMENT");
            }
            if (IsCheckedCottage)
            {
                accommodationTypes.Add("COTTAGE");
            }
            if (IsCheckedHouse)
            {
                accommodationTypes.Add("HOUSE");
            }

            if (IsValid)
            {

                AccommodationService.Search(Accommodations, SearchName, SearchCity, SearchState, accommodationTypes, SerachGuests, SearchReservationDays);
            }
            else
            {
                var notificationManager = new NotificationManager();
                NotificationContent content = new NotificationContent { Title = "Unable to search!", Message = "Your filed are not in correct frmat!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }

        }

        private void ButtonShowAll(object param)
        {

            AccommodationService.ShowAll(Accommodations);

        }

        private void ButtonBook(object param)
        {
            var notificationManager = new NotificationManager();

            if (SelectedAccommodation == null)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Please select an accommodation to reserve.", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else
            {
                NavigationService.Navigate(new BookAccommodation(SelectedAccommodation, NavigationService));
            }
        }

        private void ButtonShowImages(object sender)
        {
            if(SelectedAccommodation != null)
            {
                NavigationService.Navigate(new ShowAccommodationImages(SelectedAccommodation));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
