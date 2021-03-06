using UnityEngine;
using System.Collections;

public class RayCastingScript : MonoBehaviour {

	public Camera cameraa;
	bool deplacement = false;
	public int offset = 1;
	private RaycastHit focusHit;
	private Transform objectHit;

	void Start(){

	}

	void FixedUpdate ()
	{
		RaycastHit hit;
		Ray ray = cameraa.ScreenPointToRay (Input.mousePosition);


		if (Physics.Raycast (ray, out hit)) {


			if (hit.transform.GetComponent<Saisissable> () != null && !deplacement && Input.GetMouseButtonDown (0)) {
				objectHit = hit.transform;
				deplacement = true;
				objectHit.GetComponent<Rigidbody> ().isKinematic = true;

				print ("Saisie");
			} else if (deplacement && Input.GetMouseButtonUp (0)) {
				deplacement = false;
				objectHit.GetComponent<Rigidbody> ().isKinematic = false;
				print ("Lache");
			}

			if (deplacement) {
				print ("bouge");
				objectHit.GetComponent<Rigidbody> ().MovePosition (ray.origin + (ray.direction * offset)); 
				Debug.DrawLine (cameraa.gameObject.transform.position, objectHit.position, Color.red);
			}

		}

	}
}

