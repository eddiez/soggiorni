   M S B A M L   `   `   `  ����  	Soggiorni)    #Soggiorni.CambiaPeriodoCameraWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Cambia Periodo e/o Camera��5   	   $	��312��6+   $	��321��68      sfondoWindow#���   6D    � 
ResizeMode$ NoResize=�6p    � WindowStartupLocation$ CenterScreen=�6�   .��5      � .+�5   
   �� -   5        $��	txtArrivo��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	39,14,0,0q�6�   $��Arrivo��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��datePickerArrivo��5   ^   $��14(�6   $��25��6#   $
��Left=�6/   $��
117,12,0,0q�6J   $	��Top=�6v   $	��133��6�   6�   �� 5	   
   -   5        $��txtPartenza��5	   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	39,45,0,0q�6�   $��Partenza��6�   $	��Top=�6�     5
   
   -   5        $��datePickerPartenza��5
   ^   $��14(�6   $��25��6#   $
��Left=�6/   $��
117,43,0,0q�6J   $	��Top=�6x   $	��133��6�   6�   �� 5   
   -   5        $��	txtCamera��5   �   $��Segoe UI)�6   $��14(�6*   $��Normal"�68   
���   �$��23��6_   $
��Left=�6k   $��	39,74,0,0q�6�   $��Camera��6�   $	��Top=�6�   �� 5   
   -   5        $��	cbxCamere��5   �    �� DisplayMemberPath$ Numero��6+    �� SelectedValuePath$ Numero��6F   $��23��6a   $
��Left=�6m   $��
117,74,0,0q�6�   $	��Top=�6�   $	��133��6�   ��6   �� 6�   � 5   
   -   5        $��gridVerificaDisp��5   a   ���	#FFF2F2F2$��99��6&   $
��Left=�62   $��
39,117,0,0q�6M   $	��Top=�6�   $	��211��6�    J� OpacityMask 6y   Z� .+�5      �� -   5        $��btnVerificaDisp��5   �   $��Verifica disponiblità��63   $��Segoe UI)�6S   $��14(�6i   $��Italic$�6w   $
��Bold"�6�   $��23��6�   $
��Left=�6�   $��21,6,0,0q�6�   $	��Top=�6�   $��Center=�6  $	��163��6&  A� 5      -	   5        $��ellipseSemaforo��5   ^     semaforoGrigio#���  6   $��60��6>   $��
76,33,68,0q�6J   
�������$	��Top=�6�   $��60��6�    J� BitmapEffect 5      F� 5       F� Color$ Black��6-    F� 	Direction$	 320Q�6;   	 F� Opacity$		 0.5Q�6K   
 F� ShadowDepth$
 5Q�6Y    F� Softness$	 0.3Q�6i   5      5      �� 5   
   -
   5        $��btnModifica��5   _   $��Modifica��6   $��25��6$   $
��Left=�60   $��
72,230,0,0q�6K   $	��Top=�6r   $��86��6�   6�   �� 5   
   -   5        $��
btnAnnulla��5   _   $��Annulla��6   $��25��6#   $
��Left=�6/   $��164,230,0,0q�6J   $	��Top=�6q   $��86��6�   6�   5      5      