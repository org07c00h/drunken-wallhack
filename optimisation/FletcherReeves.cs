using System;

namespace optimisation
{
	public static class FletcherReeves
	{
		public static Vector2 FindMin(Vector2 x, double EPS)
		{
			int i = 0;
			double alpha;
			Vector2 grad = Rosenbrock.Gradient (x);
			Vector2 d = -1 * Rosenbrock.Gradient (x);
			double prevGradSquare;

			do {
				i++;
				prevGradSquare = grad.Norm * grad.Norm;

				alpha = Rosenbrock.GoldenSearch(x, d);
				x += alpha * d;
				grad = Rosenbrock.Gradient(x);

				if(i % 2 == 0)
				{
					d = -1 * grad;
				}
				else
				{
					double beta = grad.Norm * grad.Norm / prevGradSquare;
					d = beta * d - grad;
				}


			} while(d.Norm > EPS);

			return x;
		}
	}
}

