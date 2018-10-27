using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject playerToFollow;
    public float timeToCatchUp;

    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        if (playerToFollow == null) {
            return;
        }
        Vector2 player = new Vector2(playerToFollow.transform.position.x,
                                     playerToFollow.transform.position.y);
        Vector2 cameraPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 difference = Vector2.Lerp(cameraPos, player, Time.deltaTime / timeToCatchUp);
        Vector3 newPosition = new Vector3(difference.x, difference.y, transform.position.z);
        transform.position = newPosition;
    }
}
