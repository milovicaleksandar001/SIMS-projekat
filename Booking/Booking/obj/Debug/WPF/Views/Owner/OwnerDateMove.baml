   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	        Booking.View.OwnerDateMove   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  OwnerDateMove��5   	   $	��768��6   $
��1024��6,    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� $��10,6,0,0q�6   $
��Bold"�6&   $��32(�68   $��Date move requests��6F   ���	#FFFFF200 J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 4Q�6#      Color$ #303841��63      
BlurRadius$ 5Q�6C   5      �� 5   
   $��0,-150,0,480q�6   $
��1024��6*   $��Center=�67   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DateMoveRequests��5         
IsReadOnly .    AutoGenerateColumns .  $	��520��5   E   	   HeadersVisibility$	 Column=�6R   $��-320 -60 0 0q�6m   $��12(�6�   $	��650��6�   
 J� RenderTransformOrigin$
 0.503,0.552&�6�    �� SelectedItem 5      �� *)'SelectedAccommodationReservationRequest+ �� UpdateSourceTrigger$ PropertyChanged=���5      �� *
Requests+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Accommodation name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *-+AccommodationReservation.Accommodation.Name+  5      $ Previous starting day��6%   $ * 6D    6N   �� *%#AccommodationReservation.ArrivalDay+ �� StringFormat$ {0:dd/MM/yyyy}��  5      $ Previous end day��6%   $	 110 6?    6K   �� *'%AccommodationReservation.DepartureDay+$ {0:dd/MM/yyyy}��  5      $ New starting day��6%   $	 110 6?    6K   �� *NewArrivalDay+$ {0:dd/MM/yyyy}��  5      $ New end day��6%   $ 85 6:    6E   �� *NewDeparuteDay+$ {0:dd/MM/yyyy}��  5      $ 
Accessable��6%   $ 75 69    6D   �� *
Accessable+5       �� 5!   
   $��	Reasoning��6   $
��Left=�6$   $��
750,70,0,0q�6?   $��	ExtraBold"�6S   $	��Top=�6j   $��32(�6�   �� 5"   
   $
��Left=�6    � ToolTip$D >Press to enter a reason why you declined the date move request��6-   $��690,125,0,0q�6v    �� TextWrapping$
 Wrap=�6�   $	��470��6�   $	��Top=�6�   $	��310��6�   $��15(�6�   ��6�   ��  �� Path$ OwnerComment�$ PropertyChanged=�� 5#   
   $��LeftToRight=�6   $��120,640,0,0q�60   .+�5$      �� $��118 -10 0 0 q�6   $
��Left=�6,   $X RChoose a request and then press this to accept the date move request and change it��6G   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Accept+.��6�   ACCEPT6   �� 5%      $��
10 -10 0 0q�6   $��Center=�6*   $i cChoose a request and then press this to reject the date move request, everything will stay the same��6E   $
��Left=�6�   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6  �� *Reject+.��6"  REJECT6*  �� 5&      $��
60 -10 0 0q�6   $��Center=�6*   $  Press to close this window��6E   $
��Left=�6j   $	��150��6�   $��75��6�   $
��Bold"�6�   $��35(�6�   ��6�   �� *Close+.��6�   CLOSE6�   5'      � 5(   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5)      �� $��
118 5 0 0 q�6   $
��Left=�6*   $ Press to open wizard��6E   $��80��6d   $��30��6o   $
��Bold"�6{   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   5*      5+      5,      