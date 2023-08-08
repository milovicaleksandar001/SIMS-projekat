using Booking.Model;
using Booking.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Booking.WPF.ViewModels.Guest1
{
    public class ReservationDetailsViewModel : INotifyPropertyChanged
    {
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

        public String _accmoodationLabel;
        public String AccommodationLabel
        {
            get => _accmoodationLabel;
            set
            {
                if (_accmoodationLabel != value)
                {
                    _accmoodationLabel = value;
                    OnPropertyChanged();
                }
            }
        }

        public String _arrivalDayLabel;
        public String ArrivalDayLabel
        {
            get => _arrivalDayLabel;
            set
            {
                if (_arrivalDayLabel != value)
                {
                    _arrivalDayLabel = value;
                    OnPropertyChanged();
                }
            }
        }

        public String _departureDay;
        public String DepartureDayLabel
        {
            get => _departureDay;
            set
            {
                if (_departureDay != value)
                {
                    _departureDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public String _guestName;
        public String GuestNameLabel
        {
            get => _guestName;
            set
            {
                if (_guestName != value)
                {
                    _guestName = value;
                    OnPropertyChanged();
                }
            }
        }

        public String _ownerName;
        public String OwnerNameLabel
        {
            get => _ownerName;
            set
            {
                if (_ownerName != value)
                {
                    _ownerName = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ReservationDetailsViewModel(AccommodationReservation selectedReservation)
        {
            AccommodationLabel = selectedReservation.Accommodation.Name + "-" + selectedReservation.Accommodation.Location.State + "-" +
                selectedReservation.Accommodation.Location.City + "-" + selectedReservation.Accommodation.Type;

            CurrentImageUrl = selectedReservation.Accommodation.Images[0].Url;
            ArrivalDayLabel = selectedReservation.ArrivalDay.ToString("dd-MM-yyy");
            DepartureDayLabel = selectedReservation.DepartureDay.ToString("dd-MM-yyy");
            GuestNameLabel = selectedReservation.Guest.Username;
            OwnerNameLabel = selectedReservation.Accommodation.Owner.Username;
        }
    }
}
