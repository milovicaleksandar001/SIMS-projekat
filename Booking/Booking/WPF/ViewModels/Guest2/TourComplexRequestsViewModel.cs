using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest2;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class TourComplexRequestsViewModel : INotifyPropertyChanged
	{
		private readonly Window _window;
		private ITourComplexRequestService _tourRequestService;
		private ITourRequestService _tourRequestService2;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<TourComplexRequest> TourComplexRequests { get; set; }
		public ObservableCollection<TourRequest> TourRequests { get; set; }

		public ObservableCollection<int> TourComplexRequestsIds { get; set; }
		public int SelectedRequestId { get; set; }

		private int _selectedIndex;
		public int SelectedIndex
		{
			get => _selectedIndex;
			set
			{
				if (_selectedIndex != value)
				{
					_selectedIndex = value;
					OnPropertyChanged();
				}
			}
		}

		public RelayCommand Button_Click_Close { get; set; }
		public RelayCommand Button_Click_Request { get; set; }
		public RelayCommand Selection_Changed { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public TourComplexRequestsViewModel(Window window)
		{
			_window = window;
			_tourRequestService = InjectorService.CreateInstance<ITourComplexRequestService>();
			_tourRequestService2 = InjectorService.CreateInstance<ITourRequestService>();

			TourComplexRequests = new ObservableCollection<TourComplexRequest>();
			TourRequests = new ObservableCollection<TourRequest>();
			TourComplexRequestsIds = new ObservableCollection<int>();

			LoadList();
			InitializeCommands();
		}

		private void InitializeCommands()
		{
			Button_Click_Close = new RelayCommand(ButtonClose);
			Button_Click_Request = new RelayCommand(ButtonRequest);
			Selection_Changed = new RelayCommand(LoadRequests_Command);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/ComplexRequest.mp4");
            view.ShowDialog();
        }

        private void LoadList()
		{
			TourComplexRequests.Clear();
			var list = _tourRequestService.GetRequestsByUserId(TourService.SignedGuideId);
			foreach (var request in list)
			{
				TourComplexRequests.Add(request);
			}
			LoadIds();
		}

		private void LoadIds()
		{
			TourComplexRequestsIds.Clear();
			foreach (var request in TourComplexRequests)
			{
				TourComplexRequestsIds.Add(request.Id);
			}
			SelectedIndex = 0;
			LoadRequests();
		}

		private void LoadRequests_Command(object param)
		{
			LoadRequests();
		}

		private void LoadRequests()
		{
			TourRequests.Clear();
			foreach (var request in _tourRequestService2.GetByComplexRequestId(SelectedRequestId))
			{
				TourRequests.Add(request);
			}
		}

		private void ButtonClose(object param)
		{
			_window.Close();
		}

		private void ButtonRequest(object param)
		{
			CreateTourComplexRequestView view = new CreateTourComplexRequestView();
			view.ShowDialog();
			LoadList();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
