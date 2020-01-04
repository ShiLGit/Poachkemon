using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOCHEESE : MonoBehaviour
{
    public bool isRabbit;
    public Target noCheeseTarget;

    public void CheeseDamage(float dmg)
    {
        if (isRabbit == true)
            noCheeseTarget.TakeDamage(dmg / 3);
        else
            noCheeseTarget.TakeDamage(dmg);
    }

}
