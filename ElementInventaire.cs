using System;
namespace Test
{
	public class ElementInventaire
	{
		private string objet;
		private int quantite;
		private int limite;
		public ElementInventaire(string obj)
		{
			this.objet = obj;
			this.quantite = 0;
			this.limite = -1;
		}

		public void AddQuantite(int val)
		{
			this.quantite += val;
			if (this.limite > -1 && this.quantite > this.limite)
			{
				this.quantite = this.limite;
			}
		}

		public void SupprimerQuantite(int val)
		{
			this.quantite -= val;
			if (this.quantite < 0)
			{
				this.quantite = 0;
			}
		}

		public void setLimite(int lim)
		{
			this.limite = lim;
		}

		public string Objet()
		{
			return this.objet;
		}

		public int Quantite()
		{
			return this.quantite;
		}

		public int Limite()
		{
			return this.limite;
		}

		public string Affiche()
		{
			return "[ " + this.objet + " -> [ Quantite : " + this.quantite + ", Limite :" + this.limite + " ]";
		}
	}
}
