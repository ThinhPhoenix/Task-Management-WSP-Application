   M S B A M L   `   `   `  ����I  ETaskManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagementTaskManagement  5   	       TaskManagement.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagement     5   	     � Title$  Login��5   	    � WindowStartupLocation$ CenterScreen=�6    � 
ResizeMode$ NoResize=�6<   ���#121212
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ Label��5      $��LOGIN��6   $��0��6/   $��1��6<   $��Center=�6L   $��Center=�6i   $
��Bold"�6�   $��48(�6�   
�������6�   �� 5   
   $��1��6   $��1��6   ���#1E1E1E �� Padding$ 20q�6C    �� CornerRadius$ 10��6P   ._�5      �� $��Center=�6   $��Center=�64   $	��300��6Q   .+�5      �� $��
Username :��6   $��15(�6-   
�������6;   �� 5      -   5         ��Name$ username��5      $	��260��6,   $��30��68   $��0,5,0,0q�6D   $��5q�6U   $��14(�6a   ���#252526
����������#007ACC$��1q�6�   �� 5      $��
Password :��6   $��15(�6-   $��0,20,0,0q�6;   
�������6M   G� 5      -   5        	 G�Name$	 password��5      $	��260��60   $��30��6<   $��0,5,0,0q�6H   $��5q�6Y   $��14(�6e   ���#252526
����������#007ACC$��1q�6�   �� 5      -   5        $��Login��5      $	��175��6)   $��40��65   $��0,20,0,0q�6A   $
��Bold"�6i   $��18(�6{   ���#007ACC
����������#1E1E1E$��0q�6�   5      5      5       5!      