using Booking.Model;
using Booking.Model.Enums;
using Booking.Service;
using Booking.Styles;
using Booking.WPF.Views.Guest1;
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using LiveChartsCore.SkiaSharpView.Painting.ImageFilters;

namespace Booking.View
{
    public partial class FirstGuestHomePage : Window
    {
        public static bool isTranslated;
        private App app;
        private string currentLanguage;
        public string CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                currentLanguage = value;
            }
        }

       // private bool _isLightMode;

        private bool _isDarkMode;
        public bool IsDarkMode
        {
            get { return _isDarkMode; }
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    OnPropertyChanged(nameof(IsDarkMode));

                    if (_isDarkMode)
                    {
                        StyleManager.ApplyDarkStyle();
                    }
                    else
                    {
                        StyleManager.ApplyLightStyle();
                    }

                    // Send a message to other windows to update their styles
                    Messenger.Default.Send(new ChangeModeMessage(_isDarkMode));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FirstGuestHomePage()
        {
            InitializeComponent();
            this.DataContext = this;
            this.app = System.Windows.Application.Current as App;
            this.app = (App)System.Windows.Application.Current;
            this.CurrentLanguage = "en-US";
            isTranslated = false;
            FrameHomePage.Content = new HomePageFirstGuest(this.FrameHomePage.NavigationService);
        }

        private void MenuItem_Click_HomePage(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new HomePageFirstGuest(this.FrameHomePage.NavigationService);
        }

        private void MenuItem_Click_MyReservations(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new FirstGuestAllReservations(this.FrameHomePage.NavigationService);
           
        }

     

        private void MenuItem_Click_ResheduleRequests(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new FisrtGuestAllRequests(this.FrameHomePage.NavigationService);
        }

        private void MenuItem_Click_Reviews(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new FirstGuestReviews();
        }

        private void MenuItem_Click_LogOut(object sender, RoutedEventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            this.Close();
        }

        private void MenuItem_Click_MyProfile(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new FirstGuestProfile();
        }

        private bool isSRBSelected = false;
        private bool isENGSelected = false;

        public bool IsENGSelected
        {
            get { return isENGSelected; }
            set
            {
                isSRBSelected = value;
                OnPropertyChanged(nameof(isENGSelected));
            }
        }

        public bool IsSRBSelected
        {
            get { return isSRBSelected; }
            set
            {
                isSRBSelected = value;
                OnPropertyChanged(nameof(IsSRBSelected));
            }
        }
        private void MenuItem_Click_ENG(object sender, RoutedEventArgs e)
        {
            //SRBMenuItem.IsSelected = true;
            //ENGMenuItem.IsSelected = false;
            IsSRBSelected = true;
            isENGSelected = false;
            isTranslated = false;
            CurrentLanguage = "en-US";
            app.ChangeLanguage(CurrentLanguage);
        }

        private void MenuItem_Click_SRB(object sender, RoutedEventArgs e)
        {
            isTranslated = true;
            CurrentLanguage = "sr-LATN";
            app.ChangeLanguage(CurrentLanguage);
        }

        
        private void MenuItem_Click_Light(object sender, RoutedEventArgs e)
        {
            
        }

        
        private bool themeIsChecked;

        public bool ButtonIsChecked
        {
            get
            {
                themeIsChecked = Properties.Settings.Default.theme;
                return themeIsChecked;
            }
            set
            {
                Properties.Settings.Default.theme = value;
                Properties.Settings.Default.Save();
                themeIsChecked = value;
                OnPropertyChanged("ThemeIsChecked");
                //ThemeChanged();
                StyleManager.ApplyDarkStyle();
                IsDarkMode = !IsDarkMode;
                App.MessagingService.PublishModeChange(IsDarkMode);
            }
        }




        private void MenuItem_Click_Dark(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void MenuItem_Click_Forums(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new ShowAllForums(this.FrameHomePage.NavigationService);
        }

        private void MenuItem_Click_QuickSerach(object sender, RoutedEventArgs e)
        {
            FrameHomePage.Content = new QuickSearch(this.FrameHomePage.NavigationService);
        }
    }
}
