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

namespace Docking
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

        private void btnPreviousTab_Click(object sender, RoutedEventArgs e)
        {
          //  DockPanel.SetDock(tcSample, Dock.Left);
        }

        private void btnNextTab_Click(object sender, RoutedEventArgs e)
        {
        //   DockPanel.SetDock(tcSample, Dock.Right);
        }

        private void btnSelectedTab_Click(object sender, RoutedEventArgs e)
        {
         //   DockPanel.SetDock(tcSample, Dock.Top);
        }
    }
}
