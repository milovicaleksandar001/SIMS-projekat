using Booking.Commands;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class ShowTourDestinationsViewModel
	{
		private readonly Window _window;

		public ObservableCollection<TourKeyPoint> Destinations { get; set; }
		public Tour Tour { get; set; }
		public string Location { get; set; }
		public RelayCommand Button_Click_Close { get; set; }

		public ShowTourDestinationsViewModel(Window window, Tour tour)
		{
			_window = window;
			Tour = tour;
			Location = tour.Location.State + ", " + tour.Location.City;
			Destinations = new ObservableCollection<TourKeyPoint>(tour.Destinations);
			Button_Click_Close = new RelayCommand(ButtonClose);
		}

		private void ButtonClose(object param)
		{
			_window.Close();
		}
	}
}
