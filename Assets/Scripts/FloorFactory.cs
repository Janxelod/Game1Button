using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFactory : MonoBehaviour {

    public GameObject floorPivot;
    public GameObject streetFloorPivot;
    public float floorPivotLastPos;
    public float streetFloorPivotLastPos;
    private Camera worldCamera;
    public float offsetX;
    // Use this for initialization
    void Start () {
        floorPivotLastPos = GameObject.Find("floorPivot").transform.position.x + GameObject.Find("floorPivot").GetComponent<Floor>().width / 2; 
        streetFloorPivotLastPos = GameObject.Find("streetFloorPivot").transform.position.x + GameObject.Find("streetFloorPivot").GetComponent<Floor>().width / 2;
        worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (floorPivotLastPos < CameraFollow.OrthographicBounds(worldCamera).max.x + offsetX) {
            CreateNewFloor("floorPivot");
        }
        if (streetFloorPivotLastPos < CameraFollow.OrthographicBounds(worldCamera).max.x + offsetX) {
            CreateNewFloor("streetFloorPivot");
        }
    }
    void CreateNewFloor(string type) {
        GameObject newFloor = Instantiate((type == "floorPivot")? floorPivot:streetFloorPivot);
        newFloor.SetActive(true);
        newFloor.transform.parent = floorPivot.transform.parent;
        float newPosX = 0;
        if (type == "floorPivot") {
            newPosX = floorPivotLastPos + newFloor.GetComponent<Floor>().width ;
            floorPivotLastPos = newPosX;
        } else if(type == "streetFloorPivot") {
            newPosX = streetFloorPivotLastPos + newFloor.GetComponent<Floor>().width;
            streetFloorPivotLastPos = newPosX;
        }
        newFloor.transform.position = new Vector3(newPosX, newFloor.transform.position.y, 0);
    }
}
