using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + GameController.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void btnPlayAgain_Clicked() {
        Application.LoadLevel("Main");
	}
}
