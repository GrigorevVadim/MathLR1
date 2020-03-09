using System;
using System.Text;

namespace MathLR1.Task1
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var gauss = new Gauss(SourceData.n, SourceData.A, SourceData.b);
            gauss.Triangle();
            gauss.Calculate();
            gauss.Verification();
            
            UserConsole.Wait();
        }
    }
}