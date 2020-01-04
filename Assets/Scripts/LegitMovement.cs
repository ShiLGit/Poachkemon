using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegitMovement : MonoBehaviour {

    public float speed = 5f, runBuff = 50f;
    public float sensitivity = 9f;
    public GameObject eyes;
    CharacterController player;
    float moveFB, moveLR;

    float rotX, rotY;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("WTF");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= runBuff;
            Debug.Log(speed);
        }
        else
        {
            speed = 5f;
            Debug.Log(speed);
        }

        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

    }
}
