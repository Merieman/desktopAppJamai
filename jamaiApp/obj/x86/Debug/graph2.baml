   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	    jamaiApp   jamaiApp.graph2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  Graph ��5   	   $	��450��6   $	��800��6%    � WindowState$ 	Maximized=�61   .��5      �  � ColumnDefinitions 5   
   �� 5	      $
��431* �6   �� 5
      $
��369* �6   .+�5   
   �� -   5        $��Image1��5   7   $��44��6   $
��Left=�6   $
��Fill=�6E   $	��Top=�6T   $	��121��6l   $ ��/output-onlinepngtools.png��6x   o� 5   
   -   5        $��Menu1��5   I   $��25��6   $
��Left=�6   $��	177,0,0,0q�66   $	��Top=�6V   $	��192��6n   
����������	#FF407BFF$��1��6�   .@�5      m� -   5        $��Retour��5      $��14(�6'   $��Normal"�65   6I   m� 5      -   5         m�Name$ user1��5      $
��User��6&   $��14(�64   $��Normal"�6B   m� 5      -   5        $��	MenuItem1��5   :   $��Déconnexion��6   $��14(�6,   6:   5      #   LiveCharts.Wpf.CartesianChart  5   
   $��
10,98,20,0q�6   $��2��61   &    LiveCharts.Wpf.Charts.Base.Chart   Series 5         LiveCharts.Wpf.LineSeries     LiveCharts.Wpf.Series   Title$ Température��6!      Stroke �#1B5E20   Values 65   �� *
DataPoints+   PointGeometry 6d   Z�   5      $ Consigne��6!    �#FF0000 62   �� *DataPoints2+ 6b   Z� 	   AxisX	 5         LiveCharts.Wpf.Axis  
   Title$
 X Axis��6      AxisY 5        $
 Y Axis��6   5      �� 5   
   -   5         ��Name$ n_charge��5      $��Label��6"   $
��Left=�62   $��	10,57,0,0q�6M   $	��Top=�6`   $	��228��6x    J� OpacityMask
 �   ����	#FF6EB2E6���	#FFFBF8F8��5       �� 5!       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5"      �  � Color$ Black��6#   � 5#      $ 	#FFDA4839��6#    � Offset$ 1Q�65   5$      5&      �� 5'   
   -   5        $ 	consigne1��5'      $��Label��6#   $
��Left=�63   $��
283,57,0,0q�6N   $	��Top=�6b   $	��224��6z   $��2��6�   ���	#FF6EB2E6
�������6�   5(      5)      