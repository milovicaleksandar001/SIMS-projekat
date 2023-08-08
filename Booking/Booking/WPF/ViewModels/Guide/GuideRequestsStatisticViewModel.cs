using Booking.Commands;
using Booking.Domain.DTO;
using Booking.Domain.Model;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Observer;
using Booking.Service;
using Booking.Util;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.Windows.Forms;
using System.Windows.Media;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;

namespace Booking.WPF.ViewModels.Guide
{
    public class GuideRequestsStatisticViewModel : INotifyPropertyChanged
    {

        public ILocationService locationService { get; set; }
        public ITourRequestService tourRequestService { get; set; }

        private bool _isLocationSelected;
        private bool _isLanguageSelected;
        private bool _isLocationEnabled;
        private bool _isLanguageEnabled;

        public bool IsLocationSelected
        {
            get { return _isLocationSelected; }
            set
            {
                _isLocationSelected = value;
                OnPropertyChanged(nameof(IsLocationSelected));
                OnPropertyChanged(nameof(IsLanguageSelected));
                UpdateControlsEnabledState();
            }
        }

        public bool IsLanguageSelected
        {
            get { return _isLanguageSelected; }
            set
            {
                _isLanguageSelected = value;
                OnPropertyChanged(nameof(IsLanguageSelected));
                OnPropertyChanged(nameof(IsLocationSelected));
                UpdateControlsEnabledState();
            }
        }

        public bool IsLocationEnabled
        {
            get { return _isLocationEnabled; }
            set
            {
                _isLocationEnabled = value;
                OnPropertyChanged(nameof(IsLocationEnabled));
            }
        }

        public bool IsLanguageEnabled
        {
            get { return _isLanguageEnabled; }
            set
            {
                _isLanguageEnabled = value;
                OnPropertyChanged(nameof(IsLanguageEnabled));
            }
        }

        private void UpdateControlsEnabledState()
        {
            IsLocationEnabled = IsLocationSelected;
            if (IsLocationEnabled)
            {
                LanguageTB = null;
                RequestsByYearCollection = null;
                RequestsByMonthCollection = null;
            }
            IsLanguageEnabled = IsLanguageSelected;
            if (IsLanguageEnabled)
            {
                SelectedLocation = null;
                RequestsByYearCollection = null;
                RequestsByMonthCollection = null;
            }
        }

        private bool _isDataGridGenerralyVisible = true;
        public bool IsDataGridGenerallyVisible
        {
            get { return _isDataGridGenerralyVisible; }
            set { _isDataGridGenerralyVisible = value; OnPropertyChanged(); }
        }

        private bool _isDataGridYearlyVisible = true;
        public bool IsDataGridYearlyVisible
        {
            get { return _isDataGridYearlyVisible; }
            set { _isDataGridYearlyVisible = value; OnPropertyChanged(); }
        }

        private bool _isLabelYearVisible = true;
        public bool IsLabelYearVisible
        {
            get { return _isLabelYearVisible; }
            set { _isLabelYearVisible = value; OnPropertyChanged(); }
        }

        private bool _isTBYearVisible = true;
        public bool IsTBYearVisible
        {
            get { return _isTBYearVisible; }
            set { _isTBYearVisible = value; OnPropertyChanged(); }
        }

        private string _selectedLocation;
        public string SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged("SelectedLocation");
            }
        }

        public string _languageTB;
        public string LanguageTB
        {
            get => _languageTB;
            set
            {
                if (_languageTB != value)
                {
                    _languageTB = value;
                    OnPropertyChanged(nameof(LanguageTB));
                }
            }
        }

        public string _yearTB;
        public string YearTB
        {
            get => _yearTB;
            set
            {
                if (_yearTB != value)
                {
                    _yearTB = value;
                    OnPropertyChanged(nameof(YearTB));
                }
            }
        }

        private Brush _buttonBackground = new SolidColorBrush(Color.FromRgb(0xAA, 0xCB, 0xF0));
        public Brush Menu_Generally_Color
        {
            get { return _buttonBackground; }
            set
            {
                _buttonBackground = value;
                OnPropertyChanged(nameof(Menu_Generally_Color));
            }
        }

        private Brush _buttonBackground2 = new SolidColorBrush(Color.FromRgb(0x72, 0x87, 0x9E));
        public Brush Menu_Yearly_Color
        {
            get { return _buttonBackground2; }
            set
            {
                _buttonBackground2 = value;
                OnPropertyChanged(nameof(Menu_Yearly_Color));
            }
        }


        private ObservableCollection<YearlyRequests> _requestsByYearCollection;
        public ObservableCollection<YearlyRequests> RequestsByYearCollection
        {
            get { return _requestsByYearCollection; }
            set
            {
                _requestsByYearCollection = value;
                OnPropertyChanged(nameof(RequestsByYearCollection));
            }
        }

        private ObservableCollection<MonthlyRequests> _requestsByMonthCollection;
        public ObservableCollection<MonthlyRequests> RequestsByMonthCollection
        {
            get { return _requestsByMonthCollection; }
            set
            {
                _requestsByMonthCollection = value;
                OnPropertyChanged(nameof(RequestsByMonthCollection));
            }
        }

        public ObservableCollection<string> LocationsCollection { get; set; }

        private void FillLocationsComboBox()
        {
            List<string> items = new List<string>();

            using (StreamReader reader = new StreamReader("../../Resources/Data/locations.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string[] fields = reader.ReadLine().Split(',');
                    foreach (var field in fields)
                    {
                        string[] pom = field.Split('|');
                        items.Add(pom[1] + ", " + pom[2]);
                    }
                }
            }

            LocationsCollection.Clear();
            foreach (string str in items)
            {
                LocationsCollection.Add(str);
            }
        }

        public ObservableCollection<TourRequest> tourRequests { get; set; }
        public ObservableCollection<TourRequest> acceptedTourRequests { get; set; }
        public ObservableCollection<TourRequest> notAcceptedTourRequests { get; set; }

        public RelayCommand Close { get; set; }
        public RelayCommand Show { get; set; }
        public RelayCommand Menu_ThisYear { get; set; }
        public RelayCommand Menu_Generally { get; set; }
        public RelayCommand Button_Click_GenerateReport { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Window _window;
        public GuideRequestsStatisticViewModel(Window window)
        {
            _window = window;

            locationService = InjectorService.CreateInstance<ILocationService>();
            tourRequestService = InjectorService.CreateInstance<ITourRequestService>();

            LocationsCollection = new ObservableCollection<string>();
            tourRequests = new ObservableCollection<TourRequest>(tourRequestService.GetAll());
            acceptedTourRequests = new ObservableCollection<TourRequest>(tourRequestService.GetAllAccepted());
            notAcceptedTourRequests = new ObservableCollection<TourRequest>(tourRequestService.GetAllNotAccepted());

            SetDefaultValues();
            FillLocationsComboBox();
            SetCommands();
        }

        private void SetDefaultValues()
        {
            IsDataGridGenerallyVisible = true;
            IsDataGridYearlyVisible = false;
            IsLabelYearVisible = false;
            IsTBYearVisible = false;

            IsLocationEnabled = true;
            IsLocationSelected = true;
        }

        private void CountByLocation()
        {
            if (SelectedLocation != null)
            {
                string pom = SelectedLocation.ToString();
                string[] CountryCity = pom.Split(',');
                string Country = CountryCity[0];
                string City = CountryCity[1].Trim();

                int locationId = locationService.GetIdByCountryAndCity(Country, City);


                var yearlyRequestsList = tourRequestService.GetRequestsByYearAndLocation(locationId);
                var observableYearlyRequestsList = new ObservableCollection<YearlyRequests>(yearlyRequestsList);

                RequestsByYearCollection = observableYearlyRequestsList;

                if (RequestsByYearCollection.Count == 0)
                {
                    System.Windows.MessageBox.Show("On location " + Country + ", " + City + " you don't have tour requests!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
            else
            {
                System.Windows.MessageBox.Show("First you need to select location", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void CountByLanguage()
        {
            if (LanguageTB != null)
            {
                var yearlyRequestsList = tourRequestService.GetRequestsByYearAndLanguage(LanguageTB);
                var observableYearlyRequestsList = new ObservableCollection<YearlyRequests>(yearlyRequestsList);

                RequestsByYearCollection = observableYearlyRequestsList;
                if (RequestsByYearCollection.Count == 0)
                {
                    System.Windows.MessageBox.Show("On language " + LanguageTB + " you don't have tour requests!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("First you need to input language!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
        public void SetCommands()
        {
            Close = new RelayCommand(ButtonClose);
            Show = new RelayCommand(ButtonShow);
            Menu_ThisYear = new RelayCommand(ButtonMenu_ThisYear);
            Menu_Generally = new RelayCommand(ButtonMenu_Generally);
            Button_Click_GenerateReport = new RelayCommand(ButtonGenerateReport);
        }

        private void ButtonMenu_ThisYear(object param)
        {
            IsDataGridGenerallyVisible = false;
            IsDataGridYearlyVisible = true;
            IsLabelYearVisible = true;
            IsTBYearVisible = true;
            YearTB = null;
            LanguageTB = null;
            SelectedLocation = null;
            RequestsByYearCollection = null;
            RequestsByMonthCollection = null;
            Menu_Generally_Color = new SolidColorBrush(Color.FromRgb(0x72, 0x87, 0x9E));
            Menu_Yearly_Color = new SolidColorBrush(Color.FromRgb(0xAA, 0xCB, 0xF0));
        }
        private void ButtonMenu_Generally(object param)
        {
            IsDataGridGenerallyVisible = true;
            IsDataGridYearlyVisible = false;
            IsLabelYearVisible = false;
            IsTBYearVisible = false;
            YearTB = null;
            LanguageTB = null;
            SelectedLocation = null;
            RequestsByYearCollection = null;
            RequestsByMonthCollection = null;
            Menu_Yearly_Color = new SolidColorBrush(Color.FromRgb(0x72, 0x87, 0x9E));
            Menu_Generally_Color = new SolidColorBrush(Color.FromRgb(0xAA, 0xCB, 0xF0));
        }

        private void ButtonClose(object param)
        {
            CloseWindow();
        }
        private void ButtonShow(object param)
        {

            if (IsDataGridGenerallyVisible)
            {
                if (IsLocationEnabled)
                    CountByLocation();

                if (IsLanguageEnabled)
                    CountByLanguage();
            }

            if (IsDataGridYearlyVisible)
            {
                if (IsLocationEnabled)
                    CountByLocationAndYear();
                if (IsLanguageEnabled)
                    CountByLanguageAndYear();
            }


        }

        private void CountByLocationAndYear()
        {
            if (SelectedLocation != null && YearTB != null)
            {
                string pom = SelectedLocation.ToString();
                string[] CountryCity = pom.Split(',');
                string Country = CountryCity[0];
                string City = CountryCity[1].Trim();

                int locationId = locationService.GetIdByCountryAndCity(Country, City);


                var monthlyRequestsList = tourRequestService.GetRequestsByMonthAndLocation(locationId, Convert.ToInt32(YearTB));
                var observableMonthlyRequestsList = new ObservableCollection<MonthlyRequests>(monthlyRequestsList);

                RequestsByMonthCollection = observableMonthlyRequestsList;

                if (RequestsByMonthCollection.Count == 0)
                {
                    System.Windows.MessageBox.Show("On location " + Country + ", " + City + " you don't have tour requests!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

            }
            else
            {
                System.Windows.MessageBox.Show("First you need to select location and year", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void CountByLanguageAndYear()
        {
            if (LanguageTB != null && YearTB != null)
            {
                var monthlyRequestsList = tourRequestService.GetRequestsByMonthAndLanguage(LanguageTB, Convert.ToInt32(YearTB));
                var observableMonthlyRequestsList = new ObservableCollection<MonthlyRequests>(monthlyRequestsList);

                RequestsByMonthCollection = observableMonthlyRequestsList;
                if (RequestsByMonthCollection.Count == 0)
                {
                    System.Windows.MessageBox.Show("On language " + LanguageTB + " you don't have tour requests!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("First you need to input language and year!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

        }

        private int countAcceptedRequests()
        {
            int count = 0;
            
            foreach(var r in tourRequests) 
            {
            if(r.Status == "Accepted")
                { count++; }
            }

            return count;
        }


        private int countNotAcceptedRequests()
        {
            int count = 0;

            foreach (var r in tourRequests)
            {
                if (r.Status != "Accepted")
                { count++; }
            }

            return count;
        }

        private bool canPrint()
        {
            return tourRequests.Count > 0;
        }
        private void ButtonGenerateReport(object param)
        {
            if (canPrint())
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", FileName = "TourRequestStatistic_Report", ValidateNames = true, InitialDirectory = GetDownloadsPath() })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Document doc = new Document(PageSize.A4);
                        try
                        {

                            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                            doc.Open();

                            Paragraph para1 = new Paragraph("Statistic about accepted/not accepted tour requests", new Font(Font.FontFamily.HELVETICA, 21,Font.BOLD));
                            para1.Alignment = Element.ALIGN_CENTER;
                            doc.Add(para1);

                            String paragraph = "Date: " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm");
                            Paragraph para2 = new Paragraph(paragraph, new Font(Font.FontFamily.HELVETICA, 15));
                            para2.Alignment = Element.ALIGN_CENTER;
                            para2.SpacingAfter = 10;
                            doc.Add(para2);


                            Paragraph spacing = new Paragraph("\n\n");
                            doc.Add(spacing);

                            PdfPTable table = new PdfPTable(2);
                            

                            PdfPCell cell1 = new PdfPCell(new Phrase("Accepted", new Font(Font.FontFamily.HELVETICA, 14)));
                            cell1.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell1.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell1.Padding = 10;
                            cell1.BorderWidthBottom = 1f;
                            cell1.BorderWidthTop = 1f;
                            cell1.BorderWidthLeft = 1f;
                            cell1.BorderWidthRight = 1f;
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.VerticalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell1);

                            PdfPCell cell2 = new PdfPCell(new Phrase(countAcceptedRequests().ToString(), new Font(Font.FontFamily.HELVETICA, 14)));   
                            cell2.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell2.Padding = 10;
                            cell2.BorderWidthBottom = 1f;
                            cell2.BorderWidthTop = 1f;
                            cell2.BorderWidthLeft = 1f;
                            cell2.BorderWidthRight = 1f;
                            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell2.VerticalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell2);

                            PdfPCell cell3 = new PdfPCell(new Phrase("Not accepted", new Font(Font.FontFamily.HELVETICA, 14)));
                            cell3.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell3.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell3.Padding = 10;
                            cell3.BorderWidthBottom = 1f;
                            cell3.BorderWidthTop = 1f;
                            cell3.BorderWidthLeft = 1f;
                            cell3.BorderWidthRight = 1f;
                            cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell3.VerticalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell3);

                            PdfPCell cell4 = new PdfPCell(new Phrase(countNotAcceptedRequests().ToString(), new Font(Font.FontFamily.HELVETICA, 14)));                
                            cell4.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell4.Padding = 10;
                            cell4.BorderWidthBottom = 1f;
                            cell4.BorderWidthTop = 1f;
                            cell4.BorderWidthLeft = 1f;
                            cell4.BorderWidthRight = 1f;
                            cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell4.VerticalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell4);
                            
                            doc.Add(table);

                            Paragraph spacing1 = new Paragraph("\n\n");
                            doc.Add(spacing1);

                            LineSeparator line = new LineSeparator();
                            line.LineWidth = 0.5f; 
                            line.LineColor = BaseColor.BLACK; 

                            doc.Add(line);

                            Paragraph para3 = new Paragraph("All accepted requests", new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD));
                            para3.Alignment = Element.ALIGN_CENTER;
                            doc.Add(para3);
                            Paragraph spacing2 = new Paragraph("\n");
                            doc.Add(spacing2);

                            PdfPTable table1 = new PdfPTable(4); 

                            PdfPCell cell11 = new PdfPCell(new Phrase("Request No.", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell11.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell11.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell11.BorderWidthBottom = 1f;
                            cell11.BorderWidthTop = 1f;
                            cell11.BorderWidthLeft = 1f;
                            cell11.BorderWidthRight = 1f;
                            cell11.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell11.VerticalAlignment = Element.ALIGN_CENTER;
                            table1.AddCell(cell11);

                            PdfPCell cell22 = new PdfPCell(new Phrase("Created date", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell22.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell22.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell22.BorderWidthBottom = 1f;
                            cell22.BorderWidthTop = 1f;
                            cell22.BorderWidthLeft = 1f;
                            cell22.BorderWidthRight = 1f;
                            cell22.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell22.VerticalAlignment = Element.ALIGN_CENTER;
                            table1.AddCell(cell22);

                            PdfPCell cell33 = new PdfPCell(new Phrase("Location", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell33.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell33.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell33.BorderWidthBottom = 1f;
                            cell33.BorderWidthTop = 1f;
                            cell33.BorderWidthLeft = 1f;
                            cell33.BorderWidthRight = 1f;
                            cell33.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell33.VerticalAlignment = Element.ALIGN_CENTER;
                            table1.AddCell(cell33);

                            PdfPCell cell44 = new PdfPCell(new Phrase("Language", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell44.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell44.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell44.BorderWidthBottom = 1f;
                            cell44.BorderWidthTop = 1f;
                            cell44.BorderWidthLeft = 1f;
                            cell44.BorderWidthRight = 1f;
                            cell44.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell44.VerticalAlignment = Element.ALIGN_CENTER;
                            table1.AddCell(cell44);


                            foreach (var t in acceptedTourRequests) 
                            {
                                PdfPCell cellNo = new PdfPCell(new Phrase(t.Id.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                                PdfPCell cellDate = new PdfPCell(new Phrase(t.CreatedDate.ToString("dd.MM.yyyy."), new Font(Font.FontFamily.HELVETICA, 10)));

                                Location loc = locationService.GetById(t.Location.Id);
                                String locPrint = loc.City + ", " + loc.State;

                                PdfPCell cellLoc = new PdfPCell(new Phrase(locPrint, new Font(Font.FontFamily.HELVETICA, 10)));

                                PdfPCell cellLanguage = new PdfPCell(new Phrase(t.Language, new Font(Font.FontFamily.HELVETICA, 10)));

                                cellNo.HorizontalAlignment = Element.ALIGN_CENTER;
                                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                                cellLoc.HorizontalAlignment = Element.ALIGN_CENTER;
                                cellLanguage.HorizontalAlignment = Element.ALIGN_CENTER;

                                table1.AddCell(cellNo);
                                table1.AddCell(cellDate);
                                table1.AddCell(cellLoc);
                                table1.AddCell(cellLanguage);
                            }

                            doc.Add(table1);

                            doc.Add(spacing);

                            doc.Add(line);


                            Paragraph para4 = new Paragraph("All not accepted requests", new Font(Font.FontFamily.HELVETICA, 21, Font.BOLD));
                            para4.Alignment = Element.ALIGN_CENTER;
                            doc.Add(para4);
                            Paragraph spacing3 = new Paragraph("\n");
                            doc.Add(spacing3);

                            PdfPTable table2 = new PdfPTable(4); 

                            PdfPCell cell111 = new PdfPCell(new Phrase("Request No.", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell111.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell111.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell111.BorderWidthBottom = 1f;
                            cell111.BorderWidthTop = 1f;
                            cell111.BorderWidthLeft = 1f;
                            cell111.BorderWidthRight = 1f;
                            cell111.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell111.VerticalAlignment = Element.ALIGN_CENTER;
                            table2.AddCell(cell111);

                            PdfPCell cell222 = new PdfPCell(new Phrase("Created date", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell222.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell222.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell222.BorderWidthBottom = 1f;
                            cell222.BorderWidthTop = 1f;
                            cell222.BorderWidthLeft = 1f;
                            cell222.BorderWidthRight = 1f;
                            cell222.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell222.VerticalAlignment = Element.ALIGN_CENTER;
                            table2.AddCell(cell222);

                            PdfPCell cell333 = new PdfPCell(new Phrase("Location", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell333.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell333.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell333.BorderWidthBottom = 1f;
                            cell333.BorderWidthTop = 1f;
                            cell333.BorderWidthLeft = 1f;
                            cell333.BorderWidthRight = 1f;
                            cell333.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell333.VerticalAlignment = Element.ALIGN_CENTER;
                            table2.AddCell(cell333);

                            PdfPCell cell444 = new PdfPCell(new Phrase("Language", new Font(Font.FontFamily.HELVETICA, 10)));
                            cell444.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cell444.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER | Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                            cell444.BorderWidthBottom = 1f;
                            cell444.BorderWidthTop = 1f;
                            cell444.BorderWidthLeft = 1f;
                            cell444.BorderWidthRight = 1f;
                            cell444.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell444.VerticalAlignment = Element.ALIGN_CENTER;
                            table2.AddCell(cell444);


                            foreach (var t in notAcceptedTourRequests)
                            {
                                PdfPCell cellNo = new PdfPCell(new Phrase(t.Id.ToString(), new Font(Font.FontFamily.HELVETICA, 10)));
                                PdfPCell cellDate = new PdfPCell(new Phrase(t.CreatedDate.ToString("dd.MM.yyyy."), new Font(Font.FontFamily.HELVETICA, 10)));

                                Location loc = locationService.GetById(t.Location.Id);
                                String locPrint = loc.City + ", " + loc.State;

                                PdfPCell cellLoc = new PdfPCell(new Phrase(locPrint, new Font(Font.FontFamily.HELVETICA, 10)));

                                PdfPCell cellLanguage = new PdfPCell(new Phrase(t.Language, new Font(Font.FontFamily.HELVETICA, 10)));

                                cellNo.HorizontalAlignment = Element.ALIGN_CENTER;
                                cellDate.HorizontalAlignment = Element.ALIGN_CENTER;
                                cellLoc.HorizontalAlignment = Element.ALIGN_CENTER;
                                cellLanguage.HorizontalAlignment = Element.ALIGN_CENTER;

                                table2.AddCell(cellNo);
                                table2.AddCell(cellDate);
                                table2.AddCell(cellLoc);
                                table2.AddCell(cellLanguage);
                            }

                            doc.Add(table2);

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
            else
            {
                System.Windows.MessageBox.Show("Not enough data to generate pdf!");
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


        private void CloseWindow()
        {
            _window.Close();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
