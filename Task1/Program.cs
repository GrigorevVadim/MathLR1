namespace MathLR1.Task1
{
    internal class Program
    {
        public static void Main()
        {
            var gauss = new Gauss();
            gauss.Init();
            gauss.Triangle();
            gauss.Calculate();
            gauss.Verification();
            
            UserConsole.Wait();
        }
    }
}