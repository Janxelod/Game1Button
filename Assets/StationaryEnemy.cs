using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour {

	EdgeCollider2D triangleCollider;
	float visionWidth = 20; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		triangleCollider = gameObject.GetComponent<EdgeCollider2D>();
		triangleCollider.points [0] = transform.position;
		triangleCollider.points [1] = new Vector2 (-visionWidth / 2 - (int.Parse(ArduinoConnector.ArduinoMsg)/10), -20f); //Magic number. This is what the floors are set at.
		triangleCollider.points [2] = new Vector2 (visionWidth / 2 + (int.Parse(ArduinoConnector.ArduinoMsg)/10), -20f);
		triangleCollider.points [3] = transform.position;
		gameObject.GetComponent<EdgeCollider2D> ().points = triangleCollider.points;
	}

	void OnTriggerEnter2D(Collider2D objCollider)
	{
		if (objCollider.CompareTag ("Player")) {
			//Kill Player
			Debug.Log("Player Seen");
		}
	}
}
