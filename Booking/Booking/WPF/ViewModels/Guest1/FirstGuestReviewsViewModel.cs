using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.WPF.ViewModels.Guest1
{
    public class FirstGuestReviewsViewModel
    {
        public ObservableCollection<AccommodationGrade> Grades { get; set; }

        public IAccommodationGradeService AccommodationGradeService { get; set; }

        public AccommodationGrade SelectedGrade { get; set; }


        public FirstGuestReviewsViewModel()
        {
            AccommodationGradeService = InjectorService.CreateInstance<IAccommodationGradeService>();
            Grades = new ObservableCollection<AccommodationGrade>(AccommodationGradeService.GetSeeableGrades());
        }
    }
}
