using System;
using System.Text;

namespace MathLR1.Task4
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var polynomial = 3;
            var sourceGreed = SourceData.CreateSourceGreed();
            var sourceValues = SourceData.CreateSourceValues(sourceGreed, SourceData.InvokeSourceFunction);
            var resultGreed = SourceData.CreateResultGreed();

            PrintSource(polynomial, sourceGreed, sourceValues, resultGreed);
            
            var newton = new Newton(3, sourceGreed, sourceValues, resultGreed);
            var (resultValues, resultResidual) = newton.GetResult();
            
            PrintResult(resultGreed, resultValues, resultResidual);
            
            UserConsole.Wait();
        }

        private static void PrintSource(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            UserConsole.PrintNumber("Порядок полинома", polynomial);
            UserConsole.PrintVector("Исходная сетка узлов", sourceGreed);
            UserConsole.PrintVector("Значения на исходной сетке", sourceValues);
            UserConsole.PrintVector("Новая сетка узлов", resultGreed);
        }

        private static void PrintResult(double[] resultGreed, double[] resultValues, double[] resultResidual)
        {
            UserConsole.PrintVector("Новая сетка узлов", resultGreed);
            UserConsole.PrintVector("Pn", resultValues);
            UserConsole.PrintVector("Rn", resultResidual);
        }
    }
}