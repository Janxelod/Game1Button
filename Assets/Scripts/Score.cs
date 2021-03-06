﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public int playerScore;
	private float playerStartPos;

	Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
		playerScore = 0;
		playerStartPos = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		playerScore = (int)( GameObject.FindGameObjectWithTag ("Player").transform.position.x - playerStartPos);
		scoreText.text = "Score : " + playerScore;
	}
}
