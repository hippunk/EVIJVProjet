using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	public class Possibilité
	{
		private string value;        // La possibilité 
		private int dialogueSuivant; // Cle pour atteindre la prochaine liste de possibilité si cette possibilité est choisi.

		public Possibilité (string text)
		{
			this.value = text;
			this.dialogueSuivant = -1;
		}


		public void setDialogueSuivant(int id)
		{
			this.dialogueSuivant = id;
		}

		public string Value()
		{
			return this.value;
		}

		public int DialogueSuivant()
		{
			return this.dialogueSuivant;
		}

		public string Affiche()
		{
			return "[ text=" + this.value + ", suivant=" + this.dialogueSuivant + "]"; 
		}
	}

	public class ArbrePossibilité
	{
		private Dictionary<int, List<Possibilité>> arbre; // Arbre de possibilité
		private int cleInitial;  // Cle du noeud origine de l'arbre
		private int cleActuel;   // Cle du noeud courant dans l'arbre

		public ArbrePossibilité()
		{
			this.arbre = new Dictionary<int, List<Possibilité>>();
			this.cleInitial = -1;
			this.cleActuel = -1;
		}

		// Ajoute une possibilité à l'arbre si la cle est déjà presente dans l'arbre
		// on la rajoute à la liste des possibilitées du noeud cle
		public void addPossibilité(int cle, string text)
		{
			if (this.arbre.ContainsKey(cle) == false)
			{
				List<Possibilité> liste = new List<Possibilité>();
				liste.Add(new Possibilité(text));
				this.arbre.Add(cle, liste);
			}
			else
			{
				this.arbre[cle].Add(new Possibilité(text));
			}
		}

		// Permet de retourner en haut de l'arbre
		public void resetDialogue()
		{
			this.cleActuel = this.cleInitial;
		}

		// Change la cle initial
		public void setCleInitial(int newKey)
		{
			this.cleInitial = newKey;
		}

		// Permet de creer le lien entre le noeud idPere et le noeud idFils
		// Si le noeud de IdPere n'existe pas alors il le crée.
		// Attention : Il ne crée pas le noeud idFils.
		public void addArrete(int idPere, string text, int idFils)
		{
			if (this.arbre.ContainsKey(idPere) == false)
			{
				addPossibilité(idPere, text);
			}

			bool present = false;
			for (int i = 0; i < this.arbre[idPere].Count; i++)
			{
				string auxtext = this.arbre[idPere].ElementAt(i).Value();
				if (auxtext == text)
				{
					this.arbre[idPere].ElementAt(i).setDialogueSuivant(idFils);
					present = true;
					break;
				}
			}

			if (present == false)
			{
				addPossibilité(idPere, text);
				addArrete(idPere, text, idFils);
			}

		}

		//Renvoi la liste des textes contenus dans le noeud idPere
		public List<string> getListPossibilité(int idPere)
		{
			List<string> liste = new List<string>();

			if (this.arbre.ContainsKey(idPere) == true)
			{
				for (int i = 0; i < this.arbre[idPere].Count; i++)
				{
					liste.Add(this.arbre[idPere].ElementAt(i).Value());
				}
			}
			return liste;
		}

		//Change cleActuel en fonction de la possibilité choisit
		public void Suivant(string text)
		{
			if (this.arbre.ContainsKey(cleActuel) == true)
			{
				for (int i = 0; i < this.arbre.Count; i++)
				{
					if (this.arbre[cleActuel].ElementAt(i).Value() == text)
					{
						this.cleActuel = this.arbre[cleActuel].ElementAt(i).DialogueSuivant();
						break;
					}
				}
			}
		}

		// Lit un fichier et initialise l'arbre de possibilité avec ces données
		// Format du Fichier :
		// cleInitial
		// numeroNoeud;texteDeLaPossibilité;numeroNoeudSuivant
		public void lireFichier(string chemin)
		{
			
			string[] lines = System.IO.File.ReadAllLines(chemin);

			for (int i = 0; i < lines.Length; i++)
			{
				if (i == 0)
				{
					this.cleInitial = Int32.Parse(lines[0]);
				}
				else
				{
					char[] delimiterChars = { ';' };
					string[] ligneSplitter = lines[i].Split(delimiterChars);
					addArrete(Int32.Parse(ligneSplitter[0]), ligneSplitter[1], Int32.Parse(ligneSplitter[2]));
				}
			}
			this.resetDialogue();
		}

		// Affichage (debug)
		public string AfficheListePossibilité(int clePere)
		{
			string texte = "";
			for (int i = 0; i < this.arbre[clePere].Count; i++)
			{
				texte += "\n\t" + this.arbre[clePere].ElementAt(i).Affiche();
			}
			return texte;
		}

		// Affichage (Debug)
		public void afficheArbrePossibilite()
		{
			Console.WriteLine("Cle initial: " + this.cleInitial + "\n");
			for (int i = 0; i < this.arbre.Count; i++)
			{
				int idPere = this.arbre.Keys.ElementAt(i);
				Console.WriteLine(idPere + ": " + AfficheListePossibilité(idPere));
			}
		}
	}
}


