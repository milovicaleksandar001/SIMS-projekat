   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.GuideBooking.WPF.Views.Guide  5   	   7    1Booking.WPF.Views.Guide.GuideAcceptingTourRequest   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Guide     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  6=     � Title$  GuideAcceptingTourRequest��5   	   $	��650��6+   $	��883��68    � WindowStartupLocation$ CenterScreen=�6D    � 
ResizeMode$ NoResize=�6i   ���#D6E6F2.��5	      � .+�5
   
   �� $��65,4,0,0q�6   $
��Bold"�6&   $��32(�68   $��Accepting tour request��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��-18,-505,0,0q�6   $	��730��6*   $��Center=�66   �� 5   
   $��-20 -325 0 0q�6   $	��730��6+   $	��160��67   ���#C7E2ED
���   �$��2��6b    �� RadiusX$ 10��6v    �� RadiusY$ 10��6�   �� 5   
   $	��700��6   $	��150��6!   $��
0 -325 0 0q�6.   .+�5      �� $��	-8 15 0 0q�6   $��15(�6'   .��65   
Country:6?   �� 5      $	��120��6   $��25��6#   $��-445 -25 0 0q�6/   $��15(�6E   	 �� SelectedItem	 5      �� 
 �� Path$
 SelectedCountry� �� UpdateSourceTrigger$ PropertyChanged=���5      �� $
 CountryCollection�*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ SelectionChanged��6!   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6,   �� *FillCityCommand+5      5      �� 5!      $��	-8 25 0 0q�6   $��15(�6'   .��65   City:6<   �� 5"      $	��120��6   $��25��6#   $��-445 -25 0 0q�6/   $��15(�6E   {�5#      �� *CityComboboxEnabled+$ PropertyChanged=���5$      �� $
 CityCollection�	 5%      �� $
 SelectedCity�$ PropertyChanged=�6i   5&      �� 5(   
   $	��700��6   $	��150��6"   $��
0 -325 0 0q�6/   .+�5)      �� $��
220 15 0 0q�6   $��15(�6(   .��66   Guests number:6F   �� 5*      $	��120��6   $��25��6"   $��110 -25 0 0q�6.   $��15(�6C   ��6Q   �� *SelectedNumberOfGuests+6{   �� 5+      $��
220 25 0 0q�6   $��15(�6(   .��66   	Language:6A   �� 5,      $	��120��6   $��25��6"   $��110 -25 0 0q�6.   $��15(�6C   ��6Q   �� *SelectedLanguage+6u   5-      �� 5/   
   $	��700��6   $	��150��6"   $��
0 -325 0 0q�6/   .+�50      �� $��
480 15 0 0q�6   $��15(�6(   .��66   Start date:6C   (  "System.Windows.Controls.DatePicker  51      $	��120��6   $��25��6%   $��550 -26 0 0q�61   $��15(�6F      SelectedDate 6T   �� *	StartDate+6y   �� 52      $��
480 25 0 0q�6   $��15(�6(   .��66   	End date:6A     53      $	��120��6   $��25��6%   $��550 -26 0 0q�61   $��15(�6F    6T   �� *	EndDate+6w   54      � 56   
   $��-10 -195 0 0q�6   $	��180��6*   $��50��66   .+�57      �� $��65��6   $��30��6    $��Filter��6,   $��0 0 0 0q�6=   $��15(�6N   $
��Bold"�6\   ��6n   �� *Filter+ � 	Resources 58       �� 
TargetType �� Property �� Value��%c   '��       �� 59      " ��6   .�5:      ��  �@��CornerRadius$ 5��69   6E   5;      5<      5=      �� 5>      $��65��6   $��30��6    $��Reset��6,   $��15 0 0 0q�6<   $��15(�6N   $
��Bold"�6\   ��6n   �� *ResetFilter+ 5?      ��%c   '��       �� 5@      " ��6   .�5A      ��  �@��CornerRadius$ 5��69   6E   5B      5C      5D      5E      �� 5G   
   $��40 230 59 0q�6   .+�5I      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5J         
IsReadOnly . $	��725��5L      $	��320��5M         	RowHeight$ 50Q�5N       �� AlternationCount$ 2��5O         AutoGenerateColumns .     SelectionMode$ Single=�5Q         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .  	 5T      �� *SelectedTourRequest+��5U      �� $
 TourRequests�$ PropertyChanged=�   Columns 5V      0  *System.Windows.Controls.DataGridTextColumn  5X      ,	  &System.Windows.Controls.DataGridColumn  	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	  135
 6)   ! 	  Header$! State��65   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6D   �� *Location.State+6i     5Y      $	  135
 6)   $
! City��65   " 6C   �� *Location.City+6g     5Z      $	  130
 6)   $! Language��65   " 6G   �� *
Language+  5[      $	  100
 6)   $! Guests Number��66   " 6M   �� *GuestsNumber+  5\      $	  108
 6)   $! 
Start Date��65   " 6I   �� *	StartTime+# �� StringFormat$# {0:dd/MM/yyyy}��6�     5]      $	  109
 6)   $! End Date��65   " 6G   �� *	EndTime+$# {0:dd/MM/yyyy}��6�   $   RowStyle$ 5`      �� 5a      )  #System.Windows.Controls.DataGridRow"  6   .�5b      ��  � �� �#ADBAC467   % �� Triggers% 5c      P� 5d      & P� Property& �@��AlternationIndex' P� Value$' 0��6O   . �5e   "   ��  � �� �#F5F5F56?   5f      5h      5j      5k      � 5m   
   $��	0 560 0 0q�6   $	��160��6'   $��50��63   .+�5n      �� $��70��6   $��40��6    $��Accept��6,   $��0 0 0 0q�6=   $��15(�6N   $
��Bold"�6\   ��6n   �� *Accept+ 5o      ��%c   '��       �� 5p      " ��6   .�5q      ��  �@��CornerRadius$ 5��69   6E   5r      5s      5t      �� 5w      $��70��6   $��40��6    $��Close��6,   $��20 0 0 0q�6<   $��15(�6N   $
��Bold"�6\   ��6n   �� *Close+ 5x      ��%c   '��       �� 5y      " ��6   .�5z      ��  �@��CornerRadius$ 5��69   6E   5{      5|      5}      5~      5�      5�      