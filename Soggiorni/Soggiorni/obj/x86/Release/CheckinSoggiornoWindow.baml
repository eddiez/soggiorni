   M S B A M L   `   `   `  ����   	Soggiorni&     Soggiorni.CheckinSoggiornoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Check-In Soggiorno��$	��296��$	��403�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�   sfondoWindow#���   .��� .+��� -   $��	txtSchede��$��Segoe UI)�$��24(�$
��Bold"����	#FF8D4600$��34��$
��Left=�$��	21,12,0,0q�$��SCHEDE DI NOTIFICA��$	��Top=�$	��298��&   System.Windows.Controls.DataGrid  -   $��dataGridSchede��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  $��Segoe UI)�$��14(�$��Normal"����	#FF717171
   GridLinesVisibility$
 Vertical=�   HeadersVisibility$ Column=�$	��131��   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��
21,77,12,0q�   SelectionMode$ Single=�$��10��$	��Top=�   VerticalGridLinesBrush �	#FFD8D8D8����    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5,2,5,2q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Cognome��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Cliente.Cognome+  $
 Nome�� �� *Cliente.Nome+�� -   $��btnAddScheda��$��20��$��Right=�$��	0,51,43,0q�$��8��$	��Top=�$��25�� � ToolTip$, &Crea schedina per un cliente esistente��.���� $)��#/Soggiorni;component/Images/add.png���� -   $��btnDeleteScheda��$��20��$��Right=�$��	0,51,12,0q�$��9��$	��Top=�$��25��$. (Elimina schedina del cliente selezionato��.���� $,��&/Soggiorni;component/Images/delete.png���� -   $��
btnAnnulla��$��Annulla��$��30��$��Right=�$��
0,219,12,0q�$	��Top=�$��82���� -   $��btnSalva��$��Salva��$��30��$��Right=�$��0,219,100,0q�$	��Top=�$��82���� -   $��btnPrint��$��30��$
��Left=�$��
21,219,0,0q�$	��Top=�$��38��.����  �� Orientation$ 
Horizontal=�.+��� $-��'/Soggiorni;component/Images/printer.png��$
��None=��� -   $��btnPrestampato��$��30��$
��Left=�$	��Top=�$��38��$��66,220,278,8q�.���� $ 
Horizontal=�.+��� $8��2/Soggiorni;component/Images/page_white_acrobat.ico��$
��None=��� -	   $��btnNewCliente��$��20��$
��Left=�$��	21,51,0,0q�$��9��$	��Top=�$��25��$+ %Inserisci nuovo cliente nell'archivio��.���� $.��(/Soggiorni;component/Images/user_add.png��