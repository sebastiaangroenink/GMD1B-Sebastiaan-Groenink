using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {
	private int launchSpeed =250;

	void OnCollisionStay (Collision coll) {
		if (Input.GetButtonDown ("Jump"))
		{
			Vector3 dir = coll.transform.position - transform.position;
			coll.rigidbody.AddForce (dir.normalized * launchSpeed);//als je op Jump (spacebar) drukt en je raakt het balletje dan wordt die met X kracht teruggeschoten in zijn tegenoverliggende hoek.
		}
	}
}
