   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	   (    "Soggiorni.SelectMesePresenzeWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	     � Title$'  !Seleziona mese per presenze ISTAT��5   	      sfondoWindow#���   63   $	��372��6_   $	��400��6l    � 
ResizeMode$ NoResize=�6x    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter��%   &	         5   
   6   5      .��5	      � .+�5
   
   �� -   5        $��txtHeaderText��5
   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	50,12,0,0q�6�   $/��)Genera file presenze ISTAT per il mese di��6�   $	��Top=�6�   �� 5   
   -   5        $��cbxMese��5   j   $��23��60   $
��Left=�6<   $��	52,53,0,0q�6W   $	��Top=�6y   $	��169��6�   ��6   �� *Keys+6�   �� 5   
   -   5        $��
txtboxAnno��5   M   $��23��6   $
��Left=�6   $��
227,53,0,0q�69   $	��Top=�6_   $��74��6w   �� 5   
   -   5        $��
separator1��5   M   $��5��6   $
��Left=�6   $��	0,154,0,0q�6:   $	��Top=�6_   $	��419��6w   �� 5   
   -   5        $��txtSoggiorni��5   �   $��Segoe UI)�6   $��12(�6*   $
��Bold"�68   
���   �$��23��6]   $
��Left=�6i   $��
12,169,0,0q�6�   $2��,Soggiorni senza schede di notifica associate��6�   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridSoggiorni��5   �     AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  ���	#FF688CAF   CanUserReorderColumns .     CanUserSortColumns .  $��13(�6�   ���	#FF717171   GridLinesVisibility$ Vertical=�6�   	   HeadersVisibility$	 Column=�6�   $	��127��6  $
��Left=�6  $��Center=�6,  
   HorizontalGridLinesBrush

 �   �   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6�  $��
12,189,0,0q�6�     SelectionMode$ Single=�6�  $	��Top=�6  $��Center=�6     VerticalGridLinesBrush �	#FFD8D8D8$	��354��6b  ��6�  ��    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   � #��z��6'   $��5q�6Y   .+�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��6�     5      $ Partenza��6�    6%   �� *
Partenza+# [ $ 
dd/MM/yyyy��6�     5       $ Cliente��6I    6%   �� *Cliente.Cognome+6I     5!      $ Camera��6G    6%   �� *Camera.Numero+6G   4  .System.Windows.Controls.DataGridCheckBoxColumn  5"      $ 
Check-In ?��6I    6)   �� *IsCheckedIn+6I   5$      �� 5%   
   -   5        $��	btnGenera��5%   a   $��	Crea file��6   $��23��6%   $
��Left=�61   $��227,112,0,0q�6L   $	��Top=�6r   $��75��6�   6�   5&      5'      