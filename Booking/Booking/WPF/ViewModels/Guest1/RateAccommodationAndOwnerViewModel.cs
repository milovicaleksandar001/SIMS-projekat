using Booking.Domain.Model.Images;
using Booking.Domain.ServiceInterfaces;
using Booking.Model;
using Booking.Service;
using Booking.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using System.Collections.ObjectModel;
using Booking.Commands;
using Notifications.Wpf;
using System.Text.RegularExpressions;
using Booking.Model.Images;
using System.Windows.Media.Imaging;
using Booking.WPF.Views.Guest1;

namespace Booking.WPF.ViewModels.Guest1
{
    public class RateAccommodationAndOwnerViewModel: INotifyPropertyChanged, IDataErrorInfo
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        public String AccommodationLabel { get; set; } = String.Empty;
        public String OwnerLabel { get; set; } = String.Empty;

        public ObservableCollection<int> comboBoxCourtesy { get; set; }
        public ObservableCollection<int> comboBoxCleaness { get; set; }


        public AccommodationAndOwnerGrade accommodationAndOwnerGrade;
        public IAccommodationAndOwnerGradeService AccommodationAndOwnerGradeService { get; set; }
        public IGuestsAccommodationImagesService GuestsAccommodationImagesService { get; set; }
        public AccommodationReservation AccommodationReservation { get; set; }

        public NavigationService NavigationService { get; set; }

        List<string> imagePaths = new List<string>();
        int currentImageIndex = -1;

        public RelayCommand AddPicture { get; set; }
        public RelayCommand RemovePicture { get; set; }
        public RelayCommand NextPicture { get; set; }
        public RelayCommand PreviousPicture { get; set; }


        private int _cleaness;
        public int Cleaness
        {
            get => _cleaness;
            set
            {
                if (_cleaness != value)
                {
                    _cleaness = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _courtesy;
        public int Courtesy
        {
            get => _courtesy;
            set
            {
                if (_courtesy != value)
                {
                    _courtesy = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged();
                }
            }
        }

        public string _tbPictures;
        public string TbPictures
        {
            get => _tbPictures;
            set
            {
                if (_tbPictures != value)
                {
                    _tbPictures = value;
                    OnPropertyChanged();
                }
            }
        }

        private BitmapImage _imageSlideshowSource;
        public BitmapImage ImageSlideshowSource
        {
            get { return _imageSlideshowSource; }
            set
            {
                _imageSlideshowSource = value;
                OnPropertyChanged(nameof(ImageSlideshowSource));
            }
        }

        private Visibility _buttonNextVisibility = Visibility.Visible;
        public Visibility ButtonNextVisibility
        {
            get { return _buttonNextVisibility; }
            set { _buttonNextVisibility = value; OnPropertyChanged(); }
        }

        private Visibility _buttonPreviousVisibility = Visibility.Visible;
        public Visibility ButtonPreviousVisibility
        {
            get { return _buttonPreviousVisibility; }
            set { _buttonPreviousVisibility = value; OnPropertyChanged(); }
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


        public RelayCommand Button_Click_Subbmit { get; set; }
        public RelayCommand Button_Click_Plus { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName.Equals("Comment") )
                {
                    if (Comment == String.Empty)
                    {
                        return "This filed is required!";
                    }
                }

                if (columnName.Equals("Courtesy"))
                {
                    if(Courtesy == 0)
                    {
                        return "This filed is required!";
                    }
                }

                if (columnName.Equals("Cleaness"))
                {
                    if(Cleaness == 0)
                    {
                        return "This filed is required!";
                    }
                }
                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Comment", "Courtesy", "Cleaness"};

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



        public RateAccommodationAndOwnerViewModel(AccommodationReservation accommodationReservation, NavigationService navigationService)
        {
            AccommodationLabel = setAccommodationLabel(accommodationReservation);
            OwnerLabel = setOwnerLabel(accommodationReservation);
            AccommodationReservation = new AccommodationReservation();

            GuestsAccommodationImagesService = InjectorService.CreateInstance<IGuestsAccommodationImagesService>();

            AccommodationReservation = accommodationReservation;
            accommodationAndOwnerGrade = new AccommodationAndOwnerGrade();
            AccommodationAndOwnerGradeService = InjectorService.CreateInstance<IAccommodationAndOwnerGradeService>();
            accommodationAndOwnerGrade.Id = AccommodationAndOwnerGradeService.NextId();

            NavigationService = navigationService;
            Button_Click_Subbmit = new RelayCommand(ButtonSubbmit);

            AddPicture = new RelayCommand(ButtonAddPicture);
            RemovePicture = new RelayCommand(ButtonRemovePicture);

            NextPicture = new RelayCommand(buttonNext_Click);
            PreviousPicture = new RelayCommand(buttonPrevious_Click);
           
            Comment = String.Empty;
            Courtesy = 0;
            Cleaness = 0;
            setComboBoxes();
            NextPreviousPhotoButtonsVisibility();

        }

        private void NextPreviousPhotoButtonsVisibility()
        {
            if (imagePaths.Count == 0)
            {
                ImageSlideshowSource = null;
                ButtonNextVisibility = Visibility.Collapsed;
                ButtonPreviousVisibility = Visibility.Collapsed;
            }
            else
            {
                ButtonNextVisibility = Visibility.Visible;
                ButtonPreviousVisibility = Visibility.Visible;
            }
        }


        public void setComboBoxes()
        {
            List<int> grades = new List<int>(){ 1, 2, 3, 4, 5 };
            comboBoxCleaness = new ObservableCollection<int>(grades);
            comboBoxCourtesy = new ObservableCollection<int>(grades);
        }


        private String setAccommodationLabel(AccommodationReservation accommodationReservation)
        {
            return accommodationReservation.Accommodation.Name + "-" + accommodationReservation.Accommodation.Location.State + "-" + accommodationReservation.Accommodation.Location.City + "-" + accommodationReservation.Accommodation.Type;

        }

        private String setOwnerLabel(AccommodationReservation accommodationReservation)
        {
            return accommodationReservation.Accommodation.Owner.Username;
        }

        private void MakeGrade()
        {
            accommodationAndOwnerGrade.Cleaness = Cleaness;
            accommodationAndOwnerGrade.OwnersCourtesy = Courtesy;
            accommodationAndOwnerGrade.Comment = Comment;
            accommodationAndOwnerGrade.AccommodationReservation = AccommodationReservation;
          
        }

    

        private void ButtonSubbmit(object param)
        {
           /* if(IsValid == false){
                //obavetsenje
                return;
            }*/
             //MakeGrade();

             // AccommodationAndOwnerGradeService.SaveGrade(accommodationAndOwnerGrade); //u save grade cuvam slike!
             //AccommodationAndOwnerGradeService.CheckSuper(AccommodationReservation); //ovo je od Coe 

             CurrentPage = new RenovationApproval(AccommodationReservation, NavigationService); 
        }

        private void ButtonAddPicture(object param)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string imagePath = dialog.FileName;
                imagePaths.Add(imagePath);
                currentImageIndex = imagePaths.Count - 1;
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures = imagePath;
            }

            if (TbPictures != "")
            {
                GuestsAccommodationImages Images = new GuestsAccommodationImages();
                Images.Url = TbPictures;
                accommodationAndOwnerGrade.Images.Add(Images);
                NextPreviousPhotoButtonsVisibility();
            }
            else
            {
                MessageBox.Show("Photo URL can't be empty!");
            }
        }

        private void ButtonRemovePicture(object param)
        {
            TourImage image = new TourImage
            {
                Url = TbPictures
            };
            ImageSlideshowSource = null;
            imagePaths.Remove(image.Url);

            int indexToRemove = -1;
            for (int i = 0; i < accommodationAndOwnerGrade.Images.Count; i++)
            {
                if (accommodationAndOwnerGrade.Images[i].Url == image.Url)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove != -1)
            {
                accommodationAndOwnerGrade.Images.RemoveAt(indexToRemove);

                if (accommodationAndOwnerGrade.Images.Count == 0)
                {
                    currentImageIndex = -1;
                    TbPictures = "";
                    ImageSlideshowSource = null;
                }
                else
                {
                    currentImageIndex = (currentImageIndex - 1 + accommodationAndOwnerGrade.Images.Count) % accommodationAndOwnerGrade.Images.Count;

                    ImageSlideshowSource = new BitmapImage(new Uri(accommodationAndOwnerGrade.Images[currentImageIndex].Url));
                    TbPictures = accommodationAndOwnerGrade.Images[currentImageIndex].Url;
                }
            }

            NextPreviousPhotoButtonsVisibility();
        }


        private void buttonPrevious_Click(object param)
        {
            if (currentImageIndex > 0)
            {
                currentImageIndex--;
                string imagePath = imagePaths[currentImageIndex];
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures = imagePath;
            }
        }

        private void buttonNext_Click(object param)
        {
            if (currentImageIndex < imagePaths.Count - 1)
            {
                currentImageIndex++;
                string imagePath = imagePaths[currentImageIndex];
                ImageSlideshowSource = new BitmapImage(new Uri(imagePath));
                TbPictures = imagePath;
            }
        }

    }
}
