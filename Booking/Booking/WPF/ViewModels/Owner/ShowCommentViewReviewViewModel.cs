using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class ShowCommentViewReviewViewModel
    {
        public string CommentTB { get; set; }
        public IAccommodationAndOwnerGradeService _gradeService { get; set; }
        public String CommentLabel { get; set; } = String.Empty;
        public RelayCommand CloseWindow { get; set; }
        private readonly Window _window;
        public ShowCommentViewReviewViewModel(int idGrade, Window window)
        {
            _window = window;
            _gradeService = InjectorService.CreateInstance<IAccommodationAndOwnerGradeService>();
            AccommodationAndOwnerGrade grade = _gradeService.GetById(idGrade);
            CommentTB = grade.Comment;
            CommentLabel = SetCommentLabel(grade);
            CloseWindow = new RelayCommand(Close);
        }
        private String SetCommentLabel(AccommodationAndOwnerGrade grade)
        {
            return "Guest: " + grade.AccommodationReservation.Guest.Username + " ,for accommodation: " + grade.AccommodationReservation.Accommodation.Name;
        }
        private void Close(object param)
        {
            _window.Close();
        }
    }
}
