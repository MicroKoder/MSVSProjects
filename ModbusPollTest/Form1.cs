using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusPollTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort port=null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (port == null)
            {
                port = new SerialPort("COM11", 9600, Parity.None, 8, StopBits.One);
              
                port.Open();

                textBox1.Text += "Port is open"+Environment.NewLine;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!port.IsOpen)
                textBox1.Text += "port not open";

            byte[] data = new byte[] { 0x03 , 0x08,  0x00 , 0x00 , 0x50 , 0xB8, 0xDD, 0x9B };

            port.Write(data,0,data.Length);
            textBox1.Text += BitConverter.ToString(data) + Environment.NewLine;

            System.Threading.Thread.Sleep(100);

            int receivedCount = port.BytesToRead;

            byte[] received = new byte[receivedCount];
            port.Read(received, 0, receivedCount);

            textBox1.Text += "Resp: " + BitConverter.ToString(received) + Environment.NewLine;
            
        }
    }
}
