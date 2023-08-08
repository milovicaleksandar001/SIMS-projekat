using Booking.Localization;
using Booking.Model;
using Booking.Service;
using Booking.Styles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualKeyboard.Wpf;

namespace Booking
{
    public partial class App : System.Windows.Application
    {
        public static MessagingService MessagingService { get; } = new MessagingService();
        public void ChangeLanguage(string currLang)
        {
            if (currLang.Equals("en-US"))
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
            }
        }
        public App()
        {
          
        }
    }
}
