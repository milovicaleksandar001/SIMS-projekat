using Booking.Model;
using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.View
{
	public partial class ShowTourImages : Window
	{
		public ShowTourImages(Tour tour)
		{
			InitializeComponent();
			DataContext = new ShowTourImagesViewModel(this, tour);
		}
	}
}
