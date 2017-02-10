using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : MonoBehaviour {

	Vector2[] triangleColliderPoints = new Vector2[4];
	float visionWidth = 2.5f; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//triangleCollider = gameObject.GetComponent<EdgeCollider2D>();
		triangleColliderPoints [0] = Vector2.zero;//transform.position
		if (int.Parse (ArduinoConnector.ArduinoMsg) >= 40) {
			triangleColliderPoints [1] = new Vector2 (-visionWidth / 2 * (int.Parse (ArduinoConnector.ArduinoMsg) / 10), -20f); //Magic number. This is what the floors are set at.
			triangleColliderPoints [2] = new Vector2 (visionWidth / 2 * (int.Parse (ArduinoConnector.ArduinoMsg) / 10), -20f);
		}
		else {
			triangleColliderPoints [1] = new Vector2 (-visionWidth / 2 * (int.Parse (ArduinoConnector.ArduinoMsg) / 10), 0f);
			triangleColliderPoints [2] = new Vector2 (visionWidth / 2 * (int.Parse (ArduinoConnector.ArduinoMsg) / 10),  0f);
		}

		triangleColliderPoints [3] = Vector2.zero;//transform.position;
		//Debug.Log(gameObject.GetComponent<EdgeCollider2D>().points);
		gameObject.GetComponent<EdgeCollider2D> ().points = triangleColliderPoints;
	}

	void OnTriggerEnter2D(Collider2D objCollider)
	{
		if (objCollider.CompareTag ("Player")) {
			if (PlayerMovement.visible == true) {
				//Kill player
				transform.position = Vector2.Lerp(transform.position, objCollider.gameObject.transform.position,0.15f);
			//	transform.position = objCollider.gameObject.transform.position;
				Debug.Log ("Player Seen");
			}
		}
	}

	void OnTriggerStay2D(Collider2D objCollider)
	{
		if (objCollider.CompareTag ("Player")) {
			if (PlayerMovement.visible == true) {
				//Kill player
				transform.position = Vector2.Lerp(transform.position, objCollider.gameObject.transform.position,0.15f);
				Debug.Log ("Player Seen");
			}
		}
	}
}
