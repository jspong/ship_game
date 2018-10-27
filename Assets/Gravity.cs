using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float g;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag != "Player") {
            return;
        }
        Vector3 distance = (gameObject.transform.transform.position - other.gameObject.transform.position);
        Rigidbody2D otherBody = other.attachedRigidbody;
        float magnitude = g * rb.mass * otherBody.mass / distance.sqrMagnitude;
        Vector3 force = distance.normalized * magnitude;
        rb.AddForce(-1 * force);
        otherBody.AddForce(force);
    }
}
