using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSelection : MonoBehaviour {

    public string man;
    public string bird;
    public string turtle;

    // Use this for initialization
    public void Man()
    {
        Application.LoadLevel(man);
    }

    public void Bird()
    {
        Application.LoadLevel(bird);
    }

    public void Turtle()
    {
        Application.LoadLevel(turtle);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
