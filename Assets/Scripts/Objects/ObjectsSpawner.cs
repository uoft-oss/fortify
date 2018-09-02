using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

    public Camera camera;
    public GameObject prefab;

	// Update is called once per frame
	void Update () {
		 
        // check for mouse clicks
        if (Input.GetMouseButtonUp(0)) {

            Debug.Log("Left mouse clicked");
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("spawwning");
                Instantiate(prefab, hit.point, Quaternion.identity);
            }
        }
	}
}
