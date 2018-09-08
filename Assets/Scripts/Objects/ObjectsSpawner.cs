using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour {

    public Camera camera;
    public GameObject[] objectArray;

    public int i;
    public int rot;

    private const string SPAWNABLE_TAG = "Spawnable";
    private const string GRID_NAME = "grid";

    public bool isDeleting;

    public void rotate() {
        rot = (rot + 90) % 360;
    }

    public void toggleDeleting() {
        isDeleting = !isDeleting;
    }

    void mouseClicked() {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            print(hit.transform.gameObject.tag);
            // spawn when not deleting
            if(!isDeleting && hit.transform.gameObject.name == GRID_NAME) {
                Instantiate(objectArray[i], hit.point, Quaternion.Euler(new Vector3(0, rot, 0)));
            } else if(isDeleting && hit.transform.gameObject.tag == SPAWNABLE_TAG) {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public void setI(int j) {
        isDeleting = false;
        i = j;
    } 

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Alpha1)) setI(0);
        if(Input.GetKeyUp(KeyCode.Alpha2)) setI(1);
        if(Input.GetKeyUp(KeyCode.R)) rotate();

        if(Input.GetMouseButtonUp(0)) {
            mouseClicked();
        }
	}
}
