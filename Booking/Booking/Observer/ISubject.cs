using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Observer
{
	public interface ISubject
	{
		void Subscribe(IObserver observer);

		void Unsubscribe(IObserver observer);

		void NotifyObservers();
	}
}
