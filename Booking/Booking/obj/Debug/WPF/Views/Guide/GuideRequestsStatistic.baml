   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Booking.WPF.ViewModels.GuideBooking.WPF.ViewModels.Guide  5   P   4    .Booking.WPF.Views.Guide.GuideRequestsStatistic   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <guide*clr-namespace:Booking.WPF.ViewModels.Guide     6P   ���#D6E6F2  � Title$  GuideRequestsStatistic��5   	   $	��650��6(   $	��830��65    � WindowStartupLocation$ CenterScreen=�6A    � 
ResizeMode$ NoResize=�6f    � 	Resources 5	          BooleanToVisibilityConverter��%   &	        �� 5
   
   6'   5      .��5      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Requests statistics��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��
0 -378 0 0q�6   $��50��6)   .+�5   
   o� $��50��6   $��18(�6   $��SemiBold"�6*   
������ .@�5      m� $��50 0 0 0q�6   
����d�$��1q�6K   $��35��6_   $��
_Generally��6k    m� Command 5      �� *Menu_Generally+��5      �� *Menu_Generally_Color+m� 5      $��35��6   
����d�$��1q�6D   $��_Yearly��6X    5      �� *Menu_ThisYear+��5      �� *Menu_Yearly_Color+�� 5      
����d�$	��0.8q�69   $��	-40 0 0 0q�6O   $	��855��6b   6p   5      5      �� 5    
   $��0,-10,0,480q�6   $	��800��6)   $��Center=�65   �� 5"   
   $��35��6   $��35��6   $��760 -396 0 0q�6)   ���#FFF980��6?   �� *Button_Click_GenerateReport+.��5#      �� .+�5$      �� $*��$/Resources/Images/document-pdf64.png��6   5%      5&      �� 5(   
   	 �� Orientation$	 
Horizontal=�6   $��300 -280 0 0q�6.   .+�5)      	� -   5        
 	�Name$
 LocationRadio��5)      $��Location��61   $��15(�6D   $	��5,0q�6R   $��Center=�6_    d� 	IsChecked 6z   �� *IsLocationSelected+ 5*       �� 
TargetType �� Property �� Value��%�   '	�       �� 5+      " 	�6   .�5,      ��  � �� �#33333367   �� 5-       � ��
 ��·�67   �� 5.       � �� �#CCCCCC68   �� 5/       � ��$
 10,5q�64   �� 50       � ��$ 0,0,5,0q�63   51      52      53      	� 55      -   5        $
 LanguageRadio��55      $��Language��61   $��15(�6D   $	��5,0q�6R   $��Center=�6_    6z   �� *IsLanguageSelected+ 56      ��%�   '	�       �� 57      " 	�6   .�58      ��  � �� �#33333367   �� 59       � ��
 ��·�67   �� 5:       � �� �#CCCCCC68   �� 5;       � ��$
 10,5q�64   5<      5=      5>      5?      �� 5A   
   $��
80 210 0 0q�6   .+�5C      �� $��SemiBold"�6   $��15(�6*   $��
 Location:��68   6O   �� 5D      -   5         ��Name$ LocationComboBox��5D      $��-360 -26 0 0q�61   $��15(�6G   $	��200��6U   $��27��6a   {�5E      ��  �� ElementName$ LocationRadio�� �� Path$ 	IsChecked���5F      �� $ LocationsCollection� �� SelectedItem 5G      �� $ SelectedLocation� �� UpdateSourceTrigger$ PropertyChanged=�5L      �� 5N   
   $��415 210 0 0q�6   .+�5P      �� $��SemiBold"�6   $��15(�6*   $��
 Language:��68   6O   �� 5Q      -   5         ��Name$ LanguageTextBox��5Q      $��15(�6/   $	��200��6=   $��27��6I   $��-10 -25 0 0q�6U   ��6j   �� *
LanguageTB+{�6�   �� $ LanguageRadio��$ 	IsChecked�5T      �� 5V   
   $��300 260 0 0q�6   .+�5X      �� $��SemiBold"�6   $��15(�6*   $�� Year:��68   y�6I   �� *IsLabelYearVisible+ �� 	Converter# [  6�   �� 5Y      -   5        $ YearTextBox��5Y      $��15(�6+   $��90��69   $��27��6D   $��-290 -25 0 0q�6P   ��5Z      �� *YearTB+y�5[      �� *IsTBYearVisible+# [  5^      �� 5`   
   $��	0 305 0 0q�6   .+�5a      &   System.Windows.Controls.DataGrid  -   5          Name$ GenerallyDataGrid��5b      
���   �   SelectionMode$ Single=�5d         
IsReadOnly . $��0,0,0,0q�5f      $	��258��5g      $	��220��6      	RowHeight$ 35Q�5h         AutoGenerateColumns .     CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .     CanUserReorderColumns .  y�5j   �   �� *IsDataGridGenerallyVisible+# [  ��5k      �� $ RequestsByYearCollection�$ PropertyChanged=�.@�6i   >    Columns  5n      0  *System.Windows.Controls.DataGridTextColumn  5o      ,  &System.Windows.Controls.DataGridColumn!   Width5  /System.Windows.Controls.DataGridLengthConverter$	! 125 6)   "   Header$
" Year��65   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6C   �� *Year+6^     5p      $	! 125 6)   $" Requests��65   # 6G   �� *Count+6c   $   RowStyle$ 5s      �� 5t      )  #System.Windows.Controls.DataGridRow"  6   .�5u      ��  � �� �#ADBAC467   % �� Triggers% 5v      P� 5w      & P� Property& �@��AlternationIndex' P� Value$' 0��6O   . �5x   "   ��  � �� �#F5F5F56?   5y      5{      5}      5~      �� 5�   
   $��	0 305 0 0q�6   .+�5�        -   5        $ YearlyDataGrid��5�      
���   �$ Single=�5�       . $��0,0,0,0q�5�      $	��258��5�      $	��220��6   $ 35Q�5�       .   .   .   .   .   .  y�5�   �   �� *IsDataGridYearlyVisible+# [  ��5�      �� $ RequestsByMonthCollection�$ PropertyChanged=�.@�6j   >  5�        5�      $	! 125 6)   $" Month��65   # 6D   �� *	MonthName+6d     5�      $	! 125 6)   $" Requests��65   # 6G   �� *Count+6c   $ 5�      �� 5�      "  6   .�5�      ��  � �� �#ADBAC467   % 5�      P� 5�      & �@��AlternationIndex$' 0��6O   . �5�   "   ��  � �� �#F5F5F56?   5�      5�      5�      5�      � 5�   
   $��	0 545 0 0q�6   $	��160��6'   .+�5�      �� $��40��6   $��70��6!   $��13(�6,   $
��Bold"�6:   $
��Show��6L   ��6[   �� *Show+ 5�      ��%c   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   6E   5�      5�      5�      �� 5�   
   $��15 0 0 0q�6   $��40��6#   $��70��6/   $��13(�6:   $
��Bold"�6H   $��Close��6[   ��6k   �� *Close+ 5�      ��%c   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 5��69   6E   5�      5�      5�      5�      5�      5�      