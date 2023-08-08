using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using Notifications.Wpf.Controls;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using Booking.WPF.ViewModels.Guest1;

namespace Booking.View
{
    public partial class FirstGuestAllReservations : Page
    {
       
        public FirstGuestAllReservations(NavigationService navigationService)
        {
            InitializeComponent();
            this.DataContext = new FirstGuestAllReservationsViewModel(navigationService);

        }

    
    }
}
