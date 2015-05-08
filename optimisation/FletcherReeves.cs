using System;

namespace optimisation
{
	public static class FletcherReeves
	{
		public static Vector2 FindMin(Vector2 x, double EPS)
		{
			int i = 0;
			Vector2 d = -1 * Rosenbrock.Gradient (x);
			double alpha;
			do {
				alpha = Rosenbrock.GoldenSearch(x, d);
				if(i % 2 == 0)
				{
					x = x + alpha * d;
					Vector2 grad = Rosenbrock.Gradient(x);
					double beta = (grad * grad) / (d * d);
					d = beta * d - grad;

				}
				else
				{
					x = x + alpha * d;
					d = -1 * Rosenbrock.Gradient(x);
				}


				i++;
			} while(d.Norm > EPS);

			return x;
		}
	}
}

