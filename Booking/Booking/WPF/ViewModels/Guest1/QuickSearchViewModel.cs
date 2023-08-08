using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Booking.WPF.ViewModels.Guest1
{
    public class QuickSearchViewModel
    {

        NavigationService navigationService;


        public QuickSearchViewModel(NavigationService navigate)
        {
            navigationService = navigate;
        }
    }
}
