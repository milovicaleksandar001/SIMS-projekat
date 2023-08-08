using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Repository;
using Booking.Service;
using Booking.Util;
using Booking.WPF.ViewModels.Guide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Booking.View
{
	public partial class SignInForm : Window
	{
		public IUserService _userService { get; set; }
		public INotificationService _notificationService { get; set; }

		private string _username;
		public string Username
		{
			get => _username;
			set
			{
				if (value != _username)
				{
					_username = value;
					OnPropertyChanged();
				}
			}
		}

        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public SignInForm()
		{
			InitializeComponent();
			DataContext = this;
            _userService = InjectorService.CreateInstance<IUserService>();
            _notificationService = InjectorService.CreateInstance<INotificationService>();
			
			//_repository.Load();
	
		}
		private void SignIn(object sender, RoutedEventArgs e)
		{
            User user = _userService.GetByUsername(Username);
            
			GuideHomePageViewModel._username = usernameTextBox.Text;
            
            List<Notification> notifications = _notificationService.GetUserNotifications(user);

            if (user != null)
			{
				if (user.Password == txtPassword.Password)
				{

					if(user.Role == 1)
					{
					
                        AccommodationService.SignedOwnerId = user.Id;
						OwnerHomePage ownerHomePage = new OwnerHomePage();
						ownerHomePage.Show();
                        _notificationService.SendNotification(notifications, user);
                        Close();
					}
                    else if (user.Role == 2)
                    {
                        TourService.SignedGuideId = user.Id;
                        GuideHomePage guideHomePage = new GuideHomePage();
                        guideHomePage.Show();
                        Close();
                    }
                    else if(user.Role == 3)
					{
						AccommodationReservationService.SignedFirstGuestId = user.Id;
                        FirstGuestHomePage fisrtGuestHomePage = new FirstGuestHomePage();
                        fisrtGuestHomePage.Show();
                        _notificationService.SendToastNotification(user);
						Close();
                    }
                    else if (user.Role == 4)
                    {
                        TourService.SignedGuideId = user.Id;
                        SecondGuestHomePage secondGuestHomePage = new SecondGuestHomePage();
						secondGuestHomePage.Show();
						Close();
					}

                }
                else
				{
					MessageBox.Show("Wrong password!");
				}
			}
			else
			{
				MessageBox.Show("Wrong username!");
			}

		}

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SignIn(sender, e);
            }
        }

        private void AboutUs(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autors of the project: \n \tKristina Zelić RA4/2020 \n \tPetar Kovačević RA25/2020  \n \tAleksandar Milović RA67/2020 \n \tMiljan Lazić RA212/2020");
        }
    }
}
