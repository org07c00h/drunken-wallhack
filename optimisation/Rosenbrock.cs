using System;

namespace optimisation
{

	// Структура двухмерного вектора с базовыми операциями 
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
			return new Vector2 (v1.X + v2.X, v1.Y + v2.Y);
		}

		public static Vector2 operator -(Vector2 v1, Vector2 v2) 
		{
			return new Vector2 (v1.X - v2.X, v1.Y - v2.Y);
		}

		//Умножение на число
		public static Vector2 operator *(double a, Vector2 v) 
		{
			return new Vector2 (a * v.X, a * v.Y);
		}

		//Скалярное произведение
		public static double operator *(Vector2 v1, Vector2 v2)
		{
			return v1.X * v2.X + v1.Y * v2.Y;
		}

		//Умножение на двухмерную матрицу
		public static Vector2 operator *(double[,] m, Vector2 v)
		{
			return new Vector2 (m[0, 0] * v.X + m[0,1] * v.Y, m[1, 0] * v.X + m[1,1] * v.Y);
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

		public Vector2 Copy()
		{
			return new Vector2 (X, Y);
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

		//Поиск минимума по направлению методом золотого сечения
		public static double GoldenSearch(Vector2 x0, Vector2 direction)
		{
			double a = 0;
			double b = 10;
			double x1 = (3 - Math.Sqrt(5))*(b - a) / 2 + a;
			double x2 = (Math.Sqrt(5) - 1) * (b - a) / 2 + a;
			const double e = 1e-8;
			double y1 = F (x0 + x1 * direction);
			double y2 = F (x0 + x2 * direction);
			while ((b-a)/2 > e) {

				if (y1 > y2)
				{
					a = x1;
					x1 = x2;
					x2 = (Math.Sqrt(5) - 1) * (b - a) / 2 + a;
					y1 = y2;
					y2 = F(x0 + x2 * direction);
				}
				else
				{
					b = x2;
					x2 = x1;
					x1 = (3 - Math.Sqrt(5))*(b - a) / 2 + a;
					y2 = y1;
					y1 = F(x0 + x1 * direction);
				}

			}
			return (a + b) / 2;
		}
	}
}

