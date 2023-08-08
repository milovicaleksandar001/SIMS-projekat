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
using Booking.Model;
using Booking.Model.Images;
using Booking.Model.Enums;
using System.IO;
using System.Collections.ObjectModel;
using Booking.Service;
using Booking.Domain.ServiceInterfaces;
using Booking.Util;
using Booking.WPF.Views.Owner;
using Booking.WPF.ViewModels.Owner;
using VirtualKeyboard.Wpf;

namespace Booking.View
{
    /// <summary>
    /// Interaction logic for OwnerRegisterAccommodation.xaml
    /// </summary>
    public partial class OwnerRegisterAccommodation : Window
    {
        public OwnerRegisterAccommodation()
        {
            InitializeComponent();
            this.DataContext = new OwnerRegisterAccommodationViewModel(this);
            
        }




    }
}