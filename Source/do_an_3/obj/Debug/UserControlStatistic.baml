   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      B >do_an_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:do_an_3do_an_3 5      "   do_an_3.UserControlStatistic   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      'localclr-namespace:do_an_3     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   �� $'��!THỐNG KÊ DOANH THU THEO THÁNG��6   $��0��5      $��Center=�6$   $��Center=�6A   $��20(�5      $
��Bold"�6"   
���  ��64   �� 5   
   -   5        $��cmbChosenYear��5      $��20��5      $	��100��6   $��1��6+   $��Right=�5       �� 
IsEditable . 6/   � 5   
   $��2��6   .+�5      #   LiveCharts.Wpf.CartesianChart  -   5        $��chartColumn��5   9   &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�6!      AxisX 5!         LiveCharts.Wpf.Axis     Title$ Doanh thu theo tháng��6      Labels 5"      �� *Labels+   AxisY 5%        $
 VNĐ��6      LabelFormatter 6+   �� *	Formatter+6R   5'      5(      �� 5*   
   -   5        $��btnListAllOrder��5*      $��DANH SÁCH ĐƠN HÀNG��6(   $��0��5+      $��3��6!   $��5,5,5,5q�6.   $��20(�5,      $
��Bold"�6   
�������5-      �� 5/   
   $-��'THỐNG KÊ DOANH THU THEO LOẠI BÁNH��6   $��1��50      $��Center=�6$   $��Center=�6A   $��20(�51      $
��Bold"�6"   
���  ��64      LiveCharts.Wpf.PieChart  53   
   -   5        $��pieChartCategoryCake��53      $��2��63   $��1��6@   $ Bottom=�54      	   	Hoverable	 .  
   DataTooltip
 6A   Z� 55      57      58      