using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;

namespace Booking.WPF.ViewModels.Guide
{
    public class ShowReviewCommentViewModel
    {
        public string CommentTB { get; set; }
        public ITourGradeService _tourGradeService { get; set; }
        public ShowReviewCommentViewModel(int idGrade)
        {
            _tourGradeService = InjectorService.CreateInstance<ITourGradeService>();
            TourGrade tg = _tourGradeService.GetById(idGrade);
            CommentTB = tg.Comment;
        }
    }
}
