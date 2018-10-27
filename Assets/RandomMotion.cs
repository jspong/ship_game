using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMotion : MonoBehaviour {

    private int i = 0;
    private bool started = false;

	// Use this for initialization
	void Start () {
        Debug.Log("Initializing " + this);
   	}

    IEnumerator Counter(int n) {
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Debug.Log(i + "/" + j);
            }
            yield return new WaitForSeconds(1f);
        }
        started = false;
    }
	
	// Update is called once per frame
    void Update () {
        if (!started) {
            Debug.Log("updating");
            StartCoroutine(Counter(4));
            started = true;
        }
    }
}
