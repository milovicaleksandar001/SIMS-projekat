using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest1;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace Booking.WPF.ViewModels.Guest1
{
    public class RenovationSuggestionsViewModel: IDataErrorInfo, INotifyPropertyChanged
    {
        public string RenovationArea { get; set; }
        public AccommodationReservation AccommodationReservation { get; set; }
        public NavigationService NavigationService { get; set; }
        public IRenovationRecommodationService renovationRecommodationService { get; set; }

        public bool FirstSelectedUrgencyLevel { get; set; }
        public bool SecondSelectedUrgencyLevel { get;  set; }
        public bool ThirdSelectedUrgencyLevel { get; set; }
        public bool FourthSelectedUrgencyLevel { get; set; }
        public bool FifthSelectedUrgencyLevel { get; set; }
        public RelayCommand ButtonClickSubmmit { get; set; }

        public RenovationRecommodation renovationRecommodation;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Error => null;

        public string this[string columnName]
        {
            get 
            {
                if (columnName.Equals("RenovationArea"))
                {
                    if (RenovationArea == String.Empty)
                    {
                        return "This filed is required!";
                    }
                }
                return null;
            }
        }

        private readonly string[] _validatedProperties = { "RenovationArea"};

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
        public RenovationSuggestionsViewModel(AccommodationReservation selectedReservation, NavigationService navigationService)
        {
            renovationRecommodationService = InjectorService.CreateInstance<IRenovationRecommodationService>();
            AccommodationReservation = selectedReservation;
            NavigationService = navigationService;
            renovationRecommodation = new RenovationRecommodation();
            ButtonClickSubmmit = new RelayCommand(ButtonSubmmit);
            RenovationArea = String.Empty;
        }

        public void MakeSuggestion()
        {
            renovationRecommodation.AccommodationReservation = AccommodationReservation;
            renovationRecommodation.Area = RenovationArea;
            if (FirstSelectedUrgencyLevel)
            {
                renovationRecommodation.UrgencyLevel = 1;
            }
            else if (SecondSelectedUrgencyLevel)
            {
                renovationRecommodation.UrgencyLevel = 2;
            }
            else if (ThirdSelectedUrgencyLevel)
            {
                renovationRecommodation.UrgencyLevel = 3;

            }else if (FourthSelectedUrgencyLevel)
            {
                renovationRecommodation.UrgencyLevel = 4;
            }else
            {
                renovationRecommodation.UrgencyLevel = 5;
            }
        }
        public void ButtonSubmmit(object param)
        {
            var notificationManager = new NotificationManager();
            if (IsValid == false)
            {
                NotificationContent errorContent = new NotificationContent { Title = "Warning!", Message = "Please fill in all fields before submitting.", Type = NotificationType.Warning };
                notificationManager.Show(errorContent, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
                return;
            }

            MakeSuggestion();
            renovationRecommodationService.SaveReccommodation(renovationRecommodation); 

            NotificationContent content = new NotificationContent { Title = "Thank you!", Message = "You successfully gave us a recommendation for improving our accommodation!", Type = NotificationType.Success };
            notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            NavigationService.Navigate(new FirstGuestReviews());
        }
    }
}
