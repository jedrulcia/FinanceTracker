   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   M IFinanceTracker.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FinanceTracker.WPF.BaseFinanceTracker.WPF.Base 5   	   #   FinanceTracker.WPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   7local%clr-namespace:FinanceTracker.WPF.Base     5   	     � Title$  
MainWindow��5	   	   $	��680��6   $
��1200��6)    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $$ ../Styles/ScrollBarStyles.xaml?�6%   �� 5      $' !../Styles/RoundedButtonStyle.xaml?�6%   %    5      .��5      �    BrushPrimaryBackground#��[  6    � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��25* �6   �� 5      $	��33* �6   �� 5      $	��33* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       .+�5#   
   � $��0��6   $��0��6    5$      �� 5%      �� 5&      .+�5)      �� $��0��5*        BrushSecondaryBackground#��[ 5+       �� CornerRadius$ 10��5,      $��10q�5-       �� Padding$ 10q�5.      $��Stretch=�5/      $��Stretch=�50      ._�51      �� $��Stretch=�52      $��Stretch=�53      ��54      �� *Months+ �� SelectedItem 55      �� *SelectedMonth+56      �� 58      -   5        $��1��58        RoundedButtonStyle#���  59      $
��NOWY��6B   $��Stretch=�5:      $��Stretch=�5;      $��10q�5<      $��10q�5=        BrushPositive#��[ 5>      $
��Bold"�5?      $��16(�5@      5B      5C      � 5G   
   $��0��6   $��3��6   $��2��6,   .+�5H      �� #��[ 5I      $ 10��5J      $��10q�5K      $ 10q�5L      $��Stretch=�5M      $��Stretch=�5N      ._�5O         LiveCharts.Wpf.PieChart  &    LiveCharts.Wpf.Charts.Base.Chart	   LegendLocation$	 Right=�6   
�������$
��Bold"�6I   
   DataTooltip
 6[   Z�    Series 5Q         LiveCharts.Wpf.PieSeries     LiveCharts.Wpf.Series   Title$ Jedzenie��6(      Fill �#9966FF   
DataLabels$
 True��6k      Values 69   �� *PieChartVM.Food+   
LabelPoint 6}   �� *PieChartVM.LabelFormatter+  5R      $ Paliwo��6(    �#FFDD33$
 True��6i    67   �� *PieChartVM.Fuel+ 6{   �� *PieChartVM.LabelFormatter+  5S      $ 
Mieszkanie��6(    �#4BC0C0$
 True��6m    6;   �� *PieChartVM.Flat+ 6   �� *PieChartVM.LabelFormatter+  5T      $ Rachunki��6(    �#FF9F40$
 True��6l    69   �� *PieChartVM.Bills+ 6~   �� *PieChartVM.LabelFormatter+  5U      $
 Raty��6(    �#36A2EB$
 True��6h    65   �� *PieChartVM.Rates+ 6z   �� *PieChartVM.LabelFormatter+  5V      $
 Inne��6(    �#FF6384$
 True��6h    65   �� *PieChartVM.Other+ 6z   �� *PieChartVM.LabelFormatter+5X      5Y      5Z      � 5]   
   $��0��6   $��1��6   $��2��6,   .+�5^      �� #��[ 5_      $ 10��5`      $��10q�5a      $ 10q�5b      $��Stretch=�5c      $��Stretch=�5d      ._�5e      �� $��Center=�6   $��Center=�6:   .+�5f      �� $��Podsumowanie roczne��6    $��16(�6;   $
��Bold"�6I   $��0,0,0,10q�6[   
�������6m   �� 5g      $��14(�6h   
�������$
��Bold"�6�   ��6    �� *YearlySummaryVM.Balance+ �� StringFormat$ Bilans: {0:N2}��6�   �� 5h      $��14(�6i   #��[ 6w   $
��Bold"�6�   ��6    �� *YearlySummaryVM.Credits+$ Uznania: {0:N2}��6�   �� 5i      $��14(�6l     BrushNegative#��[ 6z   $
��Bold"�6�   ��6    �� *YearlySummaryVM.Charges+$ Obciążenia: {0:N2}��6�   5j      5k      5l      � 5o   
   $��0��6   $��2��6   $��2��6,   .+�5p      �� #��[ 5q      $ 10��5r      $��10q�5s      $ 10q�5t      $��Stretch=�5u      $��Stretch=�5v      ._�5w      �� $��Center=�6   $��Center=�6:   .+�5x      �� $��Podsumowanie miesięczne��6    $��16(�6?   $
��Bold"�6M   $��0,0,0,10q�6_   
�������6q   �� 5z      $��14(�6i   
�������$
��Bold"�6�   ��6    �� *MonthlySummaryVM.Balance+$ Bilans: {0:N2}��6�   �� 5{      $��14(�6j   #��[ 6x   $
��Bold"�6�   ��6    �� *MonthlySummaryVM.Credits+$ Uznania: {0:N2}��6�   �� 5|      $��14(�6m   #��[ 6{   $
��Bold"�6�   ��6    �� *MonthlySummaryVM.Charges+$ Obciążenia: {0:N2}��6�   5}      5~      5      � 5�   
   $��2��6   $��0��6   .+�5�      �� #��[ 5�   	   $ 10��5�   	   $��10q�5�   	   $ 10q�5�   	   $��Stretch=�5�   	   $��Stretch=�5�   	   ._�5�      �� 
������ $��0q�5�      $��Stretch=�5�      $��Stretch=�5�      $��Visible=�5�      $��Disabled=�5�      ��5�      �� *	SalaryVMs+ 5�       �� 
TargetType  CustomScrollBarStyle �� BasedOn��%0   '��       7  �� 5�      " ��6    8   6@   5�      ��5�      �� 5�      .R�5�      �� ._�5�   "   � -   5         5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   
 � Tag 5�   &   �� 5�   *    �� Path$ Id�62   .+�5�   &   �� 
�������$
��Bold"�6Y   $��0,0,10,0q�6k   $��0��6}   ��60   �� *Name+6}   �� 5�   &   
�������$
��Bold"�6Z   $��0,0,10,0q�6l   $��1��6~   ��60   �� *Value+6~   5�   #   5�      5�      5�      5�      5�      � 5�   
   $��2��6   $��1��6   .+�5�      �� #��[ 5�      $ 10��5�      $��10q�5�      $ 10q�5�      $��Stretch=�5�      $��Stretch=�5�      ._�5�      �� 
������ $��0q�5�      $��Stretch=�5�      $��Stretch=�5�      ��5�      �� *OngoingExpenseVMs+ 5�      ��%0   '��       7  �� 5�      " ��6    8   6@   5�      ��5�      �� 5�      .R�5�      �� ._�5�   "   � -   5         5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;    5�   &   �� 5�   *   $ Id�62   .+�5�   &   �� 
�������$
��Bold"�6Y   $��0,0,10,0q�6k   $��0��6}   ��60   �� *Name+6}   �� 5�   &   
�������$
��Bold"�6Z   $��0,0,10,0q�6l   $��1��6~   ��60   �� *Value+6~   5�   #   5�      5�      5�      5�      5�      � 5�   
   $��2��6   $��2��6   .+�5�      �� #��[ 5�      $ 10��5�      $��10q�5�      $ 10q�5�      $��Stretch=�5�      $��Stretch=�5�      ._�5�      �� 
������ $��0q�5�      $��Stretch=�5�      $��Stretch=�5�      ��5�      �� *OtherExpenseVMs+ 5�      ��%0   '��       7  �� 5�      " ��6    8   6@   5�      ��5�      �� 5�      .R�5�      �� ._�5�   "   � -   5         5�   &   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;    5�   &   �� 5�   *   $ Id�62   .+�5�   &   �� 
�������$
��Bold"�6Y   $��0,0,10,0q�6k   $��0��6}   ��60   �� *Name+6}   �� 5�   &   
�������$
��Bold"�6Z   $��0,0,10,0q�6l   $��1��6~   ��60   �� *Value+6~   5�   #   5�      5�      5�      5�      5�      � 5�   
   $��2��6   $��3��6   .+�5�      �� #��[ 5�      $ 10��5�      $��10q�5�      $ 10q�5      $��Stretch=�5     $��Stretch=�5     ._�5     �� 
������ $��0q�5     $��Stretch=�5     $��Stretch=�5     ��5     �� *OverduePaymentVMs+ 5	     ��%0   '��       7  �� 5
     " ��6    8   6@   5     ��5     �� 5     .R�5     �� ._�5  "   � -   5         5  &   �� 5  *   $��* �6;   �� 5  *   $
��Auto �6;    5  &   �� 5  *   $ Id�62   .+�5  &   �� 
�������$
��Bold"�6Y   $��0,0,10,0q�6k   $��0��6}   ��60   �� *Name+6}   �� 5  &   
�������$
��Bold"�6Z   $��0,0,10,0q�6l   $��1��6~   ��60   �� *Value+6~   5  #   5     5     5     5     5     � 5"  
   $��3��6   $��0��6   $��4��6,   .+�5#     �� #��[ 5$     $ 10��5%     $��10q�5&     $ 10q�5'     $��Stretch=�5(     $��Stretch=�5)     ._�5*     #   LiveCharts.Wpf.CartesianChart   5,     !   LiveCharts.Wpf.ColumnSeries  # [ 6+   $ Uznania��5-  +      MaxColumnWidth$ 25Q�5.  +    5/  +   �� *ColumnChartCredits+  50     # [ 6+   $ Wydatki��51  +   $ 25Q�52  +    53  +   �� *ColumnChartCharges+   AxisX 56        LiveCharts.Wpf.Axis     Labels 6#   �� *ColumnChartLabels+   	Separator 57        LiveCharts.Wpf.Separator  58  "   ${�False��60      Step$ 1Q�6B   5:        AxisY 5=        5>       5?  "      Stroke
 �����60   5A     5C     5D     5E     5F     5G     