using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public NavMeshAgent nav;
    Transform playerTransform;
    public float checkRate = 0.01f;
    public float nextCheck;
	// Use this for initialization
	void Start ()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }

    }

    void FollowPlayer()
    {
        nav.transform.LookAt(playerTransform);
    }
}
