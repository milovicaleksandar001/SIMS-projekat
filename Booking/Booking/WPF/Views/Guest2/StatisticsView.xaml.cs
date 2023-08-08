using Booking.WPF.ViewModels.Guest2;
using System.Windows;

namespace Booking.WPF.Views.Guest2
{
	public partial class StatisticsView : Window
	{
		public StatisticsView()
		{
			InitializeComponent();
			this.DataContext = new StatisticsViewModel(this);
		}
	}
}
