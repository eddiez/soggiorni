   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	   0    *Soggiorni.AssociaSoggiornoAPagamentoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	     � Title$*  $Associa un Soggiorno senza check-out��5   	   $	��414��66   $	��421��6C      sfondoWindow#���   6O    � 
ResizeMode$ NoResize=�6{    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%:   &	       &	        5   
   6     5   
   6!   5	      .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridSoggiorni��5   �     AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  ���	#FF717171
   GridLinesVisibility$
 Vertical=�6�      HeadersVisibility$ Column=�6�   $	��165��6  $
��Left=�6"     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6O  $��
28,158,0,0q�6�     SelectionMode$ Single=�6�  $	��Top=�6�     VerticalGridLinesBrush �	#FFDBDBDB$	��344��6  ��6u  ��    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   � #��z��6'   $��5q�6Y   .+�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��6�     5      $ Cliente��6I    6%   �� *Cliente.Cognome+6I     5      $ Camera��6G    6%   �� *Camera.Numero+6G     5      $ Totale��6%    65   �� *TotaleSoggiorno+# [ 5      �� 5    
   -   5        $��btnCheckout��5    a   $��	Check-Out��6   $��35��6%   $
��Left=�61   $��279,340,0,0q�6L   $	��Top=�6t   $��93��6�   6�   �� 5!   
   -   5        $��	txtArrivo��5!   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	29,14,0,0q�6�   $��Data arrivo��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5"   
   -   5        $��datePickerArrivo��5"   ^   $��14(�6   $��25��6#   $
��Left=�6/   $��
164,12,0,0q�6J   $	��Top=�6v   $	��208��6�     5#   
   -   5        $��datePickerPartenza��5#   ^   $��14(�6   $��25��6#   $
��Left=�6/   $��
164,61,0,0q�6J   $	��Top=�6x   $	��208��6�   �� 5$   
   -   5        $��txtPartenza��5$   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	29,63,0,0q�6�   $��Data partenza��6�   $	��Top=�6�   �� 5%   
   -   5        $��btnCerca��5%   k   $��Cerca��6   $��14(�6!   $��25��6/   $
��Left=�6;   $��282,100,0,0q�6V   $	��Top=�6{   $��90��6�   6�   �� 5&   
   -   5        $��
separator1��5&   M   $��5��6   $
��Left=�6   $��	0,139,0,0q�6:   $	��Top=�6_   $	��525��6w   5'      5(      