using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OUA1
{
    class MainContext : INotifyPropertyChanged
    {
        static public MainContext instance;

        public MainContext()
        {
            instance = this;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string ServerUri { set; get; } = "opc.tcp://10.155.23.64:49152/OPCUAServerExpert";
        public string NodeName { set; get; } = "Demo.Dynamic.Scalar.Int32";

        private string _value;
        public string NodeValue
        {
            set { _value = value; PropertyChanged(this, new PropertyChangedEventArgs("NodeValue")); }
            get { return _value; }
        }

        private string _conStatus="disconected";
        public string ConnectionStatus
        {
            set { _conStatus = value; PropertyChanged(this, new PropertyChangedEventArgs("ConnectionStatus")); }
            get { return _conStatus; }
        }
    }
}
