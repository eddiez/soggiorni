   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  $    Soggiorni.CercaSoggiornoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$  Cerca Soggiorno��$	��503��$	��525��   sfondoWindow#���    � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	       &	          .��� .+��� -   $��	txtArrivo��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	47,22,0,0q�$��Data arrivo��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerArrivo��$��25��$
��Left=�$��
182,20,0,0q�$	��Top=�$	��133��$��14(�  -   $��datePickerPartenza��$��14(�$��25��$
��Left=�$��
182,69,0,0q�$	��Top=�$	��133���� -   $��txtboxCliente�����	#FFEAEAEA$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�.  �� 
IsReadOnly . $��182,118,0,0q�$	��Top=�$	��133���� -   $��
txtCliente��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
47,119,0,0q�$��Cliente��$	��Top=��� -   $��btnArchivioClienti��$��archivio...��$��23��$
��Left=�$��321,119,0,0q�$	��Top=�$��75���� -   $��btnResetCliente��$��azzera��$��23��$
��Left=�$��402,119,0,0q�$	��Top=�$��75���� -   $��btnCerca��$��Cerca��$��30��$
��Left=�$��182,173,0,0q�$	��Top=�$	��133��$��14(�&   System.Windows.Controls.DataGrid  -	   $��dataGridSoggiorni��   AutoGenerateColumns .  $	��200��$
��Left=�$��
47,249,0,0q�$	��Top=�$	��430��$ �� IsSynchronizedWithCurrentItem$ FalseY�   CanUserReorderColumns .     CanUserResizeColumns .  	   CanUserSortColumns	 .  
   GridLinesVisibility$
 Vertical=�   VerticalGridLinesBrush �	#FFDBDBDB   HeadersVisibility$ Column=�   AlternatingRowBackground �	#FFFFE7B1   CanUserResizeRows .     SelectionMode$ Single=����	#FF717171   
IsReadOnly . ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Partenza�� �� *
Partenza+# [ $ 
dd/MM/yyyy��  $ Cliente�� �� *Cliente.Cognome+  $ Camera�� �� *Camera.Numero+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 
Check-In ?�� �� *IsCheckedIn+  $ Check-Out ?�� �� *IsCheckedOut+   	CellStyle ��  �� 
TargetType*	  $System.Windows.Controls.DataGridCell" 	 .���  �� Property � �� �� Value ��  �� 
TargetType" 	 .R�� $��5q�#��z��.+��� $��Center=�$��Center=��� -
   $��
separator1��$��5��$
��Left=�$��	0,224,0,0q�$	��Top=�$	��525���� -   $��txtPartenza��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	47,71,0,0q�$��Data partenza��$	��Top=��� -   $��
btnTableau��$��14(�$��30��$
��Left=�$��344,173,0,0q�$	��Top=�$	��133��.����  �� Orientation$ 
Horizontal=�.+��� $:��4/Soggiorni;component/Images/billboard-icon-small.png���� $��15,3,0,0q�$��Tableau��