using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Camera cameraRef;
    void Start() {
        cameraRef = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update() {
        if (target) {
            //if (cameraRef.transform.position.x > 1) 
            {
                Vector3 point = cameraRef.WorldToViewportPoint(target.position);
                Vector3 delta = target.position - cameraRef.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                destination.x = Mathf.Clamp(destination.x, 0, 71);
                destination.y = Mathf.Clamp(destination.y, 0, 4);// 0;


                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }

        }

    }
}