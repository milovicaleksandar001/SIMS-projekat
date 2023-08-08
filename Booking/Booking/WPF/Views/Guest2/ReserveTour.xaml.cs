using Booking.Model;
using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.View
{
    public partial class ReserveTour : Window
    {
        public ReserveTour(Tour tour, SecondGuestHomePageViewModel model)
        {
            InitializeComponent();
            DataContext = new ReserveTourViewModel(this, tour, model);
        }
    }
}
