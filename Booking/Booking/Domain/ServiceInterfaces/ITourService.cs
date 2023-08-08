using Booking.Model;
using Booking.Model.Images;
using Booking.Observer;
using Booking.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface ITourService : ISubject, IService<Tour>
    {
        Tour GetByName(string name);
        Tour GetById(int id);
        List<Tour> GetMostVisitedTourGenerally();
        List<Tour> GetMostVisitedTourThisYear();
        List<Tour> GetGuideTours();
        List<Tour> GetValidTours();
		ObservableCollection<Tour> Search(ObservableCollection<Tour> observe, string state, string city, string duration, string language, string visitors);
        ObservableCollection<Tour> CancelSearch(ObservableCollection<Tour> observe);
        TourKeyPoint UpdateKeyPoint(TourKeyPoint tourKeyPoint);
        Tour AddTour(Tour tour);
        void Create(Tour tour);
        List<Tour> GetTodayTours();
        List<TourKeyPoint> GetSelectedTourKeyPoints(int idTour);
        Tour removeTour(int idTour);
        bool checkTourGuests(int tourId, int userId);
        int numberOfZeroToEighteenGuests(int selectedTourID);
        int numberOfEighteenToFiftyGuests(int selectedTourID);
        int numberOfFiftyPlusGuests(int selectedTourID);
        Tour UpdateTour(Tour tour);
        void RemoveGuideTours(int idGuide);
        int numberWithVouchersGuests(int selectedTourID);
        int numberWithOutVouchersGuests(int selectedTourID);
        TourImage FindImageByUrl(string url);
        List<TourKeyPoint> GetTourKeyPoints();
        TourKeyPoint removeKeyPoint(int idKeyPoint);
        Tour removeTour1(int idTour);
    }
}
