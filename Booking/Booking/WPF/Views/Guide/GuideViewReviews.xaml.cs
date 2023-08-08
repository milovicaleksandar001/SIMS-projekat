using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.WPF.ViewModels.Guide;
using System.Collections.ObjectModel;
using System.Windows;

namespace Booking.View.Guide
{
    public partial class GuideViewReviews : Window
    {
        public ObservableCollection<TourGrade> TourGrades { get; set; }
        public ITourGradeService _tourGradeService { get; set; }

        public TourGrade SelectedTourGrade { get; set; }
        public GuideViewReviews()
        {
            InitializeComponent();
            this.DataContext = new GuideViewReviewsViewModel(this);
            reviewsDataGrid.Items.Clear();
        }
    }
}
