   M S B A M L   `   `   `  ����  	Soggiorni)    #Soggiorni.EditSchedinaClienteWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$(  "Modifica dati cliente per schedina��5   	      sfondoWindow#���   64   $	��641��6`   $	��397��6m    � 
ResizeMode$ NoResize=�6y    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� -   5        $��
txtCognome��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	34,44,0,0q�6�   $��Cognome��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxCognome��5   �   $��Segoe UI)�6   $��12(�6(   $��Normal"�66   $��23��6J   $
��Left=�6V   {�. $��
134,44,0,0q�6�   $	��Top=�6�   $	��163��6�   $��1��6�   �� 5   
   -   5        $��txtNome��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	34,73,0,0q�6�   $
��Nome��6�   $	��Top=�6�   �� 5	   
   -   5        $��
txtboxNome��5	   �   $��Segoe UI)�6   $��12(�6(   $��Normal"�66   $��23��6J   $
��Left=�6V   {�. $��
134,73,0,0q�6�   $	��Top=�6�   $	��163��6�   $��2��6�   �� 5
   
   -   5        $��txtAddr��5
   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   $��23��6L   $
��Left=�6X   $��
34,283,0,0q�6s   $��	Indirizzo��6�   $	��Top=�6�   �� 5   
   -   5        $��
txtboxAddr��5   �   $��Segoe UI)�6   $��12(�6(   $��Normal"�66   $��23��6J   $
��Left=�6V   {�. $��134,281,0,0q�6�   $	��Top=�6�   $	��163��6�   $��9��6�   �� 5   
   -   5        $��stackPanelSesso��5   Q   $��52��6   $
��Left=�6!   $��134,100,0,0q�6<    �� Orientation$ Vertical=�6h   $	��Top=�6   $	��163��6�   .+�5      	� -   5        $��radioButtonM��5   f   $��M��6    	� 	GroupName$ Sesso��6&   $��16��68    d� 	IsChecked$
 TrueY�6D   $��0,5,0,0q�6U   $��3��6z   	� 5      -	   5        $��radioButtonF��5   V   $��F��6   $ Sesso��6&   $��16��68   $��0,10,0,0q�6D   $��4��6j   5      �� 5   
   -
   5        $��txtSesso��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,101,0,0q�6�   $��Sesso                    ��6�   $	��Top=�6�   $��38��6�   �� 5   
   -   5        $��txtDataNascita��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,168,0,0q�6�   $��Data nascita��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerNascita��5   Q   $��25��6   $
��Left=�6!   $��134,165,0,0q�6<   $	��Top=�6j   $	��163��6�   $��5��6�   �� 5   
   -   5        $��txtComuneNascita��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,197,0,0q�6�   $��Comune nasc.��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxComuneNascita��5   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�.  �� 
IsReadOnly . $��134,196,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 5   
   -   5        $��txtStatoNascita��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,226,0,0q�6�   $��Stato nascita��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxStatoNascita��5   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�. $��134,225,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 5   
   -   5        $��btnSelectComuneNascita��5   O   $	��...��6   $
��Left=�6   $��303,196,0,0q�6:   $��28��6m   $��6��6�   $��23��6�   $	��Top=�6�   �� 5   
   -   5        $��btnSelectStatoNascita��5   [   $	��...��6   $��23��6   $
��Left=�6+   $��303,225,0,0q�6F   $	��Top=�6x   $��28��6�   $��7��6�   �� 5   
   -   5        $��txtCittadinanza��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,255,0,0q�6�   $��Cittadinanza��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxCittadinanza��5   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�. $��134,254,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 5   
   -   5        $��btnSelectCittadinanza��5   [   $	��...��6   $��23��6   $
��Left=�6+   $��303,254,0,0q�6F   $	��Top=�6x   $��28��6�   $��8��6�   �� 5   
   -   5        $��txtComuneResid��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,314,0,0q�6�   $��Comune resid.��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxComuneResid��5   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�.  . $��134,311,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 5   
   -   5        $��txtStatoResid��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,346,0,0q�6�   $��Stato residenza��6�   $	��Top=�6�   �� 5   
   -   5        $��txtboxStatoResid��5   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�. $��134,344,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 5    
   -   5        $��btnSelectComuneResid��5    O   $	��...��6   $
��Left=�6   $��303,312,0,0q�6:   $��28��6k   $��10��6�   $��23��6�   $	��Top=�6�   �� 5!   
   -   5        $��btnSelectStatoResid��5!   [   $	��...��6   $��23��6   $
��Left=�6+   $��303,345,0,0q�6F   $	��Top=�6v   $��28��6�   $��11��6�   �� 5"   
   -   5        $��
txtTipoDoc��5"   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,403,0,0q�6�   $��Tipo docum.��6�   $	��Top=�6�   �� 5#   
   -   5        $��
cbxTipoDoc��5#   �    �� DisplayMemberPath$ Descrizione��6   $��23��63   $
��Left=�6?   $��134,402,0,0q�6r    �� SelectedValuePath$ Id��6�   $	��Top=�6�   $	��197��6�   $��13��6�   ��6Z   �� 6�   �� 5$   
   -   5        $��	txtNumDoc��5$   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   $��23��6L   $
��Left=�6X   $��
34,432,0,0q�6s   $��N° documento��6�   $	��Top=�6�   �� 5%   
   -   5        $��txtboxNumDoc��5%   �   $��Segoe UI)�6   $��12(�6(   $��Normal"�66   $��23��6J   $
��Left=�6V   {�. $��134,431,0,0q�6�   $	��Top=�6�   $	��163��6�   $��14��6�   �� 5&   
   -    5        $��txtDataRilascioDoc��5&   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
32,461,0,0q�6�   $��Data rilascio��6�   $	��Top=�6�     5'   
   -!   5        $��datePickerRilascioDoc��5'   Q   $��25��6   $
��Left=�6!   $��134,460,0,0q�6<   $	��Top=�6n   $	��163��6�   $��15��6�   �� 5(   
   -"   5        $��txtComuneRilascioDoc��5(   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
32,492,0,0q�6�   $��Comune rilascio��6�   $	��Top=�6�   �� 5)   
   -#   5        $��txtboxComuneRilascioDoc��5)   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�.  . $��134,491,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6   �� 5*   
   -$   5        $��txtStatoRilascioDoc��5*   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
32,521,0,0q�6�   $��Stato rilascio��6�   $	��Top=�6�   �� 5+   
   -%   5        $��txtboxStatoRilascioDoc��5+   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�. $��134,520,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 5,   
   -&   5        $ ��btnSelectComuneRilascioDoc��5,   O   $	��...��6   $
��Left=�6   $��303,491,0,0q�6:   $��28��6q   $��16��6�   $��23��6�   $	��Top=�6�   �� 5-   
   -'   5        $��btnSelectStatoRilascioDoc��5-   [   $	��...��6   $��23��6   $
��Left=�6+   $��303,520,0,0q�6F   $	��Top=�6|   $��28��6�   $��17��6�   �� 5.   
   -(   5        $��txtProvIstat��5.   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��
34,374,0,0q�6�   $��Prov. ISTAT��6�   $	��Top=�6�   �� 5/   
   -)   5        $��txtboxProvIstat��5/   �   
�������$��Segoe UI)�6&   $��12(�6<   $��Normal"�6J   $��23��6^   $
��Left=�6j   {�. $��134,373,0,0q�6�   $	��Top=�6�   $	��163��6�   ��.  6�   �� 50   
   -*   5        $��btnSelectProvIstat��50   [   $	��...��6   $��23��6   $
��Left=�6+   $��303,373,0,0q�6F   $	��Top=�6u   $��28��6�   $��12��6�   �� 51   
   -+   5        $��
btnAnnulla��51   M   $��31��6   $
��Left=�6   $��222,566,0,0q�68   $	��Top=�6_   $��75��6w   $��Annulla��6�   $��14(�6�   $��19��6�   �� 52   
   -,   5        $��btnSalva��52   ]   $��Salva��6   $��31��6!   $
��Left=�6-   $��134,566,0,0q�6H   $	��Top=�6m   $��82��6�   $��14(�6�   $��18��6�   �� 53   
   --   5        $��
textBlock1��53   M   $��27��6   $
��Left=�6    $��34,0,0,0q�6;   $#��I dati sono tutti obbligatori��6_   $	��Top=�6�   $��20(�6�   $	��263��6�   $��Normal$�6�   $��Normal"�6�   $��	Underline{�6�   	 �� TextAlignment$	 Center=�6�   54      55      