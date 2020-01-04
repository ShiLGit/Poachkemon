using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {

    public ParticleSystem muzzleFlash, shield;
    public GameObject impactEffect, mineFX, impactBoom;
    public Movement scrMovementAttack;
    public Camera fpsCam;
    public Text statHealth;
    public bool shielded;
    public Text statStatus;
    public float normalForce;

    private float startCharge, chargeTime;
    private float nextTimeToFire = 0f;
    private float shieldTime;
    private bool chargeShoot=false;
    // Update is called once per frame

    void Update ()
    {
            statHealth.text ="Your health: " + Stats.health.ToString();
        if (Time.time >= shieldTime)
        {
            if (statStatus.text == "Shielding")
                statStatus.text = "";
            shield.Stop();
            shielded = false;
        }
        if (Input.GetButtonDown("Fire1")&&Time.time>=nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / Stats.fireRate;
        }

        if (Input.GetButtonDown("Fire3") && Stats.stamina >= 30)
        {
            shield.Play();           
            shielded = true;
            Stats.stamina -= 30;
            shieldTime = Time.time + 1f;
            statStatus.text = "Shielding";
        }
        if (Input.GetButtonDown("Fire2") && Stats.stamina >= 40)
        {
            Stats.stamina -= 40;
            SpawnMine();
        }
        if (Input.GetButtonDown("Element 8")&&Stats.stamina>30)
        {
            Stats.stamina -= 30;
            Debug.Log("Charging");
            startCharge = Time.time;
            Debug.Log("efe");
            chargeShoot = !chargeShoot;
            Debug.Log("C:" +chargeShoot);
            statStatus.text = "[Knockback buff: on]";



        }

	}

    void Shoot()
    {
        RaycastHit hit;
        //IF IT HITS ANYHTING
        muzzleFlash.Play();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Stats.range))
        {
            Debug.Log(hit.transform.name);            
            Target target = hit.transform.GetComponent<Target>();

            //charge shot
            if (target != null && chargeShoot==true)
            {
                chargeTime = Time.time - startCharge;
                chargeShoot = false;
                Debug.Log(chargeTime * 30);
                target.GetComponent<Rigidbody>().AddForce(-hit.normal * normalForce * (chargeTime)); 

                GameObject impactBOOM = Instantiate(impactBoom, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactBOOM, 1.5f);

                statStatus.text = "";
                Stats.range = 30;
            }
            //normal shot
            else if (target!=null)
            {
                target.TakeDamage(Stats.damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1.5f);
    
        }
    }

    void SpawnMine()
    {
        Debug.Log("EXECUTED MINE!");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 200))
        {
            GameObject mine = Instantiate(mineFX, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    public void PlayerHurt(float damageReceived)
    {
        if (Stats.health <= 0)
        {
            Cursor.visible = true;
            Application.LoadLevel("Loozer"); }
        if (!shielded)
            Stats.health -= damageReceived;
    }
}
