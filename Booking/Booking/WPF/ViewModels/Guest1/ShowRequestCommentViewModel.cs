using Booking.Commands;
using Booking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.WPF.ViewModels.Guest1
{
    public class ShowRequestCommentViewModel
    {
        public String StatusLabel { get; set; } = String.Empty;
        public String AccommodationLabel { get; set; } = String.Empty;
        public String CommentLabel { get; set; } = String.Empty;
        public String OwnerNameLabel { get; set; } = String.Empty;
        public String RangeLabel { get; set;} = String.Empty;

        private AccommodationReservationRequests SelectedRequest { get; set; }

        public ShowRequestCommentViewModel(AccommodationReservationRequests selecetedRequest)
        {
            SelectedRequest = selecetedRequest;
            SetLables();
        }

        public void SetLables()
        {
            StatusLabel = SelectedRequest.Status.ToString();
            AccommodationLabel = SelectedRequest.AccommodationReservation.Accommodation.Name + "-" + SelectedRequest.AccommodationReservation.Accommodation.Location.State + "-"
                                    + SelectedRequest.AccommodationReservation.Accommodation.Type.ToString();

            if (SelectedRequest.Status == Model.Enums.RequestStatus.PENDNING)
            {
                CommentLabel = "There is no owner's comment!";
            }
            else
            {
                CommentLabel = SelectedRequest.Comment;
            }
            OwnerNameLabel = SelectedRequest.AccommodationReservation.Accommodation.Owner.Username;
            RangeLabel = SelectedRequest.NewArrivalDay.ToString("dd/MM/yyyy") + " - " + SelectedRequest.NewDeparuteDay.ToString("dd/MM/yyyy");

        }
    }
}
