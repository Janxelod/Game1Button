using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour {
    public float speedX;
    private bool moveRight;
    private bool moveLeft;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        CheckInput();
        movePlayer();
    }
    void CheckInput() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            moveRight = true;
            moveLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            moveLeft = true;
            moveRight = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            moveRight = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            moveLeft = false;
        }
    }
    void movePlayer() {
        if(moveLeft || moveRight) {
            float currentXposition = transform.position.x;
            Vector3 deplacement = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            if(moveLeft)
                currentXposition -= (speedX * Time.deltaTime);
            else if(moveRight)
                currentXposition += (speedX * Time.deltaTime);
            deplacement.x = currentXposition;
            transform.position = deplacement;
        }
        
    }
}
