using System;

namespace optimisation
{
	public static class RProp
	{
		private const double deltaMax_ = 50;
		private const double deltaMin_ = 0;
		private const double etaMinus_ = 0.5;
		private const double etaPlus_ = 1.5;

		public static Vector2 FindMin(Vector2 point, double EPS)
		{

			Vector2 delta = new Vector2(0.1, 0.1);
			Vector2 df;
			Vector2 dfPrev = new Vector2 (0, 0);


			do {

				df = Rosenbrock.Gradient(point);
				for(int i = 0; i < 2; i++)
				{
					double product = df[i] * dfPrev[i];
					if(product > 0)
					{
						delta[i] = Math.Min(delta[i] * etaPlus_, deltaMax_);
						point[i] -= Math.Sign(df[i]) * delta[i];
						dfPrev[i] = df[i];
					}
					else if(product < 0)
					{
						delta[i] = Math.Max(delta[i] * etaMinus_, deltaMin_);
						dfPrev[i] = 0;
					}
					else
					{
						point[i] -= Math.Sign(df[i]) * delta[i];
						dfPrev[i] = df[i];
					}
				}
			} while (df.Norm > 1e-7);



			return point;
		}


	}
}

