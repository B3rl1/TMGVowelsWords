   M S B A M L   `   `   `  ����@  <Task1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Task1.Models.RulesTask1.Models.Rules  5   	   5clr-namespace:Task1.Models.ViewTask1.Models.View  5   	       Task1.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2rules clr-namespace:Task1.Models.Rules     5   	   0viewclr-namespace:Task1.Models.View     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��830��6)   $	��830��65   $	��450��6D    � 	Resources 5       �� 
TargetType   
TextColumn �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%  &	        '  O     �� 5   
   " ��6   .�5      ��  � ��$
 Wrap=�6-   6<   5      �� 5   
   "  6   .�5      ��  � ��
 �����6@   �� 5       � ��$
 Bold"�6@   6O   �� 5       � ��$ Center=�6I   6Z   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $
��430* �6   �� 5      $
��200* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��13* �6   .+�5"   
   �� -   5        $��Label��5"      $.��(Идентификаторы строк:��6   $��5,0,0,0q�6=   6P   �� 5#   
   -   5        $��	TextBoxId��5#      $��0��6$   $��1��61   $��5,5,5,5q�6A     ErrorTemplate =� ErrorTemplate# [ 6R   .��6�    � DataContext 5$          Task1.Models.View.StringId  5%      .��5&   #   ��5'      �� 5(      	 �� Path$	 Id�6   
 �� ValidatesOnDataErrors$

 True��6$    �� UpdateSourceTrigger$ PropertyChanged=�6A    �� ValidationRules 5)      %   Task1.Models.Rules.StringIdRule  5*         MinId$ 1��6-      MaxId$ 20��67   5,      .��5-      5.      �� 5/   
   -   5        $��ButtonCount��5/      $��0��6$   $��2��61   $��Подсчитать��6A   $	��150��6V   $
��Left=�6b   $��5,5,0,5q�6}   50      &   System.Windows.Controls.DataGrid  52   
   -   5        $��dataGrid��52      $��1��6#   $��3��60   $��10,10,10,10q�6D      AutoGenerateColumns$ False��6Y      CanUserAddRows$ False��6u      CanUserDeleteRows$ False��6�      CanUserResizeRows$ False��6�      
IsReadOnly$
 True��6�   
�������$��Disabled=�6�      GridLinesVisibility$
 None=�6  $��Normal"�66     RowHeaderStyle 53      �� 54      .�55      ��  � ��
 �����6O   56         ColumnHeaderStyle 58      �� 59      .�5:      ��  � ��
 �����6H   �� 5;       � ��$
 Bold"�6H   6W   �� 5<       � ��$ Center=�6Q   6b   5=         Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Текст��6%      MinWidth$	 300Q�6T      Width5  /System.Windows.Controls.DataGridLengthConverter$
 400* 6c      	FontStyle$ Normal$�6q      
FontWeight$ Normal"�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� $
	 Text�   ElementStyle 5A      �� 5B      " ��6    .�5C      ��  � ��$
 Wrap=�6=   6L   5D      5F        5G      $# Количество слов��6%   $ 50Q�6d   $
 100* 6r   $ Normal"�6�    6>   �� $	 
WordsCount� 5H      �� 5I      " ��6    .�5J      ��  � ��$ Center=�6D   6U   �� 5K       � ��$ Center=�6B   6S   5L      5N        5O      $) #Количество гласных��6%   $ 50Q�6h   $
 100* 6v   $ Normal"�6�    6A   �� $	 VowelsCount� 5P      �� 5Q      " ��6    .�5R      ��  � ��$ Center=�6D   6U   �� 5S       � ��$ Center=�6B   6S   5T      5V      5X      5Z      5[      