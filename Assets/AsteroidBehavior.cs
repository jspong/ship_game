using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour {

    public float minSize = 3.0f;
    public float maxSize = 10.0f;
    public float minSpeed = 3.0f;
    public float maxSpeed = 10.0f;

    // Use this for initialization
    void Start() {
        // TODO: Pick a random asteroid sprite.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.value, Random.value).normalized * Random.Range(minSpeed, maxSpeed);
        rb.angularVelocity = Random.Range(minSpeed, maxSpeed);

        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
    }

}
