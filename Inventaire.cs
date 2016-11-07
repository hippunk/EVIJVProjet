using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class Inventaire
	{
		private List<ElementInventaire> listeObjet;

		public Inventaire()
		{
			this.listeObjet = new List<ElementInventaire>();	
		}


		public void AddObjets(string name, int quantite, int limite)
		{
			bool present = false;
			for (int i = 0; i < listeObjet.Count; i++)
			{
				if (listeObjet.ElementAt(i).Objet() == name)
				{
					listeObjet.ElementAt(i).AddQuantite(quantite);
					present = true;
					break;
				}
			}

			if (present == false)
			{
				ElementInventaire elem = new ElementInventaire(name);
				elem.setLimite(limite);
				elem.AddQuantite(quantite);
				listeObjet.Add(elem);
			}
		}

		public void DeleteObjets(string name, int quantite)
		{
			for (int i = 0; i < listeObjet.Count; i++)
			{
				if (listeObjet.ElementAt(i).Objet() == name)
				{
					listeObjet.ElementAt(i).SupprimerQuantite(quantite);
				}
			}
		}

		public void AfficheInventaire()
		{
			Console.WriteLine("Inventaire [");
			for (int i = 0; i < listeObjet.Count; i++)
			{
				Console.WriteLine("\n\t" + this.listeObjet.ElementAt(i).Affiche());
			}
		}

	}
}
