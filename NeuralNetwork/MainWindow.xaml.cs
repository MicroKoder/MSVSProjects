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

namespace NeuralNetwork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NeuralNet net = new NeuralNet(2, 2, 2, 0.3);

        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double[,] a = new double[2, 3] { { 0.9, 0.3, 0.4 }, { 0.2, 0.8,0.2 } };
            double[] b = new double[3] {0.9, 0.1, 0.3 };
            double[] r= Extras.dot(a, b);

            label.Content = String.Format("{0}, {1}, {2}", r[0], r[1], r[2]);
        }
    }
}
