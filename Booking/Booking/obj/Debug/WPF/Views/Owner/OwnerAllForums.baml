   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   ,    &Booking.WPF.Views.Owner.OwnerAllForums   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$  OwnerAllForums��5   	   $	��768��6    $
��1024��6-    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��42(�68   $��Forums��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-120,0,480q�6   $
��1024��6*   $��Center=�67   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly . $��12 50 12 92q�5         	RowHeight$ 40Q�5      $��20(�5      $	��550��5      	   AutoGenerateColumns	 .  
   SelectionMode$
 Single=�5         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .   �� SelectedItem 5      �� *SelectedForum+��5      ��  �� Path$ Forums� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ State��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Location.State+6c     5!      $ * 6%   $
 City��6/    6=   �� *Location.City+  5"      $ Creator��6%   $ * 66    6@   �� *User.Username+  5#      $ * 6%   $ Status��6/    6?   �� *Status+6\     5$      $ * 6%   $ Very helpful��6/    6E   �� *	Helpful+6c   5&      � 5'   
   $��LeftToRight=�6   $��200,620,0,0q�60   .+�5(      �� $��118 10 0 0 q�6   $
��Left=�6+   $	��150��6G   $��75��6S    � ToolTip$* $Press to see comments for this forum��6_   $
��Bold"�6�   $��35(�6�   ��6�   �� *ShowComments+.��6�   SEE6�   �� 5)      $��	60 10 0 0q�6   $��Center=�6)   $
��Left=�6D   $	��150��6_   $  Press to close this window��6k   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5*      � 5+   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5,      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5-      5.      5/      