   M S B A M L   `   `   `  ����D  @Soggiorni, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Soggiorni.ConvertersSoggiorni.Converters  5   	   +    %Soggiorni.SelectPeriodoSchedineWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4local"clr-namespace:Soggiorni.Converters     5   	     � Title$/  )Seleziona periodo di riferimento Schedine��5   	   $	��399��6;   $	��402��6H      sfondoWindow#���   6T    � 
ResizeMode$ NoResize=�6�    � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5      (   "Soggiorni.Converters.DateConverter  dateConverter��%   &	         5   
   6   5      .��5	      � .+�5
   
   �� -   5        $��txtArriviDa��5
   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	29,60,0,0q�6�   $��Da��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerArriviDa��5   O   $��25��6   $
��Left=�6!   $��	67,58,0,0q�6<   $��7��6i   $	��Top=�6v   $	��163��6�   $��14(�6�   �� 5   
   -   5        $��
txtArriviA��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	29,91,0,0q�6�   $��A��6�   $	��Top=�6�     5   
   -   5        $��datePickerArriviA��5   O   $��25��6   $
��Left=�6!   $��	67,89,0,0q�6<   $��7��6h   $	��Top=�6u   $	��163��6�   $��14(�6�   �� 5   
   -   5        $��txtHeaderText��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	12,20,0,0q�6�   $C��=Genera file per invio schede di notifica relative agli arrivi��6�   $	��Top=�6�   �� 5   
   -   5        $��txtQuestura��5   �   $��Segoe UI)�6   $��11(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
12,120,0,0q�6�   $P��J(la Questura accetta per legge solo le schede degli arrivi di ieri e oggi)��6�   $	��Top=�6�   �� 5   
   -   5        $��	btnGenera��5   a   $��	Crea file��6   $��23��6%   $
��Left=�61   $��282,149,0,0q�6L   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��
separator1��5   M   $��5��6   $
��Left=�6   $��	0,186,0,0q�6:   $	��Top=�6_   $	��419��6w   �� 5   
   -	   5        $��txtSoggiorni��5   �   $��Segoe UI)�6   $��12(�6*   $
��Bold"�68   
���   �$��23��6]   $
��Left=�6i   $��
12,201,0,0q�6�   $2��,Soggiorni senza schede di notifica associate��6�   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -
   5        $��dataGridSoggiorni��5   �     AlternatingRowBackground �	#FFFFE7B1   AutoGenerateColumns .  ���	#FF688CAF   CanUserReorderColumns .     CanUserSortColumns .  $��13(�6�   ���	#FF717171   GridLinesVisibility$ Vertical=�6�   	   HeadersVisibility$	 Column=�6�   $
��Left=�6  $��Center=�6  
   HorizontalGridLinesBrush

 �   �   
IsReadOnly . $ �� IsSynchronizedWithCurrentItem$ FalseY�6v  $��
12,221,0,0q�6�     SelectionMode$ Single=�6�  $��Center=�6�     VerticalGridLinesBrush �	#FFD8D8D8$	��345��6=  $	��127��6I  $	��Top=�6V  ��6�  ��    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   � #��z��6'   $��5q�6Y   .+�5   &   �� $��Center=�67   $��Center=�6T   5   #   5      5      5         Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Arrivo��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Arrivo+ �� 	Converter# [  �� ConverterParameter$ 
dd/MM/yyyy��6�     5#      $ Cliente��6I    6%   �� *Cliente.Cognome+6I     5$      $ Camera��6G    6%   �� *Camera.Numero+6G   4  .System.Windows.Controls.DataGridCheckBoxColumn  5%      $ 
Check-In ?��6)    6=   �� *IsCheckedIn+5'      5(      5)      