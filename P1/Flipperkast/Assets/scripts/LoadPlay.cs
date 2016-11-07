using UnityEngine;
using System.Collections;

public class LoadPlay : MonoBehaviour {

	public void LoadLevel(){
		Application.LoadLevel("pinball scene");
	}//als de speler op een button drukt in het mainscreen dan wordt deze functie aangeroepen
	// die ervoor zorgt dat de juiste scene wordt geladen.
}
