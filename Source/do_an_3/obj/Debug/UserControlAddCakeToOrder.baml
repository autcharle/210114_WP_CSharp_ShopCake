   M S B A M L   `   `   `  ����B  >do_an_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:do_an_3do_an_3  5      '    !do_an_3.UserControlAddCakeToOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:do_an_3     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��2* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5        $��cmbCake��5      $��2��6"   $��0,0,0,3q�5      ��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��txtIdMember��6$   $��20(�6R   ��67   �� *	name_cake+-6g   �� 5      $��20(�6;   ��6$   �� *price+6;   5      5      5      �� 5!   
   $��SỐ LƯỢNG��6   $��Center=�6$   $��Center=�6?   $��16(�5"      $
��Bold"�6"   $��1��64   �� 5$   
   -   5        $��txtQuantity��5$      $��1��6%   $��1��62   $��Center=�5%      $��Center=�64   $��16(�5&      6    �� 5(   
   $��TỔNG TIỀN��6   $��Center=�6%   $��Center=�6@   $��16(�5)      $
��Bold"�6"   $��2��64   �� 5+   
   -   5        $��lbTotalPrice��5+      $��2��6$   $��1��61   $��Center=�5,      $��Center=�64   $��16(�5-      �� 5/   
   -   5        $��btnAdd��5/      $��Thêm��64   $��1��50      $��3��6!   $��16(�6.   $��50, 0q�51      $��Center=�6    
�������52      54      55      