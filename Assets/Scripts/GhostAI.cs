using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostAI : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    public static Animator Ghost;
    public GameObject trash;
    public Attack playerScript;
    public GameObject field;
    private float timeStart;
    public bool isField = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Ghost = GetComponent<Animator>();
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > (timeStart + 25f))
        { isField = false; }
       // Ghost.SetBool("isAttacking", false);
        nav.SetDestination(player.position);

        if (Vector3.Distance(player.position, this.transform.position) < 30 && isField==false)
        {
            timeStart = Time.time;
            isField = true;
            Vector3 p = this.transform.position;
            GameObject fieldCopy = Instantiate(field, this.transform.position, Quaternion.Euler(1000,0,0));
        }

            if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            //animation.
         //   Ghost.SetBool("isAttacking", true);
            Attack();
        }
        // else
        // Ghost.SetBool("isAttacking", false);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
    }

    void Attack()
    {
        playerScript.PlayerHurt(2f);

    }
}

