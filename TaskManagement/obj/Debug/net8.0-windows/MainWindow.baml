   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	       TaskManagement.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � Title$!  Task Management Application��5   	   $	��450��6-   $	��800��6:   .��5	      � .+�5
   
   �� -   5         ��Name$ TabControlG��5
      .@�5      �� $��Tasks��6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $��10q�6:   .+�5      �� -   5        $��Add Task��5   !   $	��100��64   $��0,0,10,0q�6@   6R   �� 5      -   5        $��	Edit Task��5   !   $	��100��65   $��0,0,10,0q�6T   �� 5      -   5        $��Delete Task��5   !   $	��100��67   $��0,0,10,0q�6\   �� 5      -   5         ��Name$ SearchTextBox��5   "    �� TextWrapping$
 Wrap=�69   $��Search��6M   $	��360��6[   6g   �� 5      -   5        $��Logout��5   !   $��60��62   $��	10,0,10,0q�6=   6P   5      &   System.Windows.Controls.DataGrid  5      -   5        $��TasksDataGrid��5   H   $��1��6      AutoGenerateColumns$ False��6,      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
TaskID��,  &System.Windows.Controls.DataGridColumn   Header$ Task ID��5   A   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6R   �� *TaskId+  5      $ Title��61   	 6@   �� *Title+  5      $ Due Date��61   	 6C   �� *	DueDate+  5       $ Priority��61   	 6C   �� *
Priority+  5!      $ Status��61   	 6A   �� *Status+5#      5$      5%      �� 5(      $��Add/Edit Task��6   $��22��6-   $��
-2,-2,-2,0q�69   $	��Top=�6M   $y�Hidden=�6e   .��5)      � $��10q�6   
 � ColumnDefinitions
 5*      �� 5+      $
��Auto �6+   �� 5,      $��* �6+    5.      �� 5/      $
��Auto �6(   �� 50      $
��Auto �6(   �� 51      $
��Auto �6(   �� 52      $
��Auto �6(   �� 53      $
��Auto �6(   �� 54      $��* �6(   �� 55      $
��Auto �6(   .+�58      �� $��Title:��6   $��0��6-   $��0��6:   �� 59      -	   5        $ TitleTextBox��59      $��0��64   $��1��6A   $��0,0,0,10q�6Q   �� 5;      $��Description:��6   $��1��63   $��0��6@   �� 5<      -
   5        $ DescriptionTextBox��5<      $��1��6:   $��1��6G   $��0,0,0,10q�6W    �� AcceptsReturn$
 True��6i   $
 Wrap=�6~   �� 5>      $��	Due Date:��6   $��2��60   $��0��6=   (  "System.Windows.Controls.DatePicker  5?      -   5          Name$ DueDatePicker��5?   !   $��2��68   $��1��6E   $��0,0,0,10q�6U   �� 5@      $��	Due Date:��6   $��2��60   $��0��6=   �� 5B      $��	Priority:��6   $��3��60   $��0��6=   �� 5C      -   5         ��Name$ PriorityComboBox��5C      $��3��69   $��1��6F   $��0,0,0,10q�6V   .@�5D      �� .��6'   Low6,   �� 5E      .��6'   Medium6/   �� 5F      .��6'   High6-   5G      �� 5I      $��Status:��6   $��4��6.   $��0��6;   �� 5J      -   5        $ StatusComboBox��5J      $��4��67   $��1��6D   $��0,0,0,10q�6T   .@�5K      �� .��6'   	Pending60   �� 5L      .��6'   In Progress64   �� 5M      .��6'   	Completed62   5N      �� 5P      $��6��6!   $��1��6.   $ 
Horizontal=�6>   $��Right=�6W   .+�5Q      �� -   5        $
��Save��5Q   !   $��75��60   $��0,0,10,0q�6;   6M   �� 5R      -   5        $��Cancel��5R   !   $��75��62   6=   5S      �� 5T      -   5        $ TaskIDTB��5T       �� 
IsReadOnly$
 True��60   $��5��6B   $��1��6O   $��	0,0,0,192q�6_   $
 True��6r   $
 Wrap=�6�   $y�Hidden=�6�   �� 5U      -   5        $ isUpdate��5U      $��1��60   $
��Left=�6@   $��0,38,0,0q�6[   $��5��6m   $
 Wrap=�6z   $	��Top=�6�   $	��120��6�   $y�Hidden=�6�   5V      5W      5X      5Y      5Z      