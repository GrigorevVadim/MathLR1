using System;
using System.Text;

namespace MathLR1.Task2
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var gauss = new Gauss(SourceData.n, SourceData.A);
            gauss.Triangle();
            gauss.Determenant();
            
            UserConsole.Wait();
        }
    }
}