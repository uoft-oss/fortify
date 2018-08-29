using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public float dayDuration = 8.0f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate ( Vector3.up * ( dayDuration * Time.deltaTime ) );
	}
}
