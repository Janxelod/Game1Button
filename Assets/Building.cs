using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    public float width;
    public float height;
    private Camera worldCamera;
	// Use this for initialization
	void Start () {
        width = GetComponent<BoxCollider2D>().bounds.size.x;
        height = GetComponent<BoxCollider2D>().bounds.size.y;
        worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < CameraFollow.OrthographicBounds(worldCamera).min.x-5)
        {
            if (!name.Contains("Clone")) gameObject.SetActive(false);
            else  Destroy(gameObject);
        }
	}
}