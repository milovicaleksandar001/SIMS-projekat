using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.View;
using Booking.WPF.Views.Guest2;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class ReserveTourViewModel : INotifyPropertyChanged, IDataErrorInfo
	{
		private readonly Window _window;
		private SecondGuestHomePageViewModel Mrk;
		private ITourReservationService _tourReservationService;
		private IVoucherService _voucherService;

		public event PropertyChangedEventHandler PropertyChanged;

		private int _availability;

		public static readonly DependencyProperty IsCheckBoxCheckedProperty =
			DependencyProperty.Register("IsCheckBoxChecked", typeof(bool),
			typeof(ReserveTour), new UIPropertyMetadata(false));

		public bool IsVoucherChecked
		{
			get { return (bool)_window.GetValue(IsCheckBoxCheckedProperty); }
			set { _window.SetValue(IsCheckBoxCheckedProperty, value); }
		}
		public ObservableCollection<Voucher> Vouchers { get; set; }

		private int _numberOfPassengers;
		public int NumberOfPassengers
		{
			get => _numberOfPassengers;
			set
			{
				if (_numberOfPassengers != value)
				{
					_numberOfPassengers = value;
					OnPropertyChanged();
				}
			}
		}
		public Tour Tour { get; set; }
		public string Location { get; set; }
		public Voucher SelectedVoucher { get; set; }
		public string Label { get; set; }
		public RelayCommand Button_Click_Reserve { get; set; }
		public RelayCommand Button_Click_Close { get; set; }
		public RelayCommand Button_Click_NumericUp { get; set; }
		public RelayCommand Button_Click_NumericDown { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public ReserveTourViewModel(Window window, Tour tour, SecondGuestHomePageViewModel mrk)
		{
			_window = window;
			Tour = tour;
			Location = tour.Location.State + ", " + tour.Location.City;
			Mrk = mrk;
			NumberOfPassengers = 1;

			_tourReservationService = InjectorService.CreateInstance<ITourReservationService>();
			_voucherService = InjectorService.CreateInstance<IVoucherService>();

			Vouchers = new ObservableCollection<Voucher>(_voucherService.GetVouchersByUserId(TourService.SignedGuideId));

			_availability = _tourReservationService.CheckAvailability(Tour.Id);

			Label = "Available space left: " + _availability.ToString();

			InitializeCommands();

		}

		private void InitializeCommands()
		{
			Button_Click_Reserve = new RelayCommand(Reserve);
			Button_Click_Close = new RelayCommand(Cancel);
			Button_Click_NumericUp = new RelayCommand(NumericUp);
			Button_Click_NumericDown = new RelayCommand(NumericDown);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/ReserveATour.mp4");
            view.ShowDialog();
        }

        private void Reserve(object param)
		{
			if (IsValid)
			{
				if (_availability >= NumberOfPassengers)
				{
					if (IsVoucherChecked)
					{
						if (SelectedVoucher == null)
						{
							MessageBox.Show("Voucher is not selected!");
						}
						else
						{
							ReserveATourWithVoucher();
						}
					}
					else
					{
                        MessageBoxResult dialogResult = IsAnswerYes();
						if (dialogResult == MessageBoxResult.Yes)
						{
                            ReserveATour();
                        }
					}
				}
				else if (_availability < NumberOfPassengers && _availability > 0)
				{
					MessageBox.Show("Not enough available space, please choose another option or tour");
				}
				else
				{
					MessageBox.Show("Tour is already full");
					// Function call: calls method from parent window
					Mrk.ReserveTourSearch(Tour.Location.State, Tour.Location.City, Tour.Id);
					CloseWindow();
				}
			}
		}

		private void ReserveATour()
		{
			_tourReservationService.CreateTourReservation(Tour, NumberOfPassengers);
			MessageBox.Show("Tour reserved");
			CloseWindow();
		}
        private MessageBoxResult IsAnswerYes()
        {
            string sMessageBoxText = $"Do you want to reserve a tour?";
            string sCaption = "Tour Reservation";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Question;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }


        private void ReserveATourWithVoucher()
		{
			_voucherService.RedeemVoucher(SelectedVoucher);
			ReserveATour();
		}

		private void Cancel(object sender)
		{
			CloseWindow();
		}

		private void CloseWindow()
		{
			_window.Close();
		}

		private void NumericUp(object param)
		{
			NumberOfPassengers++;
		}

		private void NumericDown(object param)
		{
			if (NumberOfPassengers > 1)
				NumberOfPassengers--;
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public string Error => null;

		private readonly string[] _validatedProperties = { "NumberOfPassengers" };

		private Regex _number = new Regex("[1-9][0-9]*");

		public string this[string columnName]
		{
			get
			{
				if (columnName == "NumberOfPassengers")
				{
					if (NumberOfPassengers < 1)
						return "Wrong number";
					Match match = _number.Match(NumberOfPassengers.ToString());
					if (!match.Success)
						return "Wrong format";
				}

				return null;
			}
		}

		public bool IsValid
		{
			get
			{
				foreach (var property in _validatedProperties)
				{
					if (this[property] != null)
						return false;
				}

				return true;
			}
		}
	}
}
