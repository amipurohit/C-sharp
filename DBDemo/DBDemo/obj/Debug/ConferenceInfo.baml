   M S B A M L   `   `   `  ����A  =DBDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DBDemoDBDemo  5   	       DBDemo.ConferenceInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DBDemo     5   	     � Title$  Conference Infomation��5   	   $	��350��6'   $	��400��64   .��5	      � ���	#FFD5B265 � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��Name:��6   $��1��6!   $��1��61   $��5q�6>   $��16(�6I   $��DemiBold"�6W   �� 5   
   -   5         ��Name$ txtName��5      {�.  $��2��66   $��1��6F   $��5q�6T   $��16(�6_   $
��Bold"�6m   �� 5   
   $��Contact Number:��6   $��1��6+   $��2��6;   $��5q�6I   $��16(�6T   $��DemiBold"�6b   �� 5   
   -   5        $ txtContactNumber��5      {�.  $��2��6>   $��2��6N   $��5q�6\   $��16(�6g   $
��Bold"�6u   �� 5   
   $��Conference Date:��6   $��1��6,   $��3��6<   $��5q�6J   $��16(�6U   $��DemiBold"�6c   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpConferneceDate��5      {�.  $��2��6A   $��3��6Q   $��5q�6_   $��16(�6j   $
��Bold"�6x   �� 5   
   -   5        $��OK��5      $��1��6   $��5��6.   $��2��6;   $��5q�6P   $��16(�6[   $��DemiBold"�6i   6   5       5!      