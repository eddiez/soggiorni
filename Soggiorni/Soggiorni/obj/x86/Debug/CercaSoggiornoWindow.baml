   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	   $    Soggiorni.CercaSoggiornoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	     � Title$  Cerca Soggiorno��5   	   $	��503��6!   $	��525��6.      sfondoWindow#���   6:    � WindowStartupLocation$ CenterScreen=�6f    � 
ResizeMode$ NoResize=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%:   &	       &	        5   
   6     5   
   6!   5	      .��5
      � .+�5   
   �� -   5        $��	txtArrivo��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	47,22,0,0q�6�   $��Data arrivo��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerArrivo��5   P   $��25��6   $
��Left=�6!   $��
182,20,0,0q�6<   $	��Top=�6h   $	��133��6�   $��14(�6�     5   
   -   5        $��datePickerPartenza��5   ^   $��14(�6   $��25��6#   $
��Left=�6/   $��
182,69,0,0q�6J   $	��Top=�6x   $	��133��6�   �� 5   
   -   5        $��txtboxCliente��5   �   ���	#FFEAEAEA$��Segoe UI)�6)   $��12(�6?   $��Normal"�6M   $��23��6a   $
��Left=�6m   {�.  �� 
IsReadOnly . $��182,118,0,0q�6�   $	��Top=�6�   $	��133��6�   �� 5   
   -   5        $��
txtCliente��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
47,119,0,0q�6�   $��Cliente��6�   $	��Top=�6�   �� 5   
   -   5        $��btnArchivioClienti��5   c   $��archivio...��6   $��23��6'   $
��Left=�63   $��321,119,0,0q�6N   $	��Top=�6}   $��75��6�   6�   �� 5   
   -   5        $��btnResetCliente��5   ^   $��azzera��6   $��23��6"   $
��Left=�6.   $��402,119,0,0q�6I   $	��Top=�6u   $��75��6�   6�   �� 5   
   -   5        $��btnCerca��5   ]   $��Cerca��6   $��30��6!   $
��Left=�6-   $��182,173,0,0q�6H   $	��Top=�6m   $	��133��6�   $��14(�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -	   5        $��dataGridSoggiorni��5   �      AutoGenerateColumns .  $	��200��6G   $
��Left=�6T   $��
47,249,0,0q�6o   $	��Top=�6�   $	��430��6�   $ �� IsSynchronizedWithCurrentItem$ FalseY�6�      CanUserReorderColumns .     CanUserResizeColumns .  	   CanUserSortColumns	 .  
   GridLinesVisibility$
 Vertical=�6<     VerticalGridLinesBrush �	#FFDBDBDB   HeadersVisibility$ Column=�6~     AlternatingRowBackground �	#FFFFE7B1   CanUserResizeRows .     SelectionMode$ Single=�6�  ���	#FF717171   
IsReadOnly . ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  5      $ Partenza��6%    67   �� *
Partenza+# [ $ 
dd/MM/yyyy��  5      $ Cliente��6%    66   �� *Cliente.Cognome+  5      $ Camera��6%    65   �� *Camera.Numero+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 
Check-In ?��6)    6=   �� *IsCheckedIn+  5      $ Check-Out ?��6)    6>   �� *IsCheckedOut+   	CellStyle 5      �� 5       �� 
TargetType*	  $System.Windows.Controls.DataGridCell" 	 6   .�5      ��  �� Property � �� �� Value 5      �� 5        �� 
TargetType" 	 6.   .R�5!   "   � $��5q�6'   #��z��62   .+�5"   &   �� $��Center=�67   $��Center=�6T   5#   #   5$      5&      5'      5)      �� 5*   
   -
   5        $��
separator1��5*   M   $��5��6   $
��Left=�6   $��	0,224,0,0q�6:   $	��Top=�6_   $	��525��6w   �� 5+   
   -   5        $��txtPartenza��5+   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	47,71,0,0q�6�   $��Data partenza��6�   $	��Top=�6�   �� 5,   
   -   5        $��
btnTableau��5,   [   $��14(�6   $��30��6   $
��Left=�6+   $��344,173,0,0q�6F   $	��Top=�6m   $	��133��6�   .��5-      ��  �� Orientation$ 
Horizontal=�6   .+�5.      �� $:��4/Soggiorni;component/Images/billboard-icon-small.png��6   �� 5/      $��15,3,0,0q�6   $��Tableau��6.   50      51      52      53      