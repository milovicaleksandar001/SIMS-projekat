   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest1Booking.WPF.Views.Guest1  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      0    *Booking.WPF.Views.Guest1.FirstGuestReviews   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Booking.WPF.Views.Guest1     5      1ns"clr-namespace:Booking.Localization     5        N� Title$  FirstGuestReviews��5
         MyWindowStyle#���   6!   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��	10,10,0,0q�6;   $��2��6N   $��Center=�6c   .+�5      �� $"��/Resources/Images/review.png��6   $��35��6:   $��40��6F   6T   �� 5      $
��Bold"�6   $��17(�6&   ��64   '   !Booking.Localization.LocExtension  *MyReviewsTitle+6Y   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ReservationsDataGrid��5   �   $��1��6      SelectionMode$ Single=�6       AutoGenerateColumns .     
IsReadOnly . $��80,20,80,200q�6e   $��2��5      ��5   {   ��  �� Path$ Grades�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6H   
   Header
 6&     *AccNameDataGrid+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *" Accommodation.Accommodation.Name+6�     5      $	 * 6L   
 6&     *CleanlinessDataGrid+ 6V   �� *Cleanliness+6x     5      $	 * 6N   
 6&     *RuleFollowingDataGrid+ 6X   �� *RuleFollowing+6|     5      $	 * 6M   
 6%     *CommunicationDataGrid+ 6W   �� *Communication+6{     5      $	 * 6H   
 6%     *LatenessDataGrid+ 6R   �� *
Lateness+6r     5      $	 * 6F   
 6%     *OwnerUsername+ 6P   �� *,*Accommodation.Accommodation.Owner.Username+6�   5       5!      5"      