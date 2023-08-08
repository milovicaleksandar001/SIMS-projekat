using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.View
{
    public partial class SecondGuestHomePage : Window
    {
        public SecondGuestHomePage()
        {
            InitializeComponent();
            DataContext = new SecondGuestHomePageViewModel(this);
        }
    }
}
