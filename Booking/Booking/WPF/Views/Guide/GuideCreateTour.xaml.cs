using System.Windows;
using Booking.WPF.ViewModels.Guide;

namespace Booking.View
{
    public partial class GuideCreateTour : Window 
    {
        public GuideCreateTour()
        {
            InitializeComponent();
            this.DataContext = new GuideCreateTourViewModel(this);
        }
    }
}
