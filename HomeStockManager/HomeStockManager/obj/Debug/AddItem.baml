   M S B A M L   `   `   `  ����K  GHomeStockManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:HomeStockManagerHomeStockManager  5   	       HomeStockManager.AddItem   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:HomeStockManager     5   	     � Title$  Add Item to Storage��5   	   $	��464��6%   $	��586��62    � Icon$ /task-list-add.ico��6>   .��5	      � $��0,0,0,5q�6   .+�5
   
   �� -   5         ��Name$ 
btnAddItem��5
      $	��Add��6%   ���	#FF5948AF
�������$��16(�6]   $��Arial Black)�6k    � Cursor$
 Hand��6�   $��451,386,21,11q�6�   6�   �� 5   
   -   5         ��Name$ lblNameOfItem��5      $'��!Name of the item you want to add:��6'   $��Center=�6S   $	��Top=�6p   $
��Bold"�6�   $��Arial Black)�6�   $��14(�6�   $��0,18,0,0q�6�   �� 5   
   -   5         ��Name$ txtNameOfItem��5      $��Center=�6)   $��0,49,0,0q�6F   $	��Top=�6X   $	��188��6p   $��40��6|   $��20(�6�   $��Arial)�6�    �� TextAlignment$ Center=�6�    �� TextWrapping$
 Wrap=�6�   ���	#FFEFECF56�   �� 5   
   -   5        $ btnVegetablesPreset��5      $�� ��6.   $
��Left=�69   $��
27,133,0,0q�6T   $	��Top=�6h   $��66��6�   $	��102��6�   ��5      �� 5       �� ImageSource$ /vegetables.png��6   5      �� 5   
   -   5        $ btnMeatPreset��5      $�� ��6(   $
��Left=�63   $��132,133,0,0q�6N   $	��Top=�6c   $��66��6{   $	��102��6�   ��5      �� 5      $ 	/meat.png��6   5      �� 5   
   -   5        $ btnDrinksPreset��5      $�� ��6*   $��Center=�65   $��	0,133,0,0q�6R   $	��Top=�6e   $��66��6}   $	��102��6�   ��5      �� 5      $ /drinks.jpg��6   5      �� 5   
   -   5        $ btnCheesePreset��5      $�� ��6*   $
��Left=�65   $��342,133,0,0q�6P   $	��Top=�6e   $��66��6}   $	��102��6�   ��5      �� 5      $ /cheese.png��6   5       �� 5!   
   $��
Vegetables��6   $
��Left=�6%   $��
42,199,0,0q�6@   $	��Top=�6T   $��10(�6l   $��Arial Black)�6z   �� 5"   
   $
��Meat��6   $
��Left=�6   $��164,199,0,0q�6:   $	��Top=�6O   $��10(�6g   $��Arial Black)�6u   �� 5#   
   $��Drinks��6   $��Center=�6!   $��	0,199,0,0q�6>   $	��Top=�6Q   $��10(�6i   $��Arial Black)�6w   �� 5$   
   $��Cheese��6   $
��Left=�6!   $��364,199,0,0q�6<   $	��Top=�6Q   $��10(�6i   $��Arial Black)�6w   �� 5%   
   -   5        $ lblTypeItem��5%      $'��!What type of item are you adding:��6%   $��Center=�6Q   $	��Top=�6n   $
��Bold"�6�   $��Arial Black)�6�   $��14(�6�   $��	0,103,0,0q�6�   $��25��6�   $	��276��6�   (  "System.Windows.Controls.DatePicker  5&   
   -	   5        	  Name$	 
datePicker��5&      $��Center=�6)   $��	0,385,0,0q�6F   $	��Top=�6Y   $��34��6q   $	��188��6}   �� 5'   
   -
   5        $ lblItemExpiry��5'      $��Expiry:��6'   $��Center=�69   $	��Top=�6V   $
��Bold"�6n   $��Arial Black)�6�   $��14(�6�   $��	0,356,0,0q�6�   �� 5(   
   -   5        $ btnFruitPreset��5(      $�� ��6)   $
��Left=�64   $��
28,220,0,0q�6O   $	��Top=�6c   $��66��6{   $	��102��6�   ��5)      �� 5*      $ 
/fruit.png��6   5,      �� 5-   
   $��Fruits��6   $
��Left=�6!   $��
59,287,0,0q�6<   $	��Top=�6P   $��10(�6h   $��Arial Black)�6v   �� 5.   
   -   5        $ btnToppingPreset��5.      $�� ��6+   $
��Left=�66   $��133,220,0,0q�6Q   $	��Top=�6f   $��66��6~   $	��102��6�   ��5/      �� 50      $ /topping.jpg��6   52      �� 53   
   $��Topping��6   $
��Left=�6"   $��159,287,0,0q�6=   $	��Top=�6R   $��10(�6j   $��Arial Black)�6x   �� 54   
   -   5        $ btnMilkPreset��54      $�� ��6(   $��Center=�63   $��	0,220,0,0q�6P   $	��Top=�6c   $��66��6{   $	��102��6�   ��55      �� 56      $ 	/milk.jpg��6   58      �� 59   
   $
��Milk��6   $��Center=�6   $��	0,287,0,0q�6<   $	��Top=�6O   $��10(�6g   $��Arial Black)�6u   �� 5:   
   -   5        $ btnEggPreset��5:      $�� ��6'   $
��Left=�62   $��450,133,0,0q�6M   $	��Top=�6b   $��66��6z   $	��102��6�   ��5;      �� 5<      $ /egg.jpg��6   5>      �� 5?   
   $	��Egg��6   $
��Left=�6   $��484,200,0,0q�69   $	��Top=�6N   $��10(�6f   $��Arial Black)�6t   �� 5@   
   -   5        $ btnSaucePreset��5@      $�� ��6)   $
��Left=�64   $��344,220,0,0q�6O   $	��Top=�6d   $��66��6|   $	��102��6�   ��5A      �� 5B      $ /sauces.png��6   5D      �� 5E   
   $��Sauce��6   $
��Left=�6    $��374,287,0,0q�6;   $	��Top=�6P   $��10(�6h   $��Arial Black)�6v   �� 5F   
   -   5        $ btnOther��5F      $�� ��6#   $
��Left=�6.   $��451,220,0,0q�6I   $	��Top=�6^   $��66��6v   $	��102��6�   ��5G      �� 5H      $ 
/other.png��6   5J      �� 5K   
   $��Other��6   $
��Left=�6    $��481,287,0,0q�6;   $	��Top=�6P   $��10(�6h   $��Arial Black)�6v   �� 5L   
   -   5        $ 	lblPreset��5L      $��Preset:��6#   $
��Left=�65   $��
42,374,0,0q�6P   $	��Top=�6d   $��56��6|   $��96��6�   $��Center=�6�   $��Arial Black)�6�   5M      5N      