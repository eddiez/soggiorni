   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	   *    $Soggiorni.SelezionaUnPagamentoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	     � Title$  Seleziona un Pagamento��5   	   $	��447��6(   $	��330��65      sfondoWindow#���   6A    � 
ResizeMode$ NoResize=�6m    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter��%   &	         5   
   6   5      .��5	      � .+�5
   
   �� -   5        $��stackPanelTipo��5
   <   $��48��6   $
��Left=�6!    �� Orientation$ 
Horizontal=�6R   $	��Top=�6k   $	��367��6�   ���	#FF8D4600.+�5      	� -   5        $��radioButtonFatt��5   �   $��Fattura��6   $
��Bold"�6-    	� 	GroupName$ tipoPagamento��6?   $��16��6Y    d� 	IsChecked$
 TrueY�6e   $��35,0,0,0q�6v   ���	#FFFFFFC16�   	� 5      -   5        $��radioButtonRicFisc��5      $��Ricevuta Fiscale��6   $
��Bold"�65   $ tipoPagamento��6G   $��16��6a   $��85,0,0,0q�6m   ���	#FFFFFFC16�   5      �� 5   
   -   5        $��txtData��5   p   $��16(�6   $��Normal"�6"   $��30��66   $
��Left=�6B   $��	12,63,0,0q�6]   $��Data emissione��6   $	��Top=�6�   �� 5   
   -   5        $��txtDa��5   O   $��23��6   $
��Left=�6    $��
12,101,0,0q�6;   $��da��6\   $	��Top=�6f   $��14(�6~   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerDa��5   O   $��25��6   $
��Left=�6!   $��	33,99,0,0q�6<   $	��Top=�6c   $	��115��6{   �� 5   
   -   5        $
��txtA��5   ^   $��14(�6   $��23��6"   $
��Left=�6.   $��160,101,0,0q�6I   $��a��6j   $	��Top=�6s     5   
   -   5        $��datePickerA��5   P   $��25��6   $
��Left=�6!   $��
181,99,0,0q�6<   $	��Top=�6c   $	��115��6{   �� 5   
   -	   5        $��	btnSearch��5   ]   $��Cerca��6   $��23��6!   $
��Left=�6-   $��221,138,0,0q�6H   $	��Top=�6n   $��75��6�   6�   �� 5   
   -
   5        $��
separator1��5   u   
���   �$��2q�6(   $��5��6<   $
��Left=�6G   $��	0,176,0,0q�6b   $	��Top=�6�   $	��379��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridPagamenti��5   �     AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .     CanUserResizeRows .     CanUserSortColumns .  $��13(�6�   ���	#FF717171   FrozenColumnCount$ 1��6�      GridLinesVisibility$ Vertical=�6�      HeadersVisibility$ Column=�6  $	��142��69  $
��Left=�6F     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6s  $��
12,218,0,0q�6�     SelectionMode$ Single=�6�  $	��Top=�6�     VerticalGridLinesBrush �	#FFD8D8D8$	��284��60  ��6�  ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Data��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Data+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��6�     5      $ Numero��6@    6%   �� *Numero+6@     5      $ Destinatario��6F    6%   �� *Destinatario+6F   5      �� 5   
   -   5        $��txtSearchRes��5   q   $��16(�6   $��Normal"�6"   $��30��66   $
��Left=�6B   $��
12,187,0,0q�6]   $��Pagamenti trovati��6�   $	��Top=�6�   �� 5   
   -   5        $��btnSeleziona��5   a   $��	Seleziona��6   $��23��6%   $
��Left=�61   $��217,373,0,0q�6L   $	��Top=�6u   $��75��6�   6�   5      5      