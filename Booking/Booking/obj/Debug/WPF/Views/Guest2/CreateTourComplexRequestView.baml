   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest2Booking.WPF.Views.Guest2  5   	   ;    5Booking.WPF.Views.Guest2.CreateTourComplexRequestView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Booking.WPF.Views.Guest2     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5        � Title$"  CreateTourComplexRequestView��5	   	   $	��640��5
      $	��540��6    � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�5      ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value(  "System.Windows.Controls.DatePicker  ButtonStyle �� 	Resources  
CardHolder  NumericUpDownStyle��%'  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� X    7  '�� �    7  '  V    &	 �    7  &	 �    7  &	 '    �� 5      $ #348EF6��6-   �� 5      $ #EFF2FF��6/   �� 5      $
 #FFF��60   �� 5      $
 #000��6+   �� 5      $ #BBC1D1��6-   �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   �� 5       � ��$ Center=�60   �� 5       � ��$ 14(�6    5      �� 5      " ��6
   .�5       ��  � ��8   6"   �� 5!       � ��$ Calibri)�6"   5"      �� 5$      " ��6
   .�5%      ��  � ��8   6"   �� 5&       � ��$ Calibri)�6"   �� 5'       � ��$ 14(�6    5(      �� 5*      "  6
   .�5+      ��  � ��$ Center=�60   5,      �� 5.      " ��6   .�5/      ��  � ��8   6"   �� 50       � ��$ Calibri)�6"    51      ���� 52      '��       " ��6   .�53      ��  �@��CornerRadius$ 6��6&   54      55      56      �� 58      " ��6   .�59      ��  � ��8   6"   �� 5:       �@��CornerRadius$ 6��6$   �� 5;       �@��Padding$ 8q�6   5<      �� 5>      " ��6%   .�5?      ��  � ��$ Center=�60   �� 5@       � ��$ Center=�62   5A      5B      	 J� InputBindings	 5D      �� 5E   
   

 �� Key$
 F1��6<    �� Command 6   �� *Button_Click_Close+6<   �� 5F   
   $
 F2��6>    6   �� *Button_Click_Request+6>   �� 5G   
   $
 F3��6A    6   �� *Button_Click_AddRequest+6A   �� 5H   
   $
 F4��6D    6   �� *Button_Click_RemoveRequest+6D   �� 5I   
    �� 	Modifiers$
 Ctrlf�6?   $
 T��6P    6   �� *Button_Click_Tutorial+6P   .��5L      �� $��8q�6   #��[ 6   ._�5M      �  � ColumnDefinitions 5N      �� 5O      $��* �6    � RowDefinitions 5Q      �� 5R      $
��auto �6   �� 5S      $��2* �6   �� 5T      $
��auto �6   �� 5U      $��* �6   �� 5V      $
��auto �6   .+�5Y      � $��0��6   $��0 0 0 8q�6     5Z      �� 5[      $
��auto �6'   �� 5\      $��* �6'   �� 5]      $
��auto �6'    5_      �� 5`      $��* �6$   .+�5c      �� $#��/Resources/Images/edit128.png��6   $��40��6?   �� 5d      $��1��6   $��Make a request��6(   $��24(�6A   $��8 0 0 0q�6O   �� 5e      $��2��6   $��40��6)   $��4q�64   #��[ 6i   ��6?   �� *Button_Click_Tutorial+.��5f      �� .+�5g      �� $,��&/Resources/Images/videoTutorial128.png��6    5h      5i      5j      � 5l      $��1��6   $	��0 8q�6     5m      �� 5n      $��2* �6   �� 5o      $��3* �6    5q      �� 5r      $
��auto �6   �� 5s      $
��auto �6   �� 5t      $
��auto �6   �� 5u      $
��auto �6   �� 5v      $��* �6   .+�5y      �� $��0��6   $��0��6   $��Location(State, City):��6)   $��0 0 0 8q�6J   �� 5z      $��0��6   $��1��6   $��	Language:��6)   $	��0 8q�6=   �� 5{      $��0��6   $��2��6   $��	Visitors:��6)   $	��0 8q�6=   �� 5|      $��0��6   $��3��6   $��Range of dates:��6)   $	��0 8q�6C   �� 5}      $��0��6   $��4��6   $��Description:��6)   $	��Top=�6@   $��0 8 0 0q�6_   �� 5      $��1��6   $��0��6!    �� Orientation$ 
Horizontal=�6.   $��0 0 0 8q�6G   .+�5�      �� $��Center=�6�   $��0 0 8 0q�6�   $	��100��6�    �� MaxDropDownHeight$	 200��6�   ��6   �� *States+ �� SelectedItem 6>   �� *SelectedState+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�   	      	EventName$ SelectionChanged��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�   
   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6    �� *Selection_Changed+5�   
   5�      �� 5�      $��Center=�6O  $��8 0 0 0q�6q  $	��100��6�  $	 200��6�  ��6   �� *Cities+$ PropertyChanged=� �� SelectedIndex 6c   �� *CityComboBoxSelectedIndex+$ PropertyChanged=� 6�   �� *SelectedCity+ . {�6�   �� *CityComboBoxIsEnabled+$ PropertyChanged=�6�  5�      �� 5�      $��1��6   $��1��6*   $	��0 8q�67   $��Center=�6�   $
��Left=�6�   $	��100��6�   ��6D   �� *
Language+$ PropertyChanged=� . 6�   �� 5�      $��1��6   $��2��6!   $ 
Horizontal=�6.   $	��0 8q�6G   $��30��6T   .+�5�      �� $��Center=�6t   $��Center=�6�   $��36��6�   ��6   �� *NumberOfPassengers+$ PropertyChanged=� . 6�   � 5�      $��1��6   $��20��6    5�      �� 5�   	   $��* �6    5�      �� 5�   	   $��* �6   �� 5�   	   $��* �6   .+�5�      �� $��0��6   #��[ 6   ��6H   �� *Button_Click_NumericUp+.��5�   	   �� $/��)/Resources/Images/keyboard-arrow-up32.png��6   5�   	   �� 5�      $��1��6   #��[ 6   ��6H   �� *Button_Click_NumericDown+.��5�   	   �� $1��+/Resources/Images/keyboard-arrow-down32.png��6   5�   	   5�      5�      �� 5�      $��1��6   $��3��6!   $ 
Horizontal=�6.   $	��0 8q�6G   .+�5�        $��0 0 8 0q�6!   $	��100��6�      IsTodayHighlighted .     SelectedDate 62   �� *	StartDate+ �� StringFormat$ {0:dd/MM/yyyy}��$ PropertyChanged=� .    DisplayDateStart 6�   �� *	StartTime+$ PropertyChanged=� .   5�      $��8 0 0 0q�6!   $	��100��6�    .   62   �� *	EndDate+$ {0:dd/MM/yyyy}��$ PropertyChanged=� .  6�   �� *	StartTime+$ PropertyChanged=� . 5�      �� 5�      $��1��6   $��4��6   $��0 8 0 0q�6+    �� TextWrapping$
 Wrap=�6~   ��6<   �� *Description+$ PropertyChanged=�6~   5�      �� 5�      $��2��6   $	��0 8q�6   $ 
Horizontal=�6*   $��Right=�6C   .+�5�      �� $��Add Tour(F3)��6   $	��100��6$   $��27��60   $��14(�6<   #��[ 6J   ��6o   �� *Button_Click_AddRequest+5�      &   System.Windows.Controls.DataGrid  5�      $��3��6   $	��0 8q�6      AutoGenerateColumns .     
IsReadOnly .     SelectionMode$  Single=�5�      $��14(�5�      !   	RowHeight$! 50Q�5�      "   CanUserResizeColumns" .  #   CanUserAddRows# .  $   CanUserDeleteRows$ .  %   CanUserResizeRows% .  ��5�      �� *TourRequests+ 5�      �� *SelectedRequest+&   Columns& 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn'   Header$' State��6   (   Width5	  /System.Windows.Controls.DataGridLengthConverter$( 4*	 6)   1
  +System.Windows.Controls.DataGridBoundColumn) 
  Binding) 64   �� *Location.State+  5�      $
' City��6   $( 4*	 6(   ) 63   �� *Location.City+  5�      $' Language��6   $( 4*	 6,   ) 67   �� *
Language+  5�      $' Visitors��6   $( 3*	 6,   ) 67   �� *GuestsNumber+  5�      $' 
Start Date��6   $( 4*	 6.   ) 69   �� *	StartTime+$ {0:dd/MM/yyyy}��  5�      $' End Date��6   $( 4*	 6,   ) 67   �� *	EndTime+$ {0:dd/MM/yyyy}��  5�      $' Description��6   $( 5*	 6/   ) 6:   �� *Description+* 
  ElementStyle* 5�      �� 5�   	   .�5�   
   ��  � ��$
 Wrap=�63   5�   
   5�      5�      � 5�      $��4��6
   $��0 8 0 0q�6    5�      �� 5�      $��* �6   �� 5�      $
��auto �6    5�      �� 5�      $��* �6   .+�5�      �� $��0��6   $
��Left=�6!   $ 
Horizontal=�6<   .+�5�      �� $��Remove Tour(F4)��6   $	��120��6(   $��27��64   $��14(�6@   #��[ 6N   ��6s   �� *Button_Click_RemoveRequest+5�      �� 5�      $��1��6   $��Right=�6!   $ 
Horizontal=�6=   .+�5�      �� $��
Cancel(F1)��6   $	��100��6#   $��27��6/   $��14(�6;   $��0 0 8 0q�6I   #��[ 6�   ��6Z   �� *Button_Click_Close+6�   �� 5�      $��Request(F2)��6   $	��100��6$   $��27��60   $��14(�6<   $��8 0 0 0q�6J   #��[ 6�   ��6[   �� *Button_Click_Request+6�   5�      5�      5�      5�      5�      