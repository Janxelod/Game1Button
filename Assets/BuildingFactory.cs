using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour {

    public GameObject[] buildings;

    private Camera worldCamera;
    public float lastPosition;

    // Use this for initialization
    void Start () {
        lastPosition = GameObject.Find("Building4").transform.position.x;
        worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (lastPosition < CameraFollow.OrthographicBounds(worldCamera).max.x)
        {
            Debug.Log("Passed last position");
            CreateNewBuilding();
        }
	}
    void CreateNewBuilding()
    {
        int randomIndex = Random.Range(0, 3);
        GameObject newBuilding = Instantiate(buildings[randomIndex]);
        newBuilding.SetActive(true);
        newBuilding.transform.parent = buildings[randomIndex].transform.parent;
        newBuilding.transform.position = new Vector3(lastPosition + 10, newBuilding.transform.position.y, -2);
        lastPosition = newBuilding.transform.position.x;
        
    }
}
