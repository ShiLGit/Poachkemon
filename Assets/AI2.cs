using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI2 : MonoBehaviour {
    Transform player;
    NavMeshAgent nav;
    public static Animator Slime;
    public GameObject trash;
    public Attack playerScript;
    public float damage;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

	void Start ()
    {
        Slime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Slime.SetBool("isAttacking", false);
        nav.SetDestination(player.position);

        if (Vector3.Distance(player.position, this.transform.position) < 15)
        {
            //animation.
            Debug.Log("ATTACKING");
            Slime.SetBool("isAttacking", true);
            Attack();
        }
        else
            Slime.SetBool("isAttacking", false);
	}

    void Attack()
    {
        playerScript.PlayerHurt(damage);
     
    }
    }
