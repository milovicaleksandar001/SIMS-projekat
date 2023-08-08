using Booking.Commands;
using Booking.Domain.DTO;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class AccommodationStatisticsByYearsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<OwnerYearStatistic> yearStatistics { get; set; }
        public IAccommodationReservationService AccommodationReservationService { get; set; }
        public Accommodation selectedAccommodation { get; set; }
        public OwnerYearStatistic SelectedYearStatistic { get; set; }
        public String AccommodationLabel { get; set; } = String.Empty;
        public RelayCommand Detail { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand Wizard { get; set; }
        public string BestYearLabel { get; set; }
        private readonly Window _window;

        public AccommodationStatisticsByYearsViewModel(Accommodation SelectedAccommodation, Window window)
        {
            _window = window;
            selectedAccommodation = SelectedAccommodation;
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            AccommodationLabel = SetAccommodationLabel(SelectedAccommodation);
            yearStatistics = new ObservableCollection<OwnerYearStatistic>(AccommodationReservationService.GetYearStatistics(selectedAccommodation));
            Detail = new RelayCommand(DetailForYear);
            Close = new RelayCommand(CloseWindow);
            Wizard = new RelayCommand(OpenWizard);
            List<OwnerYearStatistic> BestYearStatistics = AccommodationReservationService.GetYearStatistics(selectedAccommodation);
            int bestYear = AccommodationReservationService.CalculateBestYear(BestYearStatistics,selectedAccommodation);
            BestYearLabel = bestYear.ToString();
        }
        private void CloseWindow(object param)
        {
            _window.Close();
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(2);
            wizard.Show();
        }
        public void Update()
        {
            yearStatistics.Clear();

            foreach (OwnerYearStatistic s in AccommodationReservationService.GetYearStatistics(selectedAccommodation))
            {
                yearStatistics.Add(s);
            }
        }
        private void DetailForYear(object param)
        {
            if (SelectedYearStatistic == null)
            {
                System.Windows.MessageBox.Show("Select a year for detail please", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            else
            {
                AccommodationStatisticsByMonths accommodationStatisticsByMonths = new AccommodationStatisticsByMonths(selectedAccommodation, SelectedYearStatistic);
                accommodationStatisticsByMonths.Show();
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private String SetAccommodationLabel(Accommodation accommodation)
        {
            return accommodation.Name + "-" + accommodation.Location.State + "-" + accommodation.Location.City + "-" + accommodation.Type;
        }
    }
}
