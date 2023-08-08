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

namespace Booking.WPF.ViewModels.Guide
{
    /// <summary>
    /// Interaction logic for SelectDateForComplexTour.xaml
    /// </summary>
    public partial class SelectDateForComplexTour : Window
    {
        public SelectDateForComplexTour()
        {
            InitializeComponent();
            this.DataContext = new SelectDateForComplexTourViewModel(this);
        }
    }
}
