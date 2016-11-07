using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	public int score =0;
	public int lives = 3;
	public Text scoreText;
	public Text liveText;
	
	void Update(){
		UpdateScore 	();
		UpdateLives 	();
		GameOverCheck 	();
	}
	
	void UpdateScore(){
		scoreText.text = "Score: "  +score;//elke keer als deze functie word aangeroepen wordt de score bijgewerkt naar het nummer van de int.
	}

	void UpdateLives(){
		liveText.text = "Lives: " + lives;//hier worden de lives aangepast naar de int van de hoeveelheid lives.
	}
	void GameOverCheck(){
		if (lives == 0) {
			Application.LoadLevel ("main menu");//als je levens op 0 staan (kan niet minder worden omdat er maar maximaal 1 bal tegelijk is) wordt het startscherm geladen en stopt het spel dus.
		}
	}
}