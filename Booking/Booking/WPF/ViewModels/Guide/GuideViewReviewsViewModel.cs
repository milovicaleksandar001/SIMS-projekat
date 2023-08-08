using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Util;
using Booking.View.Guide;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideViewReviewsViewModel : IObserver, INotifyPropertyChanged
    {
        public ObservableCollection<TourGrade> TourGrades { get; set; }
        public ITourGradeService _tourGradeService { get; set; }

        public TourGrade SelectedTourGrade { get; set; }

        private readonly Window _window;


        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand Close { get; set; }
        public RelayCommand Report { get; set; }
        public RelayCommand ShowReviewText { get; set; }
        public GuideViewReviewsViewModel(Window window) 
        {
            _window = window;

            _tourGradeService = InjectorService.CreateInstance<ITourGradeService>();

            _tourGradeService.Subscribe(this);

            TourGrades = new ObservableCollection<TourGrade>(_tourGradeService.GetGuideGrades());

            SetCommands();
        }

        private void CloseWindow()
        {
            _window.Close();
        }

        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            Report = new RelayCommand(ButtonReport);
            ShowReviewText = new RelayCommand(ButtonShowReviewText);
        }

        private void ButtonClose(object param)
        {
            CloseWindow();
        }

        private void ButtonReport(object param)
        {
            MessageBoxResult result = ConfirmReport();
            if (result == MessageBoxResult.Yes)
            {
                SelectedTourGrade.Valid = false;
                _tourGradeService.UpdateTourGrade(SelectedTourGrade);
                _tourGradeService.NotifyObservers();
            }
        }
        private MessageBoxResult ConfirmReport()
        {
            string sMessageBoxText = $"Are you sure to report grade?";
            string sCaption = "Report grade";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            return result;
        }

        private void ButtonShowReviewText(object param)
        {
            ShowReviewComment showReviewComment = new ShowReviewComment(SelectedTourGrade.Id);
            showReviewComment.ShowDialog();
        }
        public void Update()
        {
            TourGrades.Clear();

            foreach (TourGrade t in _tourGradeService.GetGuideGrades())
            {
                TourGrades.Add(t);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
