using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class TourRequestsView : Window
	{
		public TourRequestsView()
		{
			InitializeComponent();
			DataContext = new TourRequestsViewModel(this);
		}
	}
}
