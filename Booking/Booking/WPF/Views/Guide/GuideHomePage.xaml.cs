using System.Windows;
using Booking.WPF.ViewModels.Guide;

namespace Booking.View
{
    public partial class GuideHomePage : Window
    {
        public GuideHomePage()
        {
            InitializeComponent();
            this.DataContext = new GuideHomePageViewModel(this);
        }

    }
}
