   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest1Booking.WPF.Views.Guest1  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      0    *Booking.WPF.Views.Guest1.BookAccommodation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Booking.WPF.Views.Guest1     5      1ns"clr-namespace:Booking.Localization     5        N� Title$  BookAccommodation��5
         MyWindowStyle#���   6"    � 	Resources 5        ValidationTemplate ��Name��%�   &	       �� 5   
   .R�5      �� .+�5      �� $ textBox��6,   �� 5      
���  ����6   �� *[0].ErrorContent+6>   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��55 �6   .+�5   
   �� $��0��6   $��Center=�6"    �� Orientation$ 
Horizontal=�6?   $��15q�6X   .+�5      �� $#��/Resources/Images/reserve.png��6   $��50��6;   $��50��6G   6U   �� 5      $��18(�64   $
��Bold"�6B   ��6   '   !Booking.Localization.LocExtension  *BookAccTitle+6X   5      � 5   
   $��Center=�6   $��1��6,   $��0,10,0,0q�69   $	��500��6K   $	��Top=�6W    � ColumnDefinitions 5      �� 5       �� 5!      $	��300 �6#    5#      �� 5$      $��40 �6    �� 5%      $��60 �6    �� 5&      $��40 �6    �� 5'      $��50 �6    .+�5)      �� $��0��6:   $��0��6G   $��Center=�6X   $
��Bold"�6s   $��18(�6�   ��6     *AccommodationLabel+6�   �� 5*      $
��Left=�68   $��1��6S   $��0��6`   $��Center=�6p   $��17(�6�   ��6     *ChooseArrivalDay+6�   �� 5+      $
��Left=�6:   $��2��6U   $��0��6c   $��Center=�6s   $��17(�6�   ��6     *ChooseDepartureDay+6�   �� 5,      $
��Left=�66   $��3��6Q   $��0��6_   $��Center=�6p   $��17(�6�   ��6     *NumberOgGuests+6�   �� 5.      $
��Bold"�6<   $��15(�6O   $��0��6]   $��1��6j   $��Stretch=�6z   $��Center=�6�   ��6   �� *AccommodationLabel+6�   �� 50      $��1��6   $��1��6)   $
��Left=�66   $��Center=�6Q   $��24��6l   $	��180��6x   .+�51      (  "System.Windows.Controls.DatePicker  $	��180��6      SelectedDateFormat$ Short=�6�      SelectedDate 6)   �� *
ArrivalDay+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� StringFormat$
 {0:dd/MM/yyyy}��6�   52      �� 54      $��2��6   $��1��6'   $
��Left=�67   $��Center=�6R   $��24��6m   $	��180��6y   .+�55        $	��180��6   $ Short=�6�    6)   �� *DepartureDay+$ TwoWay=�$	 PropertyChanged=�$
 {0:dd/MM/yyyy}��6�   56      �� 57      $��3��6   $��1��6#   $��80��63   $��30��6>    =� ErrorTemplate# [ 59      $
��Left=�6Q   $��0,10,0,0q�6l   $	��Top=�6~   ��58      ��  �� Path$ NumberOfGuests�$	 PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . .��59   �   ��5:      �� 5;       �� 
TargetType" ��6    �� Triggers 5<      P� 5=       P� Property �@=�HasError P� Value . . �5>   "   ��  �� Property � �� �� Value
 �  ��6@   5?      5A      .��5B   !   5C      5D      �� 5F   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5G      �� $��9q�66   $
��Bold"�6A   $��70��6|   ��6     *ReserveButton+��6S   �� *Reserve_Button_Click+6�   �� 5H      $��9q�65   $
��Bold"�6@   $��60��6z   ��6     *CancleButton+��6R   �� *Cancle_Button_Click+6�   5I      5J      5K      