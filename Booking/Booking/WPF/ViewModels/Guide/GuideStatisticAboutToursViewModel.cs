using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guide;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideStatisticAboutToursViewModel : IObserver, INotifyPropertyChanged
    {
        public ObservableCollection<Tour> MostVisitedTourGenerraly { get; set; }
        public ObservableCollection<Tour> MostVisitedTourThisYear { get; set; }
        public ObservableCollection<Tour> averageNumberOfGuests { get; set; }
        public ITourService _tourService { get; set; }
        public User user { get; set; }
        public Tour SelectedTour { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> TourCollection { get; set; } 

        private ObservableCollection<Tour> _mostVisitedTourPom = new ObservableCollection<Tour>();
        public ObservableCollection<Tour> MostVisitedTourPom
        {
            get { return _mostVisitedTourPom; }
            set
            {
                _mostVisitedTourPom = value;
                OnPropertyChanged(nameof(MostVisitedTourPom));
            }
        }

        private Brush _buttonBackground = new SolidColorBrush(Color.FromRgb(0xAA, 0xCB, 0xF0));
        public Brush Button1Color
        {
            get { return _buttonBackground; }
            set
            {
                _buttonBackground = value;
                OnPropertyChanged(nameof(Button1Color));
            }
        }

        private Brush _buttonBackground2 = new SolidColorBrush(Color.FromRgb(0x72, 0x87, 0x9E));
        public Brush Button2Color
        {
            get { return _buttonBackground2; }
            set
            {
                _buttonBackground2 = value;
                OnPropertyChanged(nameof(Button2Color));
            }
        }
        public string _zeroToEighteenTB;
        public string ZeroToEighteenTB
        {
            get => _zeroToEighteenTB;
            set
            {
                if (_zeroToEighteenTB != value)
                {
                    _zeroToEighteenTB = value;
                    OnPropertyChanged(nameof(ZeroToEighteenTB));
                }
            }
        }

        public string _eighteenToFifthyTB;
        public string EighteenToFifthyTB
        {
            get => _eighteenToFifthyTB;
            set
            {
                if (_eighteenToFifthyTB != value)
                {
                    _eighteenToFifthyTB = value;
                    OnPropertyChanged(nameof(EighteenToFifthyTB));
                }
            }
        }
        public string _fifthyPlusTB;
        public string FifthyPlusTB
        {
            get => _fifthyPlusTB;
            set
            {
                if (_fifthyPlusTB != value)
                {
                    _fifthyPlusTB = value;
                    OnPropertyChanged(nameof(FifthyPlusTB));
                }
            }
        }
        public string _withVoucherTB;
        public string WithVoucherTB
        {
            get => _withVoucherTB;
            set
            {
                if (_withVoucherTB != value)
                {
                    _withVoucherTB = value;
                    OnPropertyChanged(nameof(WithVoucherTB));
                }
            }
        }
        public string _withOutVoucherTB;
        public string WithOutVoucherTB
        {
            get => _withOutVoucherTB;
            set
            {
                if (_withOutVoucherTB != value)
                {
                    _withOutVoucherTB = value;
                    OnPropertyChanged(nameof(WithOutVoucherTB));
                }
            }
        }

        public string _tourCB;
        public string TourCB
        {
            get => _tourCB;
            set
            {
                if (_tourCB != value)
                {
                    _tourCB = value;
                    OnPropertyChanged(nameof(TourCB));
                }
            }
        }
  


        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");
            }
        }

        public RelayCommand Close { get; set; }
        public RelayCommand Generraly { get; set; }
        public RelayCommand MostVisitedThisYear { get; set; }
        public RelayCommand ShowDescriptionText { get; set; }
        public RelayCommand ResetStatistic { get; set; }
        public RelayCommand ShowStatistic { get; set; }
        
        private readonly Window _window;

        public GuideStatisticAboutToursViewModel(Window window) 
        {
            _window = window;

            _tourService = InjectorService.CreateInstance<ITourService>();
            _tourService.Subscribe(this);

            TourCollection = new ObservableCollection<String>();
            MostVisitedTourGenerraly = new ObservableCollection<Tour>(_tourService.GetMostVisitedTourGenerally());
            MostVisitedTourThisYear = new ObservableCollection<Tour>(_tourService.GetMostVisitedTourThisYear());
            MostVisitedTourPom = new ObservableCollection<Tour>();
            MostVisitedTourPom = MostVisitedTourGenerraly;

            FillComboBox();
            SetCommands();
        }


        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            Generraly = new RelayCommand(buttonGenerraly);
            MostVisitedThisYear = new RelayCommand(buttonMostVisitedThisYear);
            ShowDescriptionText = new RelayCommand(ButtonShowDescriptionText);
            ResetStatistic = new RelayCommand(ButtonResetStatistic);
            ShowStatistic = new RelayCommand(ButtonShowStatistic);
        }


        private void FillComboBox()
        {
            List<string> items1 = new List<string>();

            using (StreamReader reader = new StreamReader("../../Resources/Data/tours.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split('|');
                    if (fields[9] == TourService.SignedGuideId.ToString() && fields[10] == "True")
                    {
                        items1.Add(fields[1]);
                    }
                }
            }
            var distinctItems = items1.Distinct().ToList();

            TourCollection.Clear();
            foreach (string item in distinctItems) 
            {
            TourCollection.Add(item);
            }
        }
        private void ButtonClose(object param)
        {
            CloseWindow();
        }

        private void buttonGenerraly(object param)
        {
            Button2Color =  new SolidColorBrush(Color.FromRgb(0x72, 0x87, 0x9E));
            Button1Color = new SolidColorBrush(Color.FromRgb(0xAA, 0xCB, 0xF0));

            MostVisitedTourPom = MostVisitedTourGenerraly;

            if (MostVisitedTourGenerraly.Count() == 0)
            {
                System.Windows.MessageBox.Show("You don't have tours with guests!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void buttonMostVisitedThisYear(object param)
        {
            Button1Color = new SolidColorBrush(Color.FromRgb(0x72, 0x87, 0x9E));
            Button2Color = new SolidColorBrush(Color.FromRgb(0xAA, 0xCB, 0xF0));

            MostVisitedTourPom = MostVisitedTourThisYear;

            if (MostVisitedTourThisYear.Count() == 0)
            {
                System.Windows.MessageBox.Show("You don't have tours with guests in this year!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void ButtonShowDescriptionText(object param)
        {
            ShowDescription showDescriptionText = new ShowDescription(SelectedTour.Id);
            showDescriptionText.Show();
        }


        private void ButtonShowStatistic(object param)
        {
            if (TourCB != null)
            {
                Tour turapom = _tourService.GetByName(TourCB);

                ZeroToEighteenTB = _tourService.numberOfZeroToEighteenGuests(turapom.Id).ToString();
                EighteenToFifthyTB = _tourService.numberOfEighteenToFiftyGuests(turapom.Id).ToString();
                FifthyPlusTB = _tourService.numberOfFiftyPlusGuests(turapom.Id).ToString();
                WithVoucherTB = _tourService.numberWithVouchersGuests(turapom.Id).ToString();
                WithOutVoucherTB = _tourService.numberWithOutVouchersGuests(turapom.Id).ToString();
            }
            else
            {
                System.Windows.MessageBox.Show("In order to show statistics, you first need to select some tour!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void ButtonResetStatistic(object param)
        {
            SelectedIndex = -1;
            ZeroToEighteenTB = "";
            EighteenToFifthyTB = "";
            FifthyPlusTB = "";
            WithVoucherTB = "";
            WithOutVoucherTB = "";
        }

        private void CloseWindow()
        {
            _window.Close();
        }
        public void Update()
        {
            MostVisitedTourGenerraly.Clear();
            foreach (Tour t in _tourService.GetMostVisitedTourGenerally())
            {
                MostVisitedTourGenerraly.Add(t);
            }

            MostVisitedTourThisYear.Clear();
            foreach (Tour t in _tourService.GetMostVisitedTourThisYear())
            {
                MostVisitedTourThisYear.Add(t);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
