   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Booking.View.Guest2Booking.View.Guest2  5   	   &     Booking.View.Guest2.ShowVouchers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Booking.View.Guest2     5   	     � Title$  ShowVouchers��5   	   $	��400��6   $	��450��6+    � WindowStartupLocation$ CenterScreen=�5	       � 
ResizeMode$ NoResize=�5
      ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid  ButtonStyle �� 	Resources  
CardHolder��%  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� 4    7  '  �    7  &	     7  &	 �    7  �� 5      $ #348EF6��6-   �� 5      $ #EFF2FF��6/   �� 5      $
 #FFF��60   �� 5      $
 #000��6+   �� 5      $ #BBC1D1��6-   �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   �� 5       � ��$ Center=�60   5      �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   5      �� 5!      "  6
   .�5"      ��  � ��8   6"   �� 5#       � ��$ Calibri)�6"   5$      �� 5&      " ��6   .�5'      ��  � ��8   6"   �� 5(       � ��$ Calibri)�6"    5)      ���� 5*      '��       " ��6   .�5+      ��  �@��CornerRadius$ 6��6&   5,      5-      5.      �� 50      " ��6   .�51      ��  � ��8   6"   �� 52       �@��CornerRadius$ 6��6$   �� 53       �@��Padding$ 8q�6   54      55      	 J� InputBindings	 57      �� 58   
   

 �� Key$
 F5��6<    �� Command 6   �� *Button_Click_Close+6<   �� 59   
    �� 	Modifiers$
 Ctrlf�6E   $
 P��6V    6   �� *Button_Click_GenerateReport+6V   �� 5:   
   $
 Ctrlf�6?   $
 T��6P    6   �� *Button_Click_Tutorial+6P   .��5=      �� $��8q�6   #��[ 6   ._�5>      �  � ColumnDefinitions 5@      �� 5A      $��* �6    � RowDefinitions 5D      �� 5E      $
��auto �6   �� 5F      $��* �6   �� 5G      $
��auto �6   .+�5J      � $��0��6
   $��0 0 0 8q�6    5K      �� 5L      $
��auto �6   �� 5M      $��* �6   �� 5N      $
��auto �6   �� 5O      $
��auto �6'    5Q      �� 5R      $��* �6   .+�5U      �� $&�� /Resources/Images/voucher128.png��6   $��40��66   �� 5V      $��1��6   $��My vouchers��6   $��24(�62   $��8 0 0 0q�6@   �� 5W      $��2��6   $��40��6   $��4q�6(   #��[ 6c   ��63   �� *Button_Click_GenerateReport+.��5X      �� .+�5Y      �� $*��$/Resources/Images/document-pdf64.png��6   5Z      5[      �� 5\      $��3��6   $��40��6)   $��4q�64   #��[ 6i   ��6?   �� *Button_Click_Tutorial+.��5]      �� .+�5^      �� $,��&/Resources/Images/videoTutorial128.png��6    5_      5`      5a        5c      $��1��6   $	��0 8q�6      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5f      $��14(�5g      ��5h      �� *
Vouchers+   Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Id+  5l      $ Expiration date��6   $ 3* 63    6>   �� *	ValidTime+ �� StringFormat$ {0:dd/MM/yyyy}��5n      �� 5p      $��2��6   $��	Close(F5)��6   $	��100��6-   $��27��69   $��14(�6E   $��Right=�6S   $��0 8 0 0q�6o   #��[ 6�   ��6�   �� *Button_Click_Close+6�   5r      5s      5t      