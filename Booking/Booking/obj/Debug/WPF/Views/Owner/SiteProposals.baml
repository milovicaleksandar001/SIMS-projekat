   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Booking.WPF.Views.OwnerBooking.WPF.Views.Owner  5   	   +    %Booking.WPF.Views.Owner.SiteProposals   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Booking.WPF.Views.Owner     5   	     � Title$  SiteProposals��5   	   $	��768��6   $
��1024��6,    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Site proposals��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   �� 5   
   $��120,-540,20,0q�6   $��70��6,    �� Orientation$ 
Horizontal=�69   .+�5      �� $��40(�6   $
��Bold"�6"   .��64   Good locations6D   5      �� 5   
   $��590,-540,20,0q�6   $��70��6,   $ 
Horizontal=�69   .+�5      �� $��40(�6   $
��Bold"�6"   .��64   Bad locations6C   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5         
IsReadOnly . $��-450 130 12 92q�5      	   	RowHeight$	 40Q�5      $��20(�5       $	��500��5!      $	��375��5"      
   AutoGenerateColumns
 .     SelectionMode$ Single=�5$         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .  ��5&      ��  �� Path$ GoodLocations� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Country��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *State+6\     5)      $ * 6%   $
 City��6/    6=   �� *City+6X   5+        5-   
   -   5        $ 	dataGrid2��5.       . $��450 130 12 92q�50      $	 40Q�51      $��20(�52      $	��500��53      $	��375��54      
 .  $ Single=�56       .   .   .   .  ��58      �� $ BadLocations�$ PropertyChanged=� 59        5:      $ * 6%   $ Country��6/    6@   �� *State+6\     5;      $ * 6%   $
 City��6/    6=   �� *City+6X   5=      � 5?   
   $��LeftToRight=�6   $��500,650,0,0q�60   .+�5@      �� $��	35 -5 0 0q�6   $��Center=�6)    � ToolTip$  Press to close this window��6D   $
��Left=�6i   $	��150��6�   $��75��6�   $
��Bold"�6�   $��32(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5A      � 5B   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5C      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5D      5E      5F      