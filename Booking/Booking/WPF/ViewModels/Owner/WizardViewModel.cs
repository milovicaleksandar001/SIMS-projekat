using Booking.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking.WPF.ViewModels.Owner
{
    public class WizardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int GottenPageNumber { get; set; }
        //public String PageLabel { get; set; } = String.Empty;

        private List<string> pageTexts;

        private int currentPageIndex;

        public String _currentPageText;
        public String CurrentPageText
        {
            get => _currentPageText;
            set
            {
                if (_currentPageText != value)
                {
                    _currentPageText = value;
                    OnPropertyChanged();
                }
            }
        }
        public String _pageLabel;
        public String PageLabel
        {
            get => _pageLabel;
            set
            {
                if (_pageLabel != value)
                {
                    _pageLabel = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool _isNextEnabled;

        public bool IsNextEnabled
        {
            get => _isNextEnabled;
            set
            {
                if (_isNextEnabled != value)
                {
                    _isNextEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool _isPreviousEnabled;

        public bool IsPreviousEnabled
        {
            get => _isPreviousEnabled;
            set
            {
                if (_isPreviousEnabled != value)
                {
                    _isPreviousEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public RelayCommand PreviousButton_Click { get; set; }
        public RelayCommand NextButton_Click { get; set; }
        public RelayCommand CloseWindow { get; set; }
        private readonly Window _window;
        public WizardViewModel(int gottenPageNumber,Window window)
        {
            _window = window;
            GottenPageNumber = gottenPageNumber;
            PageLabel = SetPageLabel(GottenPageNumber);
            pageTexts = new List<string>();
            currentPageIndex = GottenPageNumber;

            setTexts();

            PreviousButton_Click = new RelayCommand(PreviousButton);
            NextButton_Click = new RelayCommand(NextButton);
            CloseWindow = new RelayCommand(Close);
            IsPreviousEnabled = false;


            if (currentPageIndex == pageTexts.Count - 1)
            {
                IsNextEnabled = false;
            }
            else
            {
                IsNextEnabled = true;
            }
            if (currentPageIndex > 0)
            {
                IsPreviousEnabled = true;
            }

            if (currentPageIndex == 0)
            {
                IsPreviousEnabled = false;
            }
        }
        private void Close(object param)
        {
            _window.Close();
        }
        public void setTexts()
        {
            string text0 = "Here you can see all your registered accommodations, note of you add a new one it will also be displayed." +
                " On the left side you have buttons that when you press them will take you to a sepereate window which will fullfil that task." +
                " For some tasks you will first have to select an accommodation which will be used for that task." +
                " On the upper right side you have 3 buttons LogOut(change user),Wizard(help) and PDF(save a pdf file on your tablet).";
            pageTexts.Add(text0);
            string text1 = "This is the window for registering new accommodations you must eneter all the fields, to select the country and city" +
                " press the boxes and choose one of the offered choices same goes for the TYPE field. The buttons + and - are used to " +
                "increase or decrease the value of that field by 1. To add a picture press the + next to the pictures field and choose a " +
                "picture from your tablet, it will appear below it with 2 buttons. To delete a picture using the buttons find the picture you " +
                "want to delete and press the - button next to the pictures field. On the bottom you have 2 buttons CREATE(add the accommodation) " +
                "and CLOSE(close the window).";
            pageTexts.Add(text1);
            string text2 = "Here you can see the stats for the selected accommodation by year. Below that you can see the best year that the accommodation had. " +
                " Below that you have 2 buttons DETAIL(it will take you to another window for the selected year) and CLOSE(this will close the window).";
            pageTexts.Add(text2);
            string text3 = "Here you can see the stats for the selected accommodation and selected year by months. Below that you can " +
                "see the best month. Below that you have a CLOSE button(this will close the window).";
            pageTexts.Add(text3);
            string text4 = "Here you can see all the best locations where you have accommodations and the worst. " +
                "We reccomment you look in to seeing if it is worth oppening another accommodation on the good locations and" +
                " closing the ones on the bad ones. Below you have a CLOSE button(this will close the window).";
            pageTexts.Add(text4);
            string text5 = "Here you can see all the date move request you have pending you can choose one of them and decite to accept or decline it. " +
                "To accept choose the date move request and press the ACCEPT button, to decline choose the date move request enter a reason why you declined " +
                "and press the DECLINE button. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text5);
            string text6 = "Here you can see all the guests that you can grade, when you select a guest and then press the GRADE button " +
                "you will be taken to the next window where you can finish the grading. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text6);
            string text7 = "Here you can enter the values from 1 to 5 by clicking the box next to the required field. You can finish the grading " +
                "by pressing the GRADE button, note the comment is required. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text7);
            string text8 = "Here you can see all the rewievs you have got by pressing on the Show button in the collumn Comment you will " +
                "see the comment that that guest left and if you press the Show button in the Images collumn you will see the pictures that that " +
                "guest left. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text8);
            string text9 = "Here you can see the number of grades you have and the average grade note that you need at least 50 grades with " +
                "an average score of 4.5 to become a super-owner, that message will be displayed below that. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text9);
            string text10 = "Press the little calendar and choose a date, do that for start date and end date then enter the " +
                "duration of the renovation and press the button FIND. Then you will be redirected to a new window where you will " +
                "get the options for schedulig a renovation. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text10);
            string text11 = "Here you can choose a date for your planed renovation and enter the required description, when you " +
                "have done that press the Schedule button and your renovation will be scheduled. Note that guest will not be able to " +
                "schedule reservations in this period. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text11);
            string text12 = "Here you can see all the done and scheduled renovations, if you want to see the description of the " +
                "renovation press the Show button. If you want to cancel the renovation select the renovation and then press the " +
                "Delete button. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text12);
            string text13 = "Here you can see all the forums which guests opened for specific locations if you want to see the " +
                "comments on the forum, select a forum and press the SEE button. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text13);
            string text14 = "Here you can see all the comments for a specific forum. If you want to leave a comment enter it in the comment " +
                "zone and press the COMMENT button, note you can only comment if the forum is still open and if you have a accommodation" +
                " on that location.You can also report a comment if that person never " +
                "visited that location and is giving false information " +
                "by selectiong that comment and pressing the REPORT button. You also have a CLOSE button(this will close the window).";
            pageTexts.Add(text14);

            SetCurrentPage();
        }
        private String SetPageLabel(int gottenPageNumber)
        {
            if (gottenPageNumber == 0)
            {
                return "Home page";
            }
            if (gottenPageNumber == 1) 
            {
                return "Register accommodation";
            }
            if (gottenPageNumber == 2) 
            {
                return "Accommodation statistics by year";
            }
            if (gottenPageNumber == 3) 
            {
                return "Accommodation statistics by month";
            }
            if (gottenPageNumber == 4) 
            {
                return "Site proposals";
            }
            if (gottenPageNumber == 5)
            {
                return "Date move requests";
            }
            if (gottenPageNumber == 6)
            {
                return "Grading guests";
            }
            if (gottenPageNumber == 7)
            {
                return "Grading guests second window";
            }
            if (gottenPageNumber == 8)
            {
                return "View reviews";
            }
            if (gottenPageNumber == 9)
            {
                return "Super owner";
            }
            if (gottenPageNumber == 10)
            {
                return "Scheduling renovations";
            }
            if (gottenPageNumber == 11)
            {
                return "Choose date for renovation";
            }
            if (gottenPageNumber == 12)
            {
                return "Show renovations";
            }
            if (gottenPageNumber == 13)
            {
                return "Forums";
            }
            if (gottenPageNumber == 14)
            {
                return "Forum comments";
            }
            return "";
        }
        private void PreviousButton(object param)
        {
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                SetCurrentPage();
                PageLabel=SetPageLabel(currentPageIndex);
                IsNextEnabled = true;
            }

            if (currentPageIndex == 0)
            {
                IsPreviousEnabled = false;
            }
        }
        private void NextButton(object param)
        {
            if (currentPageIndex < pageTexts.Count - 1)
            {
                currentPageIndex++;
                SetCurrentPage();
                PageLabel=SetPageLabel(currentPageIndex);
                IsPreviousEnabled = true;
            }

            if (currentPageIndex == pageTexts.Count - 1)
            {
                IsNextEnabled = false;
            }
        }

        private void SetCurrentPage()
        {
            CurrentPageText = pageTexts[currentPageIndex];
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
