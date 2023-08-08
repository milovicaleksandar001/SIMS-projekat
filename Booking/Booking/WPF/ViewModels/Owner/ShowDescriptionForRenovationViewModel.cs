using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class ShowDescriptionForRenovationViewModel
    {
        public string DescriptionTB { get; set; }
        public IAccommodationRenovationService _renovationService { get; set; }
        public String DescriptionLabel { get; set; } = String.Empty;
        public RelayCommand CloseWindow { get; set; }
        private readonly Window _window;
        public ShowDescriptionForRenovationViewModel(int idRenovation, Window window)
        {
            _window = window;
            _renovationService = InjectorService.CreateInstance<IAccommodationRenovationService>();
            AccommodationRenovation renovation = _renovationService.GetById(idRenovation);
            DescriptionTB = renovation.Description;
            DescriptionLabel = SetCommentLabel(renovation);
            CloseWindow = new RelayCommand(Close);
        }
        private String SetCommentLabel(AccommodationRenovation renovation)
        {
            return "Accommodation: " + renovation.Accommodation.Name + " ,from: " + renovation.StartDay.ToShortDateString() + " ,to: " + renovation.EndDay.ToShortDateString();
        }
        private void Close(object param)
        {
            _window.Close();
        }
    }
}
