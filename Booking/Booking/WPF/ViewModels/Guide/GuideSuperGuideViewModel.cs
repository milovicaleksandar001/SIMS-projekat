using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideSuperGuideViewModel : INotifyPropertyChanged
    {

        public ISuperGuideService superGuideService { get; set; }

        public string _languageTB;
        public string LanguageTB
        {
            get => _languageTB;
            set
            {
                if (_languageTB != value)
                {
                    _languageTB = value;
                    OnPropertyChanged(nameof(LanguageTB));
                }
            }
        }

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged("SelectedLocation");
            }
        }

        public string _countToursTB;
        public string CountToursTB
        {
            get => _countToursTB;
            set
            {
                if (_countToursTB != value)
                {
                    _countToursTB = value;
                    OnPropertyChanged(nameof(CountToursTB));
                }
            }
        }
        
        public string _averageGradeTB;
        public string AverageGradeTB
        {
            get => _averageGradeTB;
            set
            {
                if (_averageGradeTB != value)
                {
                    _averageGradeTB = value;
                    OnPropertyChanged(nameof(AverageGradeTB));
                }
            }
        }

        public ObservableCollection<string> LanguageCollection { get; set; }

        private void FillLocationsComboBox()
        {
            HashSet<string> languages = new HashSet<string>();

            using (StreamReader reader = new StreamReader("../../Resources/Data/tours.csv"))
            {
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split('|');
                    string language = fields[4].Trim(); 
                    languages.Add(language);
                }
            }

            LanguageCollection = new ObservableCollection<string>(languages);
        }


        public RelayCommand Close { get; set; }
        public RelayCommand ApplyForRank { get; set; }
        public RelayCommand SetLanguage { get; set; }
        



        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Window _window;


        public GuideSuperGuideViewModel(Window window) 
        {
            _window = window;

            superGuideService = InjectorService.CreateInstance<ISuperGuideService>();

            LanguageCollection = new ObservableCollection<string>();

            SetCommands();
            FillLocationsComboBox();
        }

        

        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            ApplyForRank = new RelayCommand(ButtonApplyForRank);
            SetLanguage = new RelayCommand(ButtonSetLanguage);
        }

        private void ButtonClose(object param)
        {
            CloseWindow();
        }
        private void CloseWindow()
        {
            _window.Close();
        }

        private void ButtonApplyForRank(object param)
        {
            superGuideService.UpdateSuperGuideStatus(SelectedLanguage);
            SetTB();
        }

        private void ButtonSetLanguage(object param)
        {
            SetTB();
        }

        private void SetTB()
        {
            if (SelectedLanguage != null)
            {
                CountToursTB = superGuideService.CountGuideTours(SelectedLanguage).ToString();
                double pom = superGuideService.GuideAverageGrade(SelectedLanguage);
                if (double.IsNaN(pom))
                {
                    AverageGradeTB = "0";
                }
                else
                {
                    AverageGradeTB = pom.ToString();
                }

            }
            else
            {
                System.Windows.MessageBox.Show("You first need to select language!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
