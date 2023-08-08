using Booking.Commands;
using Booking.Domain.DTO;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using System.Windows.Forms;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using Booking.View;
using Booking.WPF.Views.Owner;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VirtualKeyboard.Wpf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace Booking.WPF.ViewModels.Owner
{
    public class OwnerHomePageViewModel: IObserver, INotifyPropertyChanged
    {
        public IAccommodationReservationService AccommodationReservationService { get; set; }
        public ObservableCollection<AccommodationReservation> Reservations { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public Accommodation SelectedAccommodation { get; set; }
        public ObservableCollection<Accommodation> Accommodations { get; set; }
        public IAccommodationService _accommodationService { get; set; }
        public IUserService _userService { get; set; }
        public RelayCommand OpenRegisterAccommodation { get; set; }
        public RelayCommand OpenSiteProposals { get; set; }
        public RelayCommand OpenDateMove { get; set; }
        public RelayCommand OpenGradingGuests { get; set; }
        public RelayCommand OpenViewReviews { get; set; }
        public RelayCommand OwnerLogOut { get; set; }
        public RelayCommand OpenSuperOwner { get; set; }
        public RelayCommand OpenAccommodationStatistics { get; set; }
        public RelayCommand OpenSchedulingRenovations { get; set; }
        public RelayCommand OpenShowRenovations { get; set; }
        public RelayCommand OpenForums { get; set; }
        public RelayCommand Wizard { get; set; }
        public RelayCommand PDF { get; set; }
        public RelayCommand ShowPictures { get; set; }

        private readonly Window _window;
        public int _pDFYear;
        public int PDFYear
        {
            get => _pDFYear;
            set
            {
                if (_pDFYear != value)
                {
                    _pDFYear = value;
                    OnPropertyChanged();
                }
            }
        }
        public OwnerHomePageViewModel(Window window)
        {
            VKeyboard.Listen<System.Windows.Controls.TextBox>(e => e.Text);
            VKeyboard.Config(typeof(KeyBoardCustom));
            _window = window;
            _accommodationService = InjectorService.CreateInstance<IAccommodationService>();
            _userService = InjectorService.CreateInstance<IUserService>();
            AccommodationReservationService = InjectorService.CreateInstance<IAccommodationReservationService>();
            _accommodationService.Subscribe(this);
            PDFYear = 0;
            User user1 = new User();
            user1 = _userService.GetById(AccommodationService.SignedOwnerId);
            Reservations = new ObservableCollection<AccommodationReservation>(AccommodationReservationService.GetAllUngradedReservations());
            Accommodations = new ObservableCollection<Accommodation>(_accommodationService.GetOwnerAccommodations());
            if (Reservations.Count != 0)
            {
                System.Windows.MessageBox.Show("Number of guests to grade: " + Reservations.Count.ToString(), "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            }
            if (user1.Wizard == 0) 
            {
                user1.Wizard = 1;
                _userService.SaveWizard(user1);
                Wizard wizard = new Wizard(0);
                wizard.Show();
            }
            SetCommands();
        }
        public void SetCommands()
        {
            OpenRegisterAccommodation = new RelayCommand(RegisterAccomodation);
            OpenSiteProposals = new RelayCommand(SiteProposal);
            OpenDateMove = new RelayCommand(DateMove);
            OpenGradingGuests = new RelayCommand(GradingGuests);
            OpenViewReviews = new RelayCommand(ViewReviews);
            OwnerLogOut = new RelayCommand(LogOut);
            OpenSuperOwner = new RelayCommand(SuperOwner);
            ShowPictures = new RelayCommand(OpenPictures);
            OpenSchedulingRenovations = new RelayCommand(SchedulingRenovation);
            OpenShowRenovations = new RelayCommand(ShowRenovation);
            OpenAccommodationStatistics = new RelayCommand(AccommodationStatistics);
            Wizard = new RelayCommand(OpenWizard);
            OpenForums = new RelayCommand(ForumsOwner);
            PDF = new RelayCommand(OwnerPDF);
        }
        private void OwnerPDF(object param)
        {
            if (SelectedAccommodation == null)
            {
                System.Windows.MessageBox.Show("Select a accommodation please", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }
            List<OwnerYearStatistic> list = new List<OwnerYearStatistic>();
            list = AccommodationReservationService.GetYearStatistics(SelectedAccommodation);
            int flag = 0;
            foreach (var stat in list)
            {
                if (stat.Year == PDFYear)
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                System.Windows.MessageBox.Show("There are no statistics for that year", "Information", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", FileName = "Accommodation_Statistics", ValidateNames = true, InitialDirectory = GetDownloadsPath() })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.A4);
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        String date = DateTime.Now.ToString("dd.MM.yyyy. HH:mm");
                        Paragraph para = new Paragraph(date, new Font(Font.FontFamily.HELVETICA, 12));
                        para.Alignment = Element.ALIGN_LEFT;
                        doc.Add(para);

                        String user = "Generated by " + _userService.GetById(AccommodationService.SignedOwnerId).Username;
                        Paragraph para3 = new Paragraph(user, new Font(Font.FontFamily.HELVETICA, 12));
                        para3.Alignment = Element.ALIGN_LEFT;
                        doc.Add(para3);

                        String accommodation = "For accommodation: " + SelectedAccommodation.Name + " Location:" + SelectedAccommodation.Location.State + "/" + SelectedAccommodation.Location.City;
                        Paragraph para2 = new Paragraph(accommodation, new Font(Font.FontFamily.HELVETICA, 12));
                        para2.Alignment = Element.ALIGN_LEFT;
                        doc.Add(para2);


                        Paragraph para1 = new Paragraph("Accommodation statistics for "+PDFYear.ToString(), new Font(Font.FontFamily.HELVETICA, 20));
                        para1.Alignment = Element.ALIGN_CENTER;
                        para1.SpacingAfter = 10;
                        doc.Add(para1);

                        PdfPTable table = new PdfPTable(5);

                        PdfPCell cell1 = new PdfPCell(new Phrase("Month", new Font(Font.FontFamily.HELVETICA, 10)));
                        cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        cell1.BorderWidthBottom = 1f;
                        cell1.BorderWidthTop = 1f;
                        cell1.BorderWidthLeft = 1f;
                        cell1.BorderWidthRight = 1f;
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell1.VerticalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell1);

                        PdfPCell cell2 = new PdfPCell(new Phrase("Number of reservations", new Font(Font.FontFamily.HELVETICA, 10)));
                        cell2.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        cell2.BorderWidthBottom = 1f;
                        cell2.BorderWidthTop = 1f;
                        cell2.BorderWidthLeft = 1f;
                        cell2.BorderWidthRight = 1f;
                        cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell2.VerticalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell2);

                        PdfPCell cell3 = new PdfPCell(new Phrase("Number of cancelations", new Font(Font.FontFamily.HELVETICA, 10)));
                        cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        cell3.BorderWidthBottom = 1f;
                        cell3.BorderWidthTop = 1f;
                        cell3.BorderWidthLeft = 1f;
                        cell3.BorderWidthRight = 1f;
                        cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell3.VerticalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell3);

                        PdfPCell cell4 = new PdfPCell(new Phrase("Number of reschedulings", new Font(Font.FontFamily.HELVETICA, 10)));
                        cell4.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        cell4.BorderWidthBottom = 1f;
                        cell4.BorderWidthTop = 1f;
                        cell4.BorderWidthLeft = 1f;
                        cell4.BorderWidthRight = 1f;
                        cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell4.VerticalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell4);

                        PdfPCell cell5 = new PdfPCell(new Phrase("Number of suggestions", new Font(Font.FontFamily.HELVETICA, 10)));
                        cell5.BackgroundColor = BaseColor.LIGHT_GRAY;
                        cell5.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                        cell5.BorderWidthBottom = 1f;
                        cell5.BorderWidthTop = 1f;
                        cell5.BorderWidthLeft = 1f;
                        cell5.BorderWidthRight = 1f;
                        cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell5.VerticalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell5);

                        foreach (var v in AccommodationReservationService.GetMonthStatistics(SelectedAccommodation, PDFYear)) 
                        {
                            PdfPCell month = new PdfPCell(new Phrase(v.Month, new Font(Font.FontFamily.HELVETICA, 10)));
                            PdfPCell reservations = new PdfPCell(new Phrase(v.NumberOfReservations.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                            PdfPCell cancelations = new PdfPCell(new Phrase(v.NumberOfCancelations.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                            PdfPCell reschedulings = new PdfPCell(new Phrase(v.NumberOfReschedulings.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                            PdfPCell suggestions = new PdfPCell(new Phrase(v.NumberOfSuggestions.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                            month.HorizontalAlignment = Element.ALIGN_CENTER;
                            reservations.HorizontalAlignment = Element.ALIGN_CENTER;
                            cancelations.HorizontalAlignment = Element.ALIGN_CENTER;
                            reschedulings.HorizontalAlignment = Element.ALIGN_CENTER;
                            suggestions.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(month);
                            table.AddCell(reservations);
                            table.AddCell(cancelations);
                            table.AddCell(reschedulings);
                            table.AddCell(suggestions);
                        }
                        doc.Add(table);
                        String bestMonth = "Best month: " + AccommodationReservationService.CalculateBestMonth(AccommodationReservationService.GetMonthStatistics(SelectedAccommodation, PDFYear), SelectedAccommodation, PDFYear);
                        Paragraph para4 = new Paragraph(bestMonth, new Font(Font.FontFamily.HELVETICA, 16));
                        para4.Alignment = Element.ALIGN_LEFT;
                        doc.Add(para4);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                        Process.Start(sfd.FileName);
                    }
                }
            }



        }
        public static string GetDownloadsPath()
        {
            string path = null;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                IntPtr pathPtr;
                int hr = SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                if (hr == 0)
                {
                    path = Marshal.PtrToStringUni(pathPtr);
                    Marshal.FreeCoTaskMem(pathPtr);
                    return path;
                }
            }
            path = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            path = Path.Combine(path, "Downloads");
            return path;
        }

        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);


        private void RegisterAccomodation(object param)
        {
            OwnerRegisterAccommodation ownerRegisterAccommodation = new OwnerRegisterAccommodation();
            ownerRegisterAccommodation.Show();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ForumsOwner(object param)
        {
            OwnerAllForums ownerAllForums = new OwnerAllForums();
            ownerAllForums.Show();
        }
        private void SiteProposal(object param)
        {
            SiteProposals siteProposals = new SiteProposals();
            siteProposals.Show();
        }
        private void ViewReviews(object param)
        {
            OwnerViewReviews ownerViewReviews = new OwnerViewReviews();
            ownerViewReviews.Show();
        }
        private void ShowRenovation(object param)
        {
            ShowRenovations showRenovations = new ShowRenovations();
            showRenovations.Show();
        }
        private void SchedulingRenovation(object param)
        {
            if (SelectedAccommodation == null)
            {
                System.Windows.MessageBox.Show("Select a accommodation for renovation please", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);                
                return;
            }
            else
            {
                SchedulingRenovations schedulingRenovations = new SchedulingRenovations(SelectedAccommodation);
                schedulingRenovations.Show();
            }
        }
        private void AccommodationStatistics(object param)
        {
            if (SelectedAccommodation == null)
            {
                System.Windows.MessageBox.Show("Select a accommodation please", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);               
                return;
            }
            else
            {
                AccommodationStatisticsByYears accommodationStatisticsByYears = new AccommodationStatisticsByYears(SelectedAccommodation);
                accommodationStatisticsByYears.Show();
            }
        }

        private void GradingGuests(object param)
        {
            OwnerGradingGuests ownerGradingGuests = new OwnerGradingGuests();
            ownerGradingGuests.Show();
        }
        private void DateMove(object param)
        {
            OwnerDateMove ownerDateMove = new OwnerDateMove();
            ownerDateMove.Show();
        }

        private void SuperOwner(object param)
        {
            SuperOwner superOwner = new SuperOwner();
            superOwner.Show();
        }

        public void Update()
        {
            Accommodations.Clear();

            foreach (Accommodation a in _accommodationService.GetOwnerAccommodations())
            {
                Accommodations.Add(a);
            }
        }
        private void OpenPictures(object param)
        {
            ShowOwnerAccommodationImages showOwnerAccommodationImages = new ShowOwnerAccommodationImages(SelectedAccommodation);
            showOwnerAccommodationImages.Show();
        }
        private void OpenWizard(object param)
        {
            Wizard wizard = new Wizard(0);
            wizard.Show();
        }
        private void LogOut(object param)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            CloseWindow();
        }
        private void CloseWindow()
        {
            _window.Close();
        }
    }
}
