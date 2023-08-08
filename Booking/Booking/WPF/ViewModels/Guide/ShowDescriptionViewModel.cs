using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;

namespace Booking.WPF.ViewModels.Guide
{
    public class ShowDescriptionViewModel
    {
        public ITourService _tourService { get; set; }

        public string DescriptionTB { get; set; }
        public ShowDescriptionViewModel(int idTour)
        {
            _tourService = InjectorService.CreateInstance<ITourService>();
            Tour tour = _tourService.GetById(idTour);
            DescriptionTB = tour.Description;
        }
    }
}
