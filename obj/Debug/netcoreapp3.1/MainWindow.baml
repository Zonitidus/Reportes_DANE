   M S B A M L   `   `   `  ����G  CReportesDane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ReportesDaneReportesDane  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 62       ReportesDane.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ReportesDane     5   	   DWpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     62     � Title$
  DANE��5   	   $	��450��6   $	��800��6#    � 
ResizeMode$ NoResize=�6/    � Cursor$	 Pen��6E    � Icon$ 
/icon2.png��6R   .��5	      � $	 Pen��6    � RowDefinitions 5
   
   �� 5      $	��37* �6   �� 5      $	��25* �6   .+�5   
   �� -   5         ��Name$ 	Open_file��5      $��	Open file��6$   $
��Left=�68   $��
30,131,0,0q�6S   $	��Top=�6g   $��1��6�   �� 5   
   -   5         ��Name$ label��5      $�� ��6   $
��Left=�6*   $��113,128,0,0q�6E   $	��Top=�6Z   $	��660��6r   $��1��6~   �� 5   
   -   5         ��Name$ tableScroll��5      $��30,32,400,98q�6,   $��2��6B   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataDANE��5      $	��269��6)   $	��323��66   5      �� 5   
   -   5        $ diagramScroll��5      $��403,32,27,98q�6.   $��2��6D   .��5        LiveCharts.Wpf.PieChart  -   5        	  Name$	 piechartData��5      &   LiveCharts.Wpf.Charts.Base.Chart
   LegendLocation$
 Bottom=�61      	Hoverable$ False��6I      DataTooltip 6[   Z� 5      5      �� 5   
   -   5         ��Name$ letters��5      $
��Left=�6$   $��
113,82,0,0q�6?   $��1��6S   $	��Top=�6`   $	��120��6x   6�   5      5      