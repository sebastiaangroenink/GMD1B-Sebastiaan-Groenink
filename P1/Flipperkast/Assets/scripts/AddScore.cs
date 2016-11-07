using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour {


	void OnCollisionEnter(){
		GameObject.Find ("ScoreManager").GetComponent<UIManager>().score += 100;
	}//als de speler hiertegenaankom krijgt hij een X aantal punten erbij.
}
