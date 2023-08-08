using Booking.Domain.DTO;
using Booking.Domain.Model;
using Booking.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface ITourRequestService : IService<TourRequest>, ISubject
    {
        string GetMostPopularLanguageInLastYear();
        int GetMostPopularLocationIdInLastYear();
        List<TourRequest> GetAll();
        List<TourRequest> GetAllOnHold();
        void Search(ObservableCollection<TourRequest> observe, string city, string country, string numberOfGuests, string language, DateTime? startDate, DateTime? endDate);
        void ShowAll(ObservableCollection<TourRequest> observe);
        List<YearlyRequests> GetRequestsByYearAndLocation(int locationId);
        List<YearlyRequests> GetRequestsByYearAndLanguage(string language);
        List<MonthlyRequests> GetRequestsByMonthAndLocation(int locationId, int year);
        List<MonthlyRequests> GetRequestsByMonthAndLanguage(string language, int year);
        TourRequest AddTourRequest(TourRequest tourRequest);
        List<TourRequest> GetRequestsByUserId(int id);
        TourRequest ChangeStatus(TourRequest tourRequest);
        int GetNumberOfRequestsByUserId(int id, string year);
        int GetNumberOfAcceptedRequestsByUserId(int id, string year);
        List<string> GetLanguagesByUserId(int id, string year);
        int GetNumberOfRequestsByLang(int id, string lang, string year);
        List<string> GetYearsByUserId(int id);
        List<string> GetStatesByUserId(int id, string year);
        int GetNumberOfRequestsByState(int id, string state, string year);
        List<string> GetCitiesByUserId(int id, string year);
        int GetNumberOfRequestsByCity(int id, string city, string year);
        double GetAverageVisitorsByUserId(int id, string year);
        List<TourRequest> GetAllNotAccepted();
        List<TourRequest> GetAllAccepted();

        List<User> CheckUnfulfilledRequest(string lang, Location loc);
        List<TourRequest> GetByComplexRequestId(int id);
        List<TourRequest> GetAllOnHoldPartOfComplex();
        TourRequest UpdateTourRequest(TourRequest tourRequest);

    }
}
