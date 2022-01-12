using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TasksNForms
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Task.Run(TaskAction);
        }

        void TaskAction()
        {
            int p = 0;
            while (p<100)
            {
                p += 10;
    
                    MyContext.instance.Percentage = p;
           

                System.Threading.Thread.Sleep(100);
            }
        }
    }

   
    public class MyContext:INotifyPropertyChanged
    {
        public static MyContext instance = null;

        public MyContext()
        {
            instance = this;
        }
        int _p = 0;
        public int Percentage 
        { 
            set
            {
                _p = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Percentage"));
            }
            get
            {
                return _p;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
