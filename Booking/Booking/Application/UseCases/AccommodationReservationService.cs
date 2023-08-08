using Booking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Booking.Model;
using Booking.Observer;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.Model;
using Booking.Domain.DTO;

namespace Booking.Service
{
    public class AccommodationReservationService : ISubject, IAccommodationReservationService
    {
        private readonly List<IObserver> _observers;
        private readonly IAccommodationResevationRepository _repository;
        private readonly IAccommodationRepository _accommodationRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAccommodationReservationRequestsRepostiory _accommodationReservationRequestRepository;
        private readonly IAccommodationGradeRepository _accommodationGradeRepository;
        private readonly IRenovationRecommodationRepository _renovationRecommedationRepository;
        private readonly IAccommodationImagesRepository _accommodationImagesRepository;
        public static int SignedFirstGuestId;
		public AccommodationReservationService()
        {
            _observers = new List<IObserver>();
            _repository = InjectorRepository.CreateInstance<IAccommodationResevationRepository>();
            _accommodationRepository = InjectorRepository.CreateInstance<IAccommodationRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
            _locationRepository = InjectorRepository.CreateInstance<ILocationRepository>();
            _accommodationReservationRequestRepository = InjectorRepository.CreateInstance<IAccommodationReservationRequestsRepostiory>();
            _accommodationGradeRepository = InjectorRepository.CreateInstance<IAccommodationGradeRepository>();
            _renovationRecommedationRepository = InjectorRepository.CreateInstance<IRenovationRecommodationRepository>();
            _accommodationImagesRepository = InjectorRepository.CreateInstance<IAccommodationImagesRepository>(); ;
        }

        public int GetSignedInFirstGuest()
        {
            return SignedFirstGuestId;
        }
        public AccommodationReservation GetById(int id)
        {
           return _repository.GetById(id);
        }
        public AccommodationReservation GetByRenovation(AccommodationRenovation renovation)
        {
            AccommodationReservation reservation = new AccommodationReservation();
            foreach (var r in _repository.GetAll()) 
            {
                if (renovation.StartDay == r.ArrivalDay && renovation.EndDay == r.DepartureDay && r.Guest.Id == renovation.Accommodation.Owner.Id && r.Accommodation.Id==renovation.Accommodation.Id)
                {
                    reservation = r;
                }
            }
            return reservation;
        }

        public List<AccommodationReservation> GetGeustsReservatonst()
        {
            List<AccommodationReservation> _guestsReservations = new List<AccommodationReservation>();

            //binding
            foreach (var reservation in _repository.GetAll())
            {
                if (reservation.Guest.Id == SignedFirstGuestId)
                {
                    reservation.Accommodation = _accommodationRepository.GetById(reservation.Accommodation.Id);
                    reservation.Accommodation.Location = _locationRepository.GetById(reservation.Accommodation.Location.Id);
                    reservation.Accommodation.Owner = _userRepository.GetById(reservation.Accommodation.Owner.Id);
                    reservation.Guest = _userRepository.GetById(SignedFirstGuestId);
                    foreach (var p in _accommodationImagesRepository.GetAll())
                    {
                        if (p.Accomodation.Id == reservation.Accommodation.Id)
                        {
                            reservation.Accommodation.Images.Add(p);
                        }
                    }
                    _guestsReservations.Add(reservation);
                }
            }
            return _guestsReservations;
        }
        public void SaveReservation(AccommodationReservation reservation)
        {
            _repository.Add(reservation);
        }
        public string CalculateBestMonth(List<OwnerMonthStatistic> BestMonthStatistics, Accommodation selectedAccommodation, int year) 
        {
            BestMonthStatistics = ChangeToNumbers(BestMonthStatistics);
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            foreach (var s in BestMonthStatistics)
            {
                s.NumberOfReservations = 0;
            }
            foreach (var r in _repository.GetAll())
            {
                foreach (var s in BestMonthStatistics)
                {
                    if (r.ArrivalDay.Year == year && r.Accommodation.Id == selectedAccommodation.Id && r.ArrivalDay <= DateTime.Now && Convert.ToInt32(s.Month) ==r.ArrivalDay.Month)
                    {
                        s.NumberOfReservations = s.NumberOfReservations + GetDaysSpan(r);
                    }
                }
            }
            BestMonthStatistics = ChangeToMonths(BestMonthStatistics);
            string bestMonth = BestMonthStatistics[0].Month;
            double bestStatistic = (Convert.ToDouble(BestMonthStatistics[0].NumberOfReservations) / Convert.ToDouble(31));
            foreach (var s in BestMonthStatistics)
            {
                if (s.Month.Equals("February"))
                {
                    if (Convert.ToDouble(s.NumberOfReservations / Convert.ToDouble(28)) > bestStatistic)
                    {
                        bestMonth = s.Month;
                        bestStatistic = (Convert.ToDouble(s.NumberOfReservations) / Convert.ToDouble(28));
                    }
                }
                else
                {
                    if (CheckMonthDuration(s))
                    {
                        if (Convert.ToDouble(s.NumberOfReservations / Convert.ToDouble(31)) > bestStatistic)
                        {
                            bestMonth = s.Month;
                            bestStatistic = (Convert.ToDouble(s.NumberOfReservations) / Convert.ToDouble(31));
                        }
                    }
                    else 
                    {
                        if (Convert.ToDouble(s.NumberOfReservations / Convert.ToDouble(30)) > bestStatistic)
                        {
                            bestMonth = s.Month;
                            bestStatistic = (Convert.ToDouble(s.NumberOfReservations) / Convert.ToDouble(30));
                        }
                    }
                }
            }
            return bestMonth;
        }
        public bool CheckMonthDuration(OwnerMonthStatistic statistic) 
        {
            return statistic.Month.Equals("January") || statistic.Month.Equals("March") || statistic.Month.Equals("May")
                || statistic.Month.Equals("July") || statistic.Month.Equals("August") || statistic.Month.Equals("October") || statistic.Month.Equals("December");
        }
        public List<OwnerMonthStatistic> GetMonthStatistics(Accommodation selectedAccommodation, int year)
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            reservationList = FillReservationsForMonthStatistics(selectedAccommodation, year);
            List<OwnerMonthStatistic> result = new List<OwnerMonthStatistic>();
            result = FillResultMonth();
            foreach (var r in reservationList)
            {
                foreach (var s in result)
                {
                    if (Convert.ToInt32(s.Month) == r.ArrivalDay.Month)
                    {
                        s.NumberOfReservations++;
                        if (r.Deleted == 1)
                        {
                            s.NumberOfCancelations++;
                        }
                    }

                }
            }
            List<AccommodationReservationRequests> requests = new List<AccommodationReservationRequests>();
            requests = FillRequests(selectedAccommodation);
            foreach (var r in requests)
            {
                foreach (var s in result)
                {
                    if (year == r.NewArrivalDay.Year && Convert.ToInt32(s.Month)==r.NewArrivalDay.Month)
                    {
                        s.NumberOfReservations--;
                    }
                    if (year == r.AccommodationReservation.ArrivalDay.Year && Convert.ToInt32(s.Month)==r.AccommodationReservation.ArrivalDay.Month)
                    {
                        s.NumberOfCancelations--;
                        s.NumberOfReschedulings++;
                    }
                }
            }
            List<RenovationRecommodation> recommodations = new List<RenovationRecommodation>();
            recommodations = FillRecommodations(selectedAccommodation);
            foreach (var r in recommodations)
            {
                foreach (var s in result)
                {
                    if (year == r.AccommodationReservation.ArrivalDay.Year && Convert.ToInt32(s.Month)==r.AccommodationReservation.ArrivalDay.Month)
                    {
                        s.NumberOfSuggestions++;
                    }
                }
            }
            result = ChangeToMonths(result);
            return result;
        }
        public List<OwnerMonthStatistic> FillResultMonth()
        {
            List<OwnerMonthStatistic> result = new List<OwnerMonthStatistic>();
            for (int i = 1; i <= 12; i++)
            {
                OwnerMonthStatistic ownerMonthStatistic = new OwnerMonthStatistic();
                ownerMonthStatistic.Month = i.ToString();
                ownerMonthStatistic.NumberOfReschedulings = 0;
                ownerMonthStatistic.NumberOfReservations = 0;
                ownerMonthStatistic.NumberOfCancelations = 0;
                ownerMonthStatistic.NumberOfSuggestions = 0;
                result.Add(ownerMonthStatistic);
            }
            return result;
        }
        public List<OwnerMonthStatistic> ChangeToMonths(List<OwnerMonthStatistic> result) 
        {

            result[0].Month = "January";
            result[1].Month = "February";
            result[2].Month = "March";
            result[3].Month = "April";
            result[4].Month = "May";
            result[5].Month = "June";
            result[6].Month = "July";
            result[7].Month = "August";
            result[8].Month = "September";
            result[9].Month = "October";
            result[10].Month = "November";
            result[11].Month = "December";
            return result;
        }
        public List<OwnerMonthStatistic> ChangeToNumbers(List<OwnerMonthStatistic> result)
        {
            result[0].Month = "1";
            result[1].Month = "2";
            result[2].Month = "3";
            result[3].Month = "4";
            result[4].Month = "5";
            result[5].Month = "6";
            result[6].Month = "7";
            result[7].Month = "8";
            result[8].Month = "9";
            result[9].Month = "10";
            result[10].Month = "11";
            result[11].Month = "12";
            return result;
        }
        public List<AccommodationReservation> FillReservationsForMonthStatistics(Accommodation selectedAccommodation, int year) 
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            foreach (var r in _repository.GetAllWithDeleted())
            {
                if (r.Accommodation.Id == selectedAccommodation.Id && r.ArrivalDay.Year==year)
                {
                    reservationList.Add(r);
                }
            }
            return reservationList;
        }
        public int GetDaysSpan(AccommodationReservation reservation) 
        {
            int days=0;
            for (DateTime date = reservation.ArrivalDay; date < reservation.DepartureDay; date=date.AddDays(1))
            {
                days++;
            }
            return days;
        }
        public int CalculateBestYear(List<OwnerYearStatistic> statistics,Accommodation selectedAccommodation)
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            foreach (var s in statistics) 
            {
                s.NumberOfReservations = 0;
            }
            foreach (var r in _repository.GetAll())
            {
                foreach (var s in statistics)
                {
                    if (r.ArrivalDay.Year == s.Year && r.Accommodation.Id == selectedAccommodation.Id && r.ArrivalDay<=DateTime.Now) 
                    {
                        s.NumberOfReservations = s.NumberOfReservations + GetDaysSpan(r);
                    }
                }
            }
            int bestYear = statistics[0].Year;
            double bestStatistic = (Convert.ToDouble(statistics[0].NumberOfReservations) / Convert.ToDouble(365));
            foreach (var s in statistics) 
            {
                if (Convert.ToDouble(s.NumberOfReservations / Convert.ToDouble(365)) > bestStatistic) 
                {
                    bestYear = s.Year;
                    bestStatistic = (Convert.ToDouble(s.NumberOfReservations) / Convert.ToDouble(365));
                }
            }
            return bestYear;
        }
        public List<OwnerYearStatistic> GetYearStatistics(Accommodation selectedAccommodation)
        {
            DateTime FirstReservation = GetFirstReservation(selectedAccommodation);
            DateTime LastReservation = GetLastReservation(selectedAccommodation);
            List<OwnerYearStatistic> result = new List<OwnerYearStatistic>();
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            foreach (var r in _repository.GetAllWithDeleted())
            {
                if (r.Accommodation.Id == selectedAccommodation.Id)
                {
                    reservationList.Add(r);
                }
            }
            int FirstYear = FirstReservation.Year;
            int LastYear = LastReservation.Year;
            result = FillResult(FirstYear,LastYear);
            foreach (var r in reservationList) 
            {
                foreach (var s in result)
                {
                    if (s.Year == r.ArrivalDay.Year) 
                    {
                        s.NumberOfReservations++;
                        if (r.Deleted == 1) 
                        {
                            s.NumberOfCancelations++;
                        }
                    }

                }
            }
            List<AccommodationReservationRequests> requests = new List<AccommodationReservationRequests>();
            requests = FillRequests(selectedAccommodation);
            foreach (var r in requests) 
            {
                foreach (var s in result) 
                {
                    if (s.Year == r.NewArrivalDay.Year) 
                    {
                        s.NumberOfReservations--;
                    }
                    if (s.Year == r.AccommodationReservation.ArrivalDay.Year) 
                    {
                        s.NumberOfCancelations--;
                        s.NumberOfReschedulings++;
                    }
                }
            }
            List<RenovationRecommodation> recommodations = new List<RenovationRecommodation>();
            recommodations = FillRecommodations(selectedAccommodation);
            foreach (var r in recommodations)
            {
                foreach (var s in result)
                {
                    if (s.Year == r.AccommodationReservation.ArrivalDay.Year)
                    {
                        s.NumberOfSuggestions++;
                    }
                }
            }
            return result;
        }
        public List<AccommodationReservationRequests> FillRequests(Accommodation selectedAccommodation)
        {
            List<AccommodationReservationRequests> requests = new List<AccommodationReservationRequests>();
            foreach (var request in _accommodationReservationRequestRepository.GetAll())
            {
                request.AccommodationReservation = _repository.GetById(request.AccommodationReservation.Id);
                if (request.AccommodationReservation.Accommodation.Id == selectedAccommodation.Id && request.Status==Model.Enums.RequestStatus.ACCEPTED) 
                {
                    requests.Add(request);
                }
            }
            return requests;
        }
        public List<RenovationRecommodation> FillRecommodations(Accommodation selectedAccommodation)
        {
            List<RenovationRecommodation> recommodations = new List<RenovationRecommodation>();
            foreach (var recommodation in _renovationRecommedationRepository.GetAll())
            {
                recommodation.AccommodationReservation = _repository.GetById(recommodation.AccommodationReservation.Id);
                if (recommodation.AccommodationReservation.Accommodation.Id == selectedAccommodation.Id)
                {
                    recommodations.Add(recommodation);
                }
            }
            return recommodations;
        }
        public List<OwnerYearStatistic> FillResult(int FirstYear,int LastYear) 
        {
            List<OwnerYearStatistic> result = new List<OwnerYearStatistic>();
            for (int i = FirstYear; i <= LastYear; i++)
            {
                OwnerYearStatistic ownerYearStatistic = new OwnerYearStatistic();
                ownerYearStatistic.Year = i;
                ownerYearStatistic.NumberOfReschedulings = 0;
                ownerYearStatistic.NumberOfReservations = 0;
                ownerYearStatistic.NumberOfCancelations = 0;
                ownerYearStatistic.NumberOfSuggestions = 0;
                result.Add(ownerYearStatistic);
            }
            return result;
        }
        public DateTime GetLastReservation(Accommodation selectedAccommodation)
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            reservationList = _repository.GetAllWithDeleted();
            DateTime dateTime = reservationList[0].ArrivalDay;
            foreach (var r in reservationList)
            {
                if (r.ArrivalDay > dateTime && r.Accommodation.Id == selectedAccommodation.Id)
                {
                    dateTime = r.ArrivalDay;
                }
            }
            return dateTime;
        }

        public DateTime GetFirstReservation(Accommodation selectedAccommodation)
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            reservationList = _repository.GetAllWithDeleted();
            DateTime dateTime = reservationList[0].ArrivalDay;
            foreach (var r in reservationList) 
            {
                if (r.ArrivalDay < dateTime && r.Accommodation.Id == selectedAccommodation.Id) 
                {
                    dateTime = r.ArrivalDay;
                }
            }
            return dateTime;
        }

        public void Delete(AccommodationReservation selectedReservation)
        {
            _repository.Delete(selectedReservation);
            _accommodationReservationRequestRepository.DeleteRequest(selectedReservation);
            NotifyObservers();
        }

        public bool IsAbleToCancleResrvation(AccommodationReservation selectedReservation)
        {
            DateTime currentDate = DateTime.Now;
            DateTime cancellationDate = selectedReservation.ArrivalDay.AddDays(-selectedReservation.Accommodation.CancelationPeriod);
            return (currentDate <= cancellationDate);
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
        public List<DateTime> MakeListOfReservedDates(DateTime initialDate, DateTime endDate)
        {
            List<DateTime> reservedDates = new List<DateTime>();
            for (DateTime date = initialDate; date <= endDate; date = date.AddDays(1))
            {
                reservedDates.Add(date);
            }
            return reservedDates;
        }
        public bool IsDatesMatche(List<DateTime> reservedDatesEntered, List<DateTime> reservedDates)
        {
            foreach (DateTime date in reservedDates)
            {
                foreach (DateTime dateEntered in reservedDatesEntered)
                {
                    if (dateEntered == date)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool Reserve(DateTime arrivalDay, DateTime departureDay, Accommodation selectedAccommodation)
        {
            List<DateTime> reservedDatesEntered = MakeListOfReservedDates(arrivalDay, departureDay);

            foreach (AccommodationReservation reservation in _repository.GetAll())
            {
                if (reservation.Accommodation.Id == selectedAccommodation.Id)
                {
                    List<DateTime> reservedDates = MakeListOfReservedDates(reservation.ArrivalDay, reservation.DepartureDay);

                    if (IsDatesMatche(reservedDatesEntered, reservedDates) == false)
                    {
                        return false;
                    }
                }
            }
            AccommodationReservation newReservation = new AccommodationReservation(selectedAccommodation, arrivalDay, departureDay, AccommodationReservationService.SignedFirstGuestId);
            SaveReservation(newReservation);
            return true;
        }
        public List<DateTime> SetReservedDates(DateTime arrivalDay, DateTime departureDay, Accommodation selected)
        {
            List<DateTime> reservedDates = new List<DateTime>();

            foreach (AccommodationReservation r in _repository.GetAll())
            {
                if (r.Accommodation.Id == selected.Id)
                {
                    for (DateTime date = r.ArrivalDay; date <= r.DepartureDay; date = date.AddDays(1))
                    {
                            reservedDates.Add(date);
                    }
                }
            }
            List<DateTime> uniqueReservedDatesList = reservedDates.Distinct().ToList();
            uniqueReservedDatesList.Sort();
            return uniqueReservedDatesList;
        }
        public bool IsReservationAvailableToGrade(AccommodationReservation accommodationReservation)
        {
            return accommodationReservation.DepartureDay <= DateTime.Now && accommodationReservation.DepartureDay.AddDays(5) >= DateTime.Now;

        }
        public List<AccommodationReservation> GetAllUngradedReservations()
        {
            List<AccommodationReservation> reservationList = new List<AccommodationReservation>();
            foreach (var reservation in _repository.GetAll())
            {
                if (IsReservationAvailableToGrade(reservation) == false)
                {
                    continue;
                }
                bool flag = _accommodationGradeRepository.IsReservationGraded(reservation.Id);
                reservation.Accommodation = _accommodationRepository.GetById(reservation.Accommodation.Id);
                reservation.Accommodation.Owner = _userRepository.GetById(reservation.Accommodation.Owner.Id);
                if (!flag && reservation.Accommodation.Owner.Id == AccommodationService.SignedOwnerId && reservation.Guest.Id!= AccommodationService.SignedOwnerId)
                {
                    reservationList.Add(reservation);
                }
            }
            return reservationList;
        }
        public List<(DateTime, DateTime)> GetDates(List<DateTime> reservedDates, int difference, DateTime departureDay, DateTime arrivalDay)
        {
            List<(DateTime, DateTime)> rangeOfDates = new List<(DateTime, DateTime)>();

            DateTime endDate = FindDateAfter(reservedDates, difference, departureDay);
            rangeOfDates.Add((endDate.AddDays(-difference), endDate));

            DateTime startDate = FindDateBefore(reservedDates, difference, arrivalDay);
            rangeOfDates.Add((startDate, startDate.AddDays(difference)));
            return rangeOfDates;
        }

        private DateTime FindDateAfter(List<DateTime> reservedDates, int difference, DateTime departureDay)
        {
            DateTime endDate = departureDay;
            while (true)
            {
                bool isEndValid = IsDateValid(reservedDates, endDate, difference);

                if (!isEndValid)
                {
                    return endDate;
                }
                else
                {
                    endDate = endDate.AddDays(-1);
                }
            }
        }
        private DateTime FindDateBefore(List<DateTime> reservedDates, int difference, DateTime arrivalDay)
        {
            DateTime startDate = arrivalDay;
            while (true)
            {
                bool isStartValid = IsDateValid(reservedDates, startDate, difference);

                if (!isStartValid)
                {
                    return startDate;
                }
                else
                {
                    startDate = startDate.AddDays(1);
                }
            }
        }
        private bool IsDateValid(List<DateTime> reservedDates, DateTime date, int difference)
        {
            for (int i = 1; i <= difference; i++)
            {
                DateTime checkDate = date.AddDays(-i);

                if (checkDate == DateTime.Now)
                {
                    return true;
                }

                if (reservedDates.Contains(checkDate))
                {
                    return true;
                }
            }
            return false;
        }
        public List<(DateTime, DateTime)> SuggestOtherDates(DateTime arrivalDay, DateTime departureDay, Accommodation selectedAccommodation)
        {
            int difference = (departureDay - arrivalDay).Days;

            List<DateTime> reservedDates = new List<DateTime>();
            reservedDates = SetReservedDates(arrivalDay, departureDay, selectedAccommodation);

            return GetDates(reservedDates, difference, departureDay, arrivalDay);
        }
        public List<(DateTime, DateTime)> SuggestDatesForRenovation(DateTime startDay, DateTime endDay, int duration, Accommodation selectedAccommodation) 
        {
            List<DateTime> reservedDates = new List<DateTime>();
            reservedDates = SetReservedDates(startDay, endDay, selectedAccommodation);
            List<(DateTime, DateTime)> rangeOfDates = new List<(DateTime, DateTime)>();
            for (DateTime date = startDay; date <= endDay; date = date.AddDays(1))
            {
                int flag = 0;
                DateTime limit = date.AddDays(duration);
                for (DateTime date2 = date; date2 <= limit; date2 = date2.AddDays(1))
                {
                    foreach (var d in reservedDates)
                    {
                        if (date2 == d) 
                        {
                            flag = 1;
                        }
                    }
                }
                if (flag == 0 && date.AddDays(duration)<=endDay) 
                {
                    rangeOfDates.Add((date, date.AddDays(duration)));
                }
            }
            return rangeOfDates;
        }


        public string IsLocationVisited(Location location)
        {
            
            foreach(var reservation in _repository.GetAll())
            {
                reservation.Accommodation = _accommodationRepository.GetById(reservation.Accommodation.Id);
                reservation.Accommodation.Location = _locationRepository.GetById(reservation.Accommodation.Location.Id);
                reservation.Accommodation.Owner = _userRepository.GetById(reservation.Accommodation.Owner.Id);
                reservation.Guest = _userRepository.GetById(SignedFirstGuestId);
                if(reservation.Accommodation.Location.Id == location.Id && reservation.Guest.Id == AccommodationReservationService.SignedFirstGuestId && reservation.ArrivalDay <= DateTime.Now)
                {
                    return "YES";
                }
            }
            return "NO";
        }
        
    }
}
