using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest2;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Booking.WPF.ViewModels.Guest2
{
	public class StatisticsViewModel : INotifyPropertyChanged
	{
		private readonly Window _window;
		private ITourRequestService _tourRequestService;

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<string> Years { get; set; }

		private string _year;
		public string SelectedYear
		{
			get => _year;
			set
			{
				if (_year != value)
				{
					_year = value;
					OnPropertyChanged();
				}
			}
		}
		public int SelectedIndex { get; set; }

		private double _visitors;
		public double Visitors
		{
			get => _visitors;
			set
			{
				if (_visitors != value)
				{
					_visitors = value;
					OnPropertyChanged();
				}
			}
		}

		public RelayCommand Button_Click_Close { get; set; }
		public RelayCommand Selection_Changed { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public StatisticsViewModel(Window window)
		{
			_window = window;

			_tourRequestService = InjectorService.CreateInstance<ITourRequestService>();

			Years = new ObservableCollection<string>(_tourRequestService.GetYearsByUserId(TourService.SignedGuideId));

			SelectedYear = "All";
			SelectedIndex = 0;

			InitializeCommands();
			UpdateCharts();
			AverageVisitors();
		}

		private void InitializeCommands()
		{
			Button_Click_Close = new RelayCommand(ButtonClose);
			Selection_Changed = new RelayCommand(ComboBoxStateSelectionChanged);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/Statistics.mp4");
            view.ShowDialog();
        }

        private void ButtonClose(object param)
		{
			_window.Close();
		}

		private void ComboBoxStateSelectionChanged(object param)
		{
			UpdateCharts();
			AverageVisitors();
		}

		private void AverageVisitors()
		{
			Visitors = _tourRequestService.GetAverageVisitorsByUserId(TourService.SignedGuideId, SelectedYear);
		}

		private IEnumerable<ISeries> _pie;
		public IEnumerable<ISeries> PieSeries
		{
			get => _pie;
			set
			{
				if (_pie != value)
				{
					_pie = value;
					OnPropertyChanged();
				}
			}
		}

		private ISeries[] _lang;
		public ISeries[] LangSeries
		{
			get => _lang;
			set
			{
				if (_lang != value)
				{
					_lang = value;
					OnPropertyChanged();
				}
			}
		}

		private ISeries[] _state;
		public ISeries[] StateSeries
		{
			get => _state;
			set
			{
				if (_state != value)
				{
					_state = value;
					OnPropertyChanged();
				}
			}
		}

		private ISeries[] _city;
		public ISeries[] CitySeries
		{
			get => _city;
			set
			{
				if (value != _city)
				{
					_city = value;
					OnPropertyChanged();
				}
			}
		}

		private Axis[] _langX;
		public Axis[] LangXAxes
		{
			get => _langX;
			set
			{
				if (value != _langX)
				{
					_langX = value;
					OnPropertyChanged();
				}
			}
		}

		private Axis[] _langY;
		public Axis[] LangYAxes
		{
			get => _langY;
			set
			{
				if (value != _langY)
				{
					_langY = value;
					OnPropertyChanged();
				}
			}
		}

		private Axis[] _stateX;
		public Axis[] StateXAxes
		{
			get => _stateX;
			set
			{
				if (value != _stateX)
				{
					_stateX = value;
					OnPropertyChanged();
				}
			}
		}

		private Axis[] _stateY;
		public Axis[] StateYAxes
		{
			get => _stateY;
			set
			{
				if (value != _stateY)
				{
					_stateY = value;
					OnPropertyChanged();
				}
			}
		}

		private Axis[] _cityX;
		public Axis[] CityXAxes
		{
			get => _cityX;
			set
			{
				if (_cityX != value)
				{
					_cityX = value;
					OnPropertyChanged();
				}
			}
		}

		private Axis[] _cityY;
		public Axis[] CityYAxes
		{
			get => _cityY;
			set
			{
				if (_cityY != value)
				{
					_cityY = value;
					OnPropertyChanged();
				}
			}
		}

		private void UpdateCharts()
		{
			PieChart();
			LangChart();
			StateChart();
			CityChart();
		}

		private void PieChart()
		{
			PieSeries = new ISeries[]
				{
					new PieSeries<double>
					{
						Values = new double[] { _tourRequestService.GetNumberOfRequestsByUserId(TourService.SignedGuideId, SelectedYear) },
						Name = "Not accepted requests",
						DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30)),
						DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer,
						DataLabelsFormatter = p => $"{p.PrimaryValue} ({p.StackedValue.Share:P2})"
					},
					new PieSeries<double>
					{
						Values = new double[] { _tourRequestService.GetNumberOfAcceptedRequestsByUserId(TourService.SignedGuideId, SelectedYear) },
						Name = "Accepted requests",
						DataLabelsPaint = new SolidColorPaint(new SKColor(30, 30, 30)),
						DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer,
						DataLabelsFormatter = p => $"{p.PrimaryValue} ({p.StackedValue.Share:P2})"
					}
				};
		}

		private void LangChart()
		{
			List<string> languages = _tourRequestService.GetLanguagesByUserId(TourService.SignedGuideId, SelectedYear);
			List<double> requests = new List<double>();

			foreach (var language in languages)
			{
				requests.Add((double)_tourRequestService.GetNumberOfRequestsByLang(TourService.SignedGuideId, language, SelectedYear));
			}

			LangSeries = new ISeries[]
				{
					new ColumnSeries<double>
					{
						Values = requests,
						Name = "Request count",
						Stroke = null,
						Fill = new SolidColorPaint(SKColors.CornflowerBlue),
						IgnoresBarPosition = true
					}
				};

			LangXAxes = new Axis[]
				{
					new Axis { Labels = languages, LabelsRotation = 15 }
				};

			LangYAxes = new Axis[]
				{
					new Axis { MinLimit = 0, MaxLimit = requests.Max() }
				};
		}

		private void StateChart()
		{
			List<string> states = _tourRequestService.GetStatesByUserId(TourService.SignedGuideId, SelectedYear);
			List<double> requests = new List<double>();

			foreach (var state in states)
			{
				requests.Add((double)_tourRequestService.GetNumberOfRequestsByState(TourService.SignedGuideId, state, SelectedYear));
			}

			StateSeries = new ISeries[]
				{
					new ColumnSeries<double>
					{
						Values = requests,
						Name = "Request count",
						Stroke = null,
						Fill = new SolidColorPaint(SKColors.CornflowerBlue),
						IgnoresBarPosition = true
					}
				};

			StateXAxes = new Axis[]
				{
					new Axis { Labels = states, LabelsRotation = 15 }
				};

			StateYAxes = new Axis[]
				{
					new Axis { MinLimit = 0, MaxLimit = requests.Max() }
				};
		}

		private void CityChart()
		{
			List<string> cities = _tourRequestService.GetCitiesByUserId(TourService.SignedGuideId, SelectedYear);
			List<double> requests = new List<double>();

			foreach (var city in cities)
			{
				requests.Add((double)_tourRequestService.GetNumberOfRequestsByCity(TourService.SignedGuideId, city, SelectedYear));
			}

			CitySeries = new ISeries[]
				{
					new ColumnSeries<double>
					{
						Values = requests,
						Name = "Request count",
						Stroke = null,
						Fill = new SolidColorPaint(SKColors.CornflowerBlue),
						IgnoresBarPosition = true
					}
				};

			CityXAxes = new Axis[]
				{
					new Axis { Labels = cities, LabelsRotation = 15 }
				};

			CityYAxes = new Axis[]
				{
					new Axis { MinLimit = 0, MaxLimit = requests.Max() }
				};
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
