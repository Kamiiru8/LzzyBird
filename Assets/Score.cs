using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;
	static Score instance;

	static public void AddPoint(){
		if (instance.bird.death)
			return;
		score++;
		if (score > highScore) {
			highScore = score;
		}
	}

	BirdMovement bird;

	void Start(){
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		bird = player_go.GetComponent<BirdMovement>();
		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}

	void OnDestroy(){
		instance = null;
		PlayerPrefs.SetInt ("highScore",highScore);
	}

	void Update () {
		Text guiText = GetComponent<Text>();
		guiText.text = "Your Score: " + score + "\nHigh Score: " + highScore;
	}
}
