using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    //public Rigidbody theRB;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

	// Use this for initialization
	void Start ()
    {
        // theRB = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //  theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

      //  moveDirection = (transform.forward * Input.GetAxis("Verticle")) + (transform.right * Input.GetAxis("Horizontal"));
     //   moveDirection = moveDirection.normalized * moveSpeed;

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

    }
}
