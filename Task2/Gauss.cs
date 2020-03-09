namespace MathLR1.Task2
{
    public class Gauss
    {
        private int n { get; set; }
        private double[,] A { get; set; } 

        public Gauss(int n, double[,] A)
        {
            this.n = n;
            this.A = A;
            
            UserConsole.PrintNumber("Порядок системы, n", n);
            UserConsole.PrintMatrix("Матрица системы, A", A, n);
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
                }
            }
            UserConsole.PrintMatrix("Треугольная матрица", A, n);
        }

        public void Determenant()
        {
            double determenant = 1;
            for (int i = 0; i < n; i++)
            {
                determenant = A[i,i] * determenant;
            }
            UserConsole.PrintNumber("Определитель", determenant);
        }
    }
}