using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public float health = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (health <= 0) {
            DestroySelf();
        }
	}

    void AddDamage(float damage) {

        Debug.Log("taking damage");
        health -= damage;
    }

    void DestroySelf() {
        Debug.Log("destroyyy");
        Destroy(this.gameObject);
    }
}
