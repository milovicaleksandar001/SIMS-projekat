   M S B A M L   `   `   `  ����  Booking&     Booking.View.GuideKeyPointsCheck   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � Title$ GuideKeyPointsCheck��5   	   $	��375��6%   $	��660��62   ���#D6E6F2.��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��404* �6   �� 5      $
��197* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ GridKeyPoints��5   	   $��25,27,132,57q�5   	   $	��270��5   	   $	��250��6      
IsReadOnly .    AutoGenerateColumns .     SelectionMode$ Single=�5   	   |�.     CanUserResizeColumns .  	   CanUserAddRows	 .  
   CanUserResizeRows
 .   �� SelectedItem 5   	   �� *SelectedTourKeyPoint+��5   	   ��  �� Path$ 	KeyPoints� �� UpdateSourceTrigger$ PropertyChanged=�   	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value
 ���� 63   �� 5       � ��
 ���� 64   �� 5       � ��$ 1q�68   �� 5       � ��$ 5q�60    �� Triggers 5       P� 5!       P� Property �@ 
IsSelected P� Value . . �5"      ��  � ��
 �   �6;   �� 5#       � ��
 � ���6;   �� 5$       � ��
 �����6<   5%      5'         Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ State��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Location.State+6c     5+      $ * 6%   $
 City��6/    6=   �� *Location.City+6a   4  .System.Windows.Controls.DataGridCheckBoxColumn  5,      $ 60 6)   $ Achieved��64    6F   �� *
Achieved+   	CellStyle 5-      �� 5.      "  6    .�5/      ��  � ��$ No��68    50      P� 51   "    �@ 
IsSelected . . �52   &   ��  � ��
 �   �6C   �� 53   &    � ��
 � ���6C   �� 54   &    � ��
 �����6D   55   #   �� 56   "    �� Binding 6.   �� *
Achieved+ �� Value True6K   .a�57   &   ��  � ��$	 Yes��6@   58   #   5:      5<      5>        5@   
   -   5        $ 	GridGuest��5A      $��345,27,25,57q�5B   	   $	��270��5C   	   $	��250��6    .  .  $ Single=�5F   	   |�.   .  	 .  
 .  $��2��5J   R    5I   	   �� *SelectedGuest+��5J   	   �� $ Guests�$ PropertyChanged=� 5L      �� 5M      "  6   .�5N      ��  � ��
 ���� 63   �� 5O       � ��
 ���� 64   �� 5P       � ��$ 1q�68   �� 5Q       � ��$ 5q�60    5R      P� 5S       �@ 
IsSelected . . �5T      ��  � ��
 �   �6;   �� 5U       � ��
 � ���6;   �� 5V       � ��
 �����6<   5W      5Y       5[        5\      $ * 6%   $
 Name��6/    6=   �� *
Username+6\   5_      � 5a   
   $��LeftToRight=�6   $
��Left=�60   $	��Top=�6K   $��50��6c   $	��200��6o   $��220,288,0,0q�6{    K� ZIndex$ 1��6�   .+�5b      �� $��Achieve��6   $��70��6(   $��35��63   $��12(�6A   $��9 0 0 0q�6O   $
��Bold"�6a   $��Center=�6t   $��Center=�6�   ��6�   �� *AchieveKeypoint+ � 	Resources 5c      ��%c   '��       �� 5d      " ��6   .�5e      ��  �@��CornerRadius$ 5��69   6E   5f      5g      5h      �� 5i      $��	Add Guest��6   $��70��6*   $��35��65   $��12(�6B   $��48 0 0 0q�6P   $
��Bold"�6c   $��Right=�6v   $��Center=�6�   ��6�   �� *
AddGuest+ 5j      ��%c   '��       �� 5k      " ��6   .�5l      ��  �@��CornerRadius$ 5��69   6E   5m      5n      5o      5p      5r      5s      