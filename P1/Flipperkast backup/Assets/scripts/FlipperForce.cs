using UnityEngine;
using System.Collections;

public class FlipperForce : MonoBehaviour {
	private bool used;
	private float timer =0.5f;
	private int flipperForce =50;
	
	
	void Update () {
		Timer();
	}
	
	void Timer () {
		if (Input.GetButton("A") || Input.GetButton("D"))
		{
			used = true;
		}
		
		if (used)
			timer -= 1 * Time.deltaTime;
		
		if (timer <= 0)
		{
			used = false;
			timer = 0.5f;
		}
	}
	
	void OnCollisionStay (Collision coll) {
		if (used)
		{
			Vector3 dir = coll.transform.position - transform.position;
			coll.rigidbody.AddForce (dir.normalized * flipperForce);
		}//hier heb ik een simpel systeem geschreven zodat als de speler de flippers niet gebruikt en de animatie uitstaat,
		//de bal niet word weggestuiterd totdat de speler de animatie in gang zet DMV A en D toetsen.
	}
}