   M S B A M L   `   `   `  ����B  >do_an_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:do_an_3do_an_3  5      7 clr-namespace:do_an_3.Convertersdo_an_3.Converters  5          do_an_3.UserControlHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      !localclr-namespace:do_an_3  5      1
converters clr-namespace:do_an_3.Converters  5      -   5          � 	Resources  5      &    do_an_3.Converters.NullConverter   NullConverter2   ,do_an_3.Converters.ByteArrayToImageConverter  ImageConverter��%:   &	        &	        5   
   6;     5   
   6H   5      .��5      � -   5         �Name$ Panel��5      .+�5   
   �� $��Disabled=�6   $��Hidden=�5      .��5      � $
��15 5q�6    � RowDefinitions 5      �� 5      $��75 �6$   �� 5      $��* �6$   �� 5      $��30 �6$   .+�5      � 
������� � ColumnDefinitions 5      �� 5      $	��220 �6+   �� 5      �� 5      $	��450 �6+   .+�5!      ��  �� Orientation$ 
Horizontal=�6!   $
��Left=�5"   !   .+�5%      �� -   5        $��CategoriesComboBox��5*   #   $��1��5%   #   $��40��63   $	��160��5&   #   $��10q�5'   #   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Tất cả��5(   #   $��15(�5)   #   ��5,      �� 5-   "   .R�5.   &   �� ��60   �� *name_category+6Q   5/   #   51      '  !MaterialDesignThemes.Wpf.PackIcon  54      -   5        $��ClearFilterButton��59   6   $��40��54   2   $��40��55   6   $��Center=�56   6      Kind$ CloseCircleOutline=�57   6   
�������$y�	Collapsed=�5;   6   5<      � 5?      $��1��6    5@      �� 5A      �� 5B      $	��200 �6/   �� 5C      .+�5E      �� -   5        $��PagingInfoComboBox��5G   #   $	��160��5E   #   $��60��5F   #   $��1��5H   #      MaterialDesignFilledComboBox#��[ 5I   #   $ Current Page��5J   #   $��15(�5K   #   ��5M      �� 5N   "   .R�5O   &   �� $ 
Horizontal=�61   .+�5P   *   �� ��64   �� *Page+6L   �� 5Q   *   $
�� of ��64   6B   �� 5R   *   ��64   �� *
TotalPages+6R   5S   '   5T   #   5V      �� 5W      -   5        $��PreviousButton��5X   !   $��45��5W   !   $��45��6-   $��Right=�5Y   !    / +MaterialDesignFloatingActionMiniLightButton#��[ 5Z   !   
�������.��5]        $��45��66   $��45��5^   2   $��Center=�5_   2   $��Center=�5`   2   $ ChevronLeft=�5a   2   
�������5b   F   5c      �� 5e      -   5        $��
NextButton��5j   !   $��45��5e   !   $��45��6-   $��2��5f   !   $
��Left=�5g   !   #��[ 5h   !   
�������.��5l        $��45��66   $��45��6A   $��Center=�5m   2   $
��Left=�5n   2   $ ChevronRight=�5o   2   
�������5p   F   5q      5r      �� 5u      -   5        $��SearchTextBox��5|      $��2��5u      $	��350��5v      $��50��5w      $
��50 0q�5x       * &MaterialDesignOutlinedTextFieldTextBox#��[ 5y      $ Tìm kiếm...��5z      $��15(�5{      5}      5~      � 5�      $��1��6   
����ح�.+�5�      �� -	   5         ��Name$ ListBoxCakes��5�      $
��30 5q�5�      ��5�      �� 5�      .R�5�   "   � 5�      ��5�      �� 5�      .R�5�   "   �� .+�5�   &   ��  �� BitmapScalingMode$ HighQuality=�5�   (   $
��Fill=�5�   (   $	��160��5�   (   $	��160��5�   (   $	��5 0q�5�   (   ��5�   ,   �� *image+	 �� 	Converter#	 [ 5�   7   �� 5�   &   $��20(�5�   ,   $��Center=�5�   ,   ��5�   0   �� *	name_cake+#	 [  5�   K   5�   #   5�      5�      5�      � 5�      
�������$��2��5�      6&   5�      5�      5�      5�      