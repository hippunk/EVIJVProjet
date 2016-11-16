using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class RécompenseTache
	{
		private List<ElementInventaire> listeObjet;
		private List<Tuple<string,int>> reputations;
		
		public RécompenseTache()
		{
			listeObjet = new List<ElementInventaire>();
			reputations = new List<Tuple<string, int>>();
		}

		public List<ElementInventaire> ListeObjet()
		{
			return this.listeObjet;
		}

		public List<Tuple<string, int>> Reputations()
		{
			return reputations;
		}

		public void AddObjet(List<ElementInventaire> objets)
		{
			for (int i = 0; i < objets.Count; i++)
			{
				listeObjet.Add(objets.ElementAt(i));
			}
		}

		public void deleteObjet(List<ElementInventaire> objets)
		{
			for (int i = 0; i < objets.Count; i++)
			{

				if (listeObjet.Contains(objets.ElementAt(i)))
				{
					listeObjet.Remove(objets.ElementAt(i));
				}
			}
		}

		public void AddReputation(List<Tuple<string, int>> reput)
		{
			for (int i = 0; i < reput.Count; i++)
			{
				reputations.Add(reput.ElementAt(i));
			}
		}

		public void deleteReputation(List<Tuple<string,int>> reput)
		{
			for (int i = 0; i < reput.Count; i++)
			{
				for (int j = 0; j < reputations.Count; j++)
				{
					if (reputations.ElementAt(j).Item1 == reput.ElementAt(i).Item1){
						reputations.Remove(reput.ElementAt(i));
						break;
					}
				}
			}
		}

		
	}
}
