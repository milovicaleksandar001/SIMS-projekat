using Booking.Domain.Model.Images;
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

namespace Booking.View
{
    /// <summary>
    /// Interaction logic for ShowGradeImages.xaml
    /// </summary>
    public partial class ShowGradeImages : Window
    {
        public ShowGradeImages(AccommodationAndOwnerGrade SelectedGrade)
        {
            InitializeComponent();
            this.DataContext = new ShowGradeImagesViewModel(SelectedGrade, this);
        }
    }
}
