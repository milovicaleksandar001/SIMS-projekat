   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest1Booking.WPF.Views.Guest1  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      0    *Booking.WPF.Views.Guest1.FirstGuestProfile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Booking.WPF.Views.Guest1     5      1ns"clr-namespace:Booking.Localization     5        N� Title$  FirstGuestProfile��5
         MyWindowStyle#���   6"   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   $��2��6d   .+�5      �� $ ��/Resources/Images/user.png��6   $��30��68   6F   �� 5      $��20(�67   $
��Bold"�6E   $��Center=�6W   ��6   '   !Booking.Localization.LocExtension  *MyProfileTitle+6{   5      �� 5   
   $��1��6   $��1��6   
���   �$��1q�6C    �� CornerRadius$ 10��6W   $
��Left=�6i   $��0,55, 0,190q�6�   
�������._�5      � $��Center=�6   $��Center=�60    5      �� 5      �� 5       �� 5!       5$      �� 5%      �� 5&      .+�5(      �� $��0��6?   $��0��6L   $��18(�6\   ��6     *NumberOfResevations+6m   �� 5)      $��0��6f   $��1��6s   $��18(�6�   ��6   �� *NumberOfReservations+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5*      $��1��65   $��0��6B   $��Center=�6R   $��18(�6m   ��6     *	YourTitle+6}   �� 5+      $��1��6   $��1��6*   $ 
Horizontal=�6:   .+�5,      �� $��Center=�6a   $��Center=�6~   $��18(�6�   ��6   �� *TypeOfGuest+$ PropertyChanged=�6�   �� 5-      $ ��/Resources/Images/star.png��6   $��40��6@   y�6L   �� *StarImageVisibility+$ PropertyChanged=�6�   5.      �� 5/      $��2��67   $��0��6D   $��18(�6T   ��6     *BonusPoints+6d   �� 50      $��2��6]   $��1��6j   $��Center=�6z   $��18(�6�   ��6   �� *BonusPoints+$ PropertyChanged=�6�   51      52      �� 54   
   $��1��6   $��0��6"   $��Right=�62   $	��Top=�6N   $��	0,40,30,0q�6f   .+�56      A� $	��190��6   $	��190��6"   $��10q�6/   ��57      �� 58       �� ImageSource$# /Resources/Images/profile.png��6!    j� Stretch$ UniformToFill=�6M   5:      �� 5;      $ 
Horizontal=�6   .+�5<      �� $
��Left=�64   $��17(�6O   $
��Bold"�6]   ��6     *
Username+6q   �� 5=      $��
zelic.kris��6   $��Center=�6.   $��17(�6K   $
��Bold"�6Y   6m   5>      5?      5C      5D      