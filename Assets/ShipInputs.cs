using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipInputs : MonoBehaviour {

    public ParticleSystem engineParticles;
    public ParticleSystem trailParticles;

    public float speed = 10f;
    public float maxSpeed = 50f;
    public float turningSpeed = 15f;
    [Range(0f, 1f)] public float stability = 0.05f;

    private bool dead = false;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        trailParticles.Stop();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (dead) {
            return;
        }
        rb.inertia *= (1f - stability);
        rb.angularVelocity *= (1f - stability);

        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddRelativeForce(Vector2.up * speed);

            if (!engineParticles.isEmitting) {
                trailParticles.Play();
                engineParticles.Play();
            }
        } else if (engineParticles.isEmitting) {
            engineParticles.Stop();
            trailParticles.Stop();
        }
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -turningSpeed * h));
    }
}
