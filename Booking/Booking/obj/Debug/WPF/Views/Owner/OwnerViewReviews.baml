   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	   #    Booking.View.OwnerViewReviews   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  OwnerViewReviews��5   	   $	��768��6"   $
��1024��6/    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��View reviews��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly . $��12 50 12 92q�5         	RowHeight$ 40Q�5      $��15(�5      $	��550��5      	   AutoGenerateColumns	 .  
   SelectionMode$
 Single=�5         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .   �� SelectedItem 5      �� *SelectedGrade+��5      ��  �� Path$ Grades� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Accommodation name��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *-+AccommodationReservation.Accommodation.Name+6�     5!      $ * 6%   $ Cleanliness��6/    6D   �� *
Cleaness+  5"      $ Owner courtasy��6%   $ * 6=    6G   �� *OwnersCourtesy+4  .System.Windows.Controls.DataGridTemplateColumn  5#      $ Comment��6)   $ 80 6:      CellTemplate 5$      �� 5%      .R�5&      �� $
��Show��6%    � ToolTip$C =Press to see the comment that the guest wrote for this review��64   ��6|   �� *DataContext.ShowComment+ �� RelativeSource ��  �� AncestorType"  5'      5)        5*      $ * 6%   $ Guest��6/    6>   �� *)'AccommodationReservation.Guest.Username+6|     5,      $ Images��6)   $ 80 69    5-      �� 5.      .R�5/      �� $
��Show��6%   $G APress to see the pictures that the guest uploaded for this review��64   ��6�   �� *DataContext.ShowPictures+ �� "  50      52      55      � 56   
   $��LeftToRight=�6   $��500,650,0,0q�60   .+�57      �� $��
20 -10 0 0q�6   $��Center=�6*   $  Press to close this window��6E   $
��Left=�6j   $	��150��6�   $��75��6�   $
��Bold"�6�   $��32(�6�   ��6�   �� *CloseWindow+.��6�   CLOSE6�   58      � 59   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5:      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5;      5<      5=      