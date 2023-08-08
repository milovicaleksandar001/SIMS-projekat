using Booking.Commands;
using Booking.Model;
using Booking.WPF.Views.Guest1;
using GalaSoft.MvvmLight.Views;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

using Booking.View;

namespace Booking.WPF.ViewModels
{
    public class GeneratePdfViewModel
    {

        public RelayCommand ButtonClickNo { get; set; }
        public RelayCommand ButtonClickYes { get; set; }
        public Accommodation SelectedAccommodation{ get; set; }

        private  DateTime Arrivalday { get; set; }
        private DateTime DepartureDay { get; set; }

        private int NumberOfGuest { get; set; }
        
        NavigationService NavigationService;
        public GeneratePdfViewModel(Accommodation selectedAcc, DateTime arrivalDay,  DateTime departureDay, int numberOfGuest, NavigationService navigate)
        {
            ButtonClickNo = new RelayCommand(ButtonNo);
            ButtonClickYes = new RelayCommand(ButtonYes);
            NavigationService = navigate;
            Arrivalday = arrivalDay;
            DepartureDay = departureDay;
            NumberOfGuest = numberOfGuest;
        }

        public void ButtonNo(object param)
        {
            NavigationService.Navigate(new FirstGuestAllReservations(NavigationService));
        }

        public void ButtonYes(object param)
        {
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
                Paragraph info = new Paragraph("Arrival Day: " + Arrivalday.ToString("dd/MM/yyyy") + "\n" +
                                 "Departure Day: " + DepartureDay.ToString("dd/MM/yyyy") + "\n" +
                                 "Accommodation Name: " + SelectedAccommodation.Name + "\n" +
                                 "Location: " + SelectedAccommodation.Location.City + ", " + SelectedAccommodation.Location.State + "\n" +
                                 "Type: " + SelectedAccommodation.Type.ToString() + "\n" +
                                 "Cancellation Period: " + SelectedAccommodation.CancelationPeriod + "\n" +
                                 "Owner: " + SelectedAccommodation.Owner.Username + "Petrovic" + "\n" +
                                 "Number of guests: " + NumberOfGuest + "\n" +
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
                if (SelectedAccommodation.Images.Count > 0)
                {
                    string firstImageUrl = SelectedAccommodation.Images[0].Url;
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
                var notificationManager = new NotificationManager();
                NavigationService.Navigate(new FirstGuestAllReservations(NavigationService));
                NotificationContent content = new NotificationContent { Title = "Congratulations!", Message = "You succesfuly reserve your accommodation for: " + Arrivalday.ToString("dd/MM/yyyy") + " - " + DepartureDay.ToString("dd/MM/yyyy") + " !", Type = NotificationType.Success };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
                NavigationService.Navigate(new FirstGuestAllReservations(NavigationService));
            }
        }
    }
}
