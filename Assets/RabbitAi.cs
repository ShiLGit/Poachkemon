using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RabbitAi : MonoBehaviour {


    Transform player;
    NavMeshAgent nav;
    public static Animator Rabbit;
    public GameObject trash;
    public Attack playerScript;
    public GameObject field;
    private float timeStart;
    public bool isField = false;
    public GameObject projectilePrefab;
    private GameObject projectile;
    private float projTimeStart;
    private float animStop;
    //LET RABBIT REPLACE GHOST 
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Rabbit = GetComponent<Animator>();
        timeStart = Time.time;
        projTimeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (projTimeStart <= Time.time - 4.5)
            Rabbit.SetBool("isAttacking", true);
        if (Time.time > (timeStart + 25f))
        { isField = false; }

            nav.SetDestination(player.position);

        if (Vector3.Distance(player.position, this.transform.position) < 30 && isField == false)
        {
            timeStart = Time.time;
            isField = true;
            Vector3 p = this.transform.position;
            GameObject fieldCopy = Instantiate(field, this.transform.position, Quaternion.Euler(1000, 0, 0));
        }

        if (Vector3.Distance(player.position, this.transform.position) < 10)
        {
            //animation.

            Attack();
        }
        // else
        // Ghost.SetBool("isAttacking", false);

        //PROJCTILE SHOOOOOOT
        if (projTimeStart <= Time.time - 5)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                Debug.Log(hitObject);
                if (hitObject.GetComponent<Stats>() != null)
                {
                    projTimeStart = Time.time;
                    Debug.Log("R" + this.transform.rotation.y);
                    GameObject projt=Instantiate(projectilePrefab, this.transform.position, Quaternion.Euler(0,this.transform.eulerAngles.y, 0));
                    
                }
                Rabbit.SetBool("isAttacking",false);
            }
        }
    }

    void Attack()
    {
        playerScript.PlayerHurt(2f);

    }
}
