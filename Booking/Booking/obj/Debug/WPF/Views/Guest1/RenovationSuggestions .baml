   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Booking.WPF.Views.Guest1Booking.WPF.Views.Guest1  5      ;"clr-namespace:Booking.LocalizationBooking.Localization  5      4    .Booking.WPF.Views.Guest1.RenovationSuggestions   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Booking.WPF.Views.Guest1     5      1ns"clr-namespace:Booking.Localization     5        N� Title$  RenovationSuggestions��5
         MyWindowStyle#���   6&    � 	Resources 5        ValidationTemplate ��Name��%�   &	       �� 5   
   .R�5      �� .+�5      �� $ textBox��6,   �� 5      
���  ����6   �� *[0].ErrorContent+6>   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      �� 5      $��50 �6   .+�5   
   � $��1��6    � ColumnDefinitions 5!      �� 5"      �� 5#      .+�5'      �� $��0��6    �� Orientation$ Vertical=�6)   $��20q�6@   $��Right=�6L   .+�5(      �� $
��Left=�6   $��17(�66   ��6D   '   !Booking.Localization.LocExtension  *RenvationArea+6g   �� 5)      $��0��6   $
��Left=�6+    =� ErrorTemplate# [ 5*       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6f   $	��240��6z   $��70��6�   $��5q�6�   ��5)   F   �� 	 �� Path$	 RenovationArea�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . .��5*   �   ��5+      �� 5,       �� 
TargetType" ��6     �� Triggers 5-      P� 5.   "    P� Property �@=�HasError P� Value . . �5/   &   ��  �� Property � �� �� Value
 �  ��6D   �� 50   &    � ��
 �����6D   51   #   53      .��54   %   55      56      �� 58      $	��0.7��6   $��Right=�6(   $��Stretch=�6D   
�������6`   �� 5;      $��1��6   $��20q�6)   .+�5<      �� $
��Left=�6   $��17(�63   ��6A     *RenovationUrgency+6h   �� 5=      $��	0,10,10,0q�6   .+�5>      	�  	� 	GroupName$ Levels��6"   $��3q�65   $��16(�6@   
���������5?        *Level1NiceToHave+ d� 	IsChecked 5@      �� *FirstSelectedUrgencyLevel+	� 5A      $ Levels��6"   $��3q�65   $��16(�6@   
���������5B        *Level2MinorComplaints+ 5C      �� *SecondSelectedUrgencyLevel+	� 5D      $ Levels��6"   $��3q�65   $��16(�6@   
���������5E        *Level3ReallyBothersome+ 5F      �� *ThirdSelectedUrgencyLevel+	� 5G      $ Levels��6"   $��3q�65   $��16(�6@   
���������5H        *Level4ReallyNecessary+ 5I      �� *FourthSelectedUrgencyLevel+	� 5J      $ Levels��6"   $��3q�65   $��16(�6@   
���������5K        *Level5VeryBadCondition+ 5L      �� *FifthSelectedUrgencyLevel+5M      5N      5Q      �� 5U   
   $��0��6   $��Center=�6"   $ 
Horizontal=�6?   $��10q�6X   .+�5V      �� $&�� /Resources/Images/renovation.png��6   $��50��6>   $��45��6I   6W   �� 5W      $
��Bold"�6   $��17(�6&   $��Center=�64   ��6P     *RecommodationTitle+6x   5X      �� 5[   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5\      �� $
��Bold"�6   $��5q�6'   $	��100��62   $��30��6e   ��6>   �� *ButtonClickSubmmit+��6r     *SubmitButton+6�   5]      5_      5`      