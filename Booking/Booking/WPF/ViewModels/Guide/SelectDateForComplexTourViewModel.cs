using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels
{
    public class SelectDateForComplexTourViewModel :  INotifyPropertyChanged
    {
        public ITourService tourService { get; set; }
        private readonly Window _window;

        public static DateTime GuestStartDate { get; set; }
        public static DateTime GuestEndDate { get; set; }

        private DateTime[] _selectedDeadLine;
        public DateTime[] SelectedDeadLine
        {
            get { return _selectedDeadLine; }
            set
            {
                _selectedDeadLine = value;
                OnPropertyChanged("SelectedDeadLine");
            }
        }

        public RelayCommand Apply { get; set; }
        public ObservableCollection<DateTime[]> DeadLine { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public SelectDateForComplexTourViewModel(Window window)
        {
            _window = window;
            tourService = InjectorService.CreateInstance<ITourService>();
            DeadLine = new ObservableCollection<DateTime[]>();
            Apply = new RelayCommand(ButtonApply);

            int combinationCount = 3; 
            int daysOffset = 7; 

            DateTime startDate = GuestStartDate.AddDays(-daysOffset);
            DateTime endDate = GuestEndDate.AddDays(daysOffset);

            if (IsGuideAvailable(TourService.SignedGuideId, GuestStartDate, GuestEndDate))
            {
                DateTime[] initialCombination = new DateTime[] { GuestStartDate, GuestEndDate };
                DeadLine.Add(initialCombination);
                combinationCount--;
            }

            for (int i = 0; i < combinationCount; i++)
            {
                DateTime combinationStart = startDate.AddDays(i);
                DateTime combinationEnd = combinationStart.AddDays((GuestEndDate - GuestStartDate).TotalDays);

                if (IsGuideAvailable(TourService.SignedGuideId, combinationStart, combinationEnd))
                {
                    DateTime[] combination = new DateTime[] { combinationStart, combinationEnd };
                    DeadLine.Add(combination);
                }
            }

        }

        private void ButtonApply(object param)
        {
            if (SelectedDeadLine != null)
            { 
            GuideAcceptingPartOfTourViewModel.forwardedStartDate = SelectedDeadLine[0];
            GuideAcceptingPartOfTourViewModel.forwardedEndDate = SelectedDeadLine[1];
            System.Windows.MessageBox.Show("Date successfully picked!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            CloseWindow();
            }
            else
            {
                System.Windows.MessageBox.Show("First you need to pick dates!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool IsGuideAvailable(int guideId, DateTime startDate, DateTime endDate)
        {
            List<Tour> tours = tourService.GetGuideTours();

            foreach (Tour tour in tours)
            {
                DateTime tourEndTime = tour.StartTime + TimeSpan.FromDays(tour.Duration * 24);
                bool isOverlapping = startDate < tourEndTime && endDate > tour.StartTime;

                if (isOverlapping)
                {
                    return false;
                }
            }

            return true;
        }

        private void CloseWindow()
        {
            _window.Close();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
