using UnityEngine;
using System.Collections;

public class AddLives : MonoBehaviour {

	void OnCollisionEnter(){
		GameObject.Find ("ScoreManager").GetComponent<UIManager>().lives += 1;
	}//als de speler tegen dit object aankomt krijgt hij simpelweg een extra life.
}
