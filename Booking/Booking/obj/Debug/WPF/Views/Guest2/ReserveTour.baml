   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	       Booking.View.ReserveTour   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  ReserveTour��5   	   $	��450��6   $	��450��6*    � WindowStartupLocation$ CenterScreen=�5	       � 
ResizeMode$ NoResize=�6(   ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value  ButtonStyle �� 	Resources  
CardHolder  NumericUpDownStyle��%  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� 4    7  &	 �    7  &	 �    7  &	 &    �� 5      $ #348EF6��6-   �� 5      $ #EFF2FF��6/   �� 5      $
 #FFF��60   �� 5      $
 #000��6+   �� 5      $ #BBC1D1��6-   �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   �� 5       � ��$ Center=�60   5      �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   5      �� 5       " ��6   .�5!      ��  � ��8   6"   �� 5"       � ��$ Calibri)�6"    5#      ���� 5$      '��       " ��6   .�5%      ��  �@��CornerRadius$ 6��6&   5&      5'      5(      �� 5*      " ��6   .�5+      ��  � ��8   6"   �� 5,       �@��CornerRadius$ 6��6$   �� 5-       �@��Padding$ 8q�6   5.      �� 50      " ��6%   .�51      ��  � ��$ Center=�60   �� 52       � ��$ Center=�62   53      54      	 J� InputBindings	 56      �� 57   
   

 �� Key$
 F1��6<    �� Command 6   �� *Button_Click_Close+6<   �� 58   
   $
 F2��6>    6   �� *Button_Click_Reserve+6>   �� 59   
    �� 	Modifiers$
 Ctrlf�6?   $
 T��6P    6   �� *Button_Click_Tutorial+6P   .��5<      �� $��8q�6   #��[ 6   ._�5=      �  � ColumnDefinitions 5>      �� 5?      $��* �6    � RowDefinitions 5A      �� 5B      $
��auto �6   �� 5C      $
��auto �6   �� 5D      $
��auto �6   �� 5E      $
��auto �6   �� 5F      $��* �6   �� 5G      $
��auto �6   .+�5J      � $��0��6   $��0 0 0 8q�6     5K      �� 5L      $
��auto �6'   �� 5M      $��* �6'   �� 5N      $
��auto �6'    5P      �� 5Q      $��* �6$   .+�5T      �� $'��!/Resources/Images/calendar128.png��6   $��40��6C   �� 5U      $��1��6   $��Reserve a tour��6(   $��24(�6A   $��8 0 0 0q�6O   �� 5V      $��2��6   $��40��6)   $��4q�64   #��[ 6i   ��6?   �� *Button_Click_Tutorial+.��5W      �� .+�5X      �� $,��&/Resources/Images/videoTutorial128.png��6    5Y      5Z      5[      �� 5]      $��1��6   $��8q�6&   .+�5^      �� $��Center=�6*   ��6   �� *
Location+6*   �� 5_      $��Center=�6O   ��6   �� *Tour.StartTime+ �� StringFormat$ {0:dd/MM/yyyy}��6O   5`      � 5b      $��2��6
   $	��0 8q�6    5c      �� 5d      $��* �6   �� 5e      $��* �6    5g      �� 5h      $��* �6   .+�5k      �� $��0��6    �� Orientation$ 
Horizontal=�6!   .+�5l      �� $��Number of visitors:��6   $��Center=�6+   $��14(�6M   � 5m      $��30��6    5n      �� 5o   	   $
��auto �6   �� 5p   	   $
��auto �6   .+�5s      �� $��0��6   $��Center=�6�   $��Center=�6�   $��14(�6�   $��36��6�   ��6    �� *NumberOfPassengers+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . 6�   � 5t      $��1��6   $��20��6    5u   	   �� 5v   
   $��* �6    5x   	   �� 5y   
   $��* �6   �� 5z   
   $��* �6   .+�5}   	   �� $��0��6   #��[ 6   ��6I   �� *Button_Click_NumericUp+.��5~   
   �� $/��)/Resources/Images/keyboard-arrow-up32.png��6   5   
   �� 5�   	   $��1��6   #��[ 6   ��6I   �� *Button_Click_NumericDown+.��5�   
   �� $1��+/Resources/Images/keyboard-arrow-down32.png��6   5�   
   5�   	   5�      5�      �� 5�      $��1��6   $��Center=�66   $��14(�6X   ��6   �� *Label+6X   5�      �� 5�      $��3��6   $	��0 8q�6   $ 
Horizontal=�6+   .+�5�      �� $��Redeem a voucher��6   $��14(�6Q   $��Center=�6_   $
��auto��6�    d� 	IsChecked 6*   �� *IsVoucherChecked+6�   5�      &   System.Windows.Controls.DataGrid  5�      $��4��6   $��14(�6   $	��0 8q�6)      AutoGenerateColumns .     SelectionMode$ Single=�5�         
IsReadOnly . ��5�      �� *
Vouchers+ �� SelectedItem 5�      �� *SelectedVoucher+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Id+  5�      $ Expiration date��6   $ 3* 63    6>   �� *	ValidTime+$ {0:dd/MM/yyyy}��5�      �� 5�      $��5��6   $ 
Horizontal=�6   $��Right=�66   $��0 8 0 0q�6R   .+�5�      �� $��0 0 8 0q�6   $��
Cancel(F1)��6   $	��100��6Z   $��27��6f   $��14(�6r   #��[ 6�   ��63   �� *Button_Click_Close+6�   �� 5�      $��8 0 0 0q�6   $��Reserve(F2)��6   $	��100��6]   $��27��6i   $��14(�6u   #��[ 6�   ��64   �� *Button_Click_Reserve+6�   5�      5�      5�      5�      