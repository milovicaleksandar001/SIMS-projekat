using Booking.Application.UseCases;
using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest1
{
    public class FirstGuestProfileViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ISuperGuestService SuperGuestService { get; set; }
        public IUserService UserService { get; set; }

        public string _numberOfReservations;
        public string NumberOfReservations
        {
            get => _numberOfReservations;
            set
            {
                if (_numberOfReservations != value)
                {
                    _numberOfReservations = value;
                    OnPropertyChanged();
                }

            }   
        }

        public string _typeOfGuest;
        public string TypeOfGuest
        {
            get => _typeOfGuest;
            set
            {
                if (_typeOfGuest != value)
                {
                    _typeOfGuest = value;
                    OnPropertyChanged();
                }

            }
        }

        public string _bonusPoints;
        public string BonusPoints
        {
            get => _bonusPoints;
            set
            {
                if (_bonusPoints != value)
                {
                    _bonusPoints = value;
                    OnPropertyChanged();
                }

            }
        }

        public Visibility _starImageVisibility;
        public Visibility StarImageVisibility
        {
            get => _starImageVisibility;
            set
            {
                if (_starImageVisibility != value)
                {
                    _starImageVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        public FirstGuestProfileViewModel()
        {
            SuperGuestService = InjectorService.CreateInstance<ISuperGuestService>();
            UserService = InjectorService.CreateInstance<IUserService>();
            User SignedGuest = UserService.GetById(AccommodationReservationService.SignedFirstGuestId);

            if(SignedGuest.Super == 1)
            {
                SetSuperGuest(SignedGuest);
            }
            else
            {
                SetOrdinaryGuest();
            }
            NumberOfReservations = SuperGuestService.CalculateReservationsForLastYear(SignedGuest).ToString();     
        }

        public void SetSuperGuest(User SignedGuest)
        {
            TypeOfGuest = "SUPER";
            StarImageVisibility = Visibility.Visible;
            SuperGuest superGuest = SuperGuestService.GetSuperBySignedGuestId(SignedGuest.Id);
            BonusPoints = superGuest.BonusPoints.ToString();
        }

        public void SetOrdinaryGuest()
        {
            TypeOfGuest = "ORDINARY";
            StarImageVisibility = Visibility.Hidden;
            BonusPoints = "0";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
