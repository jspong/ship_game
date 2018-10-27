using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {

    public GameObject player;
    public float speed = 10f;
    public float stayAway = 100f;
    public float stability = 0.05f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        if (player == null) {
            player = GameObject.FindWithTag("Player");
        }
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {
        if (player == null) {
            player = gameObject;
        }
        Vector3 dist = player.transform.position - transform.position;
        if (dist.magnitude < stayAway) {
            dist = Vector3.RotateTowards(dist, -dist, Mathf.PI / 2, 1f);
        }
        Vector3 cross = Vector3.Cross(transform.up, dist.normalized);
        if (cross.z > 0) {
            transform.Rotate(0, 0, 3f);
        } else {
            transform.Rotate(0, 0, -3f);
        }
        rb.AddRelativeForce(Vector2.up * speed);
        rb.angularVelocity *= 1f - stability;
    }
}
