using System;

namespace optimisation
{
	public static class Armjo
	{
		private const double delta1 = 0.3;
		private const double delta2 = 0.75;
		private const double alphaMax = 2;

		public static Vector2 FindMin(Vector2 x0, double eps)
		{
			double alpha;
			double f;
			Vector2 grad;
			int i = 0;
			Vector2 x;

			do {
				//Устанавливаем максимальное значение alpha
				alpha = 2 * alphaMax;
				//Вычисляем градиент в x_k
				grad = Rosenbrock.Gradient (x0);
				//Проверяем условие Армихо
				do {
					i++;
					alpha /= 2;
					x = x0 - alpha * grad;
					f = (Rosenbrock.F (x0) - Rosenbrock.F (x)) / (alpha * grad.Norm * grad.Norm);

				} while (!((delta1 < f) && (f < delta2)));

				x = x0.Copy ();
				x0 -= alpha * Rosenbrock.Gradient (x0);

			} while((x - x0).Norm > eps);
			return x;
		}
	}
}

