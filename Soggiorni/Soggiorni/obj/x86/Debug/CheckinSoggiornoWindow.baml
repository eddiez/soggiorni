   M S B A M L   `   `   `  ����  	Soggiorni&     Soggiorni.CheckinSoggiornoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Check-In Soggiorno��5   	   $	��296��6$   $	��403��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterScreen=�6S      sfondoWindow#���   6x   .��5      � .+�5   
   �� -   5        $��	txtSchede��5   �   $��Segoe UI)�6   $��24(�6*   $
��Bold"�68   ���	#FF8D4600$��34��6a   $
��Left=�6m   $��	21,12,0,0q�6�   $��SCHEDE DI NOTIFICA��6�   $	��Top=�6�   $	��298��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridSchede��5   �     AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .     CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .  	   CanUserSortColumns	 .  $��Segoe UI)�6�   $��14(�6�   $��Normal"�6�   ���	#FF717171
   GridLinesVisibility$
 Vertical=�6*     HeadersVisibility$ Column=�6I  $	��131��6d     
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6�  $��
21,77,12,0q�6�     SelectionMode$ Single=�6�  $��10��6  $	��Top=�6     VerticalGridLinesBrush �	#FFD8D8D8��6�  ��    	CellStyle 5      �� 5	       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5
      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   � #��z��6'   $��5,2,5,2q�6Y   .+�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Cognome��6I   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Cliente.Cognome+6I     5      $
 Nome��6F    6%   �� *Cliente.Nome+6F   5      �� 5   
   -   5        $��btnAddScheda��5   L   $��20��6   $��Right=�6   $��	0,51,43,0q�69   $��8��6`   $	��Top=�6m   $��25��6�    � ToolTip$, &Crea schedina per un cliente esistente��6�   .��5      �� $)��#/Soggiorni;component/Images/add.png��6   5      �� 5   
   -   5        $��btnDeleteScheda��5   L   $��20��6   $��Right=�6   $��	0,51,12,0q�69   $��9��6c   $	��Top=�6p   $��25��6�   $. (Elimina schedina del cliente selezionato��6�   .��5      �� $,��&/Soggiorni;component/Images/delete.png��6   5      �� 5    
   -   5        $��
btnAnnulla��5    _   $��Annulla��6   $��30��6#   $��Right=�6/   $��
0,219,12,0q�6K   $	��Top=�6q   $��82��6�   6�   �� 5!   
   -   5        $��btnSalva��5!   ^   $��Salva��6   $��30��6!   $��Right=�6-   $��0,219,100,0q�6I   $	��Top=�6n   $��82��6�   6�   �� 5"   
   -   5        $��btnPrint��5"   L   $��30��6   $
��Left=�6   $��
21,219,0,0q�68   $	��Top=�6\   $��38��6t   .��5#      ��  �� Orientation$ 
Horizontal=�6   .+�5$      �� $-��'/Soggiorni;component/Images/printer.png��6   $
��None=�6I   5%      5&      �� 5'   
   -   5        $��btnPrestampato��5'   [   $��30��6   $
��Left=�6   $	��Top=�68   $��38��6P   $��66,220,278,8q�6r   .��5(      �� $ 
Horizontal=�6   .+�5)      �� $8��2/Soggiorni;component/Images/page_white_acrobat.ico��6   $
��None=�6T   5*      5+      �� 5,   
   -	   5        $��btnNewCliente��5,   K   $��20��6   $
��Left=�6   $��	21,51,0,0q�68   $��9��6`   $	��Top=�6m   $��25��6�   $+ %Inserisci nuovo cliente nell'archivio��6�   .��5-      �� $.��(/Soggiorni;component/Images/user_add.png��6   5.      5/      50      