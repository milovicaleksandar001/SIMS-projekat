   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      (    "Booking.View.FisrtGuestAllRequests   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Booking.View     5      1ns"clr-namespace:Booking.Localization     5        N� Title$  FisrtGuestAllRequests��5
         MyWindowStyle#���   6&   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      �� 5      $��60 �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��
10,20,10,5q�6;   $��Center=�6O   .+�5      �� $#��/Resources/Images/request.png��6   $��30��6;   $��30��6G   6T   �� 5      $
��Bold"�6   $��17(�6&   ��64   '   !Booking.Localization.LocExtension  *MyReschaduleRequestsTitle+6c   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��RequestsDataGrid��5      $��1��5         SelectionMode$ Single=�6       AutoGenerateColumns .     
IsReadOnly . $��Center=�5   +   $��100,20,100,100q�6H   ��5   e   ��  �� Path$ Requests� �� SelectedItem 5   `   �� *SelectedRequest+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 140 6H   
   Header
 6%     *AccNameDataGrid+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *-+AccommodationReservation.Accommodation.Name+6�     5      $	 * 6E   
 6%     *StateDataGrid+ 6P   �� *75AccommodationReservation.Accommodation.Location.State+6�     5      $	 * 6D   
 6%     *CityDataGrid+ 6O   �� *64AccommodationReservation.Accommodation.Location.City+6�     5      $	 * 6I   
 6%     *StartDateDataGrid+ 6S   �� *NewArrivalDay+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5      $	 * 6H   
 6&     *EndDateDataGrid+ 6S   �� *NewDeparuteDay+$ {0:dd/MM/yyyy}��6�     5      $
 Status��6%   $	 * 65    6@   �� *Status+6^   5"      �� 5#   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5$      �� $
��Bold"�6?   $	��140��6Q   $��10q�6]   ��6     *ShowMoreDetailsButton+��6j   �� *ClickShowMoreDetails+6�   5%      5'      5(      