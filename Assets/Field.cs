using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {
    public float damage;
    private void Start()
    {
        Destroy(this.gameObject, 15f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Attack>()!=null)
        other.GetComponent<Attack>().PlayerHurt(damage);
    }
}
