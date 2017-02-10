using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemyMovement : MonoBehaviour {

	const int speed = 3;

	// Update is called once per frame
	void Update () {
		float velX = speed * Time.deltaTime;
		transform.position += new Vector3 (velX, 0, 0);
	}
}
