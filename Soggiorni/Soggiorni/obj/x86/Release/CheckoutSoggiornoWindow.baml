   M S B A M L   `   `   `  ����   	Soggiorni'    !Soggiorni.CheckoutSoggiornoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Checkout Soggiorno��$	��515��$	��400��   sfondoWindow#���    � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+��� -   $��btnNewPagamento��$��31��$
��Left=�$��	12,25,0,0q�$	��Top=�$	��150��.����  �� Orientation$ 
Horizontal=�.+��� $;��5/Soggiorni;component/Images/1297203264_piggy_bank.ico��$
��None=��� $��5,0,0,0q�$��Nuovo pagamento���� -   $��btnPagamEsist��$��31��$
��Left=�$��
188,25,0,0q�$	��Top=�$	��150��.���� $ 
Horizontal=�.+��� $*��$/Soggiorni;component/Images/find.png��$
��None=��� $��5,0,0,0q�$��Aggiungi a pagamento��� -   $��gridDatiPag��$��0,80,0,0q�$	��345��$	��Top=�.+��� -   $��stackPanelTipo��$ 
Horizontal=�$��48��$	��Top=�$
��Left=�$	��398�����	#FF8D4600.+�	� -   $��radioButtonFatt�� 	� 	GroupName$ tipoPagamento�� d� 	IsChecked$
 TrueY�$��60,0,0,0q�$��Fattura��$��16��$
��Bold"����	#FFFFFFC1	� -   $��radioButtonRicFisc��$ tipoPagamento��$��85,0,0,0q�$��Ricevuta Fiscale��$��16��$
��Bold"����	#FFFFFFC1�� -   $��	txtboxNum��$��30��$
��Left=�$��	90,96,0,0q�$	��Top=�$��52��$��16(��� -   $��txtNum��$��30��$
��Left=�$��	12,99,0,0q�$��Numero��$	��Top=�$��16(�$��Normal"�(  "System.Windows.Controls.DatePicker  -	   $��datePickerData��$��30��$
��Left=�$��
211,96,0,0q�$	��Top=�$	��127��$��16(��� -
   $��txtData��$��16(�$��Normal"�$��30��$
��Left=�$��156,100,0,0q�$
��Data��$	��Top=��� -   $��
txtboxDest��$��26��$
��Left=�$��156,139,0,0q�$	��Top=�$	��182��$��14(��� -   $��txtDest��$��23��$
��Left=�$��
12,142,0,0q�$��Destinatario��$	��Top=�$��14(��� -   $��
txtboxSede��$��14(�$��26��$
��Left=�$��156,176,0,0q�$	��Top=�$	��182���� -   $��txtSede��$��14(�$��23��$
��Left=�$��
12,179,0,0q�$��Indirizzo sede/resid.��$	��Top=��� -   $��
txtboxPiva��$��14(�$��26��$
��Left=�$��156,214,0,0q�$	��Top=�$	��182���� -   $��txtPiva��$��14(�$��23��$
��Left=�$��
12,217,0,0q�$��Partita IVA��$	��Top=��� -   $��txtboxCf��$��14(�$��26��$
��Left=�$��156,253,0,0q�$	��Top=�$	��182���� -   $��txtCf��$��14(�$��23��$
��Left=�$��
12,256,0,0q�$��Codice Fiscale��$	��Top=��� -   $��
txtboxNote��$��14(�$��26��$
��Left=�$��156,292,0,0q�$	��Top=�$	��182���� -   $��txtNote��$��14(�$��23��$
��Left=�$��
12,295,0,0q�$��Note pagamento��$	��Top=��� -   $��txtLastFattura��$��23��$
��Left=�$��	12,53,0,0q�$�� ��$	��Top=�$��12(����	#BC8D4600�� -   $��txtLastRicFisc��$��12(�$��23��$
��Left=�$��	12,71,0,0q�$�� ��$	��Top=����	#BC8D4600�� -   $��	btnCFCalc��$��26��$
��Left=�$��344,253,0,0q�$	��Top=�$��34��.���� $0��*/Soggiorni;component/Images/calculator.png���� -   $��btnSalva��$��Salva��$��31��$
��Left=�$��248,441,0,0q�$	��Top=�$��90���� -   $��btnDissocia��$��Dissocia��$��31��$
��Left=�$��
12,441,0,0q�$	��Top=�$��90���� -   $��
separator2��
���   �$��2q�$��5��$
��Left=�$��	0,420,0,0q�$	��Top=�$	��435��