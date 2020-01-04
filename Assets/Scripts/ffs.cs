using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ffs : MonoBehaviour {
    // Update is called once per frame
    public string next;
	public void Exit ()
    {
        Application.Quit();
    }
    public void NextSceneRestart()
    {
        Stats.maxHealth = 200;
        Stats.maxStam = 100;
        Application.LoadLevel(next);
    }
}
