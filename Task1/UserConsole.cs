using System;

namespace MathLR1.Task1
{
    public static class UserConsole
    {
        public static void PrintNumber<T>(string str, T num)
        {
            Console.WriteLine($"{str}:\n{num}");
        }
        
        public static void PrintVector(string str, double[] vector)
        {
            Console.WriteLine($"{str}: ");
            foreach (var d in vector)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine();
        }
        
        public static void PrintMatrix(string str, double[,] matrix, int n)
        {
            Console.WriteLine($"{str}: ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void Wait()
        {
            Console.ReadKey();
        }
    }
}