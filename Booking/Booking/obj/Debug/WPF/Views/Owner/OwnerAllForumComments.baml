   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   3    -Booking.WPF.Views.Owner.OwnerAllForumComments   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$  OwnerAllForumComments��5   	   $	��768��6'   $
��1024��64    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��42(�68   $��Forum comments��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6'      Color$ #303841��67      
BlurRadius$ 5Q�6G   5      �� 5      $��0,-120,0,480q�6   $
��1024��6.   $��Center=�6;   �� 5   
   $��1��6   $��10,-520,20,0q�6"   $��50��68    �� Orientation$ 
Horizontal=�6D   .+�5      �� $��17(�6   $
��Bold"�6"   .��64   Forum:6<   �� 5      $��17(�6   $	��930��6A   $��	0,-10,0,0q�6M   $��40��6`   ��6"   �� *
ForumLabel+6n   5      �� 5   
   $	��450��6   $	��550��6     �� SelectionMode$ Single=�6-   $��-420,-20,0,0q�6�    �� SelectedItem 6D   �� *SelectedComment+��6m   �� *ForumComments+��5      �� 5      .R�5      � 	 � RowDefinitions	 5      �� 5      �� 5      �� 5      �� 5       �� 5!      
 � ColumnDefinitions
 5#      �� 5$      $	��200 �6/   �� 5%      $��80 �6/   .+�5(      �� $��0��6$   $��0��61   $��20(�6A   $
��Bold"�6u   ��6O   �� *Forum.Location.State+6u   �� 5)      $��0��6$   $��1��61   $��20(�6A   $
��Bold"�6t   ��6O   �� *Forum.Location.City+6t   �� 5+      $��1��6%   $��0��62   .+�5,      �� $��15(�6(   $
��Wrap=�6O   ��66   �� *	Comment+6O   5-      �� 5/      $��2��6$   $��0��61   $��15(�6A   $��User: ��6O   �� 50      $��2��6$   $��1��61   $��15(�6A   ��6O   �� *User.Username+�� 52      $��3��6$   $��0��61   $��15(�6A   $��	Reports: ��6O   �� 53      $��3��6$   $��1��61   $��15(�6A   ��6O   �� *	Reports+�� 55      $��4��6$   $��0��61   $��15(�6A   $��	Visited: ��6O   �� 56      $��4��6$   $��1��61   $��15(�6A   ��6O   �� *	Visited+58      59      5;      �� 5<   
   $��15(�6   $	��400��6    $	��400��6,    � ToolTip$ Press to enter a comment��69   $��
580,30,0,0q�6\    �� TextWrapping$
 Wrap=�6p   ��6�   ��  �� Path$ OwnerComment� �� UpdateSourceTrigger$ PropertyChanged=��� 5=   
   $��Comment��6   $
��Left=�6"   $��720,130,0,0q�6=   $��	ExtraBold"�6R   $	��Top=�6i   $��32(�6�   � 5?   
   $��LeftToRight=�6   $��120,640,0,0q�60   .+�5@      �� $��118 -10 0 0 q�6   $
��Left=�6,   $ Press to leave a comment��6G   $	��150��6j   $��75��6v   $
��Bold"�6�   $��28(�6�   ��6�   �� *LeaveComment+.��6�   	COMMENT6�   �� 5A      $��
10 -10 0 0q�6   $��Center=�6*   $- 'Choose a comment and press to report it��6E   $
��Left=�6w   $	��150��6�   $��75��6�   $
��Bold"�6�   $��28(�6�   ��6�   �� *Report+.��6�   REPORT6�   �� 5B      $��
60 -10 0 0q�6   $��Center=�6*   $  Press to close this window��6E   $
��Left=�6j   $	��150��6�   $��75��6�   $
��Bold"�6�   $��28(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5C      � 5D   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5E      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5F      5G      5H      