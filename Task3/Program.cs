namespace MathLR1.Task3
{
    internal class Program
    {
        public static void Main()
        {
            var gauss = new Gauss();
            gauss.Init();
            gauss.Triangle();
            gauss.GaussInverse();
            gauss.Verification();
            
            UserConsole.Wait();
        }
    }
}