   M S B A M L   `   `   `  ����L  HNotifications.Wpf, Version=0.1.1.0, Culture=neutral, PublicKeyToken=nullbCclr-namespace:Notifications.Wpf.Controls;assembly=Notifications.WpfNotifications.Wpf.Controls  5   	   B >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View 5   	   ;"clr-namespace:Booking.LocalizationBooking.Localization 5   	   %   Booking.View.FirstGuestHomePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   ]notificationsCclr-namespace:Notifications.Wpf.Controls;assembly=Notifications.Wpf     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	   1ns"clr-namespace:Booking.Localization     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5
   	     � Title$  GuestBOOKING��5   	   $	��635��6   $
��1100��6+    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]    � 	Resources 5       	  Label �� 
TargetType �� Property �� Value  CheckBoxStyle1 �� 
TargetType � 	Resources  Key	 g� 	BeginTime
 �� 
TargetName �� TargetProperty O� KeyTime O� Value p� KeyTime p� Value ]�Name J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat ��Name �� CornerRadius J� RenderTransformOrigin �� ScaleX �� ScaleY �� AngleX �� AngleY �� Angle T� X T� Y �� EndPoint �� 
StartPoint  � Color! � Offset" �� Triggers# P� Property$ P� Value% N� ExitActions& ��Name  OnUnchecking' N� EnterActions  
OnChecking��%|	  &	        &	 �     7  7  �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ 	Yu Gothic)�6+   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6'   .�5      ��  � ��# � ��6+   �� 5       � ��# � ��6+   �� 5       � �� 5      �� 5      " ��6&    5      ���� 5      
OnChecking .��5   "   U� $	 00:00:00X�6@   $
 slider��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6t   .\�5   &   �� $ 00:00:00.3000000��6;   $ 25Q�6V   5   #   5       �� 5!      OnUnchecking .��5"   "   U� $	 00:00:00X�6@   $
 slider��6U   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6t   .\�5#   &   �� $ 00:00:00.3000000��6;   $ 0Q�6V   5$   #   r� 5%   "   $	 00:00:00X�6C   $
 slider��6X   $ (FrameworkElement.Margin)�6w   .	�5&   &   �� $ 00:00:00.3000000��6>   $ 1,1,1,1q�6Y   5'   #   5(      5)      .R�5+      ]� $ 	dockPanel��6$   .+�5,      �� # z 6/   #��z��6k   # z 6�   #��z��6�   ��. $��Center=�6  � 5-      $��5,5,0,5q�6#   $��53��64   
���   �.+�5.   "   �� $�� ��6,   $
��Wrap=�64   $
��Bold"�6H   $��12(�6Z   $��Right=�6h   $��0,0,3,0q�6�   �� 5/   "   $
��Left=�6,   $��2,0,0,0q�6G   $��12(�6X   $
��Bold"�6f   $�� ��6x   $
��Wrap=�6�   �� 50   "   $ slider��6D   $
��Left=�6)   $��23��6T   $��1,1,1,1q�6_   $ 3,3,3,3��6y   $ 0.5,0.5&�6�   $��1,1,1,1q�6�   z�51   &   V� 52   *   .~�53   .   �� $ 1Q�6=   $ 1Q�6H   �� 54   .   $ 0Q�6<   $ 0Q�6G   �� 55   .   $ 0Q�6>   T� 56   .   $ 0Q�6A   $ 0Q�6G   57   +   ��59   &   �� 5:   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5;   .   � $  	#FFFFFFFF��6;   $! 0Q�6M   � 5<   .   $
  Gray��6;   $! 1Q�6H   5=   +   ��5?   &   �� 5@   *   $ 0.5,1&�6>   $ 0.5,0&�6O   .��5A   .   � $  	AliceBlue��6;   $! 1Q�6M   � 5B   .   $
  Gray��6;   $! 0Q�6H   5C   +   5E   #   5F      5G      " 5I      P� 5J      # �@d�	IsChecked$
$ TrueY�6;   % 5K   "   �� 5L   &   $"& OnUnchecking_BeginStoryboard��6a   8��  ' 5N   "   �� 5O   &   $ & OnChecking_BeginStoryboard��6_   8�� 5Q      P� 5R      # � {�$ .  . �5S   "   �� # � ��6?    � ��5T      5V      5X      5Y      5Z      .��5\      � 
�������( � RowDefinitions( 5]   
   �� 5^      $��35 �6   �� 5_      $
��Auto �6   .+�5b   
   �� $��0��6   ) �� Orientation$) 
Horizontal=�6"   .+�5c      o� $
��Auto��6   $
��1100��6!   
�������.@�5d      m� -   5        $
��Bold"�5d   6   $��Right=�6H   ��6   '  !Booking.Localization.LocExtension  *
HomePage+6d   m� 5e      -   5        $
��Bold"�5e   9   $��Right=�6K   ��6     *QuickSearch+6g   m� 5f      -   5        $
��Bold"�5f   <   $��Right=�6N   ��6     *MyReservations+6j   m� 5g      -   5        $
��Bold"�5g   A   $��Right=�6S   ��6     *RescheduleRequests+6o   m� 5h      -   5        $
��Bold"�5h   5   $��Right=�6G   ��6     *	Reviews+6c   m� 5i      -   5        $
��Bold"�5i   4   $��Right=�6F   ��6     *Forums+6b   �� 5j      $	��120��6   
�������6(   �� 5m      $) 
Horizontal=�6   $	��Top=�66   $��Center=�6N   $��1��6k   $	��180��6x   $��34��6�   .+�5n      �� 
���   �#���   6M   $��Right=�6m   $��60��6�   $��0,0,0,4q�6�   ��6     *	darkTheme+6�   �� 5o      -   5        * ��Name$* themeCheckBox��5o       #���  67   $��60��6�   $��33��6�   + d� 	IsChecked+ 6`   �� *ButtonIsChecked+6�   �� 5p      
���   �#���   6M   $��60��6m   $��0,0,0,4q�6x   ��6     *
lightTheme+6x   5q      m� 5s      -   5        $	��SRB��5s      $
��Bold"�6(   $��Right=�6:   
�������$��1q�6�   $��2q�6�   , m� Icon, 5t      �� 5u      $ ��/Resources/Images/flag.png��6!   $��-6,-2,-16,0q�6E   $��30��6Z   ��5w      �� 5x      " m�6    .�5y      ��  � ��$ 14(�69   - �� Triggers- 5z      �� 5{   "   . �� Binding. 6.   �� *IsSRBSelected+/ �� Value/ True6P   .a�5|   &   ��  � ��$ 23(�6A   5}   #   P� 5~   "   # �@J�IsMouseOver$ . . �5   &   ��  � ��$ 18(�6A   5�   #   5�      5�      m� 5�      -	   5        $	��ENG��5�      $
��Bold"�6(   $��Right=�6:   
�������$��1q�6�   $��2q�6�   , 5�      �� 5�      $!��/Resources/Images/flag1.png��6!   $��
-7,0,-14,0q�6F   $��Bottom=�6[   $��20��6v   ��5�      �� 5�      " m�6    .�5�      ��  � ��$ 14(�69   - 5�      �� 5�   "   . 6.   �� *IsENGSelected+/ True6P   .a�5�   &   ��  � ��$ 23(�6A   �� 5�   &    � ��
 ��+��6C   5�   #   P� 5�   "   # �@J�IsMouseOver$ . . �5�   &   ��  � ��$ 18(�6A   5�   #   5�      5�      m� 5�      -
   5        $
��Bold"�5�   4   $
��Left=�6F   
�������$��1q�6t   $��3q�6�   ��6     *LogOut+, 5�      �� 5�      $"��/Resources/Images/logOut.png��6!   $��30��6G   $��17��6R   5�      m� 5�      -   5        $
��Bold"�5�   7   $
��Left=�6I   
�������$��1,1,1,1q�6w   $��3q�6�   ��6     *	MyProfile+, 5�      �� 5�      $ ��/Resources/Images/user.png��6    6F   5�      5�      5�      �� 5�   
   $) Vertical=�6   $��1��6,   $
��Auto��69   $��Stretch=�6G   $��Stretch=�6c   $��
0,0,0,-573q�6�   .+�5�      � 0 � ColumnDefinitions0 5�      �� 5�      $
��611* �6'   �� 5�      $
��489* �6'   .+�5�       � -   5        1  �Name$1 FrameHomePage��5�      $
��Auto��6/   $��2��6=   1   +Notifications.Wpf.Controls.NotificationArea  5�      -   5        2  Name$2 
WindowArea��5�   1   3 K� ZIndex$
3 1000��6E   $��Right=�6Y   4   Position$4 TopRight=�5�   1   $
��Auto��6E   $	��525��6R   $��20q�6_   $��Center=�6k   $��1��6�   6�   5�      5�      5�      5�      