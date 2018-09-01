using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float directionChangeSlowInterval = 0.15f;
    public float directionChangeFastInterval = 0.8f;
    public float maxHeadingChange = 30;
    public bool attacking = false;

    private CharacterController controller;
    private float heading;
    private Vector3 targetRotation;
    private Animator animator;

    private bool idle = true;
    private float directionChangeInterval = 0.5f;

    private float startTime = 0f;

	// Use this for initialization
	void Awake () {
		controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        startTime = Time.time;
	}

    IEnumerator NewHeading() {
        while(true) {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void NewHeadingRoutine() {
        float floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
        float ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (!attacking) {
            animator.SetBool("Attacking", false);
            if (Time.time - startTime > Random.Range(7, 10)) {
                idle = !idle;
                startTime = Time.time;
                if (idle) directionChangeInterval = directionChangeFastInterval;
                else directionChangeInterval = directionChangeSlowInterval;
            }
            
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
            
            if (idle) {
                Debug.Log("idling");
                animator.SetBool("Walking", false);
            }
            else {
                animator.SetBool("Walking", true);
                var forward = transform.TransformDirection(Vector3.forward);
                controller.SimpleMove(forward * speed);
            }
        }
        else {
            animator.SetBool("Attacking", true);
        }
	}
}
