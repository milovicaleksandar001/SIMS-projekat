using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class TourNotificationViewModel
	{
		private readonly Window _window;
		private readonly ITourNotificationService _notificationService;

		public ObservableCollection<TourNotification> Notifications { get; set; }

		public TourNotification SelectedNotification { get; set; }

		public RelayCommand Button_Click_Close { get; set; }
		public RelayCommand Button_Click_ShowTour { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public TourNotificationViewModel(Window window)
		{
			_window = window;
			_notificationService = InjectorService.CreateInstance<ITourNotificationService>();

			Notifications = new ObservableCollection<TourNotification>(_notificationService.GetByUserId(TourService.SignedGuideId));

			InitializeCommands();
		}

		private void InitializeCommands()
		{
			Button_Click_Close = new RelayCommand(ButtonClose);
			Button_Click_ShowTour = new RelayCommand(ButtonShowTour);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/Notifications.mp4");
            view.ShowDialog();
        }

        private void ButtonClose(object param)
		{
			_window.Close();
		}

		private void ShowTour()
		{
            string message = "Name: " + SelectedNotification.Tour.Name + "\n"
                + "Location: " + SelectedNotification.Tour.Location.State + ", " + SelectedNotification.Tour.Location.City + "\n"
                + "Language: " + SelectedNotification.Tour.Language + "\n"
                + "Departure: " + SelectedNotification.Tour.StartTime.ToString("dd.MM.yyyy") + "\n"
                + "Duration: " + SelectedNotification.Tour.Duration + "\n"
                + "Description: " + SelectedNotification.Tour.Description;
            MessageBox.Show(message);
        }

		private void ButtonShowTour(object param)
		{
			if(SelectedNotification == null)
			{
				MessageBox.Show("Select a notification");
			}
			else
			{
                ShowTour();
            }
		}
	}
}
