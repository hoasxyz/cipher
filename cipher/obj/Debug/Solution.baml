   M S B A M L   `   `   `  ����A  =cipher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ciphercipher  5   	       cipher.Solution   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:cipher     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  错题整理��5	   	   $��572.431��6   $��837.771��6'    � 	Resources 5         StyleContextMenuTest �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%�   &	        �� 5   
   " ��6-    5      �� 5       6   �� *RightorWrong+
 错误6?   .a�5      ��  � ��
 �  ��63   5      5      5      .��5      � $��0,0,-6.667,-2.667q�6    � RowDefinitions 5   
   �� 5      	 � ColumnDefinitions	 5   
   �� 5      �� 5      $��0* �6   .+�5#   
   �� -   5        
 ��Name$
 	ListView1��5#      $��50,160,52,90q�6&    �� View 5%      �� 5'      .P�5)      �� $��题号��6%    �� Width$	 100��61    �� DisplayMemberBinding 6>   �� *Num+�� 5*      $��题目��6%   $	 150��61    6=   �� *
Question+�� 5+      $��正确答案��6%   $	 170��63    6?   �� *
Rightans+�� 5,      $��你的答案��6%   $	 170��63    6?   �� *	Yourans+�� 5-      $��正误��6%   $	 100��61    6=   �� *RightorWrong+5.      50      �� 51   
   -   5         ��Name$ Label1��51      $��Label��6    $
��Left=�60   $��
107,74,0,0q�6K   $	��Top=�6_   $��18(�6w   $��33��6�   $	��186��6�   �� 52   
   -   5        $ Label2��52      $��Label��6    $
��Left=�60   $��107,112,0,0q�6K   $	��Top=�6`   $��25��6x   $	��302��6�   �� 53   
   -   5          MaterialDesignFlatButton#��[ 53      $��输出答案��6C   $��	0,77,70,0q�6R   $	��Top=�6e   $��16(�6�   $��Right=�6�   $	��156��6�   (  "MaterialDesignThemes.Wpf.ColorZone  55   
      Mode$ PrimaryDark=�56      $��16q�57         CornerRadius$ 3��58      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�59      $��48��6>   $��-7,0,0,0q�6J   .��5:      ��  �� Orientation$ 
Horizontal=�5;      .+�5<      �� $��Center=�5=      $��16 0 0 0q�5>      $��试题答案��6'   5?      5@      5B      5C      