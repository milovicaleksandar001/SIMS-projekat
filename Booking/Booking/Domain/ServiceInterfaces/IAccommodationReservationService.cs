using Booking.Domain.DTO;
using Booking.Domain.Model;
using Booking.Model;
using Booking.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.ServiceInterfaces
{
    public interface IAccommodationReservationService : IService<AccommodationReservation>, ISubject
    {
        List<AccommodationReservation> GetGeustsReservatonst();
        void SaveReservation(AccommodationReservation reservation);
        void Delete(AccommodationReservation selectedReservation);
        bool IsAbleToCancleResrvation(AccommodationReservation selectedReservation);
        List<DateTime> MakeListOfReservedDates(DateTime initialDate, DateTime endDate);
        bool IsDatesMatche(List<DateTime> reservedDatesEntered, List<DateTime> reservedDates);
        bool Reserve(DateTime arrivalDay, DateTime departureDay, Accommodation selectedAccommodation);
        List<DateTime> SetReservedDates(DateTime arrivalDay, DateTime departureDay, Accommodation selected);
        bool IsReservationAvailableToGrade(AccommodationReservation accommodationReservation);
        List<AccommodationReservation> GetAllUngradedReservations();
        List<(DateTime, DateTime)> GetDates(List<DateTime> reservedDates, int difference, DateTime departureDay, DateTime arrivalDay);
        List<(DateTime, DateTime)> SuggestOtherDates(DateTime arrivalDay, DateTime departureDay, Accommodation selectedAccommodation);
        AccommodationReservation GetById(int id);
        int GetSignedInFirstGuest();
        List<(DateTime, DateTime)> SuggestDatesForRenovation(DateTime startDay, DateTime endDay, int duration, Accommodation selectedAccommodation);
        AccommodationReservation GetByRenovation(AccommodationRenovation renovation);
        List<OwnerYearStatistic> GetYearStatistics(Accommodation selectedAccommodation);
        List<OwnerYearStatistic> FillResult(int FirstYear,int LastYear);
        DateTime GetFirstReservation(Accommodation selectedAccommodation);
        List<AccommodationReservationRequests> FillRequests(Accommodation selectedAccommodation);
        DateTime GetLastReservation(Accommodation selectedAccommodation);
        int CalculateBestYear(List<OwnerYearStatistic> statistics,Accommodation selectedAccommodation);
        int GetDaysSpan(AccommodationReservation reservation);
        List<OwnerMonthStatistic> GetMonthStatistics(Accommodation selectedAccommodation, int year);
        List<OwnerMonthStatistic> FillResultMonth();
        List<OwnerMonthStatistic> ChangeToMonths(List<OwnerMonthStatistic> result);
        List<AccommodationReservation> FillReservationsForMonthStatistics(Accommodation selectedAccommodation, int year);
        List<OwnerMonthStatistic> ChangeToNumbers(List<OwnerMonthStatistic> result);
        string CalculateBestMonth(List<OwnerMonthStatistic> BestMonthStatistics, Accommodation selectedAccommodation, int year);
        bool CheckMonthDuration(OwnerMonthStatistic statistic);

        string IsLocationVisited(Location location);
    }
}
