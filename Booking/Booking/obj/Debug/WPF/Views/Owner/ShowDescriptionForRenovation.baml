   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   :    4Booking.WPF.Views.Owner.ShowDescriptionForRenovation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$"  ShowDescriptionForRenovation��5   	   $	��768��6.   $
��1024��6;    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��30 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��3q�6K   .+�5      �� $
��Bold"�6   $��17(�6&   .��65   Renovation description6M   5      �� 5   
   $��1��6   $��30��6"   $��	10,0,20,0q�6.   $ 
Horizontal=�6A   .+�5      �� $��16(�6   $
��Bold"�6"   .��64   Description:6B   �� 5      $��16(�6   $	��890��6G   ��6"   �� *DescriptionLabel+6U   5      �� 5   
   $ 
Horizontal=�6   $��	-20,0,0,0q�6.   $��Center=�6A   $��2��6^   $
��1024��6k   .+�5      �� $
��Left=�6   $��	34,15,0,0q�63   $��20(�6F   $
��Wrap=�6T   $	��Top=�6h   $
�� 500��6�   $	��970��6�   ��6�   �� *DescriptionTB+5      �� 5   
   $ 
Horizontal=�6   $��	-20,0,0,0q�6.   $��Center=�6A   $��2��6^   $
��1024��6k   .+�5      � $��LeftToRight=�6   $��500,570,0,0q�64   .+�5      �� $��	20 10 0 0q�6   $��Center=�6-    � ToolTip$  Press to close this window��6H   $
��Left=�6m   $	��120��6�   $��60��6�   $
��Bold"�6�   $��32(�6�   ��6�   �� *CloseWindow+.��6�   CLOSE6�   5      5      5       5!      