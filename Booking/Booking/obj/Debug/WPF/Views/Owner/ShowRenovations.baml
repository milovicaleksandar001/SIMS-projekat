   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   -    'Booking.WPF.Views.Owner.ShowRenovations   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$  ShowRenovations��5   	   $	��768��6!   $
��1024��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Show renovations��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly . $��12 50 12 92q�5         	RowHeight$ 40Q�5      $��15(�5      $	��550��5      	   AutoGenerateColumns	 .  
   SelectionMode$
 Single=�5         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .   �� SelectedItem 5      �� *SelectedRenovation+��5      ��  �� Path$ Renovations� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Accommodation name��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *Accommodation.Name+6t     5!      $ Starting date��6%   $ * 6<    6F   �� *
StartDay+ �� StringFormat$ {0:dd/MM/yyyy}��  5"      $ Ending date��6%   $ * 6:    6D   �� *EndDay+$ {0:dd/MM/yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  5#      $ Description��6)   $ 90 6>      CellTemplate 5$      �� 5%      .R�5&      �� $
��Show��6%    � ToolTip$6 0Press to see the description for this renovation��64   ��6o   �� *DataContext.ShowDescription+ �� RelativeSource ��  �� AncestorType"  5'      5)      5,      � 5-   
   $��LeftToRight=�6   $��180,650,0,0q�60   .+�5.      �� $��118 -10 0 0 q�6   $
��Left=�6,   $X RChoose a request and then press this to accept the date move request and change it��6G   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Delete+.��6�   Delete6   �� 5/      $��
60 -10 0 0q�6   $��Center=�6*   $  Press to close this window��6E   $
��Left=�6j   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   50      � 51   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�52      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   53      54      55      