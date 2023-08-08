using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class OwnerAllForumsViewModel : IObserver
    {
        public ObservableCollection<Forum> Forums { get; set; }
        public IForumService ForumService { get; set; }
        public Forum SelectedForum { get; set; }
        public RelayCommand ShowComments { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand Wizard { get; set; }
        private readonly Window _window;

        public OwnerAllForumsViewModel(Window window)
        {
            _window = window;
            ForumService = InjectorService.CreateInstance<IForumService>();
            Forums = new ObservableCollection<Forum>(ForumService.GetAll());
            ShowComments = new RelayCommand(ShowForumComments);
            Close = new RelayCommand(CloseWindow);
            Wizard = new RelayCommand(OpenWizard);
        }
        private void CloseWindow(object param)
        {
            _window.Close();
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(13);
            wizard.Show();
        }
        public void Update()
        {
            Forums.Clear();

            foreach (Forum forum in ForumService.GetAll())
            {
                Forums.Add(forum);
            }
        }
        private void ShowForumComments(object param)
        {
            if (SelectedForum == null)
            {
                System.Windows.MessageBox.Show("Please select a forum", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);               
                return;
            }
            OwnerAllForumComments ownerAllForumComments = new OwnerAllForumComments(SelectedForum);
            ownerAllForumComments.Show();
        }
    }
}
