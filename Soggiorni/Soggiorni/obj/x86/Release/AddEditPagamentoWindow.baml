   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  &     Soggiorni.AddEditPagamentoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$  Aggiungi nuovo pagamento��$	��725��$	��648��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	       &	          .��� .+��� -   $��stackPanelTipo��$��48��$
��Left=� �� Orientation$ 
Horizontal=�$	��Top=�$	��704�����	#FF8D4600.+�	� -   $��radioButtonFatt��$��Fattura��$
��Bold"� 	� 	GroupName$ tipoPagamento��$��25�� d� 	IsChecked$
 TrueY�$��	100,0,0,0q�$��16(����	#FFFFFFC1	� -   $��radioButtonRicFisc��$��Ricevuta Fiscale��$
��Bold"�$ tipoPagamento��$��25��$��	215,0,0,0q�$��16(����	#FFFFFFC1�� -   $��	txtboxNum��$��16(�$��30��$
��Left=�$��
110,74,0,0q�$	��Top=�$��52���� -   $��txtNum��$��16(�$��Normal"�$��30��$
��Left=�$��	12,77,0,0q�$��Numero��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerData��$��16(�$��30��$
��Left=�$��110,110,0,0q�$	��Top=�$	��127���� -   $��txtData��$��16(�$��Normal"�$��30��$
��Left=�$��
12,110,0,0q�$
��Data��$	��Top=��� -   $��txtLastRicFisc��$��13(�$��23��$
��Left=�$��306,117,0,0q�$��b��$	��Top=����	#BC8D4600�� -	   $��txtLastFattura��$��13(�$��23��$��a�����	#BC8D4600$��
306,81,0,0q�$
��Left=�$	��Top=��� -
   $��groupBoxPagante�����	#FFFFFFC1���	#7D8D4600$��2q�$��Berlin Sans FB)�$��26(�$
��Bold"����	#FF8D4600$��12,160,16,0q�$	��191��$	��Top=����� ���	#FF8D4600$��Dati Pagante��.��� .+��� -   $��
txtboxDest��$��14(�$��26��$
��Left=�$��	158,6,0,0q�$	��Top=�$	��356��$��Segoe UI)�$��Normal"����	#FF5F5F5F�� -   $��txtDest��$��14(�$��23��$
��Left=�$��14,9,0,0q�$��Destinatario��$	��Top=�$��Segoe UI)�$��Normal"��� -   $��
txtboxSede��$��14(�$��26��$
��Left=�$��
158,43,0,0q�$	��Top=�$	��356��$��Segoe UI)�$��Normal"����	#FF5F5F5F�� -   $��txtSede��$��14(�$��23��$
��Left=�$��	14,46,0,0q�$��Indirizzo sede/resid.��$	��Top=�$��Segoe UI)�$��Normal"��� -   $��
txtboxPiva��$��14(�$��26��$
��Left=�$��
158,81,0,0q�$	��Top=�$	��356��$��Segoe UI)�$��Normal"����	#FF5F5F5F�� -   $��txtPiva��$��14(�$��23��$
��Left=�$��	14,84,0,0q�$��Partita IVA��$	��Top=�$��Segoe UI)�$��Normal"��� -   $��txtboxCf��$��14(�$��26��$
��Left=�$��158,120,0,0q�$	��Top=�$	��356��$��Segoe UI)�$��Normal"����	#FF5F5F5F�� -   $��	btnCFCalc��$��26��$
��Left=�$��522,120,0,0q�$	��Top=�$��34��.���� $0��*/Soggiorni;component/Images/calculator.png���� -   $��txtCf��$��14(�$��23��$
��Left=�$��
14,123,0,0q�$��Codice Fiscale��$	��Top=�$��Segoe UI)�$��Normal"��� -   $��
txtboxNote��$��14(�$��26��$
��Left=�$��
12,587,0,0q�$	��Top=�$	��273���� -   $��txtNote��$��14(�$��23��$
��Left=�$��
12,558,0,0q�$��Note pagamento��$	��Top=��� -   $��groupBoxSoggiorni�����	#FFCEFFD1���	#7D006F08$��2q�$��Berlin Sans FB)�$��18(�$
��Bold"����	#FF8D4600$	��175��$
��Left=�$��
12,360,0,0q�$	��Top=�$	��300������ ���	#FF006F08$��	Soggiorni��.��� .+�&   System.Windows.Controls.DataGrid  -   $��dataGridSoggiorni��   AlternatingRowBackground �	#EFCEFFD1   AutoGenerateColumns .  	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .     CanUserResizeRows .     CanUserSortColumns .  ���	#FF717171   GridLinesVisibility$ Vertical=�   HeadersVisibility$ Column=�$	��112��   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�   SelectionMode$ Single=�   VerticalGridLinesBrush �	#FFDBDBDB$	��280��$��12(�$��Segoe UI)�$��Normal"�$	��Top=�$��0,10,0,0q�����    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Cliente�� �� *Cliente.Cognome+  $ Camera�� �� *Camera.Numero+  $ Totale�� �� *TotaleSoggiorno+# [ �� -   $��btnAssociaSoggiorno��$��20��$
��Left=�$��8��$	��Top=�$��25��$��224,124,0,0q�.���� $)��#/Soggiorni;component/Images/add.png���� -   $��btnDissociaSoggiorno��$��20��$
��Left=�$��9��$	��Top=�$��25��$��258,124,0,0q�.���� $,��&/Soggiorni;component/Images/delete.png���� -   $��groupBoxAltreAtt�����	#FFD4E6FF���	#7D0075FF$��2q�$��Berlin Sans FB)�$��18(�$
��Bold"����	#FF0075FF$	��174��$��Right=�$��
0,361,14,0q�$	��Top=�$	��300������ ���	#FF0037FF$��Altre Attività��.��� .+�  -   $��dataGridAtt�� �	#EFD4E6FF .  	 .  
 .   .   .  ���	#FF717171$ Vertical=�$ Column=�$	��110�� . $ FalseY�$ Single=� �	#FFDBDBDB$	��280��$��Normal"�$��12(�$��Segoe UI)�$	��Top=�$��0,10,0,0q�����  �� "  .���  � �� �� "  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   $
 Data�� �� *Data+# [ $ 
dd/MM/yyyy��  $ 	Attività�� �� *VoceInStampata+  $ Totale�� �� *Totale+# [ �� -   $��	btnAddAtt��$��20��$
��Left=�$��8��$	��Top=�$��25��$��224,124,0,0q�.���� $)��#/Soggiorni;component/Images/add.png���� -   $��btnDeleteAtt��$��20��$
��Left=�$��9��$	��Top=�$��25��$��258,124,0,0q�.���� $,��&/Soggiorni;component/Images/delete.png���� -   $��txtImponibile��$��16(�$��23��$
��Left=�$��357,543,0,0q�$��
Imponibile��$	��Top=�$
��Bold"��� -   $��txtImpImponibile��$��16(�$
��Bold"�$��23��$��Right=�$��
0,543,20,0q�$��€ 900��$	��Top=��� -    $��	txtTotale��$��20(�$
��Bold"�$��23��$
��Left=�$��357,587,0,0q�$��Totale��$	��Top=��� -!   $��txtImportoTotale��$��20(�$
��Bold"�$��23��$��Right=�$��
0,587,20,0q�$��€ 1000��$	��Top=��� -"   $��
separator1��$��5��$
��Left=�$��	0,626,0,0q�$	��Top=�$	��650��$��2q�
���   ��� -#   $��btnSalva��$��16(�$��34��$
��Left=�$��506,652,0,0q�$��14��$	��Top=�$	��100��.���� $ 
Horizontal=�.+��� $��26��$/��)/Soggiorni;component/Images/button_ok.png��$��24���� $��14(�$��15,0,0,0q�$��Center=�Salva�� -$   $��
btnElimina��$��16(�
�������$��34��$
��Left=�$��
12,652,0,0q�$��17��$	��Top=�$	��100������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFFFB1B1��  � Offset$  0Q�� $	 Red��$	  0.5Q�� $ 	#FFB70000��$  1Q�.���� $ 
Horizontal=�.+��� $
��Bold"�
���   �	Elimina�� -%   $��btnPrint��$��16(�$��34��$
��Left=�$��262,652,0,0q�$��14��$	��Top=�$	��100��.���� $ 
Horizontal=�.+��� $��26��$-��'/Soggiorni;component/Images/printer.png��$��24���� $��14(�$��15,0,0,0q�$��Center=�Stampa�� -&   $��txtIva��$��12(�$
��Bold"�$��23��$
��Left=�$��357,571,0,0q�$��	IVA (10%)��$	��Top=��� -'   $��	txtImpIva��$��12(�$
��Bold"�$��23��$��Right=�$��
0,571,20,0q�$��€ 100��$	��Top=�