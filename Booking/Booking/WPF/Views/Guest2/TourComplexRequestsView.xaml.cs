using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class TourComplexRequestsView : Window
	{
		public TourComplexRequestsView()
		{
			InitializeComponent();
			DataContext = new TourComplexRequestsViewModel(this);
		}
	}
}
