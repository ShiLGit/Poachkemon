using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip1 : MonoBehaviour {
    public string nextScene;

    void Start()
    {
        Cursor.visible = true;
    }

    public void GoTo()
    {
        Stats.health = Stats.maxHealth;
        Stats.stamina = Stats.maxStam;
        Application.LoadLevel(nextScene);
    }
}
