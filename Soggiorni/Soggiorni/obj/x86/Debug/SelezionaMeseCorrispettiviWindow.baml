   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	   0    *Soggiorni.SelezionaMeseCorrispettiviWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	     � Title$"  Seleziona Mese Corrispettivi��5   	   $	��629��6.   $	��400��6;      sfondoWindow#���   6G    � 
ResizeMode$ NoResize=�6s    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter/   )Soggiorni.Converters.BoolFatturaConverter  boolFattConverter��%W   &	       &	      &	 &       5   
   6     5   
   6!     5	   
   6%   5
      .��5      � .+�5   
   �� -   5        $��txtHeaderText��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	52,12,0,0q�6�   $"��Corrispettivi per il mese di��6�   $	��Top=�6�   �� 5   
   -   5        $��cbxMese��5   j   $��23��60   $
��Left=�6<   $��	52,53,0,0q�6W   $	��Top=�6y   $	��169��6�   ��6   �� *Keys+6�   �� 5   
   -   5        $��
txtboxAnno��5   M   $��23��6   $
��Left=�6   $��
227,53,0,0q�69   $	��Top=�6_   $��89��6w   �� 5   
   -   5        $��
separator1��5   M   $��5��6   $
��Left=�6   $��	0,127,0,0q�6:   $	��Top=�6_   $	��419��6w   $��2q�6�   
���   �6�   �� 5   
   -   5        $��txtPagamenti��5   �   $��Segoe UI)�6   $��12(�6*   $
��Bold"�68   
���   �$��23��6]   $
��Left=�6i   $��
12,145,0,0q�6�   $&�� Pagamenti con stesso progressivo��6�   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridPagamentiDup��5   �     AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  ���	#FF688CAF   CanUserReorderColumns .     CanUserSortColumns .  $��13(�6�   ���	#FF717171   GridLinesVisibility$ Vertical=�6�   	   HeadersVisibility$	 Column=�6�   $	��127��6  $
��Left=�6  $��Center=�6,  
   HorizontalGridLinesBrush

 �   �   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6�  $��
12,162,0,0q�6�     SelectionMode$ Single=�6�  $	��Top=�6  $��Center=�6      VerticalGridLinesBrush �	#FFD8D8D8$	��354��6e  ��6�  ��    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   � #��z��6'   $��5q�6Y   .+�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Data+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��6�     5!      $ Numero��6@    6%   �� *Numero+6@     5"      $ Importo��6%    66   �� *Totale+# [   5#      $
 Tipo��6q    6%   �� *	IsFattura+# [ 6q   5%      �� 5&   
   -   5        $��	btnGenera��5&   f   $��Verifica errori��6   $��23��6+   $
��Left=�67   $��
227,91,0,0q�6R   $	��Top=�6w   $��89��6�   6�   �� 5'   
   -   5        $��txtGridNullo��5'   �   $��Segoe UI)�6   $��12(�6*   $
��Bold"�68   
���   �$��23��6]   $
��Left=�6i   $��
12,296,0,0q�6�   $ ��Pagamenti ad importo nullo��6�   $	��Top=�6�     5(   
   -	   5        $��dataGridPagamentiNulli��5(   �   �	#FFFFE7B1 .  ���	#FF688CAF .   .  $��13(�6�   ���	#FF717171$ Vertical=�6�   $	 Column=�6�   $	��127��6  $
��Left=�6  $��Center=�6,  

 �   � . $ FalseY�6�  $��
12,313,0,0q�6�  $ Single=�6�  $	��Top=�6
  $��Center=�6"   �	#FFD8D8D8$	��354��6g  ��6�  ��  5)      �� 5*      "  6   .�5+      ��  � �� 5,      �� 5-      "  6.   .R�5.   "   � #��z��6'   $��5q�6Y   .+�5/   &   �� $��Center=�67   $��Center=�6T   50   #   51      53      54       56        57      $
 Data��6�    6%   �� *Data+# [ $ 
dd/MM/yyyy��6�     58      $ Numero��6@    6%   �� *Numero+6@     59      $ Importo��6m    6%   �� *Totale+# [ 6m     5:      $
 Tipo��6q    6%   �� *	IsFattura+# [ 6q   5<      �� 5=   
   -
   5        $��btnPrint��5=   ^   $��Stampa��6   $��23��6"   $
��Left=�6.   $��292,567,0,0q�6I   $	��Top=�6n   $��74��6�   6�   � 5>   
   -   5        $��grid1��5>   J   $��67��6   $
��Left=�6   $��
13,475,0,0q�66   $	��Top=�6W   $	��353��6o    � ColumnDefinitions 5?      �� 5@      $
��106* �6#   �� 5A      $	��60* �6#   �� 5B      $	��58* �6#   �� 5C      $
��129* �6#    � RowDefinitions 5E      �� 5F      $��23 �6    �� 5G      $��23 �6    �� 5H      $��23 �6    .+�5J      �� -   5        $��txtTipoHead��5J   ?   $��21��6   $
��Left=�6$   $
��Tipo��6R   $��Bottom=�6^   $	��106��6y    �� TextAlignment$ Center=�6�   $��Normal"�6�   $��Italic$�6�   �� 5K      -   5        $��txtPrimoHead��5K   Q   $��23��6   $
��Left=�6$   $��0,-2,0,0q�6?   $��Primo��6e   $	��Top=�6r   $��1��6�   $��60��6�   $ Center=�6�   $��Italic$�6�   �� 5L      -   5        $��
txtUltHead��5L   R   $��Italic$�6   $��23��6+   $
��Left=�67   $��Ultimo��6d   $ Center=�6r   $	��Top=�6�   $��58��6�   $��2��6�   $��0,-2,0,0q�6�   �� 5M      -   5        $��txtMancHead��5M   d   $��Italic$�6   $��23��6+   $
��Left=�67   $��0,-2,0,0q�6R   $��Progr. Mancanti��6w   $ Center=�6�   $	��Top=�6�   $	��129��6�   $��3��6�   �� 5N      -   5        $��txtTipoFatt��5N   ]   $��1��6   $��23��6%   $
��Left=�61   $��1,0,0,0q�6L   $��Fattura��6p   $��Center=�6   $	��105��6�   $ Center=�6�   �� 5O      -   5        $��
txtTipoRic��5O   Q   $��23��6   $
��Left=�6$   $��-1,0,0,0q�6?   $��Ricevuta Fiscale��6c   $ Center=�6{   $��Center=�6�   $	��107��6�   $��2��6�   �� 5P      -   5        $��txtFirstFatt��5P   ?   $��23��6   $
��Left=�6$   $��0��6S   $ Center=�6\   $��Center=�6s   $��60��6�   $��1��6�   $��1��6�   �� 5Q      -   5        $��txtFirstRic��5Q   ?   $��23��6   $
��Left=�6$   $��0��6R   $ Center=�6[   $��Center=�6r   $��60��6�   $��1��6�   $��2��6�   �� 5R      -   5        $��txtLastFatt��5R   ?   $��23��6   $
��Left=�6$   $��0��6R   $ Center=�6[   $��Center=�6r   $��58��6�   $��2��6�   $��1��6�   �� 5S      -   5        $��
txtLastRic��5S   ?   $��23��6   $
��Left=�6$   $��0��6Q   $ Center=�6Z   $��Center=�6q   $��58��6�   $��2��6�   $��2��6�   �� 5T      -   5        $��txtFattManc��5T   ?   $��23��6   $
��Left=�6$   $��0��6R   $ Center=�6[   $��Center=�6r   $	��129��6�   $��3��6�   $��1��6�   �� 5U      -   5        $��
txtRicManc��5U   ?   $��23��6   $
��Left=�6$   $��0��6Q   $ Center=�6Z   $��Center=�6q   $	��129��6�   $��3��6�   $��2��6�   5V      �� 5W   
   -   5        $��txtProgMancHead��5W   �   $��Segoe UI)�6   $��12(�6*   $
��Bold"�68   
���   �$��23��6]   $
��Left=�6i   $��
13,454,0,0q�6�   $��Progressivi mancanti��6�   $	��Top=�6�   �� 5X   
   -   5        $��
separator2��5X   N   $��5��6   $
��Left=�6   $��
13,494,0,0q�6:   $	��Top=�6`   $	��353��6x   �� 5Y   
   -   5        $��
separator3��5Y   M   $��5��6   $
��Left=�6   $��	0,556,0,0q�6:   $	��Top=�6_   $	��419��6w   
���   �$��2q�6�   5Z      5[      