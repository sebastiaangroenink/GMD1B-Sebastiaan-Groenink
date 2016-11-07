using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
			DestroyObject (other.gameObject);
			GameObject.Find ("ScoreManager").GetComponent<UIManager>().lives -=1;
			GameObject.Find ("Spawner").GetComponent<SpawnBall>().play = false;
		}// als er een object met de tag Enemy (bal) tegen de collider van dit object aankomt wordt de *enemy* vernietigd,
		//verliest de speler een life en kan hij een nieuwe bal spawnen.
	}
}