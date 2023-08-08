using Booking.WPF.ViewModels.Guide;
using System.Windows;

namespace Booking.WPF.Views.Guide
{
    public partial class ShowDescription : Window
    {
        public ShowDescription(int idTour)
        {
            InitializeComponent();
            this.DataContext = new ShowDescriptionViewModel(idTour);         
        }
    }
}
