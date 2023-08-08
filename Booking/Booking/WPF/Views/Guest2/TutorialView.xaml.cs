using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
    public partial class TutorialView : Window
    {
        public TutorialView(string url)
        {
            InitializeComponent();
            DataContext = new TutorialViewModel(this, url);
        }
    }
}
