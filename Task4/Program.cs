using System;
using System.Text;

namespace MathLR1.Task4
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var sourceGreed = SourceData.CreateSourceGreed();
            var sourceValues = SourceData.CreateValues(sourceGreed);
            var resultGreed = SourceData.CreateResultGreed();
            if (!UserConsole.GetValue("Введите порядок полинома", out var polynomial, 1, sourceGreed.Length - 1))
            {
                UserConsole.PrintString($"Введенное значение не распознается как порядок полинома");
                UserConsole.Wait();
                return;
            }

            PrintSource(polynomial, sourceGreed, sourceValues, resultGreed);
            
            var lagrange = new Lagrange(polynomial, sourceGreed, sourceValues, resultGreed);
            var (resultPolynomialValues, resultFunctionValues, resultResidual) = lagrange.GetResult();
            
            PrintResult(resultGreed, resultPolynomialValues, resultFunctionValues, resultResidual);
            
            UserConsole.Wait();
        }

        private static void PrintSource(int polynomial, double[] sourceGreed, double[] sourceValues, double[] resultGreed)
        {
            UserConsole.PrintString("Входные данные:");
            UserConsole.PrintNumber("Порядок полинома", polynomial);
            UserConsole.PrintTable(
                ("x", sourceGreed),
                ("f(x)", sourceValues));
            UserConsole.PrintVector("Новая сетка узлов", resultGreed);
        }

        private static void PrintResult(double[] resultGreed, double[] resultPolynomialValues, double[] resultFunctionValues, double[] resultResidual)
        {
            UserConsole.PrintString("\nВыходные данные:");
            UserConsole.PrintTable(
                ("xi", resultGreed),
                ("f(xi)", resultFunctionValues),
                ("P(xi)", resultPolynomialValues),
                ("R(xi)", resultResidual));
        }
    }
}