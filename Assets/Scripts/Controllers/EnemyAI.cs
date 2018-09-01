using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public Transform goal;

    private NavMeshAgent agent;
    private Animator animator;
    private bool reachedGoal = false;
    private float remaining;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        animator = GetComponent<Animator>();
        animator.SetBool("Walking", true);
        remaining = Vector3.Distance(transform.position, goal.position);

        InvokeRepeating("checkDistance", 1.0f, 1.0f);
	}

    void checkDistance() {
        float dist = remaining;
        remaining = Vector3.Distance(transform.position, goal.position);

        Debug.Log(Mathf.Abs(remaining - dist));

        if (!reachedGoal) {
            reachedGoal = Mathf.Abs(remaining - dist) <= 0.2;
        }
        else {
            animator.SetBool("Walking", false);
            animator.SetBool("Attacking", true);
        }
    }

    void Update() {
        
    }
	
}
