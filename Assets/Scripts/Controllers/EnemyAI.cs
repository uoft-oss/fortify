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
    private bool isAttacking = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.position);
        animator = GetComponent<Animator>();
        animator.SetBool("Walking", true);
        remaining = Vector3.Distance(transform.position, goal.position);

        //InvokeRepeating("checkDistance", 1.0f, 1.0f);
        InvokeRepeating("CheckCollision", 1.0f, 2.0f);
	}

    void checkDistance() {
        if (!isAttacking) {
            float dist = remaining;
            remaining = Vector3.Distance(transform.position, goal.position);

            reachedGoal = Mathf.Abs(remaining - dist) <= 0.2;

            if (reachedGoal) {
                SetAttacking();
            }
            else {
                SetWalking();
            }
        }
    }

    void Update() {
        
    }

    void CheckCollision() {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5.0f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if ((hitColliders[i].transform.tag == "Enemy" || hitColliders[i].transform.tag == "Spawnable") && hitColliders[i].GetComponent<Life>() != null) {
                hitColliders[i].SendMessage("AddDamage", 5.0f);               
                SetAttacking();
                break;
            }
            else {
                SetWalking();
            }
            i++;
        }
    }

    void SetAttacking() {
        isAttacking = true;
        agent.speed = 0;
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);
    }

    void SetWalking() {
        isAttacking = false;
        agent.speed = 4f;
        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);
    }
	
}
