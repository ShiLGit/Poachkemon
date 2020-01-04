using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {

    public string nextScene;

	// Use this for initialization
	public void Next()
    {
        Application.LoadLevel(nextScene);
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }
}
