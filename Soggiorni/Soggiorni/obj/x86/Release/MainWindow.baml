   M S B A M L   `   `   `  ���� D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters      Soggiorni.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     4local"clr-namespace:Soggiorni.Converters     -     � Title$  Soggiorni Pianetti v. 2.1��   sfondoWindow#���   $	��700��$
��1000�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ CanMinimize=� � 	Resources (   "Soggiorni.Converters.DateConverter  dateConverter+   %Soggiorni.Converters.DecimalConverter  decimalConverter��%   &	       &	          .��]� ��. .+�o�  o� 
IsMainMenu . $	��Top=�$	��Top=�.@�m� $��_File��.@�m� -   $��_Esci�� m� Icon �� $*��$/Soggiorni;component/Images/exit.png��m� $��_Clienti��.@�m� -   $��	_Aggiungi��{�.  �� $.��(/Soggiorni;component/Images/user_add.png��m� -   $(��"Esporta dati per mail auguri (Csv)��{�.  �� $*��$/Soggiorni;component/Images/cake.png��m� $��_Classifiche��{�.  m� $��
_Soggiorni��.@�m� -   $%��Pre-stampato schede di notifica��{�.  �� $��Uniform=�$8��2/Soggiorni;component/Images/page_white_acrobat.ico��m� -   $"��Crea file schede di notifica��{�.  �� $4��./Soggiorni;component/Images/user_policeman.ico���� m� -   $3��-Crea file presenze mensile ISTAT (automatico)��{�.  �� $3��-/Soggiorni;component/Images/statistics_16.ico��m� -   $(��"Crea file presenze ISTAT (manuale)��{�.  �� $5��//Soggiorni;component/Images/page_white_edit.png���� m� -	   $��Disponibilità camere��{�.  �� $1��+/Soggiorni;component/Images/system-help.ico��m� -
   $��Notifiche premi fedeltà��{�.  �� $,��&/Soggiorni;component/Images/trophy.png��m� $��_Statistiche��{�.  m� $��	Pagamenti��.@�m� -   $��Genera corrispettivi��{�.  �� $3��-/Soggiorni;component/Images/cash_terminal.ico��m� $��?��.@�m� -   $��About��m� $��Camere��$y�Hidden=�.@�m� $��	_Aggiungi��{�.  m� $��_Elenco��{�.  m� $��Tipo Servizi��$y�Hidden=�.@�m� $��	_Aggiungi��{�.  m� $��_Elenco��{�.  �  � ColumnDefinitions �� $	��50* ��� $	��50* � � RowDefinitions �� $	��50* ��� $	��50* �.+�� 	 � Orientation$	 
Horizontal=�$��30,30,30,11q�.+��� -   $��btnAddSoggiorno��$��0,0,0,0q�$	��120��$
��Left=�$	��Top=�$	��120��
���   ����� .+��� -   $��imgAddSoggiorno��$��90��$��Center=�$
��Fill=�$	��Top=�$��90��$/��)/Soggiorni;component/Images/add-event.ico���� $��20��$��Center=�$��Nuovo soggiorno��$	��Top=�$��12(�$
��Bold"����	#FF55241A�� -   $��
btnTableau��$��30,0,0,0q�$	��120��$��Center=�$	��Top=�$	��120������ .+��� -   $��
imgTableau��$��90��$
��Fill=�$��Center=�$4��./Soggiorni;component/Images/billboard-icon.png��$	��Top=�$��90���� $��12(�$
��Bold"����	#FF55241A$��20��$��Center=�$��Tableau��$	��Top=��� -   $��btnNewPagamento��$	��120��$��30,0,0,0q�$	��120��.���� .+��� -   $��image1��$��90��$��Center=�$1��+/Soggiorni;component/Images/piggy_bank2.ico��$
��Fill=�$	��Top=�$��90���� $��12(�$
��Bold"����	#FF55241A$��20��$��Center=�$��Nuovo Pagamento��$	��Top=��� -   $��btnSearchSoggiorno��$��0,40,0,0q�$	��120��$
��Left=�$	��Top=�$	��120������ .+��� -   $��imgSearchSoggiorno��$��90��$��Center=�$
��Fill=�$	��Top=�$��90��$2��,/Soggiorni;component/Images/event-search.ico���� $��20��$��Center=�$��Cerca Soggiorno��$	��Top=�$��12(�$
��Bold"����	#FF55241A�� -   $��btnSearchCliente��$��	30,40,0,0q�$	��120��$
��Left=�$	��120��$	��Top=����� .+��� -   $��imgSearchCliente��$��90��$��Center=�$
��Fill=�$	��Top=�$��90��$.��(/Soggiorni;component/Images/contacts.ico���� $��20��$��Center=�$��Cerca cliente��$	��Top=�$��12(�$
��Bold"����	#FF55241A�� -   $��btnSearchPagamento��$	��120��$��	30,40,0,0q�$	��120��.���� .+��� -   $��image2��$��90��$��Center=�$5��//Soggiorni;component/Images/open_safety_box.ico��$
��Fill=�$	��Top=�$��90���� $��12(�$
��Bold"����	#FF55241A$��20��$��Center=�$��Cerca Pagamento��$	��Top=��� $��0��$��1��.+��� -   $��
textBlock1��$��
20,30,20,0q�$��39��$
��Left=�$��Soggiorni in corso��$	��Top=�$	��445��$��28(�$��
Trajan Pro)�$��Normal$�
 �� TextAlignment$
 Center=�$
��Bold"����	#FF835832&   System.Windows.Controls.DataGrid  -   $��dataGridCurrent��   FrozenColumnCount$ 1��   AutoGenerateColumns .  $	��240��$	��445��   AlternatingRowBackground �	#FFFFE7B1   GridLinesVisibility$ Vertical=�   HorizontalGridLinesBrush
 �   �   VerticalGridLinesBrush �	#FFD8D8D8$��Center=�$��Center=�$��Center=�$��13(�   
IsReadOnly .    HeadersVisibility$ Column=����	#FF688CAF   SelectionMode$ Single=�   CanUserReorderColumns .  ���	#FF717171$ �� IsSynchronizedWithCurrentItem$ FalseY�   CanUserSortColumns .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Cliente��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Cliente.Cognome+  $ Partenza�� �� *
Partenza+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��  $ Camera�� �� *Camera.Numero+  $ Agriturismo�� �� *Camera.Agriturismo+  $ Totale�� �� *TotaleSoggiorno+# [    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value ��   �� 
TargetType"   .R�� $��5q�#��z��.+��� $��Center=�$��Center=��� $��1��$��1��.+��� -   $��txtNext��$��
20,10,20,0q�$��39��$
��Left=�$��Soggiorni prossimo mese��$	��Top=�$	��445��$��28(�$��
Trajan Pro)�$��Normal$�$
 Center=�$
��Bold"����	#FF835832  -   $��dataGridNext�� .  $	��240��$	��445�� �	#FFFFE7B1$ Vertical=�
 �   � �	#FFD8D8D8$��Center=�$��Center=�$��Center=�$��13(� . $ Column=����	#FF688CAF$ Single=� .  ���	#FF717171$ FalseY� .  ����    $ Arrivo�� �� *Arrivo+# [ $ 
dd/MM/yyyy��  $ Partenza�� �� *
Partenza+# [ $ 
dd/MM/yyyy��  $ Cliente�� �� *Cliente.Cognome+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ Confermata ?�� �� *
Confermato+  $ Camera�� �� *Camera.Numero+  $ Agriturismo�� �� *Camera.Agriturismo+ �� "  .���  � �� �� "   .R�� $��5q�#��z��.+��� $��Center=�$��Center=��� -   $��	groupBox1��$��1��$	��279��$��
24,10,30,0q�$	��Top=�$��28(�$��
Trajan Pro)�
�������
�������$��2q����� $
��Oggi��
�������.��� .+�  -   $��dataGridArriviOggi�� .  $	��208��$
��Left=�$��5,23,0,0q�$	��Top=�$	��200��$ Column=�$��12(�$��Segoe UI)����	#FF717171$ Vertical=� �	#FFD8D8D8 �	#FFFFE7B1$ Single=�$ FalseY� .  .  ����    $ Camera�� �� *Camera.Numero+  $ Cliente�� �� *Cliente.Cognome+  $ 
Check-In ?�� �� *IsCheckedIn+ �� "  .���  � �� �� "   .R�� $��2q�#��z��.+��� $��Center=�$��Center=�  -   $��dataGridPartenzeOggi�� .  $	��208��$
��Left=�$��
210,23,0,0q�$	��Top=�$	��200��$��12(�$��Segoe UI)����	#FF717171$ Vertical=� �	#FFD8D8D8 �	#FFFFE7B1$ Single=�$ FalseY�$ Column=� .  .  ����    $ Camera�� �� *Camera.Numero+  $ Cliente�� �� *Cliente.Cognome+  $ Check-Out ?�� �� *IsCheckedOut+ �� "  .���  � �� �� "   .R�� $��2q�#��z��.+��� $��Center=�$��Center=��� -    $��
textBlock3��$��
Trajan Pro)�$��14(����	#FF835832$��23��$
��Left=�$��5,4,0,0q�$��Arrivi��$
 Center=�$	��Top=�$	��201���� -!   $��
textBlock2��$��23��$
��Left=�$��	210,4,0,0q�$��Partenze��$	��Top=�$	��200��$��
Trajan Pro)����	#FF835832$��14(�$
 Center=�