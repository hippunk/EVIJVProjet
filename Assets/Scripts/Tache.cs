using UnityEngine;
using System.Collections;

public class Tache : MonoBehaviour {

	private static int idGen = 0;
	private int id;
	public string name;
	public string description;
	//private List<RécompenseTache> récompense;

	// Use this for initialization
	void Start () {
		id = idGen++;
	}

	// Update is called once per frame
	void Update () {
		

	}


	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}

	public string Description {
		get {
			return this.description;
		}
		set {
			description = value;
		}
	}
		
	public override string ToString () {
		return string.Format ("[Tache: id={0}, name={1}, description={2}]", id, name, description);
	}
	

}
