using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualKeyboard
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> buttons = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();

            for (int i=0; i<4; i++)
                for(int j=0; j<4; j++)
                {
                    if (i == 3 && j == 3)
                        break;

                    Button btn = new Button();
                    btn.Content = (i * 4 + j).ToString();
                    Grid.SetColumn(btn, j);
                    Grid.SetRow(btn, i);

                    if (i == 3 && j == 2)
                        Grid.SetColumnSpan(btn, 2);

                  

                    grid.Children.Add(btn);
                    buttons.Add(btn);

                    
                }
        }
    }
}
