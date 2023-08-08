using Booking.WPF.ViewModels.Guide;
using System.Windows;

namespace Booking.View
{
    public partial class GuideKeyPointsCheck : Window
    {     
        public GuideKeyPointsCheck(int idTour)
        {
            InitializeComponent();
            this.DataContext = new GuideKeyPointsCheckViewModel(idTour,this);        
        }
    }
}
