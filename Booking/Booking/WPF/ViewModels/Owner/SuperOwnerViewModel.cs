using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class SuperOwnerViewModel
    {
        public IAccommodationAndOwnerGradeService _gradeService { get; set; }
        public RelayCommand CloseSuper { get; set; }
        public RelayCommand Wizard { get; set; }
        private readonly Window _window;
        public string NumberOfGradesText { get; set; } 
        public string AverageGradeText { get; set; }
        public string IsSuperText { get; set; }
        public SuperOwnerViewModel(Window window)
        {
            _window = window;
            _gradeService = InjectorService.CreateInstance<IAccommodationAndOwnerGradeService>();
            NumberOfGradesText = _gradeService.GetNumberOfGrades().ToString();
            AverageGradeText = _gradeService.GetAverageGrade().ToString();
            IsSuperText = _gradeService.SuperWindowText();
            //NumberOfGrades.Text = _gradeService.GetNumberOfGrades().ToString();
            //AverageGrade.Text = _gradeService.GetAverageGrade().ToString();
            //IsSuper.Text = _gradeService.SuperWindowText();
            CloseSuper = new RelayCommand(Close);
            Wizard = new RelayCommand(OpenWizard);
        }
        private void Close(object param)
        {
            _window.Close();
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(9);
            wizard.Show();
        }
    }
}
