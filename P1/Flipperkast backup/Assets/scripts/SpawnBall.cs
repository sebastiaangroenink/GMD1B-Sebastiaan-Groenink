using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {
	public GameObject prefab;
	public GameObject pinballSpawn;
	public bool play;

	void Update (){
		SpawnPinball ();
	}

	void SpawnPinball (){
		if (Input.GetButtonDown ("E") && GameObject.Find ("ScoreManager").GetComponent<UIManager>().lives >=1 && !play) {
			GameObject pinball = (GameObject)Instantiate (prefab, transform.position, Quaternion.identity);
			// als je op E drukt ,je lives meer zijn dan 1 en er geen andere bal in het spel is dan word er een nieuwe bal geinstantiated op de positie van het object waar dit script opstaat (een empty gameObject voor de launcher).
			play = true;// hier word play op true gezet zodat je geen tweede bal in het spel kan brengen.
		}
	}
}
