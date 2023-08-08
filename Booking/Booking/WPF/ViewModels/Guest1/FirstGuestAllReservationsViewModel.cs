using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Util;
using Booking.View;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;
using Booking.WPF.Views.Guest1;

namespace Booking.WPF.ViewModels.Guest1
{
    public class FirstGuestAllReservationsViewModel: IObserver
    {
        public ObservableCollection<AccommodationReservation> Reservations { get; set; }

        public IAccommodationReservationService _accommodationReservationService;

        public INotificationService _notificationService;

        public IAccommodationAndOwnerGradeService accommodationAndOwnerGradeService;
        public AccommodationReservation SelectedReservation { get; set; }
        public NavigationService NavigationService { get; set; }

        public RelayCommand Button_Click_RateAccommodationAndOwner { get; set; }
        public RelayCommand Button_Click_ResheduleAccommodationReservation { get; set; }
        public RelayCommand Button_Click_CancleReservation { get; set; }
        public RelayCommand Button_Click_GeneratePDF { get; set; }

        public RelayCommand Show_Details_button { get; set; }

        public FirstGuestAllReservationsViewModel(NavigationService navigationService)
        {
            SelectedReservation = new AccommodationReservation();
            accommodationAndOwnerGradeService = InjectorService.CreateInstance<IAccommodationAndOwnerGradeService>();
            _accommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            _notificationService = InjectorService.CreateInstance<INotificationService>();

            Reservations = new ObservableCollection<AccommodationReservation>(_accommodationReservationService.GetGeustsReservatonst());

            _accommodationReservationService.Subscribe(this);
            
            NavigationService = navigationService;

            this.Button_Click_RateAccommodationAndOwner = new RelayCommand(ButtonRateAccommodationAndOwner);
            this.Button_Click_ResheduleAccommodationReservation = new RelayCommand(ButtonResheduleAccommodationReservation);
            this.Button_Click_CancleReservation = new RelayCommand(ButtonCancleReservation);
            this.Button_Click_GeneratePDF = new RelayCommand(GeneratePdf);
            this.Show_Details_button = new RelayCommand(ShowDetails);
        }
        public void ShowDetails(object sender)
        {
            if (SelectedReservation == null)
            {
                var notificationManager = new NotificationManager();
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Please select your reservation!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
                return;
            }
            else
            {
                NavigationService.Navigate(new ReservationDetails(SelectedReservation));
            }
        }


        public void GeneratePdf(object sender)
        {
            if (SelectedReservation == null)
            {
                var notificationManager = new NotificationManager();
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Please select your reservation!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.DefaultExt = "pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Generate the file path based on the user's selection
                string filePath = saveFileDialog.FileName;

                // Create a new PDF document
                Document document = new Document();

                // Create a new instance of PdfWriter to write to the PDF document
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                // Open the document for writing
                document.Open();

                // Add the header
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;
                headerTable.DefaultCell.Border = Rectangle.NO_BORDER;

                // Add header text
                PdfPCell headerTextCell = new PdfPCell(new Phrase("Booking Application", new Font(Font.FontFamily.HELVETICA, 12)));
                headerTextCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                headerTextCell.Border = Rectangle.NO_BORDER;
                headerTable.AddCell(headerTextCell);

                // Add the header line
                PdfPCell headerLineCell = new PdfPCell();
                headerLineCell.Border = Rectangle.NO_BORDER;
                headerLineCell.FixedHeight = 1f;
                headerLineCell.BorderWidthBottom = 1f;
                headerLineCell.BorderColorBottom = BaseColor.BLACK;
                headerTable.AddCell(headerLineCell);

                // Add the header table to the document
                document.Add(headerTable);

                // Add the image and title
                string imagePath = "C:\\Users\\Kiki\\Desktop\\sims_druga_tacka\\booking\\Booking\\Booking\\Resources\\Images\\pdfPicture.png";
                if (!string.IsNullOrEmpty(imagePath))
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                    image.ScaleToFit(40f, 40f);
                    image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    Paragraph title = new Paragraph();
                    title.Add(new Chunk(image, 0, 0, true));
                    title.Add(new Phrase("RESERVATION REPORT", new Font(Font.FontFamily.HELVETICA, 15, Font.BOLD)));
                    title.SpacingBefore = 20f;
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                }

                // Add the information paragraph
                Paragraph info = new Paragraph("Arrival Day: " + SelectedReservation.ArrivalDay.ToString("dd/MM/yyyy") + "\n" +
                                 "Departure Day: " + SelectedReservation.DepartureDay.ToString("dd/MM/yyyy") + "\n" +
                                 "Accommodation Name: " + SelectedReservation.Accommodation.Name + "\n" +
                                 "Location: " + SelectedReservation.Accommodation.Location.City + ", " + SelectedReservation.Accommodation.Location.State + "\n" +
                                 "Type: " + SelectedReservation.Accommodation.Type.ToString() + "\n" +
                                 "Cancellation Period: " + SelectedReservation.Accommodation.CancelationPeriod + "\n" +
                                 "Owner: " + SelectedReservation.Accommodation.Owner.Username + "Petrovic" + "\n" +
                                 "Number of guests: " + "2" + "\n" +
                                 "Guest: " + "Kristina Zelic",
                                 new Font(Font.FontFamily.HELVETICA, 12));
                info.SpacingBefore = 20f;
                info.Alignment = Element.ALIGN_LEFT;
                document.Add(info);

                // Add the title for the unordered list
                Paragraph listTitle = new Paragraph("Accommodation Details:", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD));
                listTitle.SpacingBefore = 10f;
                listTitle.Alignment = Element.ALIGN_LEFT;
                document.Add(listTitle);

                // Add the unordered list
                List unorderedList = new List(List.UNORDERED);
                unorderedList.SetListSymbol("\u2022"); // Use bullet point symbol

                unorderedList.Add(new ListItem("  Check-in time: 2:00 PM"));
                unorderedList.Add(new ListItem("  Check-out time: 11:00 AM"));
                unorderedList.Add(new ListItem("  Free Wi-Fi available"));
                unorderedList.Add(new ListItem("  No pets allowed"));

                document.Add(unorderedList);

                // Add the custom paragraph
                Paragraph customParagraph = new Paragraph();
                customParagraph.Add(new Chunk("Important Notice: ", new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.RED)));
                customParagraph.Add("Smoking is strictly prohibited in all areas of the accommodation. Violators may be subject to penalties.");

                document.Add(customParagraph);

                // Add spacing between paragraph and image
                document.Add(new Paragraph(" ")); // Add an empty paragraph for spacing

                // Add the first image
                if (SelectedReservation.Accommodation.Images.Count > 0)
                {
                    string firstImageUrl = SelectedReservation.Accommodation.Images[0].Url;
                    if (!string.IsNullOrEmpty(firstImageUrl))
                    {
                        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(firstImageUrl);
                        image.ScaleToFit(400f, 400f);
                        image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                        document.Add(image);
                    }
                }

                // Add spacing between line separator and footer
                document.Add(new Paragraph(" ")); // Add an empty paragraph for spacing

                // Add centered paragraph below the image
                Paragraph thankYouParagraph = new Paragraph();
                thankYouParagraph.Alignment = Element.ALIGN_CENTER;
                thankYouParagraph.SpacingBefore = 10f;
                thankYouParagraph.Add(new Chunk("Thank you for your reservation, ", new Font(Font.FontFamily.HELVETICA, 12, Font.ITALIC)));
                thankYouParagraph.Add(new Chunk("hope to see you soon!", new Font(Font.FontFamily.HELVETICA, 12, Font.ITALIC | Font.BOLD)));
                document.Add(thankYouParagraph);


                // Add spacing between line separator and footer
                document.Add(new Paragraph(" ")); // Add an empty paragraph for spacing
                                                  // Add spacing between paragraph and image

                // Add the line separator
                LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                document.Add(line);


                // Add the footer
                PdfPTable footerTable = new PdfPTable(1);
                footerTable.WidthPercentage = 100;
                footerTable.DefaultCell.Border = Rectangle.NO_BORDER;

                // Add the footer text with page number
                PdfPCell footerTextCell = new PdfPCell(new Phrase("Page " + writer.PageNumber, new Font(Font.FontFamily.HELVETICA, 10)));
                footerTextCell.Border = Rectangle.NO_BORDER;
                footerTextCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                footerTable.AddCell(footerTextCell);

                // Add the footer line
                PdfPCell footerLineCell = new PdfPCell();
                footerLineCell.Border = Rectangle.NO_BORDER;
                footerLineCell.FixedHeight = 1f;
                footerTable.AddCell(footerLineCell);

                // Add the footer table to the document
                document.Add(footerTable);

                // Close the document
                document.Close();

                // Open the generated PDF file
                Process.Start(filePath);
            }
        }

        private void ButtonRateAccommodationAndOwner(object param)
        {
            var notificationManager = new NotificationManager();
            NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "You are unable to rate you accomodation and owner", Type = NotificationType.Error };


            if (accommodationAndOwnerGradeService.PermissionForRating(SelectedReservation))
            {
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(30));
            }
            else
            {
                NavigationService.Navigate(new RateAccommodationAndOwner(SelectedReservation, NavigationService));
            }
        }

        private void ButtonResheduleAccommodationReservation(object param)
        {
            var notificationManager = new NotificationManager();

            if (SelectedReservation == null)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Please select your reservation!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else
            {
                NavigationService.Navigate(new ReshaduleAccommodationReservation(SelectedReservation, NavigationService));
            }
        }

        private void ButtonCancleReservation(object param)
        {
            bool cancel = _accommodationReservationService.IsAbleToCancleResrvation(SelectedReservation);

            var notificationManager = new NotificationManager();
            NotificationContent contentDenied = new NotificationContent { Title = "Permission denied!", Message = "You are unable to cancle yout resevartion!", Type = NotificationType.Error };
            NotificationContent contentAllowed = new NotificationContent { Title = "Succesful!", Message = "Your reservation is cancelled!", Type = NotificationType.Success };

            if (cancel)
            {
                _notificationService.MakeCancellationNotification(SelectedReservation);
                _accommodationReservationService.Delete(SelectedReservation);

                notificationManager.Show(contentAllowed, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else if (SelectedReservation == null)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Please select your reservation!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else
            {
                notificationManager.Show(contentDenied, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(30));
            }
        }
        public void Update()
        {
            Reservations.Clear();
            //ovde logicko brisanje
            foreach (var reservation in _accommodationReservationService.GetGeustsReservatonst())
            {
                Reservations.Add(reservation);
            }
        }


    }
}
