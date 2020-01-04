using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {
    public float health = 50f, dedTime;
    public Attack scrAttack;
    public Rigidbody me;
    public Text targetHealth;
    public static Animator SlimeT;
    public string NextLevel;
    public string disableAI;

    void Start()
    {
        Cursor.visible = false;
        targetHealth.text = "Enemy Health: "+ health.ToString();
        SlimeT = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        targetHealth.text = "Enemy Health: " + health.ToString();

        if (health <= 0f)
        {
            dedTime = Time.time + 2;
            targetHealth.text = "Enemy Health: 0";
            Die();
        }
    }

    void Die()
    {
        if (disableAI == "Slime")
        {
            SlimeT.SetBool("isDying", true);
            GetComponent<AI2>().enabled = false;
        }
        else if(disableAI=="Ghost")
        GetComponent<GhostAI>().enabled = false;
        else if (disableAI=="Rabbit")
        GetComponent<RabbitAi>().enabled = false;

        Cursor.visible = true;
        Application.LoadLevel(NextLevel);
    }

}
