using System;
using System.Collections.Generic;

namespace MathLR1.Task4
{
    public class Lagrange
    {
        private int Polynomial { get; set; }
        private List<double> SourceGreed { get; set; }
        private List<double> SourceValue { get; set; }
        private List<double> ResultGreed { get; set; }
        private double[] ResultValue { get; set; }
        private double[] ResultError { get; set; }

        public Lagrange()
        {
            SourceGreed = new List<double>();
            SourceValue = new List<double>();
            ResultGreed = new List<double>();
        }

        public void Init()
        {
            var h = 2;
            
            for (int x = 1; x <= 51; x += h)
            {
                SourceGreed.Add(x);
                SourceValue.Add(1/(1 + Math.Log10(x)));
            }

            for (int j = 0; j <= 50; j++)
            {
                ResultGreed.Add(1 + j * h / 2);
            }

            Polynomial = 5;
            
            ResultValue = new double[ResultGreed.Count];
            ResultError = new double[ResultGreed.Count];
            
            UserConsole.PrintVector("Исходная сетка узлов интерполяции", SourceGreed);
            UserConsole.PrintVector("Значения интерполяционной функции", SourceValue);
            UserConsole.PrintVector("Новая сетка узлов, на которой необходимо вычислить значения функции", ResultGreed);
            UserConsole.PrintNumber("Порядок полинома", Polynomial);
        }

        public void Calculate()
        {
            for (int j = 0; j < ResultGreed.Count; j++)
            {
                ResultValue[j] = LagrangePnCalculate(ResultGreed[j]);
                ResultError[j] = LagrangeRnCalculate(ResultGreed[j]);
            }

            UserConsole.PrintVector("Новая сетка", ResultGreed);
            UserConsole.PrintVector("Значение полинома на новой сетке", ResultValue);
            UserConsole.PrintVector("Погрешность интерполирования", ResultError);
        }
        
        private double LagrangePnCalculate(double cur)
        {
            double sum = 0;
            for (int i = 0; i < SourceGreed.Count; i++)
            {
                double temp = SourceValue[i];
                for (int j = 0; j < SourceGreed.Count; j++)
                {
                    if (i == j) continue;
                    temp *= (cur - SourceGreed[j]);
                    temp /= (SourceGreed[i] - SourceGreed[j]);
                }
                sum += temp;
            }

            return sum;
        }

        private double LagrangeRnCalculate(double cur)
        {
            double sum = 0;
            for (int i = 0; i < SourceGreed.Count; i++)
            {
                double temp1 = SourceValue[i];
                for (int j = 0; j < SourceGreed.Count; j++)
                {
                    if (i == j) continue;
                    temp1 /= (SourceGreed[i] - SourceGreed[j]);
                }
                sum += temp1;
            }

            double temp2 = sum;
            for (int j = 0; j < Polynomial; j++)
            {
                temp2 *= (cur - SourceGreed[j]);
            }

            return temp2;
        }
    }
}