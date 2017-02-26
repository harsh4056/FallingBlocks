﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {


	public GameObject gameOverScreen;
	public  Text secondsSurvivedUI;
	bool gameOver;
	// Use this for initialization
	void Start () {
		FindObjectOfType<PlayerController> ().OnPlayerDeath+=OnGameOver;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameOver) {
			if (Input.touchCount==1) {
				
				SceneManager.LoadScene (0);
			}
		}
	
	}

	 void OnGameOver(){
		gameOverScreen.SetActive (true);
		secondsSurvivedUI.text = Time.timeSinceLevelLoad.ToString();
		gameOver = true;


	}

}
