   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   :    4Booking.WPF.Views.Owner.ShowOwnerAccommodationImages   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$"  ShowOwnerAccommodationImages��5   	   $	��768��6.   $
��1024��6;    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��3q�6K   .+�5      �� $%��/Resources/Images/imageIcon.png��6   $��30��6=   $��30��6I   6V   �� 5      $
��Bold"�6   $��17(�6&   .��65   Accommodation images6K   5      �� 5   
   $��1��6   $��	10,0,20,0q�6"   $ 
Horizontal=�65   .+�5      �� $��17(�6   $
��Bold"�6"   .��64   Accommodation:6D   �� 5      $��17(�6   $	��500��6I   ��6"   �� *AccommodationLabel+6W   5      �� 5   
   $ 
Horizontal=�6   $��	-20,0,0,0q�6.   $��Center=�6A   $��2��6^   $
��1024��6k   .+�5      �� -   5         ��Name$ PreviousButton��5      $��30q�6z    � ToolTip$' !Press to see the previous picture��6�   $��30��6�   $��95��6�   {�6-   �� *IsPreviousEnabled+ �� UpdateSourceTrigger$ PropertyChanged=���6�   �� *PreviousButton_Click+��5      �� 5      $ 
Horizontal=�6!   .+�5      �� $��25��6!   $��30��6,   $$��/Resources/Images/prevoius.png��68   �� 5      $��PREVIOUS��6$   $��5q�64   $��SemiBold"�6?   5      5       �� 5!      $��0��6   $	��500��6!   $��10q�6.   $	��750��6:   ��6F   �� *CurrentImageUrl+ �� Mode$ OneWay=�$ PropertyChanged=��� 5"      -   5        $ 
NextButton��5"      $��10q�6*   $��30��66   $# Press to see the next picture��6B   $��80��6j   ��6u   �� *NextButton_Click+{�6�   �� *IsNextEnabled+$ PropertyChanged=���5#      �� 5$      $ 
Horizontal=�6!   .+�5%      �� $
��NEXT��6$   $��5q�60   $��SemiBold"�6;   �� 5&      $��25��6!   $��30��6,   $ ��/Resources/Images/next.png��68   5'      5)      5*      � 5+   
   $��LeftToRight=�6   $��500,740,0,0q�60   .+�5,      �� $��70 -100 0 0q�6   $��Center=�6+   $  Press to close this window��6F   $
��Left=�6k   $	��120��6�   $��60��6�   $
��Bold"�6�   $��32(�6�   ��6�   �� *CloseWindow+.��6�   CLOSE6�   5-      5.      5/      