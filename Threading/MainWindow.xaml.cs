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
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;

namespace Threading
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public event EventHandler changeText = delegate { };

        MainContext c = new MainContext();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = c;
        }

        event EventHandler CounterChanged;
        event EventHandler JobComplete;

        void BackgroundJob()
        {
          
            while (true)
            {
              
                Thread.Sleep(100);
             

                CounterChanged(this, new EventArgs());
                Debug.WriteLine(i);

                if (i > 10)
                    break;
            }
            JobComplete(this, new EventArgs());
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(BackgroundJob);
            CounterChanged += MainWindow_CounterChanged;
            JobComplete += MainWindow_JobComplete;
            task.Start();
        }

        private void MainWindow_JobComplete(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            c.Display = "Complete";
        }

        int i = 0;
        private void MainWindow_CounterChanged(object sender, EventArgs e)
        {
            i++;
            c.Display = i.ToString();
           
        }
    }

    class MainContext: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        string _display;

        public string Display
        {
            set { _display = value; PropertyChanged(this, new PropertyChangedEventArgs("Display")); }
            get { return _display; }
        }
    }
    
}
