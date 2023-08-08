using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Styles
{
    public class ChangeModeMessage
    {
        public bool IsDarkMode { get; }
        public ChangeModeMessage(bool isDarkMode) { IsDarkMode = isDarkMode; }
    }
}
