using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDrawing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        List<Line> lines = new List<Line>();
        private void canvas_Loaded(object sender, RoutedEventArgs e)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 100000; i++)
            {
                Line line = new Line() {    X1 = rand.Next(0, (int)canvas.ActualWidth), Y1 = rand.Next(0, (int)canvas.ActualHeight),
                                            X2 = rand.Next(0, (int)canvas.ActualWidth), Y2 = rand.Next(0, (int)canvas.ActualHeight)
                };
                line.Stroke = Brushes.DarkBlue;
                Canvas.SetLeft(line, 0);
                Canvas.SetTop(line, 0);
                
                canvas.Children.Add(line);
            }
        }
        int left = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime t1 = DateTime.Now;
            foreach (UIElement item in canvas.Children)
            {
                Canvas.SetLeft(item, left);
            }
            left++;
            DateTime t2 = DateTime.Now;

            label.Content = (t2 - t1).Milliseconds;
        }
    }
}
