   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   3    -Booking.WPF.Views.Owner.SchedulingRenovations   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$  SchedulingRenovations��5   	   $	��768��6'   $
��1024��64    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
   
      ValidationTemplate ��Name��%�   &	        �� 5      .R�5      �� .+�5      �� $ NameTextBox��60   �� 5      
���  ����6    �� *[0].ErrorContent+6B   5      5      5      .��5      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Scheduling renovations��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   �� 5   
   $��
10,80,20,0q�6    �� Orientation$ 
Horizontal=�6)   .+�5      �� $��25(�6   $
��Bold"�6"   .��64   Accommodation:6D   �� 5      $��25(�6   $	��780��6I   ��6"   �� *AccommodationLabel+6W   5      �� 5    
   $��Start date*��6   $
��Left=�6&   $��
50,150,0,0q�6A   $	��Top=�6U   $��25(�6m   �� 5!   
   $��	End date*��6   $
��Left=�6$   $��
50,300,0,0q�6?   $	��Top=�6S   $��25(�6k   �� 5"   
   $"��Renovation duration in days*��6   $
��Left=�67   $��
50,450,0,0q�6R   $	��Top=�6f   $��25(�6~   (  "System.Windows.Controls.DatePicker  5#   
   $	��350��6   $��150,-400,0,0q�6!   	 � ToolTip$	 Press to enter a date��67   $��40��6W   
   SelectedDateFormat$
 Short=�6�      SelectedDate 6c   �� *
StartDay+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ {0:dd/MM/yyyy}��6�     5$   
   $	��350��6   $��150,-100,0,0q�6!   $��40��67   $	 Press to enter a date��6C   $
 Short=�6�    6c   �� *EndDay+$ TwoWay=�$ PropertyChanged=�$ {0:dd/MM/yyyy}��6�   �� 5%   
   $
��Left=�6   $��413,455,0,0q�6-    �� TextWrapping$
 Wrap=�6B   $4	 .Press to enter how long the renovation will be��6V   $	��Top=�6�   $��40��6�   $	��350��6�   $��25(�6�    =� ErrorTemplate# [  6K  ��6�   ��  �� Path$ Duration�$ PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . .��6�  ��5&      �� 5'       �� 
TargetType" ��6    �� Triggers 5(      P� 5)       P� Property �@=�HasError P� Value . . �5*      ��  �� Property � �� �� Value
 �  ��6<   5+      5-      .��5.      5/      � 50   
   $��LeftToRight=�6   $��200,620,0,0q�60   .+�51      �� $��118 10 0 0 q�6   $
��Left=�6+   $	��150��6G   $��75��6S   $"	 Press to see available dates��6_   $
��Bold"�6�   $��35(�6�   ��6�   �� *Find+.��6�   FIND6�   �� 52      $��	60 10 0 0q�6   $��Center=�6)   $
��Left=�6D   $	��150��6_   $ 	 Press to close this window��6k   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   53      � 54   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�55      �� $��
118 5 0 0 q�6   $
��Left=�6*   $	 Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   56      57      58      