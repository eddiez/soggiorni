   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  0    *Soggiorni.SelezionaMeseCorrispettiviWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$"  Seleziona Mese Corrispettivi��$	��629��$	��400��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter/   )Soggiorni.Converters.BoolFatturaConverter  boolFattConverter��%-   &	       &	      &	 
           .��� .+��� -   $��txtHeaderText��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	52,12,0,0q�$"��Corrispettivi per il mese di��$	��Top=��� -   $��cbxMese��$��23��$
��Left=�$��	52,53,0,0q�$	��Top=�$	��169������ *Keys+�� -   $��
txtboxAnno��$��23��$
��Left=�$��
227,53,0,0q�$	��Top=�$��89���� -   $��
separator1��$��5��$
��Left=�$��	0,127,0,0q�$	��Top=�$	��419��$��2q�
���   ��� -   $��txtPagamenti��$��Segoe UI)�$��12(�$
��Bold"�
���   �$��23��$
��Left=�$��
12,145,0,0q�$&�� Pagamenti con stesso progressivo��$	��Top=�&   System.Windows.Controls.DataGrid  -   $��dataGridPagamentiDup��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  ���	#FF688CAF   CanUserReorderColumns .     CanUserSortColumns .  $��13(����	#FF717171   GridLinesVisibility$ Vertical=�	   HeadersVisibility$	 Column=�$	��127��$
��Left=�$��Center=�
   HorizontalGridLinesBrush

 �   �   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��
12,162,0,0q�   SelectionMode$ Single=�$	��Top=�$��Center=�   VerticalGridLinesBrush �	#FFD8D8D8$	��354������    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Data+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Numero�� �� *Numero+  $ Importo�� �� *Totale+# [   $
 Tipo�� �� *	IsFattura+# [ �� -   $��	btnGenera��$��Verifica errori��$��23��$
��Left=�$��
227,91,0,0q�$	��Top=�$��89���� -   $��txtGridNullo��$��Segoe UI)�$��12(�$
��Bold"�
���   �$��23��$
��Left=�$��
12,296,0,0q�$ ��Pagamenti ad importo nullo��$	��Top=�  -	   $��dataGridPagamentiNulli�� �	#FFFFE7B1 .  ���	#FF688CAF .   .  $��13(����	#FF717171$ Vertical=�$	 Column=�$	��127��$
��Left=�$��Center=�

 �   � . $ FalseY�$��
12,313,0,0q�$ Single=�$	��Top=�$��Center=� �	#FFD8D8D8$	��354������  �� "  .���  � �� �� "  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   $
 Data�� �� *Data+# [ $ 
dd/MM/yyyy��  $ Numero�� �� *Numero+  $ Importo�� �� *Totale+# [   $
 Tipo�� �� *	IsFattura+# [ �� -
   $��btnPrint��$��Stampa��$��23��$
��Left=�$��292,567,0,0q�$	��Top=�$��74��� -   $��grid1��$��67��$
��Left=�$��
13,475,0,0q�$	��Top=�$	��353�� � ColumnDefinitions �� $
��106* ��� $	��60* ��� $	��58* ��� $
��129* � � RowDefinitions �� $��23 ��� $��23 ��� $��23 �.+��� -   $��txtTipoHead��$��21��$
��Left=�$
��Tipo��$��Bottom=�$	��106�� �� TextAlignment$ Center=�$��Normal"�$��Italic$��� -   $��txtPrimoHead��$��23��$
��Left=�$��0,-2,0,0q�$��Primo��$	��Top=�$��1��$��60��$ Center=�$��Italic$��� -   $��
txtUltHead��$��Italic$�$��23��$
��Left=�$��Ultimo��$ Center=�$	��Top=�$��58��$��2��$��0,-2,0,0q��� -   $��txtMancHead��$��Italic$�$��23��$
��Left=�$��0,-2,0,0q�$��Progr. Mancanti��$ Center=�$	��Top=�$	��129��$��3���� -   $��txtTipoFatt��$��1��$��23��$
��Left=�$��1,0,0,0q�$��Fattura��$��Center=�$	��105��$ Center=��� -   $��
txtTipoRic��$��23��$
��Left=�$��-1,0,0,0q�$��Ricevuta Fiscale��$ Center=�$��Center=�$	��107��$��2���� -   $��txtFirstFatt��$��23��$
��Left=�$��0��$ Center=�$��Center=�$��60��$��1��$��1���� -   $��txtFirstRic��$��23��$
��Left=�$��0��$ Center=�$��Center=�$��60��$��1��$��2���� -   $��txtLastFatt��$��23��$
��Left=�$��0��$ Center=�$��Center=�$��58��$��2��$��1���� -   $��
txtLastRic��$��23��$
��Left=�$��0��$ Center=�$��Center=�$��58��$��2��$��2���� -   $��txtFattManc��$��23��$
��Left=�$��0��$ Center=�$��Center=�$	��129��$��3��$��1���� -   $��
txtRicManc��$��23��$
��Left=�$��0��$ Center=�$��Center=�$	��129��$��3��$��2���� -   $��txtProgMancHead��$��Segoe UI)�$��12(�$
��Bold"�
���   �$��23��$
��Left=�$��
13,454,0,0q�$��Progressivi mancanti��$	��Top=��� -   $��
separator2��$��5��$
��Left=�$��
13,494,0,0q�$	��Top=�$	��353���� -   $��
separator3��$��5��$
��Left=�$��	0,556,0,0q�$	��Top=�$	��419��
���   �$��2q�