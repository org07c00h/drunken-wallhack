using System;

namespace optimisation
{
	public static class Armjo
	{
		private const double delta1 = 0.3;
		private const double delta2 = 0.7;
		private const double alphaMax = 2;

		public static Vector2 FindMin(Vector2 x0, double eps)
		{
			double alpha;
			double f;
			Vector2 grad;
			int i = 0;
			Vector2 x;
			double g1;
			double g2;
			do {
				//Устанавливаем максимальное значение alpha
				alpha = 2 * alphaMax;
				//Вычисляем градиент в x_k
				grad = Rosenbrock.Gradient (x0);
				//Проверяем условие Армихо
				x = x0.Copy();
				do {
					i++;
					alpha /= 2;
					x = x0 - alpha * grad;
					f = -(Rosenbrock.F(x) - Rosenbrock.F(x0)) / (alpha * grad.Norm * grad.Norm);

				} while (!((delta1 <= f) && (f <= delta2)) && (alpha > 1e-8));
				if(alpha < 1e-8)
				{

					alpha = 1e-6;
				}
				x = x0.Copy ();
				x0 -= alpha * Rosenbrock.Gradient (x0);

			} while(grad.Norm > eps);
			Console.WriteLine ("Iterations: {0}", i);
			return x;
		}
	}
}

