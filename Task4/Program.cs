using System;

namespace MathLR1.Task4
{
    internal class Program
    {
        public static void Main()
        {
            var sourceGreed = CreateSourceGreed();
            var sourceValues = CreateSourceValues(sourceGreed, InvokeSourceFunction);
            var resultGreed = CreateResultGreed();
            
            var newton = new Newton(3, sourceGreed, sourceValues, resultGreed);
            var (resultValues, resultResidual) = newton.GetResult();
            
            PrintResult(resultGreed, resultValues, resultResidual);
            
            UserConsole.Wait();
        }

        private static double InvokeSourceFunction(double arg) => 
            1 / (1 + Math.Log10(arg));

        private static double[] CreateSourceGreed()
        {
            var greed = new double[26];
            for (int i = 0; i < greed.Length; i++)
            {
                greed[i] = 1 + i * 2;
            }

            return greed;
        }

        private static double[] CreateSourceValues(double[] sourceGreed, Func<double, double> function)
        {
            var resultGreed = new double[sourceGreed.Length];
            for (int i = 0; i < resultGreed.Length; i++)
            {
                resultGreed[i] = function(sourceGreed[i]);
            }

            return resultGreed;
        }

        private static double[] CreateResultGreed()
        {
            var greed = new double[51];
            for (int i = 0; i < greed.Length; i++)
            {
                greed[i] = 1 + i;
            }

            return greed;
        }

        private static void PrintResult(double[] resultGreed, double[] resultValues, double[] resultResidual)
        {
            UserConsole.PrintVector("x", resultGreed);
            UserConsole.PrintVector("Pn", resultValues);
            UserConsole.PrintVector("Rn", resultResidual);
        }
    }
}