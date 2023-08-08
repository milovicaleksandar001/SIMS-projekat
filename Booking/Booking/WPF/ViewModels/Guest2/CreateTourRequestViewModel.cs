using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using Booking.WPF.Views.Guest2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class CreateTourRequestViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
		private readonly Window _window;
		private ILocationService _locationService;
		private ITourRequestService _tourRequestService;

		public event PropertyChangedEventHandler PropertyChanged;

		public List<string> States { get; set; }
		public ObservableCollection<string> Cities { get; set; }

		public string SelectedState { get; set; }
		public string SelectedCity { get; set; }
		public string Language { get; set; } = string.Empty;

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

		private bool _isEnabled;
		public bool CityComboBoxIsEnabled
		{
			get => _isEnabled;
			set
			{
				if (_isEnabled != value)
				{
					_isEnabled = value;
					OnPropertyChanged();
				}
			}
		}
		private int _selectedIndex;
		public int CityComboBoxSelectedIndex
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

		private DateTime _startDate;
		public DateTime StartDate
		{
			get => _startDate;
			set
			{
				if (_startDate != value)
				{
					_startDate = value;
					OnPropertyChanged();
				}
			}
		}

		private DateTime _endDate;
		public DateTime EndDate
		{
			get => _endDate;
			set
			{
				if (value != _endDate)
				{
					_endDate = value;
					OnPropertyChanged();
				}
			}
		}
		public DateTime StartTime { get; set; } = DateTime.Now.Date.AddDays(2);
		public string Description { get; set; } = string.Empty;

		public RelayCommand Button_Click_Close { get; set; }
		public RelayCommand Button_Click_Request { get; set; }
		public RelayCommand Selection_Changed { get; set; }
		public RelayCommand Button_Click_NumericUp { get; set; }
		public RelayCommand Button_Click_NumericDown { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public CreateTourRequestViewModel(Window window)
		{
			_window = window;
			NumberOfPassengers = 1;

			_locationService = InjectorService.CreateInstance<ILocationService>();
			_tourRequestService = InjectorService.CreateInstance<ITourRequestService>();

			States = _locationService.GetAllStates();
			Cities = new ObservableCollection<string>();

			SelectedState = "All";
			SelectedCity = "All";

			StartDate = StartTime;
			EndDate = StartTime;

            FillCityComboBox();
			InitializeCommands();
		}

		private void InitializeCommands()
		{
			Button_Click_Close = new RelayCommand(ButtonCancel);
			Button_Click_Request = new RelayCommand(ButtonRequest);
			Selection_Changed = new RelayCommand(ComboBoxStateSelectionChanged);
			Button_Click_NumericUp = new RelayCommand(NumericUp);
			Button_Click_NumericDown = new RelayCommand(NumericDown);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/SimpleRequest.mp4");
            view.ShowDialog();
        }

        private void ComboBoxStateSelectionChanged(object param)
		{
			FillCityComboBox();
		}

		private void FillCityComboBox()
		{
			Cities = _locationService.GetAllCitiesByState(Cities, SelectedState);
			SelectedCity = "All";
			CityComboBoxSelectedIndex = 0;
			if (SelectedState.Equals("All"))
			{
				CityComboBoxIsEnabled = false;
			}
			else
			{
				CityComboBoxIsEnabled = true;
			}
		}

		private void ButtonCancel(object sender)
		{
			CloseWindow();
		}

		private void CloseWindow()
		{
			_window.Close();
		}

		private void ButtonRequest(object param)
		{
			if (IsValid)
			{
				TourRequest tourRequest = new TourRequest();
				Location location = new Location();

				location.Id = _locationService.GetIdByCountryAndCity(SelectedState, SelectedCity);
				location.State = SelectedState;
				location.City = SelectedCity;

				tourRequest.CreatedDate = DateTime.Now;
				tourRequest.Location = location;
				tourRequest.Language = Language;
				tourRequest.GuestsNumber = NumberOfPassengers;
				tourRequest.StartTime = StartDate;
				tourRequest.EndTime = EndDate;
				tourRequest.Description = Description;
				tourRequest.TourReservedStartTime = DateTime.Today;

				_tourRequestService.AddTourRequest(tourRequest);
				CloseWindow();
			}
			else
			{
				MessageBox.Show("All fields must be filled!");
			}
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

        private readonly string[] _validatedProperties = { "NumberOfPassengers", "SelectedState", "SelectedCity", "Language", "StartDate", "EndDate" };

        private Regex _number = new Regex("[1-9][0-9]*");
        private Regex _word = new Regex("^[A-Za-z]*$");

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
				else if(columnName == "SelectedState")
				{
					if(SelectedState.Equals("All"))
					{
						return "Not selected field";
					}
				}
				else if(columnName == "SelectedCity")
				{
					if(string.IsNullOrEmpty(SelectedCity) || SelectedCity.Equals("All"))
					{
						return "Not selected field";
					}
				}
				else if(columnName == "Language")
				{
                    if (string.IsNullOrEmpty(Language))
                    {
						return "Empty field";
                    }
					else
					{
                        Match match = _word.Match(Language);
                        if (!match.Success)
                            return "Wrong format";
                    }
                }
				else if(columnName == "StartDate")
				{
					if(StartDate < StartTime)
					{
						return "Wrong date";
					}
				}
				else if(columnName == "EndDate")
				{
					if(EndDate < StartDate)
					{
						return "Wrong date";
					}
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
