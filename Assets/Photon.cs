﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photon : MonoBehaviour {

    public float speed = 10.0f;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}
}
