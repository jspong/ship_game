using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public Transform objectPrefab;
    public int count;

	// Use this for initialization
	void Awake () {
        float width = GetComponent<Tile>().width;
        float height = GetComponent<Tile>().height;
        for (int i = 0; i < count; i++) {
            float x = Random.Range(-0.5f, 0.5f) * width;
            float y = Random.Range(-0.5f, 0.5f) * height;
            Instantiate(objectPrefab, transform.position + new Vector3(x, y, 0f), transform.rotation, transform.parent);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
