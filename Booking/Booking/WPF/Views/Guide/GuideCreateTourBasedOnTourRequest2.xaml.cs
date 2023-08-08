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
    public partial class GuideCreateTourBasedOnTourRequest2 : Window
    {
        public GuideCreateTourBasedOnTourRequest2()
        {
            InitializeComponent();
            this.DataContext = new GuideCreateTourBasedOnTourRequestViewModel2(this);
        }
    }
}
