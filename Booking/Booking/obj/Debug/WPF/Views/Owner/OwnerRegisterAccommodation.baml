   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	   -    'Booking.View.OwnerRegisterAccommodation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  62     � Title$   OwnerRegisterAccommodation��5	   	   $	��768��6,   $
��1024��69    � 
ResizeMode$ NoResize=�6F    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5         ValidationTemplate ��Name��%�   &	        �� 5   
   .R�5      �� .+�5      �� $ NameTextBox��6,   �� 5      
���  ����6   �� *[0].ErrorContent+6>   5      5      5      .��5      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Register accommodation��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   �� 5   
   $��Name*��6   $
��Left=�6    $��	40,60,0,0q�6;   $	��Top=�6N   $��20(�6f   �� 5   
   -   5        $��NameTextBox��5      $
��Left=�6&   	 � ToolTip$%	 Press to add accommodation name��6A   $��
220,70,0,0q�6k   
 �� TextWrapping$

 Wrap=�6   $	��Top=�6�   $��30��6�   $	��250��6�   $��20(�6�    =� ErrorTemplate# [  6X  ��6�   ��  �� Path$ AccommodationName� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . .��6�  ��5      �� 5        �� 
TargetType" ��6    �� Triggers 5!      P� 5"       P� Property �@=�HasError P� Value . . �5#      ��  �� Property � �� �� Value
 �  ��6<   5$      5&      .��5'      5(      �� 5)   
   $��Country*��6   $
��Left=�6#   $��
40,110,0,0q�6>   $	��Top=�6R   $��20(�6j   �� 5*   
   $��City*��6   $
��Left=�6    $��
40,160,0,0q�6;   $	��Top=�6O   $��20(�6g   �� 5,   
   $��17,0,-105,0q�6   .+�5-      �� $��-440,115,0,0q�6   $	��250��6.   $E	 ?Press and choose in what country will your new accommodation be��6:   $��30��6�   # [  5.   �    �� SelectedItem 6   �� $ SelectedCountry�$ PropertyChanged=� .  . ��5/      �� $ CountryCollection� .  . *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 50      +  %Microsoft.Xaml.Behaviors.EventTrigger  51         	EventName$ SelectionChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 52      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *FillCityCommand+53      ��55      �� 56      " ��6    57      P� 58       �@=�HasError . . �59   "   ��  � ��
 �  ��6@   5:      5<      5>      �� 5?      $��-440,20,0,0q�6   $	��250��6,   $B	 <Press and choose in what city will your new accommodation be��68   $��30��6   # [  5B   �   {�5@      �� *CityComboboxEnabled+$ PropertyChanged=���5A      �� $ CityCollection� .  .  5B      �� $ SelectedCity�$ PropertyChanged=� .  . ��5C      �� 5D      " ��6     5E      P� 5F   "    �@=�HasError . . �5G   &   ��  � ��
 �  ��6D   5H   #   5J      5L      5M      �� 5O   
   $��Type*��6   $
��Left=�6    $��
40,210,0,0q�6;   $	��Top=�6O   $��20(�6g   �� 5P   
   $��-432,70,0,0q�6   .+�5Q      �� -   5        $��TypecomboBox��5Q      $��2��6+   $��1��68   $��30��6H   $L	 FPress and choose what type of accommodation is your new accommodation ��6T   $	��250��6�   $��Center=�6�   $��170,145,55,243q�6�   ��6�   �� $ comboBoxType�$ PropertyChanged=� 64  �� $
 Type�$ PropertyChanged=�5R      �� 5T      $��Max guests*��6   $
��Left=�6.   $��
40,260,0,0q�6I   $	��Top=�6]   $��20(�6u   �� 5U   
   $
��Left=�6   $��221,265,0,0q�6-   $

 Wrap=�6B   $O	 IPress to enter maximum number of guests allowed in your new accommodation��6V   $	��Top=�6�   $��30��6�   $	��250��6�   $��20(�6�   # [  6f  ��6�   �� $ Capacity�$ PropertyChanged=� .  . .��6�  ��5V      �� 5W      " ��6    5X      P� 5Y       �@=�HasError . . �5Z      ��  � ��
 �  ��6<   5[      5]      .��5^      5_      �� 5`   
   $��-690,200,0,0q�6   .+�5a      ��  K� ZIndex$ 1��6   $��
660,65,0,0q�6&   $��+��6;   $��30��6G   $'	 !Press to increase the number by 1��6S   $��30��6   $��14(�6�   $
��Bold"�6�   ��6�   �� *IncreaseMaxGuests+�� 5b      $ 1��6   $��730,-30,0,0q�6&   $��-��6<   $��30��6H   $'	 !Press to decrease the number by 1��6T   $��30��6�   $��14(�6�   $
��Bold"�6�   ��6�   �� *DecreaseMaxGuests+5c      �� 5e   
   $��	Min days*��6   $
��Left=�6$   $��
40,310,0,0q�6?   $	��Top=�6S   $��20(�6k   �� 5f   
   $
��Left=�6   $��221,315,0,0q�6-   $b	 \Press to add minimum number of days required to make a reservation on your new accommodation��6B   $

 Wrap=�6�   $	��Top=�6�   $��30��6�   $	��250��6�   $��20(�6�   # [  6�  ��6�   �� $ MinNumberOfDays�$ PropertyChanged=� .  . .��6�  ��5g      �� 5h      " ��6    5i      P� 5j       �@=�HasError . . �5k      ��  � ��
 �  ��6<   5l      5n      .��5o      5p      �� 5q   
   $��-690,250,0,0q�6   .+�5r      �� $ 1��6   $��
660,65,0,0q�6&   $��+��6;   $��30��6G   $'	 !Press to increase the number by 1��6S   $��30��6   $��14(�6�   $
��Bold"�6�   ��6�   �� *IncreaseMinDays+�� 5s      $ 1��6   $��730,-30,0,0q�6&   $��-��6<   $��30��6H   $'	 !Press to decrease the number by 1��6T   $��30��6�   $��14(�6�   $
��Bold"�6�   ��6�   �� *DecreaseMinDays+5t      �� 5v   
   $��Cancelation days*��6   $
��Left=�6,   $��
40,360,0,0q�6G   $	��Top=�6[   $��20(�6s   �� 5w   
   $
��Left=�6   $��221,365,0,0q�6-   $

 Wrap=�6B   $S	 MPress to add minimum days before the reservation that the guest can cancel it��6V   $	��Top=�6�   $��30��6�   $	��250��6�   $��20(�6�   # [  6s  ��6�   �� $ CancelationPeriod�$ PropertyChanged=� .  . .��6�  ��5x      �� 5y      " ��6    5z      P� 5{       �@=�HasError . . �5|      ��  � ��
 �  ��6<   5}      5      .��5�      5�      �� 5�   
   $��-690,300,0,0q�6   .+�5�      �� $ 1��6   $��
660,65,0,0q�6&   $��+��6;   $��30��6G   $'	 !Press to increase the number by 1��6S   $��30��6   $��14(�6�   $
��Bold"�6�   ��6�   �� *IncreaseCancelationPeriod+�� 5�      $ 1��6   $��730,-30,0,0q�6&   $��-��6<   $��30��6H   $'	 !Press to decrease the number by 1��6T   $��30��6�   $��14(�6�   $
��Bold"�6�   ��6�   �� *DecreaseCancelationPeriod+5�      �� 5�   
   $��	Pictures*��6   $
��Left=�6$   $��
540,60,0,0q�6?   $	��Top=�6S   $��20(�6k   �� 5�   
   -   5         ��Name$ 
tbPictures��5�      $
��Left=�6&   $��
650,65,0,0q�6A   $1	 +This is your pictures path in your computer��6U   $

 Wrap=�6�   $	��Top=�6�   $��30��6�   $	��250��6�   $��15(�6�   # [  6]  ��6�   �� $ 
TbPictures�$ PropertyChanged=� .  . .��6�  ��5�      �� 5�      " ��6    5�      P� 5�       �@=�HasError . . �5�      ��  � ��
 �  ��6<   5�      5�      .��5�      5�      �� 5�   
   $��
0,0,-192,2q�6   .+�5�      �� $ 1��6   $��690,65,32,122q�6'   $��+��6?   $��30��6K   $	 Press to add a picture��6W   $��30��6x   $��17(�6�   $
��Bold"�6�   ��6�   �� *
AddPicture+�� 5�      $ 1��6   $��752,-275,0,0q�6&   $��-��6=   $��30��6I   $��30��6U   $1	 +Press to delete the current showing picture��6`   $��17(�6�   $
��Bold"�6�   ��6�   �� *RemovePicture+5�      � 5�   
   $��LeftToRight=�6   $��200,620,0,0q�60   .+�5�      �� $��118 10 0 0 q�6   $
��Left=�6+   $	��150��6G   $��75��6S   $1	 +Press to finish creating your accommodation��6_   $
��Bold"�6�   $��35(�6�   ��6�   �� *Create+.��6�   CREATE6�   �� 5�      $��	60 10 0 0q�6   $��Center=�6)   $
��Left=�6D   $	��150��6_   $ 	 Press to close this window��6k   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5�      �� 5�   
   
���   �$��2q�6%   ._�5�      �� $��530,-240,0,0q�6   $	��450��6/   $	��280��6;   .+�5�      �� -   5         ��Name$ buttonPrevious��5�      $	��⬅��61   $��25��6=   $��25��6I   $#	 Press to see previous picture��6T   $��-400 125 0 0q�6|   ��6�   �� *PreviousPicture+y�6�   �� *ButtonPreviousVisibility+�� 5�      -   5        $ 
buttonNext��5�      $	��➞��6-   $��25��69   $��25��6E   $	 Press to see next picture��6P   $��400 -35 0 0q�6t   ��6�   �� *NextPicture+y�6�   �� *ButtonNextVisibility+�� 5�      -   5         ��Name$ imageSlideshow��5�      $��UniformToFill=�60   $	��230��6H   $	��350��6U   $��
0 -120 0 0q�6a   ��6u   �� *ImageSlideshowSource+5�      5�      � 5�   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5�      �� $��
118 5 0 0 q�6   $
��Left=�6*   $	 Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5�      5�      5�      