using Booking.WPF.ViewModels.Guide;
using System.Windows;

namespace Booking.View
{
    public partial class GuideFollowTourLive : Window
    {
        public GuideFollowTourLive()
        {
            InitializeComponent();
            this.DataContext = new GuideFollowTourLiveViewModel(this);
        }
    }
}
