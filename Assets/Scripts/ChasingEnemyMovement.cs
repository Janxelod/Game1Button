using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemyMovement : MonoBehaviour {

	const int speed = 5;
    public float speedX = 0;
	// Update is called once per frame
	void Update () {
		float velX = speedX * Time.deltaTime;
		transform.position += new Vector3 (velX, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D objCollider)
	{
		if (objCollider.CompareTag ("Player")) {
			//Kill Player
			Debug.Log("Player caught");
			PlayerDeath.playerDeath = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isGameStarted = false;
		}
	}
}
