   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Booking.ViewBooking.View  5   	        Booking.View.OwnerHomePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Booking.View     5   	     � Title$  OwnerHomePage��5   	   $	��768��6   $
��1024��6,    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         ValidationTemplate ��Name��%�   &	        �� 5   
   .R�5      �� .+�5      �� $ NameTextBox��6,   �� 5      
���  ����6   �� *[0].ErrorContent+6>   5      5      5      .��5      � .+�5   
   �� $	��Top=�6   $��	0,0,639,0q�6*   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FFD2F119��6#    � Offset$ 1Q�65   5      .+�5      �� $�� Register accommodation��6   $��18(�67   $	��250��6E   $��65��6Q   $
��Left=�6]    � ToolTip$$ Press to add new accommodation��6x   $��	1 20 10 0q�6�   $
��Left=�6�   ��6�   �� *OpenRegisterAccommodation+6�   �� 5      $�� Accomodation stats��6   $��18(�63   $	��250��6A   $��65��6M   $
��Left=�6Y   $��1 5 10 0q�6t   $
��Left=�6�   ��6�   �� *OpenAccommodationStatistics+�� 5       $�� Site proposal��6   $��18(�6.   $	��250��6<   $��65��6H   $
��Left=�6T   $��1 5 10 0q�6o   $
��Left=�6�   ��6�   �� *OpenSiteProposals+�� 5!      $�� Handling date changes��6   $��18(�66   $, &Press to see requests for date changes��6D   $	��250��6u   $��65��6�   $
��Left=�6�   $��1 5 10 0q�6�   $
��Left=�6�   ��6�   �� *OpenDateMove+6�   �� 5"      $�� Gradeing guests��6   $��18(�60   $	��250��6>   $2 ,Press to see reservations that you can grade��6J   $��65��6�   $
��Left=�6�   $��1 5 10 0q�6�   $
��Left=�6�   ��6�   �� *OpenGradingGuests+6�   �� 5#      $�� View reviews��6   $��18(�6-   $	��250��6;   $2 ,Press to see grades that you got from guests��6G   $��65��6~   $
��Left=�6�   $��1 5 10 0q�6�   $
��Left=�6�   ��6�   �� *OpenViewReviews+6�   �� 5$      $�� Super-owner��6   $��18(�6,   $	��250��6:   $+ %Press to see if you are a super-owner��6F   $��65��6v   $
��Left=�6�   $��1 5 10 0q�6�   $
��Left=�6�   ��6�   �� *OpenSuperOwner+6�   �� 5%      $�� Scheduling renovations��6   $��18(�67   $	��250��6E   $��65��6Q   $
��Left=�6]   $��1 5 10 0q�6x   $
��Left=�6�   ��6�   �� *OpenSchedulingRenovations+�� 5&      $�� Show renovations��6   $��18(�61   $	��250��6?   $��65��6K   $
��Left=�6W   $��1 5 10 0q�6r   $
��Left=�6�   ��6�   �� *OpenShowRenovations+�� 5'      $�� Forum��6   $��18(�6&   $	��250��64   $��65��6@   $
��Left=�6L   $��1 5 10 0q�6g   $
��Left=�6y   ��6�   �� *
OpenForums+5/      �� 51   
   $��	260,0,5,0q�6   ���#D6E6F2.+�53      �� $��8 0 0 0q�6   $
��Bold"�6)   $��32(�6;   $��	Home page��6I   ���	#FFFFF200	 J� Effect	 54      3  -System.Windows.Media.Effects.DropShadowEffect  55      
   ShadowDepth$
 4Q�6'      Color$ #303841��67      
BlurRadius$ 5Q�6G   57      �� 59      $��8 0 0 0q�6   $	��717��6)   $
��Left=�65   �� 5:      $	��700��6   .��5;      &   System.Windows.Controls.DataGrid  
���   �   SelectionMode$ Single=�5=         
IsReadOnly . $��
8 20 10 10q�5?         	RowHeight$ 35Q�5@       �� AlternationCount$ 2��5A         AutoGenerateColumns .     CanUserResizeColumns .     CanUserAddRows .     CanUserResizeRows .     CanUserSortColumns .     CanUserReorderColumns .   �� SelectedItem 5D      �� *SelectedAccommodation+ �� UpdateSourceTrigger$ PropertyChanged=���5E      ��  �� Path$ Accommodations�$ PropertyChanged=�   Columns 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6-      Header$
 Name��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Name+6b     5I      $ * 6-   $ State��67    6F   �� *Location.State+6k     5J      $ * 6-   $
 City��67    6E   �� *Location.City+6i     5K      $ 75 6-   $
 Type��68    6F   �� *Type+  5L      $ Capacity��6-   $ 55 6?    6J   �� *
Capacity+  5M      $ 90 6-   $ Minimum days��68    6N   �� *MinNumberOfDays+  5N      $	 110 6-   $ Cancelation Period��69    6U   �� *CancelationPeriod+4  .System.Windows.Controls.DataGridTemplateColumn  5O      $ Pictures��61      CellTemplate 5P      �� 5Q   "   .R�5R   &   �� $	��See��6�   $3 -Press to open pictures for this accommodation��6�   $��11(�6�   $��65��6�   $��30��6�   $��Oblique$�6  ��6-   �� *DataContext.ShowPictures+ �� RelativeSource ��   �� AncestorType"    5S   *   ! �� 
TargetType" �� Property# �� Value��%c   '��       �� 5T   .   "! ��64   .�5U   2   �� " �@��CornerRadius$# 5��6Q   6]   5V   /   5W   +   5X   '   5Y   #   5[      $   RowStyle$ 5]      �� 5^      )  #System.Windows.Controls.DataGridRow"!  6    .�5_      �� " � ��# �#D6E6F26;   % �� Triggers% 5`      P� 5a   "   & P� Property& �@��AlternationIndex' P� Value$' 0��6S   . �5b   &   �� " � ��# �#F5F5F56C   5c   #   5e      5h      5i      5j      � 5k   
   $��LeftToRight=�6   $��785,10,0,671q�60   .+�5l      �� $��	118 0 0 0q�6   $
��Left=�6)   $ Press to open wizard��6D   $��80��6c   $��30��6n   $
��Bold"�6z   $��15(�6�   ��6�   �� *Wizard+.��6�   Wizard6�   �� 5m      $��18 -30 0 0 q�6   $
��Left=�6+   $ Press to change user��6F   $��80��6e   $��30��6p   $
��Bold"�6|   $��15(�6�   ��6�   �� *OwnerLogOut+.��6�   	LOG OUT6�   5n      � 5o   
   $��LeftToRight=�6   $��535,7,0,671q�60   .+�5p      �� $��Year:��6   $
��Left=�6$   $��0,0,0,0q�6?   $	��Top=�6P   $��20(�6h   �� 5q      $
��Left=�6   $��0,5,0,0q�61   $! Press to enter year for PDF��6B   ( �� TextWrapping$
( Wrap=�6h   $	��Top=�6|   $��30��6�   $	��100��6�   $��20(�6�   ) =� ErrorTemplate#) [  67  ��6�   �� $ PDFYear�$ PropertyChanged=�* �� ValidatesOnDataErrors* . + �� NotifyOnValidationError+ . .��6v  ��5r      �� 5s      "! ��6   % 5t      P� 5u      & �@=�HasError' . . �5v   "   �� " � ��
# �  ��6@   5w      5y      .��5z   !   5{      �� 5|      $��20 0 0 0q�6   $
��Left=�6(   $ Press to create pdf��6C   $��80��6a   $��30��6l   $
��Bold"�6x   $��15(�6�   ��6�   �� *PDF+.��6�   PDF6�   5}      5~      5      