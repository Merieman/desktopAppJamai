   M S B A M L   `   `   `  ����  jamaiApp    jamaiApp.AddUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Aav2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Add user��5   	    � WindowState$ 	Maximized=�5   	   $	��349��5	   	   $	��571��5
   	   .��5      (� .��5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      o� $��1��6   $��Right=�6#   
����������	#FF407BFF$��0,2,-152,-2q�6i   .@�5      m� -   5        $��Retour��5      $��14(�6+   $��Normal"�69   6M   m� 5      -   5         m�Name$ user1��5      $
��User��6*   $��14(�68   $��Normal"�6F   m� 5      -   5        $��	MenuItem1��5   >   $��Déconnexion��6   $��14(�60   6>   5      �� 5      $ ��/output-onlinepngtools.png��6   $��41��68   $	��104��6D   $
��Left=�6P   $	��Top=�6k   $��
-152,2,0,0q�6�   �� 5      $	��560��6   $��10q�6%   .+�5      �� $
��Nom:��6   �� 5      -   5         ��Name$ 
nomTextBox��5      �� 5      $��Prénom:��6   �� 5       -   5        $ prenomTextBox��5       �� 5"      $��Date de naissance:��6   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ naissTextBox��5#      �� 5%      $��	Fonction:��6   �� 5&      -   5        $ foncTextBox��5&      �� 5(      $��Date d'embauche:��6     5)      -   5        $ 
embTextBox��5)      �� 5+      $��Date de sortie:��6     5,      -	   5        $ sortieTextBox��5,      �� 5.      $��Mot de passe:��6   G� 5/      -
   5         G�Name$ 
mdpTextBox��5/      �� 51      $��Habilitation:��6   �� 52      -   5        $ 
habTextBox��52      �� 54      $��Email:��6   �� 55      -   5        $ emailTextBox��55      �� 57      $��Téléphone:��6   �� 58      -   5        $ 
telTextBox��58      �� 5:      $��Équipe:��6   �� 5;      -   5        $ 	eqTextBox��5;      �� 5=      $��Initial:��6   �� 5>      -   5        $ initTextBox��5>      5?      �� 5B      -   5         ��Name$ 	addButton��5B   %   $��1��6   $��Ajouter��6P   ���	#FF407BFF$��60��6y   $��10,530,10,0q�6�   $	��Top=�6�   $��25��6�   
�������{�.  ��6�   Z� 6�   5C      5D      5E      