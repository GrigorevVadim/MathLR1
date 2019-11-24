using System;

namespace MathLR1.Task3
{
	public class Gauss
	{
		private int n { get; set; }
		private double[,] A { get; set; }
		private double[,] TriangM { get; set; }
		private double[,] E { get; }
		private double[,] Inverse { get; set; }

		public Gauss()
		{
			E = Constants.GetE();
		}

		public void Init()
		{
			n = 3;
			A = new[,]
			{
				{2, -0.24, 1},
				{3, 5, -2},
				{1, -4, 10}
			};

			UserConsole.PrintNumber("Порядок системы, n", n);
			UserConsole.PrintMatrix("Матрица системы, A", A, n);
		}

		public void Triangle()
		{
			TriangM = Calculator.GetMatrixCopy(A, n);

			for (int i = 0; i < n; i++)
			{
				for (int j = i + 1; j < n; j++)
				{
					double koef = TriangM[j,i] / TriangM[i,i];
					for (int k = i; k < n; k++)
					{
						TriangM[j,k] = TriangM[j,k] - TriangM[i,k] * koef;
					}

					for (int k = 0; k < n; k++)
					{
						E[k,j] = E[k,j] - E[k,i] * koef;
					}
				}
			}

			UserConsole.PrintMatrix("Треугольная матрица", TriangM, n);
		}

		public void GaussInverse()
		{
			Inverse = new double[n,n];
			
			for (int i = 0; i < n; i++)
			{
				for (int j = n - 1; j >= 0; j--)
				{
					Inverse[i, j] = E[i, j];
					for (int k = j + 1; k < n; k++)
					{
						Inverse[i, j] = Inverse[i, j] - TriangM[j,k] * Inverse[i, k];
					}

					Inverse[i, j] = Inverse[i, j] / TriangM[j,j];
				}
			}

			Inverse = Calculator.TransposeMatrix(Inverse, n);
			UserConsole.PrintMatrix("Обратная матрица", Inverse, n);
		}

		public void Verification()
		{
			var calc = new double[n,n];
			
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					calc[i,j] = 0;
					for (int k = 0; k < n; k++)
					{
						calc[i,j] += Inverse[i,k] * A[k,j];
					}
				}
			}

			for (int i = 0; i < n; i++)
			{
				calc[i,i] -= 1;
			}

			UserConsole.PrintMatrix("Матрица невязки", calc, n);
		}
	}
}