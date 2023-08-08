using Booking.Domain.Model.Images;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Model.Images;
using Booking.Repository;
using Booking.Service;
using Booking.Util;
using Booking.WPF.ViewModels.Guest1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Booking.View
{
    public partial class RateAccommodationAndOwner : Page
    {
      
        public RateAccommodationAndOwner(AccommodationReservation accommodationReservation, NavigationService navigationService)
        {
            InitializeComponent();
            this.DataContext = new RateAccommodationAndOwnerViewModel(accommodationReservation, navigationService);
        }
    }
}
