using Booking.Application.UseCases;
using Booking.Commands;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using Booking.View;
using Booking.WPF.Views.Guest1;
using GalaSoft.MvvmLight.Messaging;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using Paragraph = iTextSharp.text.Paragraph;
using Image = iTextSharp.text.Image;
using iTextSharp.text.pdf.draw;
using Chunk = iTextSharp.text.Chunk;
using List = iTextSharp.text.List;
using ListItem = iTextSharp.text.ListItem;

namespace Booking.WPF.ViewModels.Guest1
{
    public class BookAccommodationViewModel:INotifyPropertyChanged , IDataErrorInfo 
    {
        public IAccommodationReservationService AccommodationReservationService { get; set; }
        public ISuperGuestService SuperGuestService { get; set; }

        public String AccommodationLabel { get; set; } = String.Empty;

        public Accommodation SelectedAccommodation;

        
       // public RelayCommand Pdf_button { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        public string _numberOfGuests;
        public string NumberOfGuests
        {
            get => _numberOfGuests;
            set
            {
                if (_numberOfGuests != value)
                {
                    _numberOfGuests = value;
                    OnPropertyChanged();
                }
            }

        }

        public DateTime _arrivalDay;
        public DateTime ArrivalDay
        {
            get => _arrivalDay;
            set
            {
                if (_arrivalDay != value)
                {
                    _arrivalDay = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime _departureDay;
        public DateTime DepartureDay
        {
            get => _departureDay;
            set
            {
                if (_departureDay != value)
                {
                    _departureDay = value;
                    OnPropertyChanged();
                }
            }
        }
        public RelayCommand Reserve_Button_Click { get; set; }
        public RelayCommand Cancle_Button_Click { get; set; }

        public NavigationService NavigationService { get; set; }


        public string Error => null;
        private Regex _numberOfGuestsRegex = new Regex("^[1-9][0-9]?$");

       

        public string this[string columnName]
        {
            get
            {
                if (columnName == "NumberOfGuests")
                {
                   if(NumberOfGuests == String.Empty)
                   {
                        if (FirstGuestHomePage.isTranslated) //ovo zbog translate 
                        {
                            return "Ovo polje je obavezno!";
                        }
                        return "This filed is required!";
                   }
                   else
                   {
                        Match match = _numberOfGuestsRegex.Match(NumberOfGuests);
                        if (!match.Success)
                        {
                            if (FirstGuestHomePage.isTranslated)
                            {
                                return "Broj gostiju nije u pravilnom formatu!";
                            }
                            return "Number of guests is not in correct format!";
                        }
                   }
                    
                }
                return null;
            }
        }

        private readonly string[] _validatedProperties = { "NumberOfGuests" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        public BookAccommodationViewModel(Accommodation selectedAccommodation, NavigationService navigationService)
        {
            SelectedAccommodation = selectedAccommodation;
            SetAccommodationLabel();
            Reserve_Button_Click = new RelayCommand(ReserveButton);
            Cancle_Button_Click = new RelayCommand(CancleButton);
           // Pdf_button = new RelayCommand(PdfButton);
            DepartureDay = DateTime.Now;
            ArrivalDay = DateTime.Now;
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            SuperGuestService = InjectorService.CreateInstance<ISuperGuestService>();
            NavigationService = navigationService;
            NumberOfGuests = String.Empty;
            
        }

        public void PdfButton(object sender)
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
                Paragraph info = new Paragraph("Arrival Day: " + ArrivalDay.ToString("dd/MM/yyyy") + "\n" +
                                 "Departure Day: " + DepartureDay.ToString("dd/MM/yyyy") + "\n" +
                                 "Accommodation Name: " + SelectedAccommodation.Name + "\n" +
                                 "Location: " + SelectedAccommodation.Location.City + ", " + SelectedAccommodation.Location.State + "\n" +
                                 "Type: " + SelectedAccommodation.Type.ToString() + "\n" +
                                 "Cancellation Period: " + SelectedAccommodation.CancelationPeriod + "\n" +
                                 "Owner: " + SelectedAccommodation.Owner.Username + "Petrovic" + "\n" +
                                 "Number of guests: " + NumberOfGuests + "\n" +
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
            }

        }

        private object _currentPage;

        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                }
            }
        }



        public void SetAccommodationLabel()
        {
            AccommodationLabel = SelectedAccommodation.Name + "-" + SelectedAccommodation.Location.State + "-" + SelectedAccommodation.Location.City;
        }

        public void ReserveButton(object param)
        {
            var notificationManager = new NotificationManager();

            if (IsValid == false)
            {
                NotificationContent content = new NotificationContent { Title = "Worning!", Message = "You have to put number of guests!", Type = NotificationType.Warning };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
                return;
            }

           
            if (ArrivalDay > DepartureDay)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Your ARRIVAL day is after DEPARTURE day", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else if ((DepartureDay - ArrivalDay).Days < SelectedAccommodation.MinNumberOfDays)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Requirements for the minimal number of days for the reservation are not accomplished", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else if (NumberOfGuests.Equals("") || int.Parse(NumberOfGuests) > SelectedAccommodation.Capacity)
            {
                NotificationContent content = new NotificationContent { Title = "Permission denied!", Message = "Number of guests is not valid!", Type = NotificationType.Error };
                notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
            }
            else
            {
                bool IsReserved = AccommodationReservationService.Reserve(ArrivalDay, DepartureDay, SelectedAccommodation);

                if (IsReserved)
                {
                    SuperGuestService.ReduceBonusPoints();
                    NotificationContent content = new NotificationContent { Title = "Congratulations!", Message = "You succesfuly reserve your accommodation for: " + ArrivalDay.ToString("dd/MM/yyyy") + " - " + DepartureDay.ToString("dd/MM/yyyy") + " !", Type = NotificationType.Success };
                    notificationManager.Show(content, areaName: "WindowArea", expirationTime: TimeSpan.FromSeconds(5));
                    NavigationService.Navigate(new FirstGuestAllReservations(NavigationService));
                }
                else
                {
                    List<(DateTime, DateTime)> suggestedDateRanges = AccommodationReservationService.SuggestOtherDates(ArrivalDay, DepartureDay, SelectedAccommodation);

                    ShowAvailableDatesDialog(suggestedDateRanges, SelectedAccommodation);
                }
            }

           
        }

        public void CancleButton(object param)
        {
            NavigationService.GoBack();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowAvailableDatesDialog(List<(DateTime, DateTime)> suggestedDateRanges, Accommodation selectedAccommodation)
        {
            NavigationService.Navigate(new AccommodationDateSugestions(suggestedDateRanges, selectedAccommodation));
        }

    }
}
