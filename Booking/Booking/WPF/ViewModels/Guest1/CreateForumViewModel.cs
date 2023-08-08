using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class CreateForumViewModel: INotifyPropertyChanged
    {

        public IForumService ForumService { get; set; }
        public ILocationService LocationService { get; set; }
        public IAccommodationReservationService _AccommodationReservationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand Open_Forum_Button { get; set; }

        private NavigationService navigationService;

        public ObservableCollection<string> CityCollection { get; set; }
        public ObservableCollection<string> CountrycomboBox { get; set; }

        public string SearchState { get; set; } = string.Empty;
        public string SearchCity { get; set; } = string.Empty;

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


        public string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged();
                }
            }
        }

        public CreateForumViewModel(NavigationService navigation)
        {
            navigationService =  navigation;
            ForumService = InjectorService.CreateInstance<IForumService>();
            LocationService = InjectorService.CreateInstance<ILocationService>();
            _AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            CityCollection = new ObservableCollection<string>();
            CountrycomboBox = new ObservableCollection<string>();
            FillCityCommand = new RelayCommand(FillCity);
            Open_Forum_Button = new RelayCommand(OpenForumButton);
            FillComboBox();
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
            foreach (string str in coutries)
            {
                CountrycomboBox.Add(str);
            }
        }

        private Forum AddForum()
        {
            Forum newForum = new Forum();
            newForum.Location.State = SearchState;
            newForum.Location.City = SearchCity;
            newForum.Location.Id = LocationService.GetIdByCountryAndCity(SearchState, SearchCity);
            newForum.User.Id = AccommodationReservationService.SignedFirstGuestId;
            ForumComment newComment = new ForumComment();
            newComment.Comment = Comment;
            newComment.Visited = _AccommodationReservationService.IsLocationVisited(newForum.Location);
            newForum.Comments.Add(newComment);
            newForum.Status = "OPENED";
            newForum.Helpful = "NO";
            ForumService.Create(newForum);
            return newForum;
        }

        public void OpenForumButton(object sender)
        {
            AddForum();
            navigationService.Navigate(new ShowAllForums(this.navigationService));
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
