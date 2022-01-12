using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetwork;


namespace DrawingForms
{
    public partial class Form1 : Form
    {
        float w, h;

        NeuralNetwork.NeuralNet neural;

        public Form1()
        {
            InitializeComponent();

            w = 32;
            h = 32;
            Bitmap bitmap = new Bitmap((int)w, (int)h, PixelFormat.Format24bppRgb);
            pictureBox1.Image = bitmap;

            neural = new NeuralNet(32*32,100,5,0.3);
        }

        bool doDraw;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            doDraw = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            doDraw = false;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            doDraw = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap((int)w, (int)h, PixelFormat.Format24bppRgb);
            pictureBox1.Image = bitmap;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            if (sav.ShowDialog() == DialogResult.OK)
                neural.Save(sav.FileName);



        }

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                neural.Load(open.FileName);
        }

        private void button_train_Click(object sender, EventArgs e)
        {
            Bitmap bmp = pictureBox1.Image as Bitmap;
            double[] indata = new double[(int)h*(int)w];
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    indata[i*(int)h+j]=  (double)(bmp.GetPixel(i, j).B)/265 +0.01;

            double[] trainOutputs = new double[5];
            trainOutputs[0] = double.Parse(textBox1.Text, System.Globalization.NumberStyles.Float);
            trainOutputs[1] = double.Parse(textBox2.Text);
            trainOutputs[2] = double.Parse(textBox3.Text);
            trainOutputs[3] = double.Parse(textBox4.Text);
            trainOutputs[4] = double.Parse(textBox5.Text);

            neural.Train(indata,trainOutputs);
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            Bitmap bmp = pictureBox1.Image as Bitmap;
            double[] indata = new double[(int)h * (int)w];
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    indata[i * (int)h + j] = (double)(bmp.GetPixel(i, j).B) / 265 + 0.01;

            double[] outputs = neural.Query(indata);

            textBox1.Text = outputs[0].ToString("F3");
            textBox2.Text = outputs[1].ToString("F3");
            textBox3.Text = outputs[2].ToString("F3");
            textBox4.Text = outputs[3].ToString("F3");
            textBox5.Text = outputs[4].ToString("F3");

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!doDraw) return;

            float picW = pictureBox1.Width;
            float picH = pictureBox1.Height;

            int x = (int)((float)e.X * w / picW);
            int y = (int)((float)e.Y * h / picH);

            int iw = (int)w;
            int ih = (int)h;

            Bitmap bmp = pictureBox1.Image as Bitmap;


            lightPixel(bmp,x,y,20);
            lightPixel(bmp, x - 1, y, 10);
            lightPixel(bmp, x, y-1 , 10);
            lightPixel(bmp, x + 1, y, 10);
            lightPixel(bmp, x , y + 1, 10);


            lightPixel(bmp, x - 1, y -1 , 5);
            lightPixel(bmp, x + 1, y - 1, 5);
            lightPixel(bmp, x - 1, y + 1, 5);
            lightPixel(bmp, x + 1, y + 1, 5);

            pictureBox1.Invalidate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0.99";
            textBox2.Text = "0.01";
            textBox3.Text = "0.01";
            textBox4.Text = "0.01";
            textBox5.Text = "0.01";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0.01";
            textBox2.Text = "0.99";
            textBox3.Text = "0.01";
            textBox4.Text = "0.01";
            textBox5.Text = "0.01";

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0.01";
            textBox2.Text = "0.01";
            textBox3.Text = "0.99";
            textBox4.Text = "0.01";
            textBox5.Text = "0.01";

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0.01";
            textBox2.Text = "0.01";
            textBox3.Text = "0.01";
            textBox4.Text = "0.99";
            textBox5.Text = "0.01";

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "0.01";
            textBox2.Text = "0.01";
            textBox3.Text = "0.01";
            textBox4.Text = "0.01";
            textBox5.Text = "0.99";

        }

        void lightPixel(Bitmap bmp, int x, int y,int a)
        {
            if (x >= 0 && y >= 0 && x < bmp.Width && y < bmp.Height)
            {
                int new_a = bmp.GetPixel(x, y).B + a;
                if (new_a > 255)
                    new_a = 255;
                bmp.SetPixel(x, y,Color.FromArgb(255,255,new_a));
            }
        }
    }
}
