   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	       Soggiorni.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	   -   5          � Title$  Soggiorni Pianetti v. 2.1��5   	      sfondoWindow#���   6+   $	��700��6W   $
��1000��6d    � WindowStartupLocation$ CenterScreen=�6q    � WindowStyle$ SingleBorderWindow=�6�    � 
ResizeMode$ CanMinimize=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%:   &	       &	        5   
   6     5	   
   6!   5
      .��5      ]� ��. .+�5   
   o�  o� 
IsMainMenu . $	��Top=�6!   $	��Top=�66   .@�5      m� $��_File��6   .@�5      m� -   5        $��_Esci��5       m� Icon 5      �� 5      $*��$/Soggiorni;component/Images/exit.png��6    5      5      m� 5      $��_Clienti��6   .@�5      m� -   5        $��	_Aggiungi��5      {�.  5      �� 5      $.��(/Soggiorni;component/Images/user_add.png��6    5      m� 5      -   5        $(��"Esporta dati per mail auguri (Csv)��5      {�.  5      �� 5      $*��$/Soggiorni;component/Images/cake.png��6    5      m� 5       $��_Classifiche��6   {�.  61   5!      m� 5"      $��
_Soggiorni��6   .@�5#      m� -   5        $%��Pre-stampato schede di notifica��5#      {�.  5$      �� 5%      $��Uniform=�6!   $8��2/Soggiorni;component/Images/page_white_acrobat.ico��63   5'      m� 5(      -   5        $"��Crea file schede di notifica��5(      {�.  5)      �� 5*      $4��./Soggiorni;component/Images/user_policeman.ico��6    5,      �� 5-      m� 5.      -   5        $3��-Crea file presenze mensile ISTAT (automatico)��5.      {�.  5/      �� 50      $3��-/Soggiorni;component/Images/statistics_16.ico��6    52      m� 53      -   5        $(��"Crea file presenze ISTAT (manuale)��53      {�.  54      �� 55      $5��//Soggiorni;component/Images/page_white_edit.png��6    57      �� 58      m� 59      -	   5        $��Disponibilità camere��59      {�.  5:      �� 5;      $1��+/Soggiorni;component/Images/system-help.ico��6    5=      m� 5>      -
   5        $��Notifiche premi fedeltà��5>      {�.  5?      �� 5@      $,��&/Soggiorni;component/Images/trophy.png��6    5B      m� 5C      $��_Statistiche��6   {�.  61   5D      m� 5E      $��	Pagamenti��6   .@�5F      m� -   5        $��Genera corrispettivi��5F      {�.  5G      �� 5H      $3��-/Soggiorni;component/Images/cash_terminal.ico��6    5J      5K      m� 5L      $��?��6   .@�5M      m� -   5        $��About��5M      6*   5N      m� 5O      $��Camere��6   $y�Hidden=�6'   .@�5P      m� $��	_Aggiungi��6   {�.  6.   m� 5Q      $��_Elenco��6   {�.  6,   5R      m� 5S      $��Tipo Servizi��6   $y�Hidden=�6-   .@�5T      m� $��	_Aggiungi��6   {�.  6.   m� 5U      $��_Elenco��6   {�.  6,   5V      5W      � 5Y   
    � ColumnDefinitions 5Z      �� 5[      $	��50* �6#   �� 5\      $	��50* �6#    � RowDefinitions 5^      �� 5_      $	��50* �6    �� 5`      $	��50* �6    .+�5c      � 	 � Orientation$	 
Horizontal=�6   $��30,30,30,11q�61   .+�5d      �� -   5        $��btnAddSoggiorno��5d   S   $��0,0,0,0q�6   $	��120��6*   $
��Left=�68   $	��Top=�6j   $	��120��6�   
���   ���5e      �� 5f      .+�5g      �� -   5        $��imgAddSoggiorno��5g   M   $��90��6$   $��Center=�60   $
��Fill=�6d   $	��Top=�6s   $��90��6�   $/��)/Soggiorni;component/Images/add-event.ico��6�   �� 5h      $��20��6(   $��Center=�64   $��Nuovo soggiorno��6Q   $	��Top=�6h   $��12(�6�   $
��Bold"�6�   ���	#FF55241A6�   5i      5k      �� 5l      -   5        $��
btnTableau��5l   U   $��30,0,0,0q�6   $	��120��6+   $��Center=�68   $	��Top=�6g   $	��120��6   ��5m      �� 5n      .+�5o      �� -   5        $��
imgTableau��5o   \   $��90��6$   $
��Fill=�60   $��Center=�6?   $4��./Soggiorni;component/Images/billboard-icon.png��6n   $	��Top=�6�   $��90��6�   �� 5p      $��12(�6(   $
��Bold"�66   ���	#FF55241A$��20��6_   $��Center=�6k   $��Tableau��6�   $	��Top=�6�   5q      5s      �� 5t      -   5        $��btnNewPagamento��5t   8   $	��120��6   $��30,0,0,0q�6&   $	��120��6O   .��5u      �� .+�5v      �� -   5        $��image1��5v   I   $��90��6    $��Center=�6,   $1��+/Soggiorni;component/Images/piggy_bank2.ico��6W   $
��Fill=�6�   $	��Top=�6�   $��90��6�   �� 5w      $��12(�6$   $
��Bold"�62   ���	#FF55241A$��20��6[   $��Center=�6g   $��Nuovo Pagamento��6�   $	��Top=�6�   5x      5y      �� 5z      -   5        $��btnSearchSoggiorno��5z   T   $��0,40,0,0q�6   $	��120��6+   $
��Left=�68   $	��Top=�6n   $	��120��6�   ��5{      �� 5|      .+�5}      �� -   5        $��imgSearchSoggiorno��5}   M   $��90��6$   $��Center=�60   $
��Fill=�6g   $	��Top=�6v   $��90��6�   $2��,/Soggiorni;component/Images/event-search.ico��6�   �� 5~      $��20��6(   $��Center=�64   $��Cerca Soggiorno��6Q   $	��Top=�6h   $��12(�6�   $
��Bold"�6�   ���	#FF55241A6�   5      5�      �� 5�      -   5        $��btnSearchCliente��5�   T   $��	30,40,0,0q�6   $	��120��6,   $
��Left=�69   $	��120��6l   $	��Top=�6x   ��5�      �� 5�      .+�5�      �� -   5        $��imgSearchCliente��5�   M   $��90��6$   $��Center=�60   $
��Fill=�6e   $	��Top=�6t   $��90��6�   $.��(/Soggiorni;component/Images/contacts.ico��6�   �� 5�      $��20��6(   $��Center=�64   $��Cerca cliente��6Q   $	��Top=�6f   $��12(�6~   $
��Bold"�6�   ���	#FF55241A6�   5�      5�      �� 5�      -   5        $��btnSearchPagamento��5�   9   $	��120��6   $��	30,40,0,0q�6&   $	��120��6S   .��5�      �� .+�5�      �� -   5        $��image2��5�   I   $��90��6    $��Center=�6,   $5��//Soggiorni;component/Images/open_safety_box.ico��6W   $
��Fill=�6�   $	��Top=�6�   $��90��6�   �� 5�      $��12(�6$   $
��Bold"�62   ���	#FF55241A$��20��6[   $��Center=�6g   $��Cerca Pagamento��6�   $	��Top=�6�   5�      5�      5�      �� 5�      $��0��6   $��1��6&   .+�5�      �� -   5        $��
textBlock1��5�   X   $��
20,30,20,0q�6   $��39��60   $
��Left=�6<   $��Soggiorni in corso��6j   $	��Top=�6�   $	��445��6�   $��28(�6�   $��
Trajan Pro)�6�   $��Normal$�6�   
 �� TextAlignment$
 Center=�6�   $
��Bold"�6�   ���	#FF8358326#  &   System.Windows.Controls.DataGrid  5�      -   5        $��dataGridCurrent��5�   Z      FrozenColumnCount$ 1��6      AutoGenerateColumns .  $	��240��6M   $	��445��6q      AlternatingRowBackground �	#FFFFE7B1   GridLinesVisibility$ Vertical=�6�      HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush �	#FFD8D8D8$��Center=�6  $��Center=�6:  $��Center=�6^  $��13(�6�     
IsReadOnly .    HeadersVisibility$ Column=�6�  ���	#FF688CAF   SelectionMode$ Single=�6�     CanUserReorderColumns .  ���	#FF717171$ �� IsSynchronizedWithCurrentItem$ FalseY�6     CanUserSortColumns .  ��6}   ��    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Cliente��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Cliente.Cognome+  5�      $ Partenza��6-    6?   �� *
Partenza+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  5�      $ Camera��6-    6=   �� *Camera.Numero+  5�      $ Agriturismo��6-    6B   �� *Camera.Agriturismo+  5�      $ Totale��6-    6=   �� *TotaleSoggiorno+# [    	CellStyle 5�      �� 5�       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5�      ��  �� Property � �� �� Value 5�   "   �� 5�   &     �� 
TargetType"   66   .R�5�   *   � $��5q�6/   #��z��6:   .+�5�   .   �� $��Center=�6?   $��Center=�6\   5�   +   5�   '   5�      5�      5�      5�      �� 5�      $��1��6   $��1��6&   .+�5�      �� -   5        $��txtNext��5�   X   $��
20,10,20,0q�6   $��39��60   $
��Left=�6<   $��Soggiorni prossimo mese��6g   $	��Top=�6�   $	��445��6�   $��28(�6�   $��
Trajan Pro)�6�   $��Normal$�6�   $
 Center=�6�   $
��Bold"�6�   ���	#FF8358326%    5�      -   5        $��dataGridNext��5�   D    .  $	��240��67   $	��445��6X    �	#FFFFE7B1$ Vertical=�6�   
 �   � �	#FFD8D8D8$��Center=�6  $��Center=�6!  $��Center=�6E  $��13(�6g   . $ Column=�6�  ���	#FF688CAF$ Single=�6�   .  ���	#FF717171$ FalseY�6   .  ��6d   ��  5�        5�      $ Arrivo��6-    6=   �� *Arrivo+# [ $ 
dd/MM/yyyy��  5�      $ Partenza��6-    6?   �� *
Partenza+# [ $ 
dd/MM/yyyy��  5�      $ Cliente��6-    6>   �� *Cliente.Cognome+4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      $ Confermata ?��61    6G   �� *
Confermato+  5�      $ Camera��6-    6=   �� *Camera.Numero+  5�      $ Agriturismo��6-    6B   �� *Camera.Agriturismo+ 5�      �� 5�      "  6    .�5�      ��  � �� 5�   "   �� 5�   &   "   66   .R�5�   *   � $��5q�6/   #��z��6:   .+�5�   .   �� $��Center=�6?   $��Center=�6\   5�   +   5�   '   5�      5�      5�      5�      �� 5�      -   5        $��	groupBox1��5�   E   $��1��6   $	��279��6$   $��
24,10,30,0q�61   $	��Top=�6V   $��28(�6n   $��
Trajan Pro)�6|   
�������
�������$��2q�6�   ��5�      �� 5�      $
��Oggi��6    
�������6,   .��5�      � .+�5�        -   5        $��dataGridArriviOggi��5�   �    .  $	��208��6S   $
��Left=�6`   $��5,23,0,0q�6{   $	��Top=�6�   $	��200��6�   $ Column=�6�   $��12(�6�   $��Segoe UI)�6�   ���	#FF717171$ Vertical=�6!   �	#FFD8D8D8 �	#FFFFE7B1$ Single=�6�  $ FalseY�6�   .  .  ��6   ��  5�        5�      $ Camera��61    6A   �� *Camera.Numero+  5�      $ Cliente��61    6B   �� *Cliente.Cognome+  5�      $ 
Check-In ?��65    6I   �� *IsCheckedIn+ 5�      �� 5�      "  6$   .�5�   "   ��  � �� 5�   &   �� 5�   *   "   6:   .R�5�   .   � $��2q�63   #��z��6>   .+�5�   2   �� $��Center=�6C   $��Center=�6`   5�   /   5�   +   5�   #   5�      5�        5�      -   5        $��dataGridPartenzeOggi��5�   �    .  $	��208��6S   $
��Left=�6`   $��
210,23,0,0q�6{   $	��Top=�6�   $	��200��6�   $��12(�6�   $��Segoe UI)�6�   ���	#FF717171$ Vertical=�6
   �	#FFD8D8D8 �	#FFFFE7B1$ Single=�6q  $ FalseY�6�  $ Column=�6�   .  .  ��6   ��  5�        5�      $ Camera��61    6A   �� *Camera.Numero+  5�      $ Cliente��61    6B   �� *Cliente.Cognome+  5�      $ Check-Out ?��65    6J   �� *IsCheckedOut+ 5�      �� 5�      "  6$   .�5�   "   ��  � �� 5�   &   �� 5�   *   "   6:   .R�5�   .   � $��2q�63   #��z��6>   .+�5�   2   �� $��Center=�6C   $��Center=�6`   5�   /   5�   +   5�   #   5�      5�      �� 5�      -    5        $��
textBlock3��5�   �   $��
Trajan Pro)�6    $��14(�68   ���	#FF835832$��23��6]   $
��Left=�6i   $��5,4,0,0q�6�   $��Arrivi��6�   $
 Center=�6�   $	��Top=�6�   $	��201��6�   �� 5      -!   5        $��
textBlock2��5   Z   $��23��6    $
��Left=�6,   $��	210,4,0,0q�6G   $��Partenze��6l   $	��Top=�6|   $	��200��6�   $��
Trajan Pro)�6�   ���	#FF835832$��14(�6�   $
 Center=�6�   5     5     5     5     5     