   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   =    7Booking.WPF.Views.Owner.AccommodationStatisticsByMonths   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$%  AccommodationStatisticsByMonths��5   	   $	��768��61   $
��1024��6>    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Accommodation statisctics��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   �� 5   
   $��10,-570,20,0q�6   $��30��6+    �� Orientation$ 
Horizontal=�67   .+�5      �� $��17(�6   $
��Bold"�6"   .��64   Accommodation:6D   �� 5      $��17(�6   $	��500��6I   ��6"   �� *AccommodationLabel+6W   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly . $��
12 0 12 92q�5      	   	RowHeight$	 40Q�5      $��15(�5      $	��400��5      
   AutoGenerateColumns
 .     SelectionMode$ Single=�5         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .  ��5!      ��  �� Path$ monthStatistics� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6%      Header$ Month��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Month+  5$      $ * 6%   $ Number of reservations��6/    6O   �� *NumberOfReservations+  5%      $ Number of cancelations��6%   $ * 6E    6O   �� *NumberOfCancelations+  5&      $ * 6%   $ Number of reschedulings��6/    6P   �� *NumberOfReschedulings+  5'      $ * 6%   $ Number of suggestions��6/    6N   �� *NumberOfSuggestions+5)      �� 5+   
   $��10,400,20,0q�6   $��50��6*   $ 
Horizontal=�67   .+�5,      �� $��30(�6   $
��Bold"�6"   .��64   Best month:6A   �� 5-      $��30(�6   $	��850��6E   ��6"   �� *BestMonthLabel+6S   5.      � 50   
   $��LeftToRight=�6   $��500,650,0,0q�60   .+�51      �� $��
20 -10 0 0q�6   $��Center=�6*    � ToolTip$  Press to close this window��6E   $
��Left=�6j   $	��150��6�   $��75��6�   $
��Bold"�6�   $��32(�6�   ��6�   �� *Close+.��6�   CLOSE6�   52      � 54   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�55      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   56      57      58      