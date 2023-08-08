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
    public class AccommodationStatisticsByMonthsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<OwnerMonthStatistic> monthStatistics { get; set; }
        public IAccommodationReservationService AccommodationReservationService { get; set; }
        public Accommodation selectedAccommodation { get; set; }
        public OwnerYearStatistic selectedYearStatistic { get; set; }
        public String AccommodationLabel { get; set; } = String.Empty;
        public RelayCommand Close { get; set; }
        public RelayCommand Wizard { get; set; }
        public string BestMonthLabel { get; set; }
        private readonly Window _window;
        public AccommodationStatisticsByMonthsViewModel(Accommodation SelectedAccommodation, OwnerYearStatistic SelectedYearStatistics, Window window)
        {
            _window = window;
            selectedAccommodation = SelectedAccommodation;
            selectedYearStatistic = SelectedYearStatistics;
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            AccommodationLabel = SetAccommodationLabel(SelectedAccommodation);
            monthStatistics = new ObservableCollection<OwnerMonthStatistic>(AccommodationReservationService.GetMonthStatistics(selectedAccommodation,selectedYearStatistic.Year));
            Close = new RelayCommand(CloseWindow);
            Wizard = new RelayCommand(OpenWizard);
            List<OwnerMonthStatistic> BestMonthStatistics = AccommodationReservationService.GetMonthStatistics(selectedAccommodation,selectedYearStatistic.Year);
            string bestMonth = AccommodationReservationService.CalculateBestMonth(BestMonthStatistics, selectedAccommodation, selectedYearStatistic.Year);
            BestMonthLabel = bestMonth;
        }
        private void CloseWindow(object param)
        {
            _window.Close();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(3);
            wizard.Show();
        }
        private String SetAccommodationLabel(Accommodation accommodation)
        {
            return accommodation.Name + "-" + accommodation.Location.State + "-" + accommodation.Location.City + "-" + accommodation.Type;
        }
        public void Update()
        {
            monthStatistics.Clear();

            foreach (OwnerMonthStatistic s in AccommodationReservationService.GetMonthStatistics(selectedAccommodation, selectedYearStatistic.Year))
            {
                monthStatistics.Add(s);
            }
        }
    }
}
