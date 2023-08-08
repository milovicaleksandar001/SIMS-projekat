using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class CreateTourComplexRequestView : Window
	{
		public CreateTourComplexRequestView()
		{
			InitializeComponent();
			DataContext = new CreateTourComplexRequestViewModel(this);
		}
	}
}
