using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillForPoints : MonoBehaviour {

    public float pointValue;

    public ParticleSystem explosion;

    public void Die() {
        Debug.Log(pointValue + " points!");
        explosion.Play();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            explosion.Play();
        }
    }
}
