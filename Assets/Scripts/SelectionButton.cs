using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionButton : MonoBehaviour {

    public void IChooseYou(string choice)
    {
        if (choice == "Turtle")
        {
        Stats.maxHealth += 20;
        Debug.Log("T");
        }
        else if (choice == "Chicken")
            Stats.maxStam += 2;
        else if (choice == "Degenerate")
            Stats.range -= 1;

        Application.LoadLevel("Satec Scene");
    }
}
