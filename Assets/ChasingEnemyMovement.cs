using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemyMovement : MonoBehaviour {

	const int speed = 10;

	// Update is called once per frame
	void Update () {
		float velX = speed * Time.deltaTime;
		transform.position += new Vector3 (velX, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D objCollider)
	{
		if (objCollider.CompareTag ("Player")) {
			//Kill Player
			Debug.Log("Player caught");
		}
	}
}
