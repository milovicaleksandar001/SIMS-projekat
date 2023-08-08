using Booking.WPF.ViewModels.Guide;
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

namespace Booking.WPF.Views.Guide
{
    public partial class GuideRequestsStatistic : Window
    {
        public GuideRequestsStatistic()
        {
            InitializeComponent();
            this.DataContext = new GuideRequestsStatisticViewModel(this);
            GenerallyDataGrid.Items.Clear();
            YearlyDataGrid.Items.Clear();
        }
    }
}
