using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonGun : MonoBehaviour {

    public float pulseRate = 0.2f;
    public Transform photonPrefab;
    public float photonSpeed = 1000f;
    public float photonLife = 3.0f;

    private float nextShot;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)) {
            if (Time.time > nextShot) {
                Shoot();
                nextShot = Time.time + pulseRate;
            }
        }
	}

    void Shoot() {
        Transform photon = Instantiate(photonPrefab, transform.localPosition + transform.up * 4, transform.localRotation, gameObject.transform.parent);
        photon.GetComponent<Photon>().speed = photonSpeed + rb.velocity.magnitude;
        Destroy(photon.gameObject, photonLife);
    }
}
