using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public static float xRot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate (new Vector3(xRot, -50));
		Debug.Log(xRot);
		Quaternion rot = Quaternion.Euler (xRot, 0, 0);
		transform.rotation = rot; 
	}
}
