using Booking.WPF.ViewModels.Guide;
using System.Windows;

namespace Booking.View
{
    public partial class GuideStatisticAboutTours : Window
    {
        public GuideStatisticAboutTours()
        {      
            InitializeComponent();
            this.DataContext = new GuideStatisticAboutToursViewModel(this);
            mostVisitedDataGrid.Items.Clear();
        }
    }
}