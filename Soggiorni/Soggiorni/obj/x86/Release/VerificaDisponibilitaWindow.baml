   M S B A M L   `   `   `  ����   	Soggiorni+    %Soggiorni.VerificaDisponibilitaWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$#  Verifica Disponiblità Camere��   sfondoWindow#���   $	��538��$	��600�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� .+��� -   $��	txtArrivo��$��23��$
��Left=�$��	82,32,0,0q�$%��Data Arrivo                    ��$	��Top=�$��18(����	#FF835832(  "System.Windows.Controls.DatePicker  -   $��datepickerArrivo��$��30��$��Right=�$��	0,30,93,0q�$	��Top=�$	��278��   SelectedDateFormat$
 Long=�$��16(��� -   $��txtPartenza��$��18(����	#FF835832$��23��$
��Left=�$��	82,88,0,0q�$��Data Partenza��$	��Top=�$	��119��  -   $��datepickerPartenza��$��16(�$��30��$��Right=�$��	0,86,93,0q�$
 Long=�$	��Top=�$	��278���� -   $��txtNotti��$��18(����	#FF835832$��23��$
��Left=�$��
82,147,0,0q�$��	N° notti��$	��Top=��� -   $��txtboxNotti��$��30��$��Right=�$��0,147,311,0q�$	��Top=�$��60��$��16(� �� 
IsReadOnly .  �� TextAlignment$ Center=��� -   $��
separator1��$��11��$
��Left=�$��	0,231,0,0q�$	��Top=�$	��600�����	#FFFCF4EE$��0q��� -   $��	btnSearch��$��Cerca��$��32��$��Right=�$��0,193,209,0q�$	��Top=�$	��162��&   System.Windows.Controls.DataGrid  -	   $��dataGridCamere��   AutoGenerateColumns .  $	��203��$
��Left=�$��
82,246,0,0q�$	��Top=�$	��419�����	#FF717171$��13(�   VerticalGridLinesBrush �	#FFD8D8D8   GridLinesVisibility$ Vertical=�	   AlternatingRowBackground	 �	#FFFFE7B1
   CanUserReorderColumns
 .     CanUserResizeColumns .     CanUserSortColumns .     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�   HeadersVisibility$ Column=�   SelectionMode$ Single=�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Numero��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Numero+  $
 Nome�� �� *Nome+  $
 Tipo�� �� *Tipo+  $ Bagno�� �� *Bagno+  $ Agriturismo�� �� *Agriturismo+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� $��5q�#��z��.+��� $��Center=�$��Center=��� -
   $��btnAdd��$��+��$��30��$��Right=�$��0,147,260,0q�$	��Top=�$��45��$
��Bold"�$��18(��� -   $��btnSub��$��-��$��18(�$
��Bold"�$��30��$��Right=�$��0,147,209,0q�$	��Top=�$��45���� -   $��
btnPrenota��$��Prenota selezionata��$��32��$
��Left=�$��366,455,0,0q�$	��Top=�$	��135��