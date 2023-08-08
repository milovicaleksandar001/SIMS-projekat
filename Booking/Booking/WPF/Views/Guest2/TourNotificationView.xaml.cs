using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class TourNotificationView : Window
	{
		public TourNotificationView()
		{
			InitializeComponent();
			this.DataContext = new TourNotificationViewModel(this);
		}
	}
}
