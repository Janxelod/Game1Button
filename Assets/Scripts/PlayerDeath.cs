using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public static bool playerDeath  = false;

	Animator anim;

	void Awake () {
		anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (playerDeath == true) { 
			anim.SetTrigger("GameOver");
		}
	}
}
