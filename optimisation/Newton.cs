using System;

namespace optimisation
{
	public static class Newton
	{
		//Обратная матрица Гессе
		private static double[,] InverseHessian(Vector2 p)
		{
			double[,] H = new double[2, 2] { {200, 400 * p.X}, {400 * p.X, 1200 * p.X * p.X - 400 * p.Y + 2} };

			double det = H[0, 0] * H[1, 1] - H[0, 1] * H[1, 0];

			for (int i = 0; i < 2; i++)
				for (int j = 0; j < 2; j++)
					H[i, j] /= det;

			return H;
		}

		public static Vector2 FindMin(Vector2 p, double eps)
		{
			Vector2 p0;
			double[,] H;

			Vector2 grad;

			do
			{
				p0 = p.Copy();
				H = Newton.InverseHessian(p0);
				grad = Rosenbrock.Gradient(p0);

				p -= (H * grad);

			} while ((p - p0).Norm > eps);

			return p;
		
		}
	}
}

