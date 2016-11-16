using UnityEngine;
using System.Collections;
using System.IO;
public class Conversation : MonoBehaviour {

	public TextAsset file;



	// Use this for initialization
	void Start () {
		ArbrePossibilité arbr = new ArbrePossibilité ();
		Debug.Log (file.text);
		arbr.lireFichier (file.text);
		arbr.afficheArbrePossibilite ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
