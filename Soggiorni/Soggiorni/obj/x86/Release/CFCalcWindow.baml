   M S B A M L   `   `   `  ����   	Soggiorni    Soggiorni.CFCalcWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Calcolo Codice Fiscale��$	��400��$	��343��   sfondoWindow#���    � WindowStartupLocation$ CenterScreen=�.��� .+�� -   $��gridCF��$	��312��$
��Left=�$	��Top=�$	��337�� � RowDefinitions �� $
��209* ��� $
��103* �.+��� -   $��
txtCognome��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	10,10,0,0q�$��Cognome��$	��Top=��� -   $��txtboxCognome��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��
110,10,0,0q�$��1��$	��Top=�$	��163���� -   $��txtNome��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	10,39,0,0q�$
��Nome��$	��Top=��� -   $��
txtboxNome��$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�. $��
110,39,0,0q�$��2��$	��Top=�$	��163���� -   $��stackPanelSesso��$��24��$
��Left=�$��
110,66,0,0q� �� Orientation$ 
Horizontal=�$	��Top=�$	��163��.+�	� -   $��radioButtonM��$��M�� 	� 	GroupName$ Sesso��$��16�� d� 	IsChecked$
 TrueY�$��0,0,0,0q�$��3��	� -   $��radioButtonF��$��F��$ Sesso��$��16��$��20,0,0,0q�$��4���� -	   $��txtSesso��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	10,67,0,0q�$��Sesso                    ��$	��Top=�$��38���� -
   $��txtDataNascita��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��	10,99,0,0q�$��Data nascita��$	��Top=�(  "System.Windows.Controls.DatePicker  -   $��datePickerNascita��$��25��$
��Left=�$��
110,96,0,0q�$��7��$	��Top=�$	��163���� -   $��txtComuneNascita��$��Segoe UI)�$��14(�$��Normal"�
���   �$��23��$
��Left=�$��
10,128,0,0q�$��Comune nasc.��$	��Top=��� -   $��txtboxComuneNascita��
�������$��Segoe UI)�$��12(�$��Normal"�$��23��$
��Left=�{�.  �� 
IsReadOnly . ��.  $��110,127,0,0q�$	��Top=�$	��163���� -   $��btnSelectComuneNascita��$	��...��$��23��$
��Left=�$��279,127,0,0q�$��8��$	��Top=�$��28���� -   $��btnArchivioClienti��$��26��$
��Left=�$��146,168,0,0q�$��8��$	��Top=�$	��127��.���� $ 
Horizontal=�.+��� $-��'/Soggiorni;component/Images/archive.png���� $��10,2,0,0q�Archivio Clienti�� -   $��stackPanel1��$��1��$	��103��$
��Left=�$	��Top=�$	��372�����	#FF00EF68.+��� -   $��txtboxCF��$��Segoe UI)�$��20(�$��Normal"�$��32��$
��Left=�{�. $��	10,20,0,0q�$��2��$	��Top=�$	��263�� . ���	#FFC9FFD2�� -   $��btnCalcolaCF��$��Calcola��$��27��$
��Left=�$��	167,5,0,0q�$��8��$	��Top=�$	��106���� -   $��btnInserisci��$��	Inserisci��$��26��$
��Left=�$��167,323,0,0q�$��8��$	��Top=�$	��106��