   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	   '    !Booking.View.ShowTourDestinations   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  ShowTourDestinations��5   	   $	��400��6&   $	��450��63    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid  ButtonStyle �� 	Resources  
CardHolder��%  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� 4    7  '  �    7  &	     7  &	 �    7  �� 5      $ #348EF6��6-   �� 5      $ #EFF2FF��6/   �� 5      $
 #FFF��60   �� 5      $
 #000��6+   �� 5      $ #BBC1D1��6-   �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   �� 5       � ��$ Center=�60   5      �� 5      " ��6
   .�5      ��  � ��8   6"   �� 5       � ��$ Calibri)�6"   5      �� 5!      "  6
   .�5"      ��  � ��8   6"   �� 5#       � ��$ Calibri)�6"   5$      �� 5&      " ��6   .�5'      ��  � ��8   6"   �� 5(       � ��$ Calibri)�6"    5)      ���� 5*      '��       " ��6   .�5+      ��  �@��CornerRadius$ 6��6&   5,      5-      5.      �� 50      " ��6   .�51      ��  � ��8   6"   �� 52       �@��CornerRadius$ 6��6$   �� 53       �@��Padding$ 8q�6   54      55      	 J� InputBindings	 57      �� 58   
   

 �� Key$
 F5��6<    �� Command 6   �� *Button_Click_Close+6<   .��5;      �� $��8q�6
   #��[ 6   ._�5<      � $��0q�6	    � ColumnDefinitions 5=      �� 5>      $��* �6    � RowDefinitions 5@      �� 5A      $
��auto �6   �� 5B      $
��auto �6   �� 5C      $��* �6   �� 5D      $
��auto �6   .+�5G      �� $��0��6   $��0 0 0 8q�6    �� Orientation$ 
Horizontal=�6/   .+�5H      �� $#��/Resources/Images/flag128.png��6   $��40��63   �� 5I      $��Checkpoints��6   $��24(�6"   $��8 0 0 0q�60   5J      �� 5L      $��1��6   $��8q�6   $ Vertical=�6(   .+�5M      �� ��6   �� *
Location+�� 5N      ��6   �� *Tour.StartTime+ �� StringFormat$ {0:dd/MM/yyyy}��5O        5Q      $��2��6   $��0 8 0 8q�5R         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5U      $��14(�5V      ��5W      �� *Destinations+   Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ State��6      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Location.State+  5Z      $
 City��6   $ * 6(    62   �� *Location.City+5\      �� 5^      $��3��6   $��	Close(F5)��6   $	��100��6-   $��27��69   $��0 8 0 0q�6E   $��Right=�6}   $��14(�6�   #��[ 6�   ��6V   �� *Button_Click_Close+6�   5_      5`      5a      