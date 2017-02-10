using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public float width;
    public float height;
    private Camera worldCamera;
    // Use this for initialization

    void Start () {
        width = GetComponent<BoxCollider2D>().bounds.size.x ;
        height = GetComponent<BoxCollider2D>().bounds.size.y  ;
        worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < CameraFollow.OrthographicBounds(worldCamera).min.x - width - 5) {
            if (name.Contains("Pivot")) gameObject.SetActive(false);
            else Destroy(gameObject);
        }
    }
}
