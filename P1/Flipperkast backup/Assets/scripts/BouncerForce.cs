using UnityEngine;
using System.Collections;

public class BouncerForce : MonoBehaviour {

	void OnCollisionEnter (Collision coll) {
		{
			Vector3 dir = coll.transform.position - transform.position;
			coll.rigidbody.AddForce (dir.normalized * 250);
		}//als de speler tegen een zogeheten bouncer aankomt wordt hij in zijn tegenoverliggende hoek teruggestuiterd met een X kracht.
	}
}
