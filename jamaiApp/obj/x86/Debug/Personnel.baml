   M S B A M L   `   `   `  ����  jamaiApp    jamaiApp.Personnel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	Personnel��5   	    � WindowState$ 	Maximized=�6   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   o� $��0��6   $��2��6   $��Right=�6,   
����������	#FF407BFF.@�5      m� -   5        $��Retour��5      $��14(�6'   $��Normal"�65   6I   m� 5      -   5         m�Name$ user1��5      $
��User��6&   $��14(�64   $��Normal"�6B   m� 5      -   5        $��	MenuItem1��5   :   $��Déconnexion��6   $��14(�6,   6K   5      �� 5   
   $ ��/output-onlinepngtools.png��6   $��49��64   $	��133��6@   $
��Left=�6L   $	��Top=�6g   $��10q�6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ userDataGrid��5      $��1��6)   $��0��66   $��3��6F   $��30q�6Z   $��Stretch=�5      $��Stretch=�61      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *id+6H     5      $	 Nom��6%   $	 * 6J   
 62   �� *nom+6J     5       $ Prenom��6%   $	 * 6P   
 65   �� *prenom+6P     5!      $ Initial��6%   $	 * 6R   
 66   �� *	initial+6R     5"      $ Fonction��6%   $	 * 6T   
 67   �� *
fonction+6T     5#      $ Habilitation��6%   $	 * 6\   
 6;   �� *habilitation+6\     5$      $ Equipe��6%   $	 * 6P   
 65   �� *equipe+6P     5%      $ Password��6%   $	 * 6T   
 67   �� *
password+6T     5&      $ Email��6%   $	 * 6N   
 64   �� *email+6N   5(      �� 5*   
   -   5         ��Name$ 	addButton��5*      $��Ajouter��6$   $��2��66   $��2��6C   $��10q�6S   $��Right=�5+      ���	#FF407BFF$��60��6D   
���������6g   Z� 6~   �� 5,   
   -   5        $ afficherButton��5,      $��Afficher��6)   $��2��6<   $��2��6I   $��
47,10,0,10q�6Y   $
��Left=�5-      ���	#FF407BFF$��65��6C   
���������6~   Z� 5.      5/      