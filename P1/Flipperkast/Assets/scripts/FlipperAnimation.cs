using UnityEngine;
using System.Collections;

public class FlipperAnimation : MonoBehaviour {
	
	Animator flipperOne;
	Animator flipperTwo;
	
	void Start () {
		flipperOne = GameObject.Find ("flipper2").GetComponent<Animator> ();
		flipperTwo = GameObject.Find ("flipper1").GetComponent<Animator> ();
	}//ik maak hier 2 variables die ik aanwijs aan de twee animators die ik heb gemaakt met daarin de animaties.
	
	
	void Update () {
		if (Input.GetButton ("A")) {
			flipperOne.SetFloat ("trigger", 1);
		} else
			flipperOne.SetFloat ("trigger", 0);
		
		if (Input.GetButton ("D")) {
			flipperTwo.SetFloat ("trigger", 1);
		} else
			flipperTwo.SetFloat ("trigger", 0);
	}//dit zijn de variables die ik binnen de animators heb aangemaakt zodat de animaties afspelen wanneer dat hoort
	//en niet willekeurig afspelen.
}
