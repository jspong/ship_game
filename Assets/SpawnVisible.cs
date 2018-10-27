using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVisible : MonoBehaviour {

    public GameObject prefab;
    public int targetCount;

    public static int currentCount;
    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = Camera.main;
	}

    private Vector3 randomCameraPos(Camera c) {
        float x = Random.Range(0f, (float)c.pixelWidth);
        float y = Random.Range(0f, (float)c.pixelHeight);
        return c.ScreenToWorldPoint(new Vector3(x, y, 0f));
    }
	
	// Update is called once per frame
	void Update () {
        //if (currentCount < targetCount) {
        //    GameObject child = Instantiate(prefab);
        //    child.transform.position = randomCameraPos(_camera);
        //    currentCount++;
        //}
	}
}
