   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest2Booking.WPF.Views.Guest2  5   	   +    %Booking.WPF.Views.Guest2.TutorialView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Booking.WPF.Views.Guest2     5   	     � Title$  TutorialView��5   	   $	��600��5	   	   $	��900��6    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�6.   ���#BBC1D1 � 	Resources 5         PrimaryBlueColor �� Color  SecondaryBlueColor  CardBackgroundColor  BlackTextColor  PrimaryGrayColor �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid  ButtonStyle �� 	Resources  
CardHolder  NumericUpDownStyle��%(  &	        &	 !     &	 B     &	 `     &	 ~     '�� �     7  '�� 4    7  '�� �    7  '      7  &	 �    7  &	 �    7  &	 $    �� 5   
   $ #348EF6��63   �� 5   
   $ #EFF2FF��65   �� 5   
   $
 #FFF��66   �� 5   
   $
 #000��61   �� 5   
   $ #BBC1D1��63   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��$ Calibri)�6+   �� 5       � ��$ Center=�69   5      �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��$ Calibri)�6+   5      �� 5!   
   " ��6   .�5"      ��  � ��8   6+   �� 5#       � ��$ Calibri)�6+   5$      �� 5&   
   "  6   .�5'      ��  � ��8   6+   �� 5(       � ��$ Calibri)�6+   �� 5)       � ��$ 14(�6)   5*      �� 5,   
   " ��6$   .�5-      ��  � ��8   6+   �� 5.       � ��$ Calibri)�6+    5/      ���� 50      '��       " ��6   .�51      ��  �@��CornerRadius$ 6��65   52      53      54      �� 56   
   " ��6#   .�57      ��  � ��8   6+   �� 58       �@��CornerRadius$ 6��6-   �� 59       �@��Padding$ 8q�6(   5:      �� 5<   
   " ��6+   .�5=      ��  � ��$ Center=�69   �� 5>       � ��$ Center=�6;   5?      5@      	 J� InputBindings	 5B      �� 5C   
   

 �� Key$
 F5��6<    �� Command 6   �� *Button_Click_Close+6<   .��5F      �� $��8q�6   #��[ 6   ._�5G   
   �  � ColumnDefinitions 5H      �� 5I      $��* �6#    � RowDefinitions 5K      �� 5L      $
��auto �6    �� 5M      $��* �6    �� 5N      $
��auto �6    .+�5Q      �� $��0��6   $��0 0 0 8q�6&    �� Orientation$ 
Horizontal=�67   .+�5R      �� $,��&/Resources/Images/videoTutorial128.png��6   $��40��6H   �� 5S      $��Tutorial��6   $��24(�6+   $��8 0 0 0q�69   5T      � 5V      $��1��6   $	��0 8q�6     5W      �� 5X      $��* �6$   �� 5Y      $
��auto �6$   .+�5\      r� $��0��6    r� Source 6,   �� *Url+5^      �� 5_      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5`      �� $��-10sec��6   $��60��6.   $��27��69   $��4q�6E   #��[ 6P   $��14(�6u   �� 5a      $��
play/pause��6   $	��100��62   $��27��6>   $��4q�6J   #��[ 6U   $��14(�6z   ��6�   �� *Button_Click_PlayPause+�� 5b      $��+10sec��6   $��60��6.   $��27��69   $��4q�6E   #��[ 6P   $��14(�6u   5c      5d      �� 5f      $��0��6   $��2��6%   $��	Close(F5)��62   $	��100��6F   $��27��6R   $��0 8 0 0q�6^   $��Right=�6o   #��[ 6�   $��14(�6�   ��6�   �� *Button_Click_Close+6�   5g      5h      5i      