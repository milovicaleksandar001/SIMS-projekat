   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	   %    Booking.View.OwnerGradingGuests   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  OwnerGradingGuests��5   	   $	��768��6$   $
��1024��61    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��42(�68   $��Grading guests��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-120,0,480q�6   $
��1024��6*   $��Center=�67   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ AccommodationDataGrid��5      $��12 50 12 92q�62      	RowHeight$ 30Q�6G      
IsReadOnly . 	   AutoGenerateColumns	 .  $	��526��5   E   
   HeadersVisibility$
 Column=�6R   $��20(�6m   $	��980��6{    J� RenderTransformOrigin$ 0.503,0.552&�6�    �� SelectedItem 5      �� *SelectedReservation+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� *reservations+$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Accommodation.Name+  5      $ Arrival Day��6%   $ * 6:    6D   �� *
ArrivalDay+ �� StringFormat$ {0:dd/MM/yyyy}��  5      $ Departure Day��6%   $ * 6<    6F   �� *DepartureDay+$ {0:dd/MM/yyyy}��5      � 5   
   $��LeftToRight=�6   $��200,620,0,0q�60   .+�5       �� $��118 10 0 0 q�6   $
��Left=�6+    � ToolTip$; 5Select a reservation and then press this to grade it ��6F   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Grade+.��6�   GRADE6�   �� 5!      $��	60 10 0 0q�6   $��Center=�6)   $  Press to close this window��6D   $
��Left=�6i   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5"      � 5#   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5$      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5%      5&      5'      