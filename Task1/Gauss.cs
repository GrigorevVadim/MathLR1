namespace MathLR1.Task1
{
    public class Gauss
    {
        private int n { get; set; }
        private double[,] A { get; set; } 
        private double[] b { get; set; }
        private double[] result { get; set; }

        public Gauss(int n, double[,] A, double[] b)
        {
            this.n = n;
            this.A = A;
            this.b = b;
            
            UserConsole.PrintNumber("Порядок системы, n", n);
            UserConsole.PrintMatrix("Матрица системы, A", A, n);
            UserConsole.PrintVector("Правая часть системы, b", b);
        }
        
        public void Triangle()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double koef =  A[j,i] / A[i,i];
                    for (int k = i; k < n; k++) 
                    {
                        A[j,k] = A[j,k] - A[i,k] * koef;
                    }
                    b[j] = b[j] - b[i] * koef;
                }
            }
            UserConsole.PrintMatrix("Треугольная матрица", A, n);
            UserConsole.PrintVector("Вектор b", b);
        }
        
        public void Calculate()
        {
            result = new double[n];
	
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    result[i] = result[i] - A[i,j] * result[j];
                }
                result[i] = result[i] / A[i,i];
            }

            UserConsole.PrintVector("Решение СЛАУ", result);
        }
        
        public void Verification()
        {
            var epsilon = new double[n];
            
            for (int i = 0; i < n; i++)
            {
                epsilon[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    epsilon[i] = A[i,j] * result[j] + epsilon[i];
                }
                epsilon[i] = b[i] - epsilon[i];
            }
            UserConsole.PrintVector("Невязка", epsilon);
        }
    }
}