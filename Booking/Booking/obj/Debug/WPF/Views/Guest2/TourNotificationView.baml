   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest2Booking.WPF.Views.Guest2  5   	   3    -Booking.WPF.Views.Guest2.TourNotificationView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Booking.WPF.Views.Guest2     5   	     � Title$  TourNotificationView��5   	   $	��400��5	      $	��450��6    � WindowStartupLocation$ CenterScreen=�5
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
 F5��6<    �� Command 6   �� *Button_Click_Close+6<   �� 5:   
   $
 S��6?    �� 	Modifiers$
 Ctrlf�6G    6   �� *Button_Click_ShowTour+6G   �� 5;   
   $
 Ctrlf�6?   $
 T��6P    6   �� *Button_Click_Tutorial+6P   .��5>      �� $��8q�6   #��[ 6   ._�5?      �  � ColumnDefinitions 5A      �� 5B      $��* �6    � RowDefinitions 5E      �� 5F      $
��auto �6   �� 5G      $��* �6   �� 5H      $
��auto �6   .+�5K      � $��0��6   $��0 0 0 8q�6     5L      �� 5M      $
��auto �6'   �� 5N      $��* �6'   �� 5O      $
��auto �6'    5Q      �� 5R      $��* �6$   .+�5U      �� $,��&/Resources/Images/notifications128.png��6   $��40��6H   �� 5V      $��1��6   $��My notifications��6(   $��24(�6C   $��8 0 0 0q�6Q   �� 5W      $��2��6   $��40��6)   $��4q�64   #��[ 6i   ��6?   �� *Button_Click_Tutorial+.��5X      �� .+�5Y      �� $,��&/Resources/Images/videoTutorial128.png��6    5Z      5[      5\        5^      $��1��6   $	��0 8q�6$      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5a      $��14(�5b         	RowHeight$ 50Q�5d      ��5c      �� *Notifications+ �� SelectedItem 5e      �� *SelectedNotification+   Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ Message��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5* 6+   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *	Message+   ElementStyle 5i      �� 5j   	   .�5k   
   ��  � ��$
 Wrap=�63   5l   
   5n        5o      $
 Date��6   $ 2* 6(    63   �� *CreatedTime+ �� StringFormat$ {0:dd/MM/yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  5p      $
 Tour��6   $ * 6,      CellTemplate 5q      �� 5r   	   .R�5s   "   �� #��[ 6�   ��6)   �� *#!DataContext.Button_Click_ShowTour+ �� RelativeSource ��  �� AncestorType"  .��5t   &   �� �� 5u   *   $
�Show��6.   �� 5v   *   �� 5w   *   $�Ctrl+S��6.   
�������6<   5x   '   5y   #   5z      5|      5~      �� 5�      $��2��6   $��	Close(F5)��6   $	��100��6-   $��27��69   $��14(�6E   $��Right=�6S   $��0 8 0 0q�6o   #��[ 6�   ��6�   �� *Button_Click_Close+6�   5�      5�      5�      