   M S B A M L   `   `   `  ����M  IFinanceTracker.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FinanceTracker.WPF.ViewsFinanceTracker.WPF.Views  5   	   +    %FinanceTracker.WPF.Views.CreateWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:FinanceTracker.WPF.Views     5   	     � Title$  CreateWindow��5   	   $	��200��6   $	��480��6+   .��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Nazwa:��6-   $��Center=�6>   �� 5   
   $��0��6   $��1��6   ��6/   �� *CreateVM.Name+�� 5   
   $��1��6   $��0��6   $��
Wartość:��6-   $��Center=�6@   �� 5   
   $��1��6   $��1��6   ��6/   �� *CreateVM.Value+�� 5!   
   $��2��6   $��0��6   $��Data:��6-   $��Center=�6=   (  "System.Windows.Controls.DatePicker  5"   
   $��2��6   $��1��6"      SelectedDate 62   �� *CreateVM.Date+�� 5%   
   $��3��6   $��0��6   $
��Typ:��6-   $��Center=�6<   �� 5&   
   $��3��6   $��1��6     �� SelectedValuePath$	 Tag��5(       �� SelectedValue 5'      �� *CreateVM.ExpenseTypeId+.@�5)      �� 
 � Tag$ 1��6   .��6#   
Jedzenie6-   �� 5*      $ 2��6   .��6#   Paliwo6+   �� 5+      $ 3��6   .��6#   
Mieszkanie6/   �� 5,      $ 4��6   .��6#   
Rachunki6-   �� 5-      $ 5��6   .��6#   Raty6)   �� 5.      $ 6��6   .��6#   Inne6)   5/      �� 52   
   $��4��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   $��0,10,0,0q�6k   .+�53      �� -   5        $��Dodaj przychód��53      $	��100��6.   $��0,0,10,0q�6:   6L   �� 54      -   5        $��Dodaj stały wydatek��54      $	��150��63   $��0,0,10,0q�6?   6Q   �� 55      -   5        $��Dodaj wydatek��55      $	��150��6-   $��0,0,10,0q�69   6K   56      57      5;      