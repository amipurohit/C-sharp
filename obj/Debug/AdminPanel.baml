   M S B A M L   `   `   `  ����E  ATest3_Bank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Test3_Bank
Test3_Bank  5   	       Test3_Bank.AdminPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Test3_Bank     5   	   -   5          � Title$  Administrator Panel��5	   	   $	��450��6%   $	��600��62    � WindowStyle$ ThreeDBorderWindow=�6>   .��5
      � $��20q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgUserLog��5         
IsReadOnly .    AutoGenerateColumns .  $��0��6U   $��3��6e   $
��10,5q�6{   
���   �
������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6<   ��  �� Path$ ID�  5      $
 Name��6%   $		 150 63   
 6@   �� $
 Name�  5      $ Account Number��6%   $		 150 6=   
 6J   �� $ 
Account.Id�  5      $ Balance��6%   $		 150 66   
 6C   �� $ Account.Balance�5      �� 5   
   -   5         ��Name$ BtnAdd��5      $	��Add��6!   $��0��6/   $��1��6@   $
��10,5q�6N   
������6q   �� 5   
   -   5        $ 	BtnUpdate��5      $��Update��6$   $��1��65   $��1��6F   $
��10,5q�6T   
������6{   �� 5   
   -   5        $ 	BtnDelete��5      $��Delete��6$   $��2��65   $��1��6E   $
��10,5q�6T   
������6z   5       5!      