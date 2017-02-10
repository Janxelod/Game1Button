using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	public int playerScore;
	private float playerStartPos;
	// Use this for initialization
	void Start () {
		playerScore = 0;
		playerStartPos = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		playerScore = (int)( GameObject.FindGameObjectWithTag ("Player").transform.position.x - playerStartPos);
	}
}
