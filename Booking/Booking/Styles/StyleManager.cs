using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.Styles
{
    public class StyleManager
    {
        private static ResourceDictionary LightStyle { get; } = new ResourceDictionary { Source = new Uri("/Booking;component/Styles/LightStyle.xaml", UriKind.RelativeOrAbsolute) };
        private static ResourceDictionary DarkStyle { get; } = new ResourceDictionary { Source = new Uri("/Booking;component/Styles/DarkStyle.xaml", UriKind.RelativeOrAbsolute) };

        public static void ApplyLightStyle()
        {
            System.Windows.Application.Current.Resources.MergedDictionaries.Remove(DarkStyle);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(LightStyle);
            System.Windows.Application.Current.Resources["MyWindowStyle"] = System.Windows.Application.Current.Resources["LightStyle"];
        }

        public static void ApplyDarkStyle()
        {
            System.Windows.Application.Current.Resources.MergedDictionaries.Remove(LightStyle);
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(DarkStyle);
            System.Windows.Application.Current.Resources["MyWindowStyle"] = System.Windows.Application.Current.Resources["DarkStyle"];
        }

        public static void RemoveStyles()
        {
            System.Windows.Application.Current.Resources.MergedDictionaries.Remove(LightStyle);
            System.Windows.Application.Current.Resources.MergedDictionaries.Remove(DarkStyle);
        }
    }
}
