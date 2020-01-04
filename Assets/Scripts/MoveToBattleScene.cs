using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBattleScene : MonoBehaviour {

    public BoxCollider player;

    public BoxCollider battle1;

    public string nextScene;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		//if (player == battle1)
       // {
           
       // }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            Application.LoadLevel(nextScene);
        }
    }
}
