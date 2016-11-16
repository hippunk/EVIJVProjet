using System;


namespace Test
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			ArbrePossibilité arbre = new ArbrePossibilité();
			string auxchemin = @"C:\Users\Kevin\Desktop\fichierTestArbrePossibilite.txt";
			arbre.lireFichier(auxchemin);
			arbre.afficheArbrePossibilite();

			Inventaire inv = new Inventaire();
			inv.AddObjets("guitare", "instrument de musique", 1, 10);
			inv.AddObjets("guitare", 4);

			inv.AddObjets("bâton", "morceau de bois", 5, 50);
			inv.AfficheInventaire();
			Console.ReadKey(true);


		}
	}
}