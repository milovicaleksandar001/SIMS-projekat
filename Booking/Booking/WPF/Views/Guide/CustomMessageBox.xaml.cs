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

    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        private void ButtonMostPopularLocation_Click(object sender, RoutedEventArgs e)
        {

            GuideCreateTourBasedOnTourRequest guideCreateTourBasedOnTourRequest = new GuideCreateTourBasedOnTourRequest();
            guideCreateTourBasedOnTourRequest.Show();
            this.Close();
        }

        private void ButtonMostPopularLanguage_Click(object sender, RoutedEventArgs e)
        {
            GuideCreateTourBasedOnTourRequest1 guideCreateTourBasedOnTourRequest1 = new GuideCreateTourBasedOnTourRequest1();
            guideCreateTourBasedOnTourRequest1.Show();
            this.Close();
        }
    }
}
