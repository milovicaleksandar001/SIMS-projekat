   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest2Booking.WPF.Views.Guest2  5   	   /    )Booking.WPF.Views.Guest2.TourRequestsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Booking.WPF.Views.Guest2     5   	     � Title$  TourRequestsView��5   	   $	��600��5	      $
��1000��6    � WindowStartupLocation$ CenterScreen=�5
       � 
ResizeMode$ NoResize=�5      ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid  ButtonStyle �� 	Resources  
CardHolder��%  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� 4    7  '  �    7  &	     7  &	 �    7  �� 5      $ #348EF6��6-   �� 5      $ #EFF2FF��6/   �� 5      $
 #FFF��60   �� 5      $
 #000��6+   �� 5      $ #BBC1D1��6-   �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   �� 5       � ��$ Center=�60   5      �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   5       �� 5"      "  6
   .�5#      ��  � ��8   6"   �� 5$       � ��$ Calibri)�6"   5%      �� 5'      " ��6   .�5(      ��  � ��8   6"   �� 5)       � ��$ Calibri)�6"    5*      ���� 5+      '��       " ��6   .�5,      ��  �@��CornerRadius$ 6��6&   5-      5.      5/      �� 51      " ��6   .�52      ��  � ��8   6"   �� 53       �@��CornerRadius$ 6��6$   �� 54       �@��Padding$ 8q�6   55      56      	 J� InputBindings	 58      �� 59   
   

 �� Key$
 F1��6>    �� Command 6   �� *Button_Click_Request+6>   �� 5:   
   $
 F5��6<    6   �� *Button_Click_Close+6<   �� 5;   
    �� 	Modifiers$
 Ctrlf�6?   $
 T��6P    6   �� *Button_Click_Tutorial+6P   .��5>      �� $��8q�6   #��[ 6   ._�5?      �  � ColumnDefinitions 5@      �� 5A      $��* �6    � RowDefinitions 5C      �� 5D      $
��auto �6   �� 5E      $��* �6   �� 5F      $
��auto �6   .+�5I      � $��0��6   $��0 0 0 8q�6     5J      �� 5K      $
��auto �6'   �� 5L      $��* �6'   �� 5M      $
��auto �6'    5O      �� 5P      $��* �6$   .+�5S      �� $%��/Resources/Images/global128.png��6   $��40��6A   �� 5T      $��1��6   $��My requests��6(   $��24(�6>   $��8 0 0 0q�6L   �� 5U      $��2��6   $��40��6)   $��4q�64   #��[ 6i   ��6?   �� *Button_Click_Tutorial+.��5V      �� .+�5W      �� $,��&/Resources/Images/videoTutorial128.png��6    5X      5Y      5Z        5\      $��1��6   $	��0 8q�6$      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5_      $��14(�5`         	RowHeight$ 50Q�5b         CanUserResizeColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .  ��5a      �� *TourRequests+   Columns 5h      0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$ State��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 3* 6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Location.State+  5j      $
 City��6   $ 3* 6(    63   �� *Location.City+  5k      $ Language��6   $ 3* 6,    67   �� *
Language+  5l      $ Visitors��6   $ 2* 6,    67   �� *GuestsNumber+  5m      $ Description��6   $ 4* 6/    6:   �� *Description+   ElementStyle 5n      �� 5o   	   .�5p   
   ��  � ��$
 Wrap=�63   5q   
   5s        5t      $ 
Start Date��6   $ 3* 6.    69   �� *	StartTime+ �� StringFormat$ {0:dd/MM/yyyy}��  5u      $ End Date��6   $ 3* 6,    67   �� *	EndTime+$ {0:dd/MM/yyyy}��  5v      $ 	Departure��6   $ 3* 6-    68   �� *TourReservedStartTime+$ {0:dd/MM/yyyy}��  5w      $ Status��6   $ 3* 6*    65   �� *Status+5y      �� 5{      $��2��6   $��0 8 0 0q�6   $��Right=�6.    �� Orientation$ 
Horizontal=�6J   .+�5|      �� $��Request(F1)��6   $	��100��6#   $��27��6/   $��14(�6;   $��0 0 8 0q�6I   #��[ 6�   ��6Z   �� *Button_Click_Request+6�   �� 5}      $��	Close(F5)��6   $	��100��6!   $��27��6-   $��14(�69   $��8 0 0 0q�6G   #��[ 6   ��6X   �� *Button_Click_Close+6   5~      5      5�      5�      