   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	        Booking.View.GradingWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  GradingWindow��5   	   $	��768��6   $
��1024��6,    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         ValidationTemplate ��Name��%�   &	        �� 5   
   .R�5      �� .+�5      �� $ NameTextBox��6,   �� 5      
���  ����6   �� *[0].ErrorContent+6>   5      5      5      .��5      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��42(�68   $��Grading guests��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-120,0,480q�6   $
��1024��6*   $��Center=�67   �� 5   
   $��Cleanliness*��6   $
��Left=�6'   $��	40,90,0,0q�6B   $	��Top=�6U   $��35(�6m   �� 5   
   $��	0,60,70,0q�6   .+�5      �� -   5         ��Name$ comboBoxCleanlinessName��5      $��0,40,0,0q�68   	 � ToolTip$J	 DPress and choose a grade which best describes the guests cleanliness��6J   $��30(�6�   $��50��6�   $	��250��6�   
 =� ErrorTemplate#
 [  6�  ��6�   ��  �� Path$ comboBoxCleanliness� �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� SelectedItem 6+  �� $ Cleanliness� �� UpdateSourceTrigger$ PropertyChanged=� .  . ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5       P� 5!       P� Property �@=�HasError P� Value . . �5"   "   ��  �� Property � �� �� Value
 �  ��6@   5#      5%      5'      5(      �� 5+   
   $��RuleFollowing*��6   $
��Left=�6)   $��
40,190,0,0q�6D   $	��Top=�6X   $��35(�6p   �� 5,   
   $��Communication*��6   $
��Left=�6)   $��
40,290,0,0q�6D   $	��Top=�6X   $��35(�6p   �� 5.   
   $��	0,60,70,0q�6   .+�5/      �� -   5        $ comboBoxRuleFollowingName��5/      $��	0,140,0,0q�6:   $M	 GPress and choose a grade which best describes the guests rule following��6M   $	��250��6�   $��30(�6�   $��50��6�   #
 [  6�  ��6�   �� $ comboBoxRuleFollowing� .  .  63  �� $ RuleFollowing�$ PropertyChanged=� .  . ��50      �� 51      " ��6    52      P� 53       �@=�HasError . . �54   "   ��  � ��
 �  ��6@   55      57      59      �� 5:      -   5        $ comboBoxCommunicationName��5:      $��0,50,0,0q�6:   $L	 FPress and choose a grade which best describes the guests communication��6L   $	��250��6�   $��30(�6�   $��50��6�   #
 [  6�  ��6�   �� $ comboBoxCommunication� .  .  61  �� $ Communication�$ PropertyChanged=� .  . ��5;      �� 5<      " ��6    5=      P� 5>       �@=�HasError . . �5?   "   ��  � ��
 �  ��6@   5@      5B      5D      5E      �� 5G   
   $��Comment*��6   $
��Left=�6#   $��
720,80,0,0q�6>   $	��Top=�6R   $��35(�6j   �� 5H   
   -   5         ��Name$ tbDescription��5H      $
��Left=�6)   $	 Press to add a comment��6D   $��630,140,0,0q�6e    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��350��6�   $��15(�6�   $	��306��6�   #
 [  6J  ��6�   �� $ Comment�$ PropertyChanged=� .  . .��6�  ��5I      �� 5J      " ��6    5K      P� 5L       �@=�HasError . . �5M      ��  � ��
 �  ��6<   5N      5P      .��5Q      5R      �� 5T   
   $��	Lateness*��6   $
��Left=�6$   $��
40,390,0,0q�6?   $	��Top=�6S   $��35(�6k   �� 5U   
   $��	0,60,70,0q�6   .+�5V      �� -   5        $ comboBoxLatenessName��5V      $G	 APress and choose a grade which best describes the guests lateness��65   $��	0,335,0,0q�6�   $	��250��6�   $��30(�6�   $��50��6�   #
 [  6�  ��6�   �� $ comboBoxLateness� .  .  6#  �� $ Lateness�$ PropertyChanged=� .  . ��5W      �� 5X      " ��6    5Y      P� 5Z       �@=�HasError . . �5[   "   ��  � ��
 �  ��6@   5\      5^      5`      5a      � 5c   
   $��LeftToRight=�6   $��200,620,0,0q�60   .+�5d      �� $��118 10 0 0 q�6   $
��Left=�6+   $	 Press to grade the guest��6F   $	��150��6i   $��75��6u   $
��Bold"�6�   $��35(�6�   ��6�   �� *Grade+.��6�   GRADE6�   �� 5e      $��	60 10 0 0q�6   $��Center=�6)   $
��Left=�6D   $ 	 Press to close this window��6_   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5f      � 5g   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5h      �� $��
118 5 0 0 q�6   $
��Left=�6*   $	 Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5i      5j      5k      