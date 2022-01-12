using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NeuralNetwork
{
    public class NeuralNet
    {
        int inNodes;
        int hidNodes;
        int outNodes;
        double learningRate;

        double[,] wih;
        double[,] who;

        public NeuralNet()
        {

        }
        public NeuralNet(int inputNodes, int hiddenNodes, int outputNodes, double learningRate)
        {
            inNodes = inputNodes;
            hidNodes = hiddenNodes;
            outNodes = outputNodes;
            this.learningRate = learningRate;

            Random rand = new Random();

     

            wih = new double[hidNodes, inNodes];
            for (int i = 0; i < hidNodes; i++)
                for (int j = 0; j < inNodes; j++)
                    wih[i, j] = (rand.NextDouble() - 0.5) * Math.Pow(hidNodes / 2.0, -0.5);


            who = new double[outNodes,hidNodes];
            for (int i = 0; i < outNodes; i++)
                for (int j = 0; j < hidNodes; j++)
                    who[i, j] = (rand.NextDouble() - 0.5) * Math.Pow(outNodes / 2.0, -0.5);


        }

        public void Train(double[] inputs, double[] trainOutputs)
        {
            // 1. Расчитываем выходы
            // рассчитать входящие сигналы для скрытого слоя hidden_inputs = nuxnpy.dot(self.wih, inputs)
            double[] hidden_inputs = Extras.dot(wih, inputs);
            // рассчитать исходящие сигналы для скрытого слоя hidden_outputs = self.activation_function(hidden_inputs)
            double[] hidden_outputs = new double[hidden_inputs.Length];
            for (int i = 0; i < hidden_outputs.Length; i++)
                hidden_outputs[i] = Extras.Expit(hidden_inputs[i]);
            // рассчитать входящие сигналы для выходного слоя final_inputs = numpy. dot (self. who, hidcLen_outputs)
            double[] final_inputs = Extras.dot(who, hidden_outputs);
            // рассчитать исходящие сигналы для выходного слоя final_outputs = self.асtivation_function(final_inputs)
            double[] final_outputs = new double[final_inputs.Length];
            for (int i = 0; i < final_outputs.Length; i++)
                final_outputs[i] = Extras.Expit(final_inputs[i]);

            double[] errors= Extras.Subtract(trainOutputs, final_outputs);

            //распределение ошибок скрытого слоя
        
            double[] hidden_errors = Extras.dot(Extras.Transpose(who), errors);


            // корректировка весов между скрытым и выходным слоем
            for (int j = 0; j < who.GetLength(1); j++)
                for (int k = 0; k < who.GetLength(0); k++)
                {
                    who[k, j] += learningRate * errors[k] * final_outputs[k] * (1.0 - (final_outputs[k])) * hidden_outputs[j];
                }

            for (int i = 0; i < wih.GetLength(1); i++)
                for (int j = 0; j < wih.GetLength(0); j++)
                {
                    wih[j, i] += learningRate * hidden_errors[j] * hidden_outputs[j] * (1.0 - (hidden_outputs[j])) * inputs[i];
                }
        }

        public double[] Query(double[] inputs)
        {
            // рассчитать входящие сигналы для скрытого слоя hidden_inputs = nuxnpy.dot(self.wih, inputs)
            double[] hidden_inputs = Extras.dot(wih, inputs);
            // рассчитать исходящие сигналы для скрытого слоя hidden_outputs = self.activation_function(hidden_inputs)
            double[] hidden_outputs = new double[hidden_inputs.Length];
            for (int i = 0; i < hidden_outputs.Length; i++)
                hidden_outputs[i] = Extras.Expit(hidden_inputs[i]);
            // рассчитать входящие сигналы для выходного слоя final_inputs = numpy. dot (self. who, hidcLen_outputs)
            double[] final_inputs = Extras.dot(who, hidden_outputs);
            // рассчитать исходящие сигналы для выходного слоя final_outputs = self.асtivation_function(final_inputs)
            double[] final_outputs = new double[final_inputs.Length];
            for (int i = 0; i < final_outputs.Length; i++)
                final_outputs[i] = Extras.Expit(final_inputs[i]);

            return final_outputs;
        }

        public void Save(string filename)
        {
            if (wih == null || who == null)
                return;


            List<byte> bytes = new List<byte>();

            bytes.AddRange(BitConverter.GetBytes(learningRate));
            bytes.AddRange(BitConverter.GetBytes(inNodes));
            bytes.AddRange(BitConverter.GetBytes(hidNodes));
            bytes.AddRange(BitConverter.GetBytes(outNodes));

            for (int i = 0; i < hidNodes; i++)
                for (int j = 0; j < inNodes; j++)
                    bytes.AddRange(BitConverter.GetBytes(wih[i,j]));

            for (int i = 0; i < outNodes; i++)
                for (int j = 0; j < hidNodes; j++)
                    bytes.AddRange(BitConverter.GetBytes(who[i,j]));

            FileStream stream = File.Create(filename);
            stream.Write(bytes.ToArray(), 0, bytes.Count);
            stream.Close();
        }

        public void Load(string filename)
        {
            byte[] data = File.ReadAllBytes(filename);

            learningRate = BitConverter.ToDouble(data,0);
            inNodes = BitConverter.ToInt32(data, 8);
            hidNodes = BitConverter.ToInt32(data, 12);
            outNodes = BitConverter.ToInt32(data, 16);

            wih = new double[hidNodes, inNodes];
            for (int i = 0; i < hidNodes; i++)
                for (int j = 0; j < inNodes; j++)
                    wih[i, j] = BitConverter.ToDouble(data,20 + (i*hidNodes + j) * 8);

            who = new double[outNodes, hidNodes];
            for (int i = 0; i < outNodes; i++)
                for (int j = 0; j < hidNodes; j++)
                    who[i, j] = BitConverter.ToDouble(data, 20 + hidNodes * inNodes * 8 + (i * outNodes + j) * 8);
        }
    }
}
