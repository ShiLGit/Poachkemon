using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    private float vVert, fGrav=26, fJump=10; 
    public float sensitivity = 9f;
    public GameObject eyes;
    public Text statStamina;
    CharacterController player;
    float moveFB, moveLR;

    float rotX, rotY;

    // Use this for initialization
    void Start ()
    {
        player = GetComponent<CharacterController>();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update()
    {
        Stats.textStamina = (int)(Stats.stamina / 10);
        statStamina.text = "Stamina: " + Stats.textStamina;
      
        //running
        if (Input.GetButton("Run") && Stats.stamina >0)
        {
            Stats.speed = Stats.baseSpeed * Stats.runBuff;
            Stats.stamina -= 1;
        }
        else if (!Input.GetButton("Run") || Stats.stamina <=0)
        {
            Stats.speed = Stats.baseSpeed;
            if (Stats.stamina <= Stats.maxStam)
                Stats.stamina += Stats.staminaRate;
        }

        //jumping
        if (player.isGrounded&&Input.GetKeyDown(KeyCode.Space))
            vVert = fJump;
        else
        {
            vVert -= fGrav * Time.deltaTime;
        }       
        
        //evaluate for position change

        moveFB = Input.GetAxis("Vertical") * Stats.speed;
        moveLR = Input.GetAxis("Horizontal") * Stats.speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveLR, vVert, moveFB);
        transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

    }
}
