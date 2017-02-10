using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
	public int playerScore;
	private float playerStartPos;
	// Use this for initialization
	void Start () {
		playerScore = 0;
		playerStartPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		playerScore = -(playerStartPos - transform.position.x);
	}
}
