using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class CreateTourRequestView : Window
	{
		public CreateTourRequestView()
		{
			InitializeComponent();
			this.DataContext = new CreateTourRequestViewModel(this);
		}
	}
}
