using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Guest2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Booking.WPF.ViewModels.Guest2
{
    public class RateTourViewModel : INotifyPropertyChanged
    {
        private readonly Window _window;
        private ITourGradeService _gradeService;

        public event PropertyChangedEventHandler PropertyChanged;

        public Tour Tour { get; set; }
        public string Location { get; set; }

        private List<string> Images { get; set; }

        private int _knowledge;
        public int GuidesKnowledge
        {
            get => _knowledge;
            set
            {
                if (value != _knowledge)
                {
                    _knowledge = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _language;
        public int GuidesLanguage
        {
            get => _language;
            set
            {
                if (_language != value)
                {
                    _language = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _amusement;
        public int Amusement
        {
            get => _amusement;
            set
            {
                if (value != _amusement)
                {
                    _amusement = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Comment { get; set; } = string.Empty;

        public RelayCommand Button_Click_Rate { get; set; }
        public RelayCommand Button_Click_AddImages { get; set; }
        public RelayCommand Button_Click_ShowImages { get; set; }
        public RelayCommand Button_Click_NumericUp1 { get; set; }
        public RelayCommand Button_Click_NumericDown1 { get; set; }
        public RelayCommand Button_Click_NumericUp2 { get; set; }
        public RelayCommand Button_Click_NumericDown2 { get; set; }
        public RelayCommand Button_Click_NumericUp3 { get; set; }
        public RelayCommand Button_Click_NumericDown3 { get; set; }
        public RelayCommand Button_Click_Tutorial { get; set; }

        public RateTourViewModel(Window window, Tour tour)
        {
            _window = window;
            Tour = tour;
            Location = tour.Location.State + ", " + tour.Location.City;

            _gradeService = InjectorService.CreateInstance<ITourGradeService>();

            Images = new List<string>();

            GuidesKnowledge = 5;
            GuidesLanguage = 5;
            Amusement = 5;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            Button_Click_Rate = new RelayCommand(RateTourAndGuide);
            Button_Click_AddImages = new RelayCommand(AddImages);
            Button_Click_ShowImages = new RelayCommand(ShowImages);
            Button_Click_NumericUp1 = new RelayCommand(NumericUp1);
            Button_Click_NumericDown1 = new RelayCommand(NumericDown1);
            Button_Click_NumericUp2 = new RelayCommand(NumericUp2);
            Button_Click_NumericDown2 = new RelayCommand(NumericDown2);
            Button_Click_NumericUp3 = new RelayCommand(NumericUp3);
            Button_Click_NumericDown3 = new RelayCommand(NumericDown3);
            Button_Click_Tutorial = new RelayCommand(ShowTutorial);
        }

        private void ShowTutorial(object param)
        {
            TutorialView view = new TutorialView("../../Resources/Videos/RateATour.mp4");
            view.ShowDialog();
        }

        private TourGrade GenerateGrade()
        {
            TourGrade tourGrade = new TourGrade();
            tourGrade.Tour = Tour;
            tourGrade.Guide.Id = Tour.GuideId;
            tourGrade.Guest.Id = TourService.SignedGuideId;
            tourGrade.KnowledgeGuideGrade = GuidesKnowledge;
            tourGrade.LanguageGuideGrade = GuidesLanguage;
            tourGrade.InterestOfTourGrade = Amusement;
            tourGrade.Comment = Comment;

            return tourGrade;
        }

        private void RateTourAndGuide(object param)
        {
            if (IsInputValid())
            {
                _gradeService.AddTourGrade(GenerateGrade());
                _window.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Invalid input!");
            }
        }

        private bool IsInputValid()
        {
            bool knowledge = GuidesKnowledge >= 1 && GuidesLanguage <= 5;
            bool language = GuidesLanguage >= 1 && GuidesLanguage <= 5;
            bool amuse = Amusement >= 1 && Amusement <= 5;
            return knowledge && language && amuse;
        }

        private void NumericUp1(object param)
        {
            if (GuidesKnowledge < 5)
                GuidesKnowledge++;
        }

        private void NumericDown1(object param)
        {
            if (GuidesKnowledge > 1)
                GuidesKnowledge--;
        }
        private void NumericUp2(object param)
        {
            if (GuidesLanguage < 5)
                GuidesLanguage++;
        }

        private void NumericDown2(object param)
        {
            if (GuidesLanguage > 1)
                GuidesLanguage--;
        }
        private void NumericUp3(object param)
        {
            if (Amusement < 5)
                Amusement++;
        }

        private void NumericDown3(object param)
        {
            if (Amusement > 1)
                Amusement--;
        }

        private void AddImages(object param)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentDirectory, "../../Resources/Images"));

            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.InitialDirectory = folderPath;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = dialog.FileName;
                Images.Add(imagePath);
            }
        }

        private void ShowImages(object param)
        {
            if(Images.Count > 0)
            {
                RateTourImagesView view = new RateTourImagesView(Images);
                view.ShowDialog();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
