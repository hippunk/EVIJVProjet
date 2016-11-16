using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class BDI
	{
		private List<Tuple<String, Belief>> beliefs;
		private List<Tuple<String, Intention>> intention;

		public BDI()
		{
			this.beliefs = new List<Tuple<string, Belief>>();
			this.intention = new List<Tuple<string, Intention>>();
		}

		// creates a new belief. (does not stores it in belief memory).
		public Tuple<String, Belief> createBelief(String Btype, Belief content)
		{
			return new Tuple<String, Belief>(Btype, content);
		}

		// reports type of a belief.
		public String beliefType(Tuple<String, Belief> bel)
		{
			return bel.Item1;
		}

		// reports the coontent of belief
		public Belief BeliefContent(Tuple<String, Belief> bel)
		{
			return bel.Item2;
		}

		// Adding information to the beliefs structure
		public void addBelief(Tuple<String, Belief> bel)
		{
			if (beliefs.Contains(bel)) { return; }
			beliefs.Add(bel);
		}

		// Removing a belief from the list of beliefs. 
		public void removeBelief(Tuple<String, Belief> bel)
		{
			beliefs.Remove(bel);
		}

		//return true if a specific belief belong to the set of beliefs
		public bool existsBelief(Tuple<String, Belief> bel)
		{
			return beliefs.Contains(bel);
		}

		// Reports true if a belief in the form of ["b-type" etc etc etc ...] exist in beliefs list
		public bool existBeliefOfType(String Btype)
		{
			List<Tuple<String, Belief>> aux = new List<Tuple<string, Belief>>();
			for (int i = 0; i < beliefs.Count; i++)
			{
				if (beliefType(beliefs.ElementAt(i)) == Btype)
				{
					aux.Add(beliefs.ElementAt(i));
				}
			}

			if (aux.Count == 0)
			{
				return false;
			}
			return true;
		}

		// Returns all beliefs of b-type in a list
		public List<Tuple<String, Belief>> BeliefOfType(String Btype)
		{
			List<Tuple<String, Belief>> aux = new List<Tuple<string, Belief>>();
			for (int i = 0; i < beliefs.Count; i++)
			{
				if (beliefType(beliefs.ElementAt(i)) == Btype)
				{
					aux.Add(beliefs.ElementAt(i));
				}
			}
			return aux;
		}

		// Returns the first belief of a certain type and removes it
		public Belief getBelief(String Btype)
		{
			if (this.existBeliefOfType(Btype))
			{
				for (int i = 0; i < beliefs.Count; i++)
				{
					if (beliefType(beliefs.ElementAt(i)) == Btype)
					{
						Belief b = beliefs.ElementAt(i).Item2;
						beliefs.RemoveAt(i);
						return b;
					}
				}
			}
			return null;
		}


		public Tuple<String,Belief> readFirstBeliefOfType(String Btype)
		{
			List<Tuple<String, Belief>> bel = BeliefOfType(Btype);
			if (bel.Count != 0)
			{
				return bel.ElementAt(0);
			}
			return null;
		}

		public void updateBelief(Tuple<String, Belief> bel)
		{
			removeBelief(readFirstBeliefOfType(beliefType(bel)));
			addBelief(bel);
		}


	
	}
}
