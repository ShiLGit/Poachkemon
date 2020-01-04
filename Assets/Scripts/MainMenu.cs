using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playGameStart;
    public string instructions;
    public string settings;

	// Use this for initialization
	public void PlayGame()
    {
        Application.LoadLevel(playGameStart);
	}

    public void Exit()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        Application.LoadLevel(instructions);

    }

    public void Settings()
    {
        Application.LoadLevel(settings);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
