using System;

namespace optimisation
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Vector2 x = FletcherReeves.FindMin (new Vector2 (0, -5), 1e-7);
			//Console.WriteLine ("({0}; {1})", x.X, x.Y);
			//RProp.FindMin ();
			Armjo.Solve (new Vector2 (5, -5), 1e-7);
		}


	}
}
