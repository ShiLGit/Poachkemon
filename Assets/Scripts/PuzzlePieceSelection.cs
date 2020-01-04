using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceSelection : MonoBehaviour {

    public string bunnyEars;
    public string greenPoké;
    public string purplePoké;

    // Use this for initialization
    public void Bunny()
    {
        Application.LoadLevel(bunnyEars);
    }

    public void Green()
    {
        Application.LoadLevel(greenPoké);
    }

    public void Purple()
    {
        Application.LoadLevel(purplePoké);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
