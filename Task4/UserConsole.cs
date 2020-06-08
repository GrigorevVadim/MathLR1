using System;

namespace MathLR1.Task4
{
    public static class UserConsole
    {
        public static bool GetValue(string str, out int value, int minValue, int maxValue)
        {
            Console.Write($"{str} от {minValue} до {maxValue}: ");
            var stringUserValue = Console.ReadLine();
            return 
                int.TryParse(stringUserValue, out value) 
                && value >= minValue 
                && value <= maxValue;
        }
        public static void PrintString(string str)
        {
            Console.WriteLine(str);
        }
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

        public static void PrintTable(params (string name, double[] values)[] table)
        {
            foreach (var headString in table) 
                Console.Write($"{headString.name,30}");
            Console.WriteLine();
            
            for (int i = 0; i < table[0].values.Length; i++)
            {
                for (int j = 0; j < table.Length; j++)
                {
                    Console.Write($"{table[j].values[i],30}");
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