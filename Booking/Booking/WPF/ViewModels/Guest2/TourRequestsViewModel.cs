using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest2;
using System.Collections.ObjectModel;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class TourRequestsViewModel
	{
		private readonly Window _window;
		private ITourRequestService _tourRequestService;

		public ObservableCollection<TourRequest> TourRequests { get; set; }

		public RelayCommand Button_Click_Close { get; set; }
		public RelayCommand Button_Click_Request { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public TourRequestsViewModel(Window window)
		{
			_window = window;
			_tourRequestService = InjectorService.CreateInstance<ITourRequestService>();

			TourRequests = new ObservableCollection<TourRequest>();

			LoadList();
			InitializeCommands();
		}

		private void InitializeCommands()
		{
			Button_Click_Close = new RelayCommand(ButtonClose);
			Button_Click_Request = new RelayCommand(ButtonRequest);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

		private void LoadList()
		{
			TourRequests.Clear();
			var list = _tourRequestService.GetRequestsByUserId(TourService.SignedGuideId);
			foreach (var request in list)
			{
				TourRequests.Add(request);
			}
		}

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/SimpleRequest.mp4");
            view.ShowDialog();
        }

        private void ButtonClose(object param)
		{
			_window.Close();
		}

		private void ButtonRequest(object param)
		{
			CreateTourRequestView view = new CreateTourRequestView();
			view.ShowDialog();
			LoadList();
		}
	}
}
