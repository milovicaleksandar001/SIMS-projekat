using Booking.Domain.Model;
using Booking.Domain.RepositoryInterfaces;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Repository;
using Booking.Service;
using Booking.Util;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.Application.UseCases
{
    public class SuperGuideService : ISuperGuideService
    {
        private readonly ISuperGuideRepository _repository;
        private readonly ITourRepository _tourRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITourGradeRepository _tourGradeRepository;

        public SuperGuideService()
        {
            _repository = InjectorRepository.CreateInstance<ISuperGuideRepository>();
            _tourRepository = InjectorRepository.CreateInstance<ITourRepository>();
            _userRepository = InjectorRepository.CreateInstance<IUserRepository>();
            _tourGradeRepository = InjectorRepository.CreateInstance<ITourGradeRepository>();
        }

        public void UpdateSuperGuideStatus(string language)
        {
            int SignedGuideId = TourService.SignedGuideId;

            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            List<Tour> guideTours = _tourRepository.GetToursByGuideAndDateRangeAndLanguage(SignedGuideId, oneYearAgo, DateTime.Now, language);


            int tourCount = guideTours.Count;

            if (tourCount < 20)
            {
                MessageBox.Show($"You don't have at least 20 tours in {language} in the last year.", "Insufficient Tours", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double averageGrade = CalculateAverageGrade(guideTours);

            if (averageGrade >= 4.0)
            {

                SuperGuide superGuide = _repository.GetSuperBySignedGuideId(SignedGuideId);
                if (superGuide == null)
                {
                    superGuide = new SuperGuide
                    {
                        Guide = _userRepository.GetById(SignedGuideId),
                        Language = language,
                        AverageGrade = averageGrade,
                        NumberOfTours = tourCount
                    };
                    _repository.Add(superGuide);
                    _userRepository.UpdateSuper(_userRepository.GetById(SignedGuideId));
                    MessageBox.Show("Congratulations, you have become super-guide! ");
                }
                else
                {
                    superGuide.Language = language;
                    superGuide.AverageGrade = averageGrade;
                    superGuide.NumberOfTours = tourCount;
                    _repository.Update(superGuide);
                    MessageBox.Show("You are already super-guide on this language! ");
                }
            }
            else
            {
                MessageBox.Show("You need average grade greater than 4.0 to become super-guide! ");
            }

            /*else
            {
                // Remove the super-guide status for the guide
                SuperGuide superGuide = _repository.GetSuperBySignedGuideId(SignedGuideId);
                if (superGuide != null)
                {
                    _repository.Delete(superGuide);
                }
            }*/
        }

        private double CalculateAverageGrade(List<Tour> guideTours)
        {
            double averageGrade = 0;
            int totalGrades = 0;

            foreach (Tour tour in guideTours)
            {
                TourGrade grade = _tourGradeRepository.GetByTourId(tour.Id);
                if (grade != null)
                {
                    int sumGrades = grade.KnowledgeGuideGrade + grade.LanguageGuideGrade + grade.InterestOfTourGrade;
                    averageGrade += (double)sumGrades / 3;
                    totalGrades++;
                }
            }

            averageGrade /= totalGrades;
            return averageGrade;
        }

        public int CountGuideTours(string language)
        {
            int SignedGuideId = TourService.SignedGuideId;
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            List<Tour> guideTours = _tourRepository.GetToursByGuideAndDateRangeAndLanguage(SignedGuideId, oneYearAgo, DateTime.Now, language);

            int tourCount = guideTours.Count;
            return tourCount;
        }

        public double GuideAverageGrade(string language)
        {
            int SignedGuideId = TourService.SignedGuideId;
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            List<Tour> guideTours = _tourRepository.GetToursByGuideAndDateRangeAndLanguage(SignedGuideId, oneYearAgo, DateTime.Now, language);
            double averageGrade = 0;
            int totalGrades = 0;

            foreach (Tour tour in guideTours)
            {
                TourGrade grade = _tourGradeRepository.GetByTourId(tour.Id);
                if (grade != null)
                {
                    int sumGrades = grade.KnowledgeGuideGrade + grade.LanguageGuideGrade + grade.InterestOfTourGrade;
                    averageGrade += (double)sumGrades / 3;
                    totalGrades++;
                }
            }

            averageGrade /= totalGrades;
            return averageGrade;
        }
    }
}
