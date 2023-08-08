using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class RateTour : Window
	{
		public RateTour(Tour tour)
		{
			InitializeComponent();
			DataContext = new RateTourViewModel(this, tour);
		}
	}
}