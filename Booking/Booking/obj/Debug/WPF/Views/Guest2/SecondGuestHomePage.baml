   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	   +clr-namespace:Booking.ViewBooking.View  5      &     Booking.View.SecondGuestHomePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      *	behaviorsclr-namespace:Booking.View  5        � Title$  SecondGuestHomePage��5
   	   $	��800��6%   $
��1200��62    � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�6(   ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid  ButtonStyle �� 	Resources  
CardHolder  NumericUpDownStyle��%(  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� 4    7  '�� �    7  '      7  &	 �    7  &	 �    7  &	 $    �� 5      $ #348EF6��6-   �� 5      $ #EFF2FF��6/   �� 5      $
 #FFF��60   �� 5      $
 #000��6+   �� 5      $ #BBC1D1��6-   �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   �� 5       � ��$ Center=�60   5      �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   5       �� 5"      " ��6
   .�5#      ��  � ��8   6"   �� 5$       � ��$ Calibri)�6"   5%      �� 5'      "  6
   .�5(      ��  � ��8   6"   �� 5)       � ��$ Calibri)�6"   �� 5*       � ��$ 14(�6    5+      �� 5-      " ��6   .�5.      ��  � ��8   6"   �� 5/       � ��$ Calibri)�6"    50      ���� 51      '��       " ��6   .�52      ��  �@��CornerRadius$ 6��6&   53      54      55      �� 57      " ��6   .�58      ��  � ��8   6"   �� 59       �@��CornerRadius$ 6��6$   �� 5:       �@��Padding$ 8q�6(   5;      �� 5=      " ��6%   .�5>      ��  � ��$ Center=�60   �� 5?       � ��$ Center=�62   5@      5A      	 J� InputBindings	 5C      �� 5D   
   

 �� Key$
 F1��6=    �� Command 6   �� *Button_Click_Search+6=   �� 5E   
   $
 F2��6>    6   �� *Button_Click_ShowAll+6>   �� 5F   
   $
 F3��6G    6   �� *Button_Click_ShowDestinations+6G   �� 5G   
   $
 F4��6A    6   �� *Button_Click_ShowImages+6A   �� 5H   
   $
 F5��6>    6   �� *Button_Click_Reserve+6>   �� 5I   
   $
 S��6B    �� 	Modifiers$
 Ctrlf�6J    6   �� *Button_Click_TourRequest+6J   �� 5J   
   $
 C��6I   $
 Ctrlf�6Q    6   �� *!Button_Click_TourComplexRequest+6Q   .��5M      �  � ColumnDefinitions 5O      �� 5P      $��* �6    � RowDefinitions 5S      �� 5T      $
��auto �6   �� 5U      $
��auto �6   �� 5V      $��* �6   .+�5Y   
   o� $��30��6   ��5Z      �� 5[      .R�5\      ]� $��Stretch=�6    5]      .@�5_      m� $��_Request��6   $��14(�6)   $��30��67   .@�5`      m� $��_Simple tour��6   $��14(�61    m� InputGestureText$ Ctrl+S��6l    m� Command 6?   �� *Button_Click_TourRequest+6l   m� 5a      $��_Complex tour��6   $��14(�62   $ Ctrl+C��6t    6@   �� *!Button_Click_TourComplexRequest+6t   5b      m� 5c      $��	_Vouchers��6   $��14(�6*    68   �� *Button_Click_ShowVouchers+m� 5d      $��_Statistics��6   $��14(�6,    6:   �� *Button_Click_Statistics+m� 5e      $��	_Tutorial��6   $��14(�6*    68   �� *Button_Click_Tutorial+m� 5f      $��_Notifications��6   $��14(�6/   $��Right=�6l    6=   �� *Button_Click_Notifications+6l   m� 5g      $��_Log out��6   $��14(�6)   $��Right=�6`    67   �� *Button_Click_SignOff+6`   5h      �� 5j   
   $��1��6   $��8 8 8 4q�6   #��[ 6/   ._�5k      �  5m      �� 5n      $��* �6    5q      �� 5r      $
��auto �6   �� 5s      $��* �6   .+�5v      �� $��0��6   $��0 0 0 8q�6    �� Orientation$ 
Horizontal=�6/   .+�5w      �� $*��$/Resources/Images/destination128.png��6   $��40��6;   �� 5x      $��Active tour��6   $��24(�6#   $��8 0 0 0q�61   $��Center=�6B   5y      �� 5{      $��1��6   $��There is no active tour��6%   $��14(�6n   $��Center=�6|   y�6G   �� *LabelVisibility+6|     5|      $��1��6      AutoGenerateColumns .     SelectionMode$ Single=�5~   	      
IsReadOnly . $��0 8 0 0q�5�   	      CanUserResizeColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     CanUserSortColumns .     CanUserReorderColumns .  ��5�   	   �� *
ActiveTour+y�5�      �� *DataGridVisibility+   RowStyle 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"  6   .�5�   	   ��  �@J�IsHitTestVisible .  6,   5�   	      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *	Tour.Name+  5�      $ Current State��6   $ * 62    6<   �� *Tour.Location.State+  5�      $ Current City��6   $ * 61    6;   �� *Tour.Location.City+  5�      $ Visitors��6   $ * 6-    67   �� *NumberOfVisitors+5�      5�      5�      �� 5�      $��2��6   $��8 4 8 8q�6   #��[ 6)   ._�5�      �  5�      �� 5�      $��* �6    5�      �� 5�      $
��auto �6   �� 5�      $
��auto �6   �� 5�      $��* �6   �� 5�      $
��auto �6   .+�5�      �� $��0��6   $��0 0 0 8q�6   $ 
Horizontal=�6/   .+�5�      �� $%��/Resources/Images/search128.png��6   $��40��66   �� 5�      $��Search tour��6   $��24(�6#   $��Center=�61   $��8 0 0 0q�6S   5�      � 5�      $��1��6   $	��0 8q�6   .+�5�      �� $ 
Horizontal=�6   $��36��6+   .+�5�      �� $��Location(State, City):��6   $��14(�6/   $��Center=�6=   �� 5�      $��Center=�6�   $��4q�6�   $	��100��6�     �� MaxDropDownHeight$	  200��6�   ��6   �� *SearchState+! �� SelectedItem! 65   �� *SelectedState+" �� UpdateSourceTrigger$" PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction#   Triggers# 5�   	   +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   
   $   	EventName$$ SelectionChanged��6   *	  $Microsoft.Xaml.Behaviors.TriggerBase% 	  Actions.% 5�      2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
  & 
  Command& 6!   �� *Selection_Changed+5�      5�   	   �� 5�      $��Center=�6)  $��4q�6K  $	��100��6V  $	  200��6b  ��6   �� *
SearchCity+$" PropertyChanged=�' �� SelectedIndex' 6Y   �� *CityComboBoxSelectedIndex+$" PropertyChanged=�! 6�   �� *SelectedCity+{�6�   �� *CityComboBoxIsEnabled+$" PropertyChanged=�6b  �� 5�      $��	Visitors:��6   $��14(�6"   $��Center=�60   �� 5�      $��Center=�6q   $��Center=�6�   $��4 4 0 4q�6�   $��36��6�   ��6   �� *SearchVisitors+$" PropertyChanged=�( �� ValidatesOnDataErrors( . 6�   � 5�      $��20��6   $��0 4 4 4q�6    5�   	   �� 5�   
   $��* �6    5�   	   �� 5�   
   $��* �6   �� 5�   
   $��* �6   .+�5�   	   �� $��0��6   #��[ 6   ��6I   �� *Button_Click_NumericUp+.��5�   
   �� $/��)/Resources/Images/keyboard-arrow-up32.png��6   5�   
   �� 5�   	   $��1��6   #��[ 6   ��6I   �� *Button_Click_NumericDown+.��5�   
   �� $1��+/Resources/Images/keyboard-arrow-down32.png��6   5�   
   5�   	   �� 5�      $��	Language:��6   $��14(�6"   $��Center=�60   �� 5�      $��Center=�6q   $��4q�6�   $	��100��6�   ��6   �� *SearchLanguage+$" PropertyChanged=�( . 6�   �� 5�      $��	Duration:��6   $��14(�6"   $��Center=�60   �� 5�      $��Center=�6q   $��4q�6�   $	��100��6�   ��6   �� *SearchDuration+$" PropertyChanged=�( . 6�   5�      � 5�      $��Right=�6    5�      �� 5�   	   $��* �6   �� 5�   	   $��* �6    5�      �� 5�   	   $��* �6   .+�5�      �� $��0��6   $��
Search(F1)��6   $	��100��64   $��27��6@   $��14(�6L   $��0 4 4 4q�6Z   #��[ 6�   ��6k   �� *Button_Click_Search+6�   �� 5�      $��1��6   $��Show all(F2)��6   $	��100��66   $��27��6B   $��14(�6N   $��4 4 0 4q�6\   #��[ 6�   ��6m   �� *Button_Click_ShowAll+6�   5�      5�      � 5�      $��2��6   $��0 8 0 8q�6    5�      �� 5�      $��* �6    5�      �� 5�      $��* �6   .+�5�        $��0q�6    .  $ Single=�5�   
    . )   	RowHeight$) 50Q�5�   
    .   .   .   .  ��5�   
   �� *Tours+! 5�   
   �� *SelectedTour+ 5�        5�   	   $
 Name��6   $ 3* 6*    65   �� *Name+  5�   	   $ State��6   $ 3* 6+    66   �� *Location.State+  5�   	   $
 City��6   $ 3* 6*    65   �� *Location.City+  5�   	   $ Language��6   $ 2* 6.    69   �� *
Language+  5�   	   $ Departure Date��6   $ 2* 64    6?   �� *	StartTime+* �� StringFormat$* {0:dd/MM/yyyy}��  5�   	   $ Duration��6   $ 2* 6.    69   �� *
Duration+  5�   	   $ Description��6   $ 6* 61    6<   �� *Description++   ElementStyle+ 5�   
   �� 5      .�5     ��  � ��$
 Wrap=�65   5     5  
   5     5
     �� 5     $��3��6   $��0 8 0 0q�6   $ 
Horizontal=�6/   $��Right=�6H   .+�5     �� $��Destinations(F3)��6   $	��110��6)   $��27��65   $��14(�6A   $��0 0 8 0q�6O   #��[ 6�   ��6`   �� *Button_Click_ShowDestinations+6�   �� 5     $��
Images(F4)��6   $	��100��6#   $��27��6/   $��14(�6;   $	��8 0q�6I   #��[ 6�   ��6V   �� *Button_Click_ShowImages+6�   �� 5     $��Reserve(F5)��6   $	��100��6$   $��27��60   $��14(�6<   $��8 0 0 0q�6J   #��[ 6�   ��6[   �� *Button_Click_Reserve+6�   5     5     5     5     5     