namespace MathLR1.Task4
{
    internal class Program
    {
        public static void Main()
        {
            var lagrange = new Lagrange();
            lagrange.Init();
            lagrange.Calculate();
            
            UserConsole.Wait();
        }
    }
}