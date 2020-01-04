using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    private float tmrMine, tmrStart;
    public float damageFactor;

    private void Start()
    {
        tmrStart = Time.time;
         Destroy(this.gameObject, 30f);
    }

    private void OnTriggerEnter(Collider other)
    {
        tmrMine = Time.time - tmrStart;

        if (other.tag == "NOCHEESE")
        {
            Debug.Log("NO FKN CHEESE");
            other.GetComponent<NOCHEESE>().CheeseDamage(damageFactor * tmrMine / 2);
            Destroy(this.gameObject);
        }
        else if (other.GetComponent<Target>() != null)
        {
            other.GetComponent<Target>().TakeDamage(damageFactor * tmrMine);
            Destroy(this.gameObject);
        }





    }
}
