using Booking.WPF.ViewModels.Guest2;
using System.Collections.Generic;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
    public partial class RateTourImagesView : Window
    {
        public RateTourImagesView(List<string> imgs)
        {
            InitializeComponent();
            DataContext = new RateTourImagesViewModel(this, imgs);
        }
    }
}
