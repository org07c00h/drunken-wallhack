using System;

namespace optimisation
{

	// <summary>
	// Обычная структура с векторными операциями
	// </summary>
	public struct Vector2
	{
		private double[] p_;

		public double X { 
			get {
				return p_ [0];
			}
			set {
				p_ [0] = value;
			}
		}


		public double Y { 
			get {
				return p_ [1];
			}
			set {
				p_ [1] = value;
			}
		}

		public Vector2(double x, double y) : this()
		{
			p_  = new double[2];
			X = x;
			Y = y;
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

		public static double operator *(Vector2 v1, Vector2 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y;
		}



		public double this[int key]
		{
			get
			{
				return p_[key];
			}
			set {
				p_ [key] = value;
			}
		}

		public double Norm
		{

			get {
				return Math.Sqrt(X * X + Y * Y);

			}

		}


	}

	public static class Rosenbrock
	{
		public static double F(Vector2 p)
		{
			return 100 * (p.Y - p.X * p.X) * (p.Y - p.X * p.X) + (1 - p.X) * (1 - p.X);
		}

		public static Vector2 Gradient(Vector2 p)
		{
			return new Vector2 (2 * (200 * p.X * p.X * p.X  - 200 * p.X * p.Y + p.X  - 1), 200 * p.Y - 200 * p.X * p.X);
		}
	
	}
}

