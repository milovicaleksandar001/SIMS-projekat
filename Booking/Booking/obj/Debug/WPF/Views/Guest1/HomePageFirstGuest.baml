   M S B A M L   `   `   `  ����B  >Booking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Booking.LocalizationBooking.Localization  5      %    Booking.View.HomePageFirstGuest   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      +ns"clr-namespace:Booking.Localization  5        N� Title$  HomePageFirstGuest��5
         MyWindowStyle#���   5       � 	Resources 5        ValidationTemplate ��Name��%�   &	       �� 5   
   .R�5      �� .+�5      �� $ textBox��6,   �� 5      
���  ����6   �� *[0].ErrorContent+6>   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��60 �6   �� 5      $��40 �6   �� 5      �� 5      $��80 �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��	20,0,20,0q�6;   $��Center=�6N   .+�5       �� $$��/Resources/Images/location.png��6   6>   �� 5!      $
��Bold"�6   $��17(�6&   ��64   '   !Booking.Localization.LocExtension  *HomePageTitle+6W   5"      � 5$   
   $��1��6   $��	20,0,20,0q�6    5%      �� 5&      �� 5'       � ColumnDefinitions 5*      �� 5+      $	��140 �6#   �� 5,      �� 5-      �� 5.      �� 5/      $	��120 �6#   �� 50      $	��100 �6#   �� 51      $	��100 �6#   �� 52      $	��100 �6#   .+�55      �� $��0��6   $��0��6$   $
��Left=�6V   ��61     *AccommodationName+6s   �� 56      $��1��6   $��0��6&   $��3q�63   ��6>   ��  �� Path$ 
SearchName�6a   �� 57      $��2��6   $��0��6$   $��Right=�6J   $��0,0,4,0q�6f   ��61     *State+6y   �� 58      $��3��6   $��3q�6T   ��6'   �� $ CountrycomboBox� �� SelectedItem 59      �� $ SearchState� �� UpdateSourceTrigger$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction	   Triggers	 5:      +  %Microsoft.Xaml.Behaviors.EventTrigger  5;      
   	EventName$
 SelectionChanged��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5<      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *FillCityCommand+5=      5?      �� 5A      $��4��6   $��0��6$   $
��Left=�6I   ��61     *Type+6f   �� 5B      $��5��6   $��0��6'   $��5q�64    d� 	IsChecked 6?   �� $ IsCheckedApartment���6m     *ApartmentType+6�   �� 5C      $��6��6   $��0��6'   $��5q�64    6?   �� $ IsCheckedCottage���6k     *CottageType+6�   �� 5D      $��7��6   $��0��6'   $��5q�64    6?   �� $ IsCheckedHouse���6i     *	HouseType+6�   �� 5F      $��0��6   $��1��6%   $
��Left=�6R   ��63     *StayingDays+6o   �� 5G      $��1��6   $��1��6'   $��3q�64    =� ErrorTemplate# [ 5H   /   ��5G   ?   �� $ SearchReservationDays�$ PropertyChanged=� �� ValidatesOnDataErrors . 5H   q   �� 5I      $��2��6   $��1��6%   $��Right=�6J   $��0,0,10,0q�6f   ��62     *City+6z   �� 5J      $��3��6   $��1��6)   $��3q�66   {�6A   �� *CityComboboxEnabled+$ PropertyChanged=���6�   �� $ CityCollection� 6�   �� $ 
SearchCity�$ PropertyChanged=�6  �� 5K      $��4��6   $��1��6%   $
��Left=�6T   ��62     *NumberOgGuests+6q   �� 5M      $��5��6   $��1��6'   $��3,3,3,0q�64   # [ 5N   /   $��24��6n   $	��Top=�6z   ��5M   E   �� $ SerachGuests�$ PropertyChanged=� . 5N   �   5O      �� 5Q   
   $��2��6   $��Right=�6   $	��120��6;   $
��Bold"�6G   $��
20,15,20,5q�6Y   ��6m   �� *Button_Click_Search+��6�     *SearchButton+6�   �� 5S   
   $��3��6   $��	20,0,20,0q�6"   .+�5T      &   System.Windows.Controls.DataGrid  -   5          Name$ AccommodationDataGrid��5T         
IsReadOnly .    AutoGenerateColumns .  $	��350��5V   E      HeadersVisibility$ Column=�6R   $��13(�6m    5U      �� *SelectedAccommodation+$ PropertyChanged=���5V   |   �� $ Accommodations�   Columns 5W      4  .System.Windows.Controls.DataGridTemplateColumn  5X      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6M      Header 6-     *ImageDataGrid+   CellTemplate 5Y      �� 5Z      .R�5[   "   �� $	��160��6I   $	��150��6U   $��2q�6b   ��6(   �� *Images[0].Url+6b   5\      5^      0
  *System.Windows.Controls.DataGridTextColumn
  5_      $	 120	 6H    6)     *NameDataGrid+1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *Name+6o   
  5`      $	 100	 6I    6)     *StateDataGrid+ 6U   �� *Location.State+6z   
  5a      $	 100	 6H    6)     *CityDataGrid+ 6T   �� *Location.City+6x   
  5b      $ 80	 6H    6)     *TypeDataGrid+ 6T   �� *Type+6o   
  5c      $ 80	 6M    6)     *CapacityDataGrid+ 6Y   �� *
Capacity+6x   
  5d       6)     *!ReservationRestricitonsDataGrid+ 6[   �� *MinNumberOfDays+6�   
  5e       6)     *CancelationPeriodDataGrid+ 6U   �� *CancelationPeriod+6}   5g      5h      �� 5k   
   $��4��6   $ 
Horizontal=�6"   $��Center=�6;   $��40��6X   $��Center=�6d   $��0,0,0,40q�6   .+�5l      �� $��5,5,5,5q�64   $��1��6E   $��30��6R   $
��Bold"�6^   ��6     *
BookButton+��6q   �� *Button_Click_Book+6�   �� 5m      $��5,5,5,5q�67   $��30��6I   $
��Bold"�6V   ��6     *ShowAllButton+��6h   �� *Button_Click_ShowAll+6�   �� 5n      $��5,5,5,5q�6;   $��30��6M   $
��Bold"�6Y   ��6     *ShowImagesButton+��6k   �� *Button_Click_ShowImages+6�   5o      5p      5q      