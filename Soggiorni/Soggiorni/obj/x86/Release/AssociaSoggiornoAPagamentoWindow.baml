   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  0    *Soggiorni.AssociaSoggiornoAPagamentoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$*  $Associa un Soggiorno senza check-out��$	��414��$	��421��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	       &	          .��� .+�&   System.Windows.Controls.DataGrid  -   $��dataGridSoggiorni��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  ���	#FF717171
   GridLinesVisibility$
 Vertical=�   HeadersVisibility$ Column=�$	��165��$
��Left=�   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��
28,158,0,0q�   SelectionMode$ Single=�$	��Top=�   VerticalGridLinesBrush �	#FFDBDBDB$	��344������    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Cliente�� �� *Cliente.Cognome+  $ Camera�� �� *Camera.Numero+  $ Totale�� �� *TotaleSoggiorno+# [ �� -   $��btnCheckout��$��	Check-Out��$��35��$
��Left=�$��279,340,0,0q�$	��Top=�$��93���� -   $��	txtArrivo��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	29,14,0,0q�$��Data arrivo��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerArrivo��$��14(�$��25��$
��Left=�$��
164,12,0,0q�$	��Top=�$	��208��  -   $��datePickerPartenza��$��14(�$��25��$
��Left=�$��
164,61,0,0q�$	��Top=�$	��208���� -   $��txtPartenza��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	29,63,0,0q�$��Data partenza��$	��Top=��� -   $��btnCerca��$��Cerca��$��14(�$��25��$
��Left=�$��282,100,0,0q�$	��Top=�$��90���� -   $��
separator1��$��5��$
��Left=�$��	0,139,0,0q�$	��Top=�$	��525��