using System;
using System.Text;

namespace MathLR1.Task3
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            var gauss = new Gauss(SourceData.n, SourceData.A);
            gauss.Triangle();
            gauss.GaussInverse();
            gauss.Verification();
            
            UserConsole.Wait();
        }
    }
}