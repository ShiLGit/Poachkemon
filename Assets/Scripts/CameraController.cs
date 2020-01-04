using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public bool useOffsetValues;

    public float rotateSpeed;

    public Transform pivot;

	// Use this for initialization
	void Start ()
    {
        if (useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
	}

	
	// Update is called once per frame
	void Update ()
    {
        //get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        float verticle = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.Rotate(-verticle, 0, 0);

        float deriredYAngle = target.eulerAngles.y;

        float deriredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(deriredXAngle, deriredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;

        transform.LookAt(target);
	}
}
