   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest1Booking.WPF.Views.Guest1  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      1    +Booking.WPF.Views.Guest1.ReservationDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Booking.WPF.Views.Guest1     5      1ns"clr-namespace:Booking.Localization     5        N� Title$  ReservationDetails��5
         MyWindowStyle#���   6"   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5      �� $'��!/Resources/Images/information.png��6   $��40��6@   6N   �� 5      $
��Bold"�6?   $��18(�6Q   ��6   '   !Booking.Localization.LocExtension  *ReservationDetailsTitle+6a   5      �� 5   
   
���   �$��1q�6%   $��1��69   $��
90,5,20,20q�6F    �� CornerRadius$ 10��6[   $��Center=�5      $	��Top=�6.   
�������._�5      �  5      �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5      $��40 �6$   �� 5       $��40 �6$   �� 5!      $	��170 �6$   .+�5%      �� $��0��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6^   .+�5&      �� $��15(�6B   $
��Bold"�6P   $	��180��6b   ��6     *ArrivalDayDetails+6p   �� 5'      $	��400��6@   $��15(�6L   ��6   �� *ArrivalDayLabel+6\   5(      �� 5*      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6^   .+�5+      �� $��15(�6C   $
��Bold"�6Q   $	��180��6c   ��6     *DeparuteDayDetails+6q   �� 5,      $	��400��6B   $��15(�6N   ��6   �� *DepartureDayLabel+6^   5-      �� 5/      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6^   .+�50      �� $��15(�6B   $
��Bold"�6P   $	��180��6b   ��6     *AccommodationLabel+6p   �� 51      $��15(�6C   $	��400��6Q   ��6   �� *AccommodationLabel+6_   52      �� 54      $��3��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6^   .+�55      �� $��15(�6:   $
��Bold"�6H   $	��180��6[   ��6     *
ResrevedBy+6i   �� 56      $��15(�6?   $	��400��6M   ��6   �� *GuestNameLabel+6[   57      �� 59      $��4��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6_   .+�5:      �� $��15(�6:   $
��Bold"�6H   $	��180��6[   ��6     *
OwnerLabel+6i   �� 5;      $��15(�6?   $	��400��6M   ��6   �� *OwnerNameLabel+6[   5<      �� 5>      $��5��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6_   .+�5?      �� $��15(�6>   $
��Bold"�6L   $	��180��6_   ��6     *NumberOgGuests+6m   �� 5@      $��3��6   $��15(�6(   $	��400��66   6D   5A      �� 5B      $��6��6   $ 
Horizontal=�6*   $��Center=�6C   $��Center=�6_   .+�5C      �� $��15(�6?   $
��Bold"�6M   $	��180��6`   ��6     *ChcekInCheckOut+6n   �� 5D      $��	11h - 10h��6   $��15(�60   $	��400��6>   6L   5E      �� 5G      $��7��6   $ 
Horizontal=�6*   $��Center=�6C   $��Stretch=�6_   .+�5H      �� $��15(�6B   $
��Bold"�6P   $	��180��6c   ��6     *AccommodationImage+6q   �� 5I      $��10q�6   $	��240��6)   ��65   �� *CurrentImageUrl+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�5J      5K      5L      5M      5N      