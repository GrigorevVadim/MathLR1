using System;

namespace MathLR1.Task4
{
    public static class SourceData
    {
        public static double[] CreateSourceGreed()
        {
            var greed = new double[26];
            for (int i = 0; i < greed.Length; i++)
            {
                greed[i] = 1 + i * 2;
            }

            return greed;
        }

        public static double[] CreateValues(double[] sourceGreed)
        {
            var resultGreed = new double[sourceGreed.Length];
            for (int i = 0; i < resultGreed.Length; i++)
            {
                resultGreed[i] = InvokeSourceFunction(sourceGreed[i]);
            }

            return resultGreed;
        }

        public static double[] CreateResultGreed()
        {
            var greed = new double[51];
            for (int i = 0; i < greed.Length; i++)
            {
                greed[i] = 1 + i;
            }

            return greed;
        }
        
        public static double InvokeSourceFunction(double arg) => 
            1 / (1 + Math.Log10(arg));
    }
}