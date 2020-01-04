using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScene : MonoBehaviour {

    public string previousScene;

	// Use this for initialization
	public void Back()
    {
        Application.LoadLevel(previousScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
