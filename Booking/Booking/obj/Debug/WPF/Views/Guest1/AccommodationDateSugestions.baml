   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest1Booking.WPF.Views.Guest1  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      :    4Booking.WPF.Views.Guest1.AccommodationDateSugestions   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Booking.WPF.Views.Guest1     5      1ns"clr-namespace:Booking.Localization     5        N� Title$!  AccommodationDateSugestions��5
         MyWindowStyle#���   6,   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      �� 5      $��40 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��3q�6f   .+�5      �� $$��/Resources/Images/question.png��6   $��40��6<   6J   �� 5      $��0��6   $��15(�6!   $��Center=�60   $��Center=�6M   $
��Bold"�6h   ��6z   '   !Booking.Localization.LocExtension  *SuggestedDatesTitle+6�   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5      �� $
��Bold"�6:   $��15(�6L   ��6     *AccommodationLabel+6\   �� 5      $	��370��6   $
��Bold"�6G   $��15(�6Y   ��6    �� *AccommodationLabel+6i   5      &   System.Windows.Controls.DataGrid  5   
   $��2��6      AutoGenerateColumns .     CanUserAddRows .  $	��500��6�   $	��300��6�   ��6!   �� *Ranges+ �� SelectedItem 6@   �� *SelectedDates+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   	   Header	 6%     *ArrivalDayDataGrid+1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6J   �� *	StartDate+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5      $ * 6�   	 6&     *DepartureDayDataGrid+
 6M   �� *	EndDate+$ {0:dd/MM/yyyy}��6�   5       �� 5"   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��3��6f   .+�5#      �� $��80��6   $��30��6    $��3q�6-   $
��Bold"�68   ��6J   �� *Button_Click_ReserveDate+��6w     *ReserveButton+6�   5$      5%      5&      