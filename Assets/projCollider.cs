using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projCollider : MonoBehaviour {

    public ParticleSystem boom;

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { boom.Play();
            Debug.Log("BOOM");
        }

    }
}
