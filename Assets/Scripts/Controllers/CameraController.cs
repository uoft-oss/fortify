using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private float speedModifier = 100f;

    public float panSpeed = 20f;
    public float panBoarderThickness = 10f;
    public Vector2 panLimit =  new Vector2(50, 50);
    public bool disableMousePan = true;

    [Space(20)]
    public float scrollSpeed = 20f;
    public float minY = 10f;    
    public float maxY = 50f;   

    [Space(20)]
    public float rotationSpeed = 50f; 
    public bool disableRotation = true;
	
	// Update is called once per frame
	void Update () {
		
        // panning

        Vector3 pos = transform.position;
        
        if (Input.GetKey("w") || (Input.mousePosition.y >= Screen.height - panBoarderThickness && !disableMousePan)) {
            pos.z += panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("s") || (Input.mousePosition.y <= panBoarderThickness && !disableMousePan)) {
            pos.z -= panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("d") || (Input.mousePosition.x >= Screen.width - panBoarderThickness && !disableMousePan)) {
            pos.x += panSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("a") || (Input.mousePosition.x <= panBoarderThickness && !disableMousePan)) {
            pos.x -= panSpeed * Time.deltaTime;
        }

        // scrolling
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * speedModifier * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        // rotation
        if (Input.GetMouseButton(1) && !disableRotation) {
            transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0));
            float x = transform.rotation.eulerAngles.x;
            float y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(x, y, 0);
        }
        
	}
}
