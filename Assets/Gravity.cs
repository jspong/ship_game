using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public float mass = 10000f;
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
        float magnitude = mass / distance.sqrMagnitude;
        otherBody.AddForce(distance.normalized * magnitude);
    }
}
