   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  %    Soggiorni.DettagliClienteWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$  Scheda cliente��$	��700��$	��800��   sfondoWindow#���    � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	       &	          .��� .+��� -   $��
txtCognome��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��	60,21,0,0q�$��Cognome��$	��Top=�
���   ��� -   $��txtboxCognome��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��
160,21,0,0q�$	��Top=�$	��163��$��1���� -   $��txtNome��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��	60,50,0,0q�$
��Nome��$	��Top=�
���   ��� -   $��
txtboxNome��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��
160,50,0,0q�$	��Top=�$	��163��$��2���� -   $��txtTel��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��
60,137,0,0q�$��Telefoni��$	��Top=�
���   ��� -   $��	txtboxTel��$��Segoe UI)�$��12(�$��Normal"�$��52��$
��Left=�{�. $��160,136,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��163��$��5���� -   $��txtAddr��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��
434,79,0,0q�$��	Indirizzo��$	��Top=��� -   $��
txtboxAddr��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��
534,77,0,0q�$	��Top=�$	��163��$��12���� -	   $��txtMail��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��
60,198,0,0q�$��Email��$	��Top=��� -
   $��
txtboxMail��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��160,198,0,0q�$	��Top=�$	��163��$��6���� -   $��txtNoteCliente��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��
434,23,0,0q�$
��Note��$	��Top=��� -   $��txtboxNoteCliente��
�������$��Segoe UI)�$��12(�$��Normal"�$��52��$
��Left=�{�. $��
534,20,0,0q�$	��Top=�$	��163��$
 Wrap=�$��11���� -   $��groupBoxSoggiorni��$	��262��$
��Left=�$��
60,356,0,0q�$	��Top=�$	��637��$��Berlin Sans FB)�$��26(�$
��Bold"����	#FFFFFFC1���	#FF8D4600$��2q����	#7D8D4600���� $��	Soggiorni�����	#FF8D4600.��� .+�&   System.Windows.Controls.DataGrid  -   $��dataGridSoggiorni��   AlternatingRowBackground �	#FFFFE7B1���	#FF717171   VerticalGridLinesBrush �	#FFD8D8D8   AutoGenerateColumns .  $	��185��$
��Left=�$��6,6,0,0q�$	��Top=�$	��604��$ �� IsSynchronizedWithCurrentItem$ FalseY�	   
IsReadOnly	 . 
   CanUserResizeColumns
 .     CanUserResizeRows .     CanUserReorderColumns .     CanUserSortColumns .     HeadersVisibility$ Column=�   GridLinesVisibility$ Vertical=�$��Segoe UI)�$��14(�$��Normal"�   SelectionMode$ Single=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Partenza+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Notti�� �� *Notti+  $ Prezzo a notte�� �� *PrezzoANotte+# [   $ Camera�� �� *Camera.Numero+  $	 Uso�� �� *	UsoCamera+  $ Totale�� �� *TotaleSoggiorno+# [    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� $��5q�#��z��.+��� $��Center=�$��Center=��� -   $��txtSpesaComplessiva��$��23��$
��Left=�$��	6,197,0,0q�$��Spesa complessiva =��$	��Top=�$��16(�$��Normal"�$��Segoe UI)��� -   $ ��txtImportoSpesaComplessiva��$��Segoe UI)�$��16(�$��Normal"�$��23��$
��Left=�$��158,197,0,0q�$
��0€��$	��Top=��� -   $��txtNumSoggiorni��$��Segoe UI)�$��16(�$��Normal"�$��23��$
��Left=�$��368,197,0,0q�$��N° soggiorni =��$	��Top=��� -   $��txtNumSoggiorniValue��$��Segoe UI)�$��16(�$��Normal"�$��23��$
��Left=�$��478,197,0,0q�$��0��$	��Top=��� -   $��
btnAnnulla��$��Annulla��$��35��$
��Left=�$��577,624,0,0q�$	��Top=�$	��120��$��14(�$��22���� -   $��btnSalva��$��Salva��$��35��$
��Left=�$��443,624,0,0q�$	��Top=�$	��120��$��14(�$��21���� -   $��
btnElimina��$��16(�
�������$��35��$
��Left=�$��
60,624,0,0q�$��23��$	��Top=�$	��100������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFFFB1B1�� � Offset$ 0Q�� $	 Red��$	 0.5Q�� $ 	#FFB70000��$ 1Q�.����  �� Orientation$ 
Horizontal=�.+��� $
��Bold"�
���   �	Elimina�� -   $��stackPanelSesso��$��52��$
��Left=�$��
160,77,0,0q�$	��Top=�$	��163��$ Vertical=�.+�	� -   $��radioButtonM��  	� 	GroupName$  Sesso��$��M��$��0,5,0,0q�$��16��! d� 	IsChecked$
! TrueY�$��3��	� -   $��radioButtonF��$  Sesso��$��F��$��0,10,0,0q�$��16��$��4���� -   $��txtSesso��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	60,78,0,0q�$��Sesso                    ��$	��Top=�$��38���� -   $��txtDataNascita��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
60,229,0,0q�$��Data nascita��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerNascita��$��25��$
��Left=�$��160,226,0,0q�$	��Top=�$	��163��$��7���� -   $��txtComuneNascita��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
60,258,0,0q�$��Comune nasc.��$	��Top=��� -   $��txtboxComuneNascita��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��160,257,0,0q�$	��Top=�$	��163��" �� 
IsReadOnly" . 
���������.  �� -   $��txtStatoNascita��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
60,287,0,0q�$��Stato nascita��$	��Top=��� -   $��txtboxStatoNascita��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��160,286,0,0q�$	��Top=�$	��163��
���������.  �� -    $��btnSelectComuneNascita��$	��...��$��23��$
��Left=�$��329,257,0,0q�$	��Top=�$��28��$��8���� -!   $��btnSelectStatoNascita��$	��...��$��23��$
��Left=�$��329,286,0,0q�$	��Top=�$��28��$��9���� -"   $��txtCittadinanza��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
60,316,0,0q�$��Cittadinanza��$	��Top=��� -#   $��txtboxCittadinanza��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��160,315,0,0q�$	��Top=�$	��163����.  �� -$   $��btnSelectCittadinanza��$	��...��$��23��$
��Left=�$��329,315,0,0q�$	��Top=�$��28��$��10���� -%   $��txtComuneResid��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��434,110,0,0q�$��Comune resid.��$	��Top=��� -&   $��txtboxComuneResid��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. " . $��534,107,0,0q�$	��Top=�$	��163����.  �� -'   $��txtStatoResid��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��434,142,0,0q�$��Stato residenza��$	��Top=��� -(   $��txtboxStatoResid��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��534,140,0,0q�$	��Top=�$	��163����.  �� -)   $��btnSelectComuneResid��$	��...��$��23��$
��Left=�$��703,108,0,0q�$	��Top=�$��28��$��13���� -*   $��btnSelectStatoResid��$	��...��$��23��$
��Left=�$��703,141,0,0q�$	��Top=�$��28��$��14���� -+   $��
txtTipoDoc��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��434,199,0,0q�$��Tipo docum.��$	��Top=��� -,   $��
cbxTipoDoc��# �� DisplayMemberPath$# Descrizione��$ �� SelectedValuePath$$ Id��$��23��$
��Left=�$��534,198,0,0q�$	��Top=�$	��197��$��16������ �� --   $��	txtNumDoc��$��Segoe UI)�$��14(�$��Normal"�$��23��$
��Left=�$��434,228,0,0q�$��N° documento��$	��Top=��� -.   $��txtboxNumDoc��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��534,227,0,0q�$	��Top=�$	��163��$��17���� -/   $��txtDataRilascioDoc��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��432,257,0,0q�$��Data rilascio��$	��Top=�  -0   $��datePickerRilascioDoc��$��25��$
��Left=�$��534,256,0,0q�$	��Top=�$	��163��$��18���� -1   $��txtComuneRilascioDoc��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��432,288,0,0q�$��Comune rilascio��$	��Top=��� -2   $��txtboxComuneRilascioDoc��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. " . $��534,287,0,0q�$	��Top=�$	��163����.  �� -3   $��txtStatoRilascioDoc��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��432,317,0,0q�$��Stato rilascio��$	��Top=��� -4   $��txtboxStatoRilascioDoc��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��534,316,0,0q�$	��Top=�$	��163����.  �� -5   $ ��btnSelectComuneRilascioDoc��$	��...��$��23��$
��Left=�$��703,287,0,0q�$	��Top=�$��28��$��19���� -6   $��btnSelectStatoRilascioDoc��$	��...��$��23��$
��Left=�$��703,316,0,0q�$	��Top=�$��28��$��20���� -7   $��txtProvIstat��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��434,170,0,0q�$��Prov. ISTAT��$	��Top=��� -8   $��txtboxProvIstat��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��534,169,0,0q�$	��Top=�$	��163����.  �� -9   $��btnSelectProvIstat��$	��...��$��23��$
��Left=�$��703,169,0,0q�$	��Top=�$��28��$��15��