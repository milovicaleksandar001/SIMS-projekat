   M S B A M L   `   `   `  ����  Booking&     Booking.View.GuideFollowTourLive   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   ���#D6E6F2 � Title$ GuideFollowTourLive��5	   	   $	��800��6%   $	��990��62   .��5
      � .+�5   
   �� $��	38 16 0 0q�6   $
��Bold"�6'   $��40(�69   $��Follow tour live��6G   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��40 -610 0 0q�6   $	��893��6)   $
��Left=�65   � 5   
   $��LeftToRight=�6   $��Center=�60   $	��Top=�6M   $��87��6e   $	��536��6q   $��	0,700,0,0q�6}    K� ZIndex$ 1��6�   .+�5      �� $��
Start tour��6   $	��105��6+   $��45��67   $��15(�6C   $��42 0 0 0q�6Q   $
��Bold"�6d   $��Center=�6v   $��Center=�6�   ��6�   �� *	StartTour+ � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%c   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 5��69   6E   5      5      5      �� 5      $	��105��6   $��45��6"   $��15(�60   $��10 0 0 0q�6>   $
��Bold"�6Q   $��Center=�6c   $��Center=�6�   ��6�   �� *ShowOnGoingTour+ 5      ��%c   '��       �� 5      "	 ��6   .�5      �� 
 �@��CornerRadius$ 5��69   6E   5       5!      .��5"      �� .+�5#      �� $��Center=�6    Show6C   �� 5$      ongoing tour6.   5%      5&      �� 5(      $��End tour��6   $	��105��6*   $��45��66   $��15(�6C   $
��Bold"�6Q   $��10 0 0 0q�6c   $��Center=�6u   $��Center=�6�   ��6�   �� *	EndTour+ 5)      ��%c   '��       �� 5*      "	 ��6   .�5+      �� 
 �@��CornerRadius$ 5��69   6E   5,      5-      5.      �� 5/      $��Close��6   $	��105��6'   $��45��63   $��15(�6@   $
��Bold"�6N   $��10 0 0 0q�6`   $��Center=�6r   $��Center=�6�   ��6�   �� *Close+ 50      ��%c   '��       �� 51      "	 ��6   .�52      �� 
 �@��CornerRadius$ 5��69   6E   53      54      55      56      �� 58   
   $��40 100 40 0q�6   .+�5:      �� .��5;      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5<         
IsReadOnly . $	��900��5>      $	��300��5?         	RowHeight$ 50Q�5@         AutoGenerateColumns .     SelectionMode$ Single=�5B         CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserReorderColumns .   �� SelectedItem 5E      �� *SelectedTour+��5F      ��  �� Path$ Tours� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6)      Header$
 Name��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Name+6^     5I      $	 105 6)   $ State��65    6D   �� *Location.State+6i     5J      $	 105 6)   $
 City��65    6C   �� *Location.City+6g     5K      $	 100 6)   $ Language��65    6G   �� *
Language+  5L      $ Max Visitors��6)   $ 90 6?    6J   �� *MaxVisitors+  5M      $	 100 6)   $ Departure Date��65    6M   �� *	StartTime+ �� StringFormat$ {0:dd/MM/yyyy}��6�     5N      $ 80 6)   $ Duration��64    6F   �� *
Duration+6e   4  .System.Windows.Controls.DataGridCheckBoxColumn  5O      $ 70 61   $ Is Started?��6<    6Q   �� *	IsStarted+   	CellStyle 5P      �� 5Q   "   *  $System.Windows.Controls.DataGridCell"	  6(   .�5R   &   �� 
 � ��$ No��6@    �� Triggers 5S   &   �� 5T   *    �� Binding 66   �� *	IsStarted+  �� Value  True6T   .a�5U   .   �� 
 � ��$	 Yes��6H   5V   +   5X   #   5Z      4	  .System.Windows.Controls.DataGridTemplateColumn	  5[      $ Description��61   ! 	  CellTemplate! 5\      �� 5]   "   .R�5^   &   �� $
��Show��6.   $��11(�6=   $��65��6K   $��45��6V   $��Oblique$�6b   ��6v   �� *!DataContext.ShowDescriptionText+" �� RelativeSource" �� # �� AncestorType"#   5_   *   ��%c   '��       �� 5`   .   "	 ��64   .�5a   2   �� 
 �@��CornerRadius$ 5��6Q   6]   5b   /   5c   +   5d   '   5e   #   5g      5k      5l      5m      �� 5n   
   $��
50,425,0,0q�6   $	��250��6(   $��SemiBold"�64   $��22(�6J   $��Photos of started tour:��6X   $��Italic$�6w   ���#303841 5o        5p      $ 1Q�6#   $ 	#FFFFF200��63   $ 9Q�6E   5r      �� 5t   
   
���   �$��2q�6%   ._�5u      �� $��	0,380,0,0q�6   $	��350��6,   $	��200��68   .+�5v      �� $	��⬅��6   $��18��6%   $��18��61   $��-315 85 0 0q�6<   ��6Q   �� *PreviousPicture+y�6u   �� *ButtonPreviousVisibility+�� 5x      $	��➞��6   $��18��6%   $��18��61   $��320 -15 0 0q�6<   ��6Q   �� *NextPicture+y�6q   �� *ButtonNextVisibility+�� 5z      $��UniformToFill=�6   $	��185��60   $	��280��6=   $��
0 -100 0 0q�6I   ��6]   �� *ImageSlideshowSource+5|      5}      5      5�      