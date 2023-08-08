using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Util;
using Booking.WPF.Views;
using Booking.WPF.Views.Guest1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class ShowAllForumsViewModel : IObserver
    {
        public ObservableCollection<Forum> Forums { get; set; }
        public IForumService ForumService { get; set; }
        public Forum SelectedForum { get; set; }
        public RelayCommand Show_Comments_Button { get; set; }
        public RelayCommand Create_Forum_Button { get; set; }
        public RelayCommand Close_Forum_Button { get; set; }

        public NavigationService navigationService;

        public ShowAllForumsViewModel(NavigationService navigation)
        {
            ForumService = InjectorService.CreateInstance<IForumService>();
            Forums = new ObservableCollection<Forum>(ForumService.GetAll());
            Show_Comments_Button = new RelayCommand(ShowForumComments);
            Create_Forum_Button = new RelayCommand(CreateForumButton);
            Close_Forum_Button = new RelayCommand(CloseForumButton);
            ForumService.Subscribe(this);
            navigationService = navigation;
        }
        public void CreateForumButton(object sender)
        {
            navigationService.Navigate(new CreateForum(navigationService));
        }

        public void CloseForumButton(object sender)
        {
            SelectedForum.Status = "CLOSED";
            ForumService.UpdateForum(SelectedForum);
        }

        public void ShowForumComments(object param)
        {
            navigationService.Navigate(new ShowAllForumComments(SelectedForum));
        }
        public void Update()
        {
            Forums.Clear();
            foreach(Forum f in ForumService.GetAll())
            {
                Forums.Add(f);
            }
        }
    }
}
