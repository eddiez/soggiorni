   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  +    %Soggiorni.SelectPeriodoPresenzeWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$<  6Seleziona il periodo per cui calcolare arrivi/partenze��$	��334��$	��400��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter��%   &	         .��� .+��� -   $��txtHeaderText��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	12,12,0,0q�$?��9Crea file di testo per inserimento manuale presenze ISTAT��$	��Top=��� -   $��
separator1��$��5��$
��Left=�$��	0,127,0,0q�$	��Top=�$	��419���� -   $��txtSoggiorni��$��Segoe UI)�$��12(�$
��Bold"�
���   �$��23��$
��Left=�$��
12,141,0,0q�$2��,Soggiorni senza schede di notifica associate��$	��Top=�&   System.Windows.Controls.DataGrid  -   $��dataGridSoggiorni��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  ���	#FF688CAF   CanUserReorderColumns .     CanUserSortColumns .  $��13(����	#FF717171   GridLinesVisibility$ Vertical=�	   HeadersVisibility$	 Column=�$	��127��$
��Left=�$��Center=�
   HorizontalGridLinesBrush

 �   �   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��
12,161,0,0q�   SelectionMode$ Single=�$	��Top=�$��Center=�   VerticalGridLinesBrush �	#FFD8D8D8$	��354������    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Partenza�� �� *
Partenza+# [ $ 
dd/MM/yyyy��  $ Cliente�� �� *Cliente.Cognome+  $ Camera�� �� *Camera.Numero+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 
Check-In ?�� �� *IsCheckedIn+�� -   $��	btnGenera��$��	Crea file��$��23��$
��Left=�$��
291,87,0,0q�$	��Top=�$��75���� -   $��txtDa��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	12,41,0,0q�$��da��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerFrom��$��25��$
��Left=�$��	52,39,0,0q�$	��Top=�$	��130���� -   $
��txtA��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
212,43,0,0q�$��a��$	��Top=�  -	   $��datePickerTo��$��25��$
��Left=�$��
236,39,0,0q�$	��Top=�$	��130��