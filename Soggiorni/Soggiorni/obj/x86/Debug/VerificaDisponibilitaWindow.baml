   M S B A M L   `   `   `  ����  	Soggiorni+    %Soggiorni.VerificaDisponibilitaWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  Verifica Disponiblità Camere��5   	      sfondoWindow#���   6.   $	��538��6Z   $	��600��6g    � WindowStartupLocation$ CenterScreen=�6s    � 
ResizeMode$ NoResize=�6�   .��5      � .+�5   
   �� -   5        $��	txtArrivo��5   N   $��23��6   $
��Left=�6    $��	82,32,0,0q�6;   $%��Data Arrivo                    ��6_   $	��Top=�5      $��18(�6.   ���	#FF8358326<   (  "System.Windows.Controls.DatePicker  5	   
   -   5        $��datepickerArrivo��5	   P   $��30��6   $��Right=�6!   $��	0,30,93,0q�6=   $	��Top=�6h   $	��278��6�      SelectedDateFormat$
 Long=�6�   $��16(�6�   6�   �� 5
   
   -   5        $��txtPartenza��5
   s   $��18(�6   ���	#FF835832$��23��69   $
��Left=�6E   $��	82,88,0,0q�6`   $��Data Partenza��6�   $	��Top=�6�   $	��119��6�     5   
   -   5        $��datepickerPartenza��5   ^   $��16(�6   $��30��6#   $��Right=�6/   $��	0,86,93,0q�6K   $
 Long=�6x   $	��Top=�6�   $	��278��6�   6�   �� 5   
   -   5        $��txtNotti��5   t   $��18(�6   ���	#FF835832$��23��69   $
��Left=�6E   $��
82,147,0,0q�6`   $��	N° notti��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxNotti��5   O   $��30��6   $��Right=�6   $��0,147,311,0q�6:   $	��Top=�6b   $��60��6z   $��16(�6�    �� 
IsReadOnly .  �� TextAlignment$ Center=�6�   �� 5   
   -   5        $��
separator1��5   N   $��11��6   $
��Left=�6    $��	0,231,0,0q�6;   $	��Top=�6`   $	��600��6x   ���	#FFFCF4EE$��0q�6�   �� 5   
   -   5        $��	btnSearch��5   ^   $��Cerca��6   $��32��6!   $��Right=�6-   $��0,193,209,0q�6I   $	��Top=�6o   $	��162��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -	   5        $��dataGridCamere��5   �      AutoGenerateColumns .  $	��203��6G   $
��Left=�6T   $��
82,246,0,0q�6o   $	��Top=�6�   $	��419��6�   ���	#FF717171$��13(�6�      VerticalGridLinesBrush �	#FFD8D8D8   GridLinesVisibility$ Vertical=�6  	   AlternatingRowBackground	 �	#FFFFE7B1
   CanUserReorderColumns
 .     CanUserResizeColumns .     CanUserSortColumns .     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6�     HeadersVisibility$ Column=�6�     SelectionMode$ Single=�6�  ��6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Numero��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Numero+  5      $
 Nome��6%    63   �� *Nome+  5      $
 Tipo��6%    63   �� *Tipo+  5      $ Bagno��6%    64   �� *Bagno+  5      $ Agriturismo��6%    6:   �� *Agriturismo+   	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   � $��5q�6'   #��z��62   .+�5   &   �� $��Center=�67   $��Center=�6T   5   #   5       5"      5$      5&      �� 5'   
   -
   5        $��btnAdd��5'   Z   $��+��6   $��30��6   $��Right=�6)   $��0,147,260,0q�6E   $	��Top=�6h   $��45��6�   $
��Bold"�6�   $��18(�6�   6�   �� 5(   
   -   5        $��btnSub��5(   z   $��-��6   $��18(�6   $
��Bold"�6+   $��30��6=   $��Right=�6I   $��0,147,209,0q�6e   $	��Top=�6�   $��45��6�   6�   �� 5)   
   -   5        $��
btnPrenota��5)   k   $��Prenota selezionata��6   $��32��6/   $
��Left=�6;   $��366,455,0,0q�6V   $	��Top=�6}   $	��135��6�   6�   5*      5+      