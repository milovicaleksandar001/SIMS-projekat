using Booking.Domain.DTO;
using Booking.Model;
using Booking.WPF.ViewModels.Owner;
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
using System.Windows.Shapes;

namespace Booking.WPF.Views.Owner
{
    /// <summary>
    /// Interaction logic for AccommodationStatisticsByMonths.xaml
    /// </summary>
    public partial class AccommodationStatisticsByMonths : Window
    {
        public AccommodationStatisticsByMonths(Accommodation SelectedAccommodation,OwnerYearStatistic SelectedYearStatistics)
        {
            InitializeComponent();
            this.DataContext = new AccommodationStatisticsByMonthsViewModel(SelectedAccommodation, SelectedYearStatistics, this);
        }
    }
}
