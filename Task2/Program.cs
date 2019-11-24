namespace MathLR1.Task2
{
    internal class Program
    {
        public static void Main()
        {
            var gauss = new Gauss();
            gauss.Init();
            gauss.Triangle();
            gauss.Determenant();
            
            UserConsole.Wait();
        }
    }
}