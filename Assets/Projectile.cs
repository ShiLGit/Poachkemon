using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage=30;
    public float speed = 10f;


    private void Start()
    {
        transform.Translate(0, 4, 0);
        Destroy(this.gameObject, 6f);
    }
    private void Update()
    {
        speed += 0.1f;
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Attack>().PlayerHurt(damage);
        }
    }
}
