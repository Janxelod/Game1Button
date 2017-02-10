using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	const int speed = 2;
	const int minSpeed = 1;
	float velX;
	public static bool visible = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string msg = ArduinoConnector.ArduinoMsg;
		float _light = (int)(int.Parse (msg)/10);
		velX = (float)(speed * _light + minSpeed) * Time.deltaTime;
		transform.position += new Vector3 (velX, 0, 0);
		//Debug.Log (visible);
	}

	void OnTriggerEnter2D(Collider2D colliderObj)
	{
		if(colliderObj.CompareTag("Building"))
		{
			visible = false;
		}
	}

	void OnTriggerExit2D(Collider2D colliderObj)
	{
		if (colliderObj.CompareTag ("Building")) {
			visible = true;
		}
	}
}
