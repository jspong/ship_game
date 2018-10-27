using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipInputs : MonoBehaviour {

    public ParticleSystem engineParticles;
    public ParticleSystem trailParticles;

    public float speed = 10f;
    public float maxSpeed = 50f;
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
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddRelativeForce(Vector2.up * speed * (maxSpeed - rb.velocity.magnitude));
            rb.angularVelocity *= 1f - stability;
            if (!engineParticles.isEmitting) {
                trailParticles.Play();
                engineParticles.Play();
            }
        } else if (engineParticles.isEmitting) {
            engineParticles.Stop();
            trailParticles.Stop();
        }
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -3f * h));
    }

    public IEnumerator Respawn() {
        yield return new WaitForSeconds(3f);
        dead = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
