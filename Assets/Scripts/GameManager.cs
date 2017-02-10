using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameTitle;
    public GameObject player;
    public float timeToStart = 3;
    public float currentTime;
	// Use this for initialization
	void Start () {
        player.GetComponent<PlayerTestScript>().speedX = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            currentTime += Time.deltaTime;
            if (currentTime > timeToStart) {
                gameTitle.SetActive(false);
                currentTime = 0;
                player.GetComponent<PlayerTestScript>().speedX = 5;
                player.GetComponent<Animator>().SetBool("GameStart", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) currentTime = 0;
	}
}
