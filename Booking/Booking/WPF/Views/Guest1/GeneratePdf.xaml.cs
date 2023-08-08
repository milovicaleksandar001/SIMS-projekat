using Booking.Model;
using Booking.WPF.ViewModels;
using System;
using System.Collections.Generic;
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

namespace Booking.WPF.Views.Guest1
{
    public partial class GeneratePdf : Page
    {
        public GeneratePdf(Accommodation selectedAccommodation,DateTime ArrivalDay, DateTime DepartureDay, int numberOfGuest, NavigationService navigate)
        {
            InitializeComponent();
            this.DataContext = new GeneratePdfViewModel(selectedAccommodation, ArrivalDay, DepartureDay, numberOfGuest, navigate);
        }
    }
}
