using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Extras
    {
        /// <summary>
        /// функция активации
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Expit(double x)
        {
           
            return 1.0/(1.0 + Math.Exp(-x));
        }

        public static double[,] dot(double[,] a, double[,] b)
        {
            int rows_a = a.GetLength(0);
            int cols_a = a.GetLength(1);

            int rows_b = b.GetLength(0);
            int cols_b = b.GetLength(1);

            if (cols_a != rows_b)
                return null;

            double[,] result = new double[rows_b,cols_b];

            for (int row = 0; row < rows_b; row++)
                for (int col = 0; col < cols_b; col++)
                {
                    double sum = 0.0;
                    for (int i = 0; i < rows_b; i++)
                        sum += a[row,i] * b[i,col];

                    result[row, col] = sum;
                }

            return result;
        }

        public static double[] dot(double[,] a, double[] b)
        {
            int rows_a = a.GetLength(0);
            int cols_a = a.GetLength(1);

            int rows_b = b.GetLength(0);

            if (cols_a != rows_b)
                throw new Exception();

            double[] result = new double[rows_a];

            for (int row = 0; row < rows_a; row++)
                {
                    double sum = 0.0;
                    for (int i = 0; i < rows_b; i++)
                        sum += a[row, i] * b[i];

                    result[row] = sum;
                }

            return result;
        }

        ///скалярное произведение столбца на строку
        public static double[,] dot(double[] a, double[] b)
        {
            double[,] r = new double[a.Length, b.Length];

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    r[i, j] = a[i] * b[j];
            return r;
        }
        /// <summary>
        /// Поэлементное вычитание значений массива
        /// </summary>
        /// <param name="a">операнд 1</param>
        /// <param name="b">операнд 2</param>
        /// <returns></returns>
        public static double[] Subtract(double[] a, double[] b)
        {
            double[] r = new double[a.Length];
            for (int i = 0; i < r.Length; i++)
                r[i] = a[i] - b[i];

            return r;
        }

        /// <summary>
        /// поэлементное умножение элементов матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[,] Mul(double[,] a, double b)
        {
            double[,] r = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    r[i, j] = a[i, j] * b;
            return r;

        }

        /// <summary>
        /// поэлементное умножение матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double[] Mul(double[] a, double[] b)
        {
            double[] r = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                r[i] = a[i] * b[i];

            return r;
        }

        /// <summary>
        /// Обновление матрицы весов путем поэлементного сложения
        /// </summary>
        /// <param name="w"></param>
        /// <param name="deltas"></param>
        public static void UpdateWeight(ref double[,] w, double[,] deltas)
        {
            for (int i = 0; i < w.GetLength(0); i++)
                for (int j = 0; j < w.GetLength(1); j++)
                    w[i, j] += deltas[i, j];
        }


        /// <summary>
        /// Транспонирование матрицы
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,] Transpose(double[,] input)
        {
            int cols = input.GetLength(1);
            int rows = input.GetLength(0);

            double[,] r = new double[cols, rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    r[j, i] = input[i, j];

            return r;
        }
    }


}
