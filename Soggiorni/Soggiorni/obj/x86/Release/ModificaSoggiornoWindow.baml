   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  '    !Soggiorni.ModificaSoggiornoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters     Z VWPFToolkit.Extended, Version=1.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[
extToolkitJhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit/extended    � Title$  Modifica Soggiorno��$	��720��$	��700�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�   sfondoWindow#���    � 	Resources +   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	         .��� .+��� -   $��btnEditCheckin��$��Modifica��$��23��$
��Left=�$��
204,11,0,0q�$	��Top=�$��75���� -   $��btnEditCheckout��$��Modifica��$��23��$
��Left=�$��
480,11,0,0q�$	��Top=�$��70��A� -   $��ellipseCheckin��$��30��$��30��$��146,8,502,0q�$	��Top=�  semaforoRosso#���   J� BitmapEffect F�  F� Color$ Black�� F� 	Direction$	 320Q� F� ShadowDepth$ 2Q� F� Softness$	 0.3Q�	 F� Opacity$		 0.5Q��� -   $��	txtArrivo��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	40,68,0,0q�$��Arrivo��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerArrivo��$��14(�$��25��$
��Left=�$��
145,64,0,0q�$	��Top=�$	��133��{�.  �� -   $��txtPartenza��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	40,98,0,0q�$��Partenza��$	��Top=�  -   $��datePickerPartenza��$��14(�$��25��$
��Left=�$��
145,96,0,0q�$	��Top=�$	��133��{�.  �� -   $��cbxUsoCamera��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�$��
417,98,0,0q�$	��Top=�$	��133��$��1��.@��� $��Singola���� $��Doppia���� $��Tripla���� $��Doppia Suite���� $��Tripla Suite���� $��Quadrupla Suite���� -	   $��txtboxNoteSoggiorno��$��23��$
��Left=�$��145,126,0,0q�$	��Top=�$	��134��$��2���� -
   $��txtboxNoteCamera��$��23��$
��Left=�$��417,126,0,0q�$	��Top=�$	��133��$��3���� -   $��checkBoxConferma��$��16��$
��Left=�$��146,160,0,0q�$	��Top=�$��12(�$��4���� -   $��txtboxPrezzoANotte��$��23��$
��Left=�$��417,156,0,0q�$	��Top=�$	��133��$��5���� -   $��
txtCliente��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
41,186,0,0q�$��Cliente��$	��Top=��� -   $��txtboxCliente�����	#FFEAEAEA$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. 
 �� 
IsReadOnly
 . $��146,186,0,0q�$	��Top=�$	��133����.  �� -   $��btnArchivioClienti��$��archivio...��$��23��$
��Left=�$��204,214,0,0q�$	��Top=�$��75��$��6���� -   $��	txtCamera��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
322,68,0,0q�$��Camera��$	��Top=��� -   $��txtUso��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
322,98,0,0q�$	��Uso��$	��Top=��� -   $��txtNoteCamera��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��321,128,0,0q�$��Note Camera��$	��Top=��� -   $��txtNoteSoggiorno��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
40,128,0,0q�$��Note Soggiorno��$	��Top=��� -   $��btnEditPeriodo��$��61��$��Right=�$��	0,68,34,0q�$	��Top=�$��62��$��16������ .+��� -   $��imgAddSoggiorno��$��35��$��Center=�$
��Fill=�$	��Top=�$��40��$*��$/Soggiorni;component/Images/edit.png���� $��12��$��Center=�$��Modifica��$	��Top=�$��10(�$
��Bold"����	#FF55241A�� -   $��txtConferma��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
40,156,0,0q�$��Confermato?��$	��Top=��� -   $��groupBoxServizi�����	#FFFFFFC1���	#7D8D4600$��2q�$��Berlin Sans FB)�$��26(�$
��Bold"����	#FF8D4600$	��220��$
��Left=�$��
40,254,0,0q�$	��Top=�$	��510������ ���	#FF8D4600$��Servizi��.��� .+�&   System.Windows.Controls.DataGrid  -   $��dataGridServizi��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .  $��Segoe UI)�$��14(�$��Normal"����	#FF717171   GridLinesVisibility$ Vertical=�   HeadersVisibility$ Column=�$	��152��$
��Left=�   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��6,27,0,0q�   SelectionMode$ Single=�$	��Top=�   VerticalGridLinesBrush �	#FFD8D8D8$	��486��$��10������    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5,2,5,2q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Tipo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Nome+  $ Totale�� �� *Totale+  �� 	Converter#  [   $ Descrizione�� �� *Note+�� -   $��btnAddServizio��$��20��$
��Left=�$��	436,0,0,0q�$	��Top=�$��25��$��8������ $)��#/Soggiorni;component/Images/add.png���� -   $��btnDeleteServizio��$��20��$
��Left=�$��	467,0,0,0q�$	��Top=�$��25��$��9��.���� $,��&/Soggiorni;component/Images/delete.png���� -   $��txtNotti��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��322,186,0,0q�$��	N° Notti��$	��Top=��� -   $��txtNumNotti��$��Segoe UI)�$��16(�$
��Bold"�
���   �$��23��$
��Left=�$��417,186,0,0q�$��3��$	��Top=��� -   $��txtPrezzoANotte��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��321,156,0,0q�$��Prezzo a notte��$	��Top=��� -   $��txtTotPernotto��$��Segoe UI)�$��14(�$
��Bold"�
���   �$��23��$
��Left=�$��447,216,0,0q�$��Totale pernotto��$	��Top=�! �� TextAlignment$! Right=��� -   $��txtImpTotPernotto��$��Segoe UI)�$��14(�$
��Bold"�
���   �$��23��$��Right=�$��
0,216,34,0q�$��€ 120��$! Right=�$	��Top=�$��88���� -    $��txtTotServizi��$��Segoe UI)�$��14(�$
��Bold"�
���   �$��23��$
��Left=�$��463,480,0,0q�$��Totale servizi��$! Right=�$	��Top=��� -!   $��txtImpTotServizi��$��Segoe UI)�$��14(�$
��Bold"�
���   �$��23��$��Right=�$��
0,480,34,0q�$��€ 120��$! Right=�$	��Top=�$��88���� -"   $��txtTotSoggiorno��$��Segoe UI)�$��18(�$
��Bold"�
���   �$��23��$
��Left=�$��406,518,0,0q�$��Totale soggiorno��$! Right=�$	��Top=��� -#   $��txtImpTotSoggiorno��$��Segoe UI)�$��18(�$
��Bold"�
���   �$��23��$��
0,518,34,0q�$��€ 1000��$! Right=�$	��Top=�$��Right=�$��88���� -$   $��txtboxCaparra��$��23��$��Right=�$��
0,552,34,0q�$	��Top=�$��51��$��11��" �� TextAlignment$" Right=��� -%   $��
txtCaparra��$��Segoe UI)�$��14(�$
��Bold"�
���   �$��23��$
��Left=�$��501,553,0,0q�$��Caparra��$	��Top=��� -&   $��txtboxNoteCaparra��$��23��$
��Left=�$��145,551,0,0q�$	��Top=�$	��133��$��12��,  &Microsoft.Windows.Controls.ColorPicker  -'   $��colorPickerSogg��$��145,518,0,0q�$��23��#   SelectedColor$# 	LawnGreen��$��0q�$   DisplayColorAndName$ . %   ShowAdvancedButton% .  $
��Left=�$	��133��$	��Top=��� -(   $��txtGruppoSogg��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
41,518,0,0q�$��Colore gruppo��$	��Top=��� -)   $��txtNoteCaparra��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
41,552,0,0q�$��Note caparra��$	��Top=��� -*   $��txtTotDaPagare��$��Segoe UI)�$��16(�$
��Bold"�
���   �$��23��$
��Left=�$��423,582,0,0q�$��Totale da pagare��$! Right=�$	��Top=��� -+   $��txtImpTotDaPagare��$��Segoe UI)�$��16(�$
��Bold"�
���   �$��23��$��Right=�$��
0,582,34,0q�$��€ 800��$! Right=�$	��Top=�$��88���� -,   $��txtboxNotePagamento��$��23��$
��Left=�$��145,583,0,0q�$	��Top=�$	��133��$��13���� --   $��txtNotePagamento��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
40,584,0,0q�$��Note pagam.��$	��Top=��� -.   $��
btnAnnulla��$��16(�$��34��$
��Left=�$��456,628,0,0q�$	��Top=�$	��100��$��15��.���� & �� Orientation$& 
Horizontal=�.+��� $��26��$3��-/Soggiorni;component/Images/button_cancel.png��$��24���� $��Center=�$��15,0,0,0q�$��14(�	Annulla�� -/   $��btnSalva��$��16(�$��34��$
��Left=�$��321,628,0,0q�$	��Top=�$	��100��$��14��.���� $& 
Horizontal=�.+��� $��26��$/��)/Soggiorni;component/Images/button_ok.png��$��24���� $��Center=�$��15,0,0,0q�$��14(�Salva�� -0   $��txtboxCamera��$��23��$
��Left=�$��
417,68,0,0q�{�.  $	��Top=�$	��134���� -1   $��
separator1��
���   �$��5��$
��Left=�$��	0,612,0,0q�$	��Top=�$��700                    ���� -2   $��
btnElimina��$��16(�$��34��$
��Left=�$��
41,628,0,0q�$	��Top=�$	��100��
�������$��17������ ' �� EndPoint$' 0.5,1&�( �� 
StartPoint$( 0.5,0&�.��� ) � Color$) 	#FFFFB1B1��* � Offset$* 0Q�� $	) Red��$	* 0.5Q�� $) 	#FFB70000��$* 1Q�.���� $& 
Horizontal=�.+��� 
���   �$
��Bold"�	Elimina�� -3   $��separatorTop��
���   �$��5��$
��Left=�$��0,44,0,0q�$	��Top=�$��700                    ���� -4   $��
txtCheckin��$��Segoe UI)�$��16(�$
��Bold"�
���   �$��23��$
��Left=�$��	41,12,0,0q�$��Check-In��$	��Top=�A� -5   $��ellipseCheckout��#���  $��30��$��426,8,222,0q�$	��Top=�$��30�� F� $ Black��$	 320Q�$		 0.5Q�$ 2Q�$	 0.3Q��� -6   $��txtCheckout��$��Segoe UI)�$��16(�$
��Bold"�
���   �$��23��$
��Left=�$��
321,12,0,0q�$��	Check-Out��$	��Top=�