using Booking.Commands;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class OwnerAllForumCommentsViewModel : IObserver, INotifyPropertyChanged
    {
        public ObservableCollection<ForumComment> ForumComments { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public IForumCommentService ForumCommentService;
        public IForumService ForumService;
        public ILocationService LocationService;
        public String ForumLabel { get; set; } = String.Empty;

        public Forum SelectedForum;
        public ForumComment SelectedComment { get; set; } //nez hoce trebati ovo neka stoji :)
        public RelayCommand LeaveComment { get; set; }
        public RelayCommand Report { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand Wizard { get; set; }
        private readonly Window _window;

        public OwnerAllForumCommentsViewModel(Forum selectedForum, Window window)
        {
            _window = window;
            ForumCommentService = InjectorService.CreateInstance<IForumCommentService>();
            ForumService = InjectorService.CreateInstance<IForumService>();
            LocationService = InjectorService.CreateInstance<ILocationService>();
            SelectedForum = selectedForum;
            ForumLabel = SetForumLabel(SelectedForum);
            ForumCommentService.Subscribe(this);
            ForumComments = new ObservableCollection<ForumComment>(ForumCommentService.GetForumComments(selectedForum));
            LeaveComment = new RelayCommand(LeaveCommentButton);
            Report = new RelayCommand(ReportComment);
            Close = new RelayCommand(CloseWindow);
            Wizard = new RelayCommand(OpenWizard);
            OwnerComment = "";
        }
        public string _ownerComment;
        public string OwnerComment
        {
            get => _ownerComment;
            set
            {
                if (_ownerComment != value)
                {
                    _ownerComment = value;
                    OnPropertyChanged();
                }
            }
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(14);
            wizard.Show();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Update()
        {
            ForumComments.Clear();

            foreach (ForumComment forumComment in ForumCommentService.GetForumComments(SelectedForum))
            {
                ForumComments.Add(forumComment);
            }
        }
        public void ReportComment(object sender) 
        {
            if (SelectedComment == null) 
            {
                System.Windows.MessageBox.Show("Please select a comment", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            if (SelectedForum.Status.Equals("CLOSED"))
            {
                System.Windows.MessageBox.Show("You can not report a comment on a closed forum", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);                
                return;
            }
            if (!LocationService.DoesOwnerHaveLocation(SelectedForum.Location.Id))
            {
                System.Windows.MessageBox.Show("You can not report on this forum", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);               
                return;
            }
            if (SelectedComment.Visited.Equals("YES")) 
            {
                System.Windows.MessageBox.Show("He was on the location", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);                
                return;
            }
            if (SelectedComment.Visited.Equals("OWNER"))
            {
                System.Windows.MessageBox.Show("He is a owner", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            SelectedComment.Reports++;
            ForumCommentService.UpdateForumComment(SelectedComment);
            ForumCommentService.NotifyObservers();
        }

        public void LeaveCommentButton(object sender)
        {
            if (SelectedForum.Status.Equals("CLOSED"))
            {
                System.Windows.MessageBox.Show("You can not comment on a closed forum", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);                
                return;
            }
            if (!LocationService.DoesOwnerHaveLocation(SelectedForum.Location.Id))
            {
                System.Windows.MessageBox.Show("You can not comment on this forum", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);                
                return;
            }
            ForumComment newForumComment = new ForumComment();
            newForumComment.Forum = SelectedForum;
            newForumComment.User.Id = AccommodationService.SignedOwnerId;
            newForumComment.Reports = 0;
            newForumComment.Comment = OwnerComment;
            newForumComment.Visited = "OWNER";
            ForumCommentService.Create(newForumComment);
            ForumCommentService.NotifyObservers();
            ForumService.NotifyObservers();
            System.Windows.MessageBox.Show("Comment succesfully added", "Success", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        private String SetForumLabel(Forum forum)
        {
            return forum.User.Username + " for location:" + forum.Location.State + "-" + forum.Location.City;
        }
        private void CloseWindow(object param)
        {
            _window.Close();
        }
    }
}
