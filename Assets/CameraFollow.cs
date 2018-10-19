using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject playerToFollow;

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 lerped = Vector3.Lerp(cam.transform.position, playerToFollow.transform.position, 0.5f);
        cam.transform.position = new Vector3(lerped.x, lerped.y, cam.transform.position.z);
        cam.transform.Rotate(cam.transform.position, 1f);
    }
}
