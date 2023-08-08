using Booking.Commands;
using Booking.Domain.DTO;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Util;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class SiteProposalsViewModel
    {
        public ObservableCollection<Suggestion> GoodLocations { get; set; }
        public ObservableCollection<Suggestion> BadLocations { get; set; }
        public ILocationService LocationService { get; set; }
        public RelayCommand Close { get; set; }
        public RelayCommand Wizard { get; set; }
        private readonly Window _window;
        public SiteProposalsViewModel(Window window)
        {
            _window = window;
            LocationService = InjectorService.CreateInstance<ILocationService>();
            Close = new RelayCommand(CloseWindow);
            Wizard = new RelayCommand(OpenWizard);
            LocationService.GetLocationsForSuggestions();
            GoodLocations = new ObservableCollection<Suggestion>(LocationService.GetBestLocations());
            BadLocations = new ObservableCollection<Suggestion>(LocationService.GetWorstLocations());
        }
        private void CloseWindow(object param)
        {
            _window.Close();
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(4);
            wizard.Show();
        }
    }
}
