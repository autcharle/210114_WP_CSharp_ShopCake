   M S B A M L   `   `   `  ����B  >do_an_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:do_an_3do_an_3  5      %    do_an_3.UserControlListAllOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:do_an_3     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� $��DANH SÁCH ĐƠN HÀNG��6   $��4��6.   $��Center=�5      $��Center=�61   $��32(�5      
���  ��$
��Bold"�63   �� 5   
   $��TÊN KHÁCH HÀNG��6   $��1��6*   $��Center=�5      $��20(�6/   $��10q�6=   �� 5   
   -   5        $��	txtFilter��5      $��1��5      $��1��6   $��0,0,0,10q�6/   $��Center=�5      $��20(�64   5   #   �� 5!   
   -   5        $��lvListAllOrder��5!      $��2��6)   $��4��66    � 	Resources 5"         GridViewColumnHeaderStyle1 �� 
TargetType �� Property �� Value��%x   &	        �� 5#      " ��6;   .�5$      ��  � ��
 �   �63   �� 5%       � ��$ 14(�61   5&      5'       �� View 5)      �� 5*      ! �� ColumnHeaderContainerStyle# [  6   .P�5,      �� $��TÊN KHÁCH HÀNG��6%    �� Width$	 250��6=   	 �� CellTemplate	 5-      �� 5.      .R�5/   "   �� 
����  �$��16(�6]   ��6,   �� *name_customer+6]   50      52      �� 54      $��TỔNG ĐƠN HÀNG��6%   $	 250��6<   	 55      �� 56      .R�57   "   �� 
����  �$��16(�6_   ��6,   �� *totalOrderMoney+6_   58      5:      �� 5<      $��NGÀY TẠO ĐƠN��6%   $	 250��6;   	 5=      �� 5>      .R�5?   "   �� 
����  �$��16(�6Z   ��6,   �� *
order_date+6Z   5@      5B      �� 5D      $��TÌNH TRẠNG��6%   $	 250��69   	 5E      �� 5F      .R�5G   "   �� 
����  �$��16(�6V   ��6,   �� *status+6V   5H      5J      5K      5N      5P      5Q      