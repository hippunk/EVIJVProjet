using UnityEngine;
using System.Collections;

public class ObjetInventaire : MonoBehaviour {

	public GameObject item;
	public string description;
	public int quantite;
	public int limite;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public GameObject Item {
		get {
			return this.item;
		}
		set {
			item = value;
		}
	}

   public override string ToString ()
	{
	return string.Format ("[ObjetInventaire: item={0}, description={1}, quantite={2}, limite={3}]", item, description, quantite, limite);
	}
	

	public string Description {
		get {
			return this.description;
		}
		set {
			description = value;
		}
	}

	public int Quantite {
		get {
			return this.quantite;
		}
		set {
			quantite = value;
		}
	}

	public void add(int qtt)	{
		if ((quantite += qtt) > limite) {
			quantite = limite;
		}
	}
	public void remove(int qtt)	{
		if ((quantite -= qtt) < 0) {
			quantite = 0;
		}
	}
	public int Limite {
		get {
			return this.limite;
		}
		set {
			limite = value;
		}
	}
	void Update () {
	
	}
}
