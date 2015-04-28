using System;

namespace optimisation
{

	// <summary>
	// Обычная структура с векторными операциями
	// </summary>
	public struct Vector2
	{

		public Vector2(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double X {
			get;
			set;
		}

		public double Y {
			get;
			set;
		}

		public static Vector2 operator +(Vector2 v1, Vector2 v2) 
		{
			return new Vector2 (v1.X + v2.X, v1.X + v2.X);
		}

		public static Vector2 operator -(Vector2 v1, Vector2 v2) 
		{
			return new Vector2 (v1.X - v2.X, v1.X - v2.X);
		}

		public static Vector2 operator *(double a, Vector2 v) 
		{
			return new Vector2 (a * v.X, a * v.Y);
		}


	}

	public static class Rosenbrock
	{
		public static double F(double x, double y)
		{
			return 100 * (y - x * x) * (y - x * x) + (1 - x) * (1 - x);
		}

		public static Vector2 Gradient(double x, double y)
		{
			return new Vector2 (-200 * (y - x * x) + 2 - 2 * x, 200 * y - 200 * x * x);
		}
	
	}
}

