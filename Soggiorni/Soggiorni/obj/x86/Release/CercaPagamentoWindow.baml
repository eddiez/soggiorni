   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  $    Soggiorni.CercaPagamentoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$  Cerca un Pagamento��$	��447��$	��330��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	       &	          .��� .+��� -   $��stackPanelTipo��$��48��$
��Left=� �� Orientation$ 
Horizontal=�$	��Top=�$	��346�����	#FF8D4600.+�	� -   $��radioButtonFatt��$��Fattura��$
��Bold"� 	� 	GroupName$ tipoPagamento��$��16�� d� 	IsChecked$
 TrueY�$��35,0,0,0q����	#FFFFFFC1	� -   $��radioButtonRicFisc��$��Ricevuta Fiscale��$
��Bold"�$ tipoPagamento��$��16��$��85,0,0,0q����	#FFFFFFC1�� -   $��txtData��$��16(�$��Normal"�$��30��$
��Left=�$��	12,63,0,0q�$��Data emissione��$	��Top=��� -   $��txtDa��$��23��$
��Left=�$��
12,101,0,0q�$��da��$	��Top=�$��14(�(  "System.Windows.Controls.DatePicker  -   $��datePickerDa��$��25��$
��Left=�$��	33,99,0,0q�$	��Top=�$	��115���� -   $
��txtA��$��14(�$��23��$
��Left=�$��160,101,0,0q�$��a��$	��Top=�  -   $��datePickerA��$��25��$
��Left=�$��
181,99,0,0q�$	��Top=�$	��115���� -	   $��	btnSearch��$��Cerca��$��23��$
��Left=�$��221,138,0,0q�$	��Top=�$��75���� -
   $��
separator1��
���   �$��2q�$��5��$
��Left=�$��	0,176,0,0q�$	��Top=�$	��379��&   System.Windows.Controls.DataGrid  -   $��dataGridPagamenti��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .     CanUserResizeRows .     CanUserSortColumns .  $��13(����	#FF717171   FrozenColumnCount$ 1��   GridLinesVisibility$ Vertical=�   HeadersVisibility$ Column=�$	��178��$
��Left=�   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��
12,218,0,0q�   SelectionMode$ Single=�$	��Top=�   VerticalGridLinesBrush �	#FFD8D8D8$	��284������    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Data+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Numero�� �� *Numero+  $ Destinatario�� �� *Destinatario+  $ Totale�� �� *Totale+# [ �� -   $��txtSearchRes��$��16(�$��Normal"�$��30��$
��Left=�$��
12,187,0,0q�$��Pagamenti trovati =��$	��Top=��� -   $��txtNumSearchRes��$��16(�$��Normal"�$��30��$
��Left=�$��156,187,0,0q�$�� ��$	��Top=�