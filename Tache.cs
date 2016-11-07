using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class Tache
	{
		public static int idGenerator = 0;
		private int id;
		private string name;
		private string description;
		private List<int> parentsMission;
		private List<RécompenseTache> récompense;
		private bool complete;
		private List<CheckPoint> etapes;

		public Tache()
		{
			this.id = idGenerator;
			idGenerator++;
			this.parentsMission = new List<int>();
			this.etapes = new List<CheckPoint>();
			this.récompense = new List<RécompenseTache>();
			this.complete = false;
		}

		public int Id()
		{
			return this.id;
		}

		public string Name()
		{
			return this.name;
		}

		public string Description()
		{
			return this.description;
		}

		public bool Complete()
		{
			return this.complete;
		}

		public void setName(string nom)
		{
			this.name = nom;
		}

		public void setDescription(string desc)
		{
			this.description = desc;
		}

		public void addParentTaches(List<int> IdTaches)
		{
			for (int i = 0; i < IdTaches.Count; i++)
			{
				if (this.parentsMission.Contains(IdTaches.ElementAt(i)) == false)
				{
					this.parentsMission.Add(IdTaches.ElementAt(i));
				}
			}
		}

		public void deleteParentTache(List<int> IdTaches)
		{
			for (int i = 0; i < IdTaches.Count; i++)
			{
				if (this.parentsMission.Contains(IdTaches.ElementAt(i)) == true)
				{
					this.parentsMission.Remove(IdTaches.ElementAt(i));
				}
			}
		}

		public void addRecompence(List<RécompenseTache> rewards)
		{
			for (int i = 0; i < rewards.Count; i++)
			{
				if (this.récompense.Contains(rewards.ElementAt(i)) == false)
				{
					this.récompense.Add(rewards.ElementAt(i));
				}
			}
		}

		public void deleteRecompense(List<RécompenseTache> rewards)
		{
			for (int i = 0; i < rewards.Count; i++)
			{
				if (this.récompense.Contains(rewards.ElementAt(i)) == true)
				{
					this.récompense.Remove(rewards.ElementAt(i));
				}
			}
		}


		public void addEtape(List<CheckPoint> etape)
		{
			for (int i = 0; i < etape.Count; i++)
			{
				if (this.etapes.Contains(etape.ElementAt(i)) == false)
				{
					this.etapes.Add(etape.ElementAt(i));
				}
			}
		}

		public void deleteEtape(List<CheckPoint> etape)
		{
			for (int i = 0; i < etape.Count; i++)
			{
				if (this.etapes.Contains(etape.ElementAt(i)) == true)
				{
					this.etapes.Remove(etape.ElementAt(i));
				}
			}
		}

		public void setComplete()
		{
			this.complete = !this.complete;
		}


	}
}
