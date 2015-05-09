using System;
using System.Diagnostics;
namespace optimisation
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Vector2 x = FletcherReeves.FindMin (new Vector2 (0, -5), 1e-7);
			//Console.WriteLine ("({0}; {1})", x.X, x.Y);

			//FletcherReeves.FindMin (new Vector2 (20, 50), 1e-7);
			//Armjo.Solve (new Vector2 (20, 50), 1e-7);
			/*double[,] m = { { 1, 1 }, { 2, 2 } };
			Vector2 x1 = new Vector2 (1, 1);
			x1 = m * x1;
			Console.WriteLine ("{0}:{1}", x1.X, x1.Y);*/
			//Newton.Solve (new Vector2 (20, 50), 1e-7);
			Stopwatch t = new Stopwatch ();

			Vector2[] point_array = { new Vector2 (5, -5), new Vector2 (0, 5), new Vector2 (10, 10), new Vector2 (20, 50) };

			for (int i = 0; i < point_array.Length; i++) {
				Console.WriteLine ("Armjo");
				t.Start ();
				Vector2 x = Armjo.FindMin (point_array [i].Copy (), 1e-7);
				t.Stop ();
				Console.WriteLine ("Point:\t ({0}, {1})", point_array [i].X, point_array [i].Y);
				Console.WriteLine ("Min:\t ({0}, {1})", x.X, x.Y);
				Console.WriteLine ("Time:\t {0}", t.Elapsed.TotalSeconds);
				Console.WriteLine ("================================");



			}

		}


	}
}
