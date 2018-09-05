using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

    public Camera camera;
    public int i;
    public int rot;
    public GameObject[] objectArray;
    private const string GRID_NAME = "grid";

    void rotate() {
        rot = (rot + 90) % 360;
    }
    


    void instantiateObj() {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            if(hit.transform.gameObject.name == GRID_NAME) {
                // spawn the object
                Instantiate(objectArray[i], hit.point, Quaternion.Euler(new Vector3(0, rot, 0)));
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Alpha1)) i = 0;
        if(Input.GetKeyUp(KeyCode.Alpha2)) i = 1;
        if(Input.GetKeyUp(KeyCode.R)) rotate();

        if(Input.GetMouseButtonUp(0)) {
            instantiateObj();
        }
	}
}
