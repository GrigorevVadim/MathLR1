namespace MathLR1.Task3
{
    public static class Calculator
    {
        public static double[,] GetMatrixCopy(double[,] source, int n)
        {
			var copy = new double[n,n];
			
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					copy[i,j] = source[i,j];
				}
			}

			return copy;
        }

        public static double[,] TransposeMatrix(double[,] source, int n)
        {
	        var transpose = new double[n,n];

	        for (int i = 0; i < n; i++)
	        {
		        for (int j = 0; j < n; j++)
		        {
			        transpose[j,i] = source[i,j];
		        }
	        }
	        
	        return transpose;
        }
    }
}