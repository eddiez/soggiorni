   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  +    %Soggiorni.SelectPeriodoSchedineWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters       � Title$/  )Seleziona periodo di riferimento Schedine��$	��399��$	��402��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter��%   &	         .��� .+��� -   $��txtArriviDa��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	29,60,0,0q�$��Da��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerArriviDa��$��25��$
��Left=�$��	67,58,0,0q�$��7��$	��Top=�$	��163��$��14(��� -   $��
txtArriviA��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	29,91,0,0q�$��A��$	��Top=�  -   $��datePickerArriviA��$��25��$
��Left=�$��	67,89,0,0q�$��7��$	��Top=�$	��163��$��14(��� -   $��txtHeaderText��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	12,20,0,0q�$C��=Genera file per invio schede di notifica relative agli arrivi��$	��Top=��� -   $��txtQuestura��$��Segoe UI)�$��11(�$��Normal"�
���   �$��23��$
��Left=�$��
12,120,0,0q�$P��J(la Questura accetta per legge solo le schede degli arrivi di ieri e oggi)��$	��Top=��� -   $��	btnGenera��$��	Crea file��$��23��$
��Left=�$��282,149,0,0q�$	��Top=�$��75���� -   $��
separator1��$��5��$
��Left=�$��	0,186,0,0q�$	��Top=�$	��419���� -	   $��txtSoggiorni��$��Segoe UI)�$��12(�$
��Bold"�
���   �$��23��$
��Left=�$��
12,201,0,0q�$2��,Soggiorni senza schede di notifica associate��$	��Top=�&   System.Windows.Controls.DataGrid  -
   $��dataGridSoggiorni��   AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  ���	#FF688CAF   CanUserReorderColumns .     CanUserSortColumns .  $��13(����	#FF717171   GridLinesVisibility$ Vertical=�	   HeadersVisibility$	 Column=�$
��Left=�$��Center=�
   HorizontalGridLinesBrush

 �   �   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�$��
12,221,0,0q�   SelectionMode$ Single=�$��Center=�   VerticalGridLinesBrush �	#FFD8D8D8$	��345��$	��127��$	��Top=�����    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��  �� 
TargetType"  .R�� #��z��$��5q�.+��� $��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Cliente�� �� *Cliente.Cognome+  $ Camera�� �� *Camera.Numero+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 
Check-In ?�� �� *IsCheckedIn+