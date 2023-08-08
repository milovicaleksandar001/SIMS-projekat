using Booking.WPF.ViewModels.Guide;
using System.Windows;

namespace Booking.View.Guide
{
    public partial class ShowReviewComment : Window
    {
        public ShowReviewComment(int idGrade)
        {
            InitializeComponent();
            this.DataContext = new ShowReviewCommentViewModel(idGrade);  
        }
    }
}
