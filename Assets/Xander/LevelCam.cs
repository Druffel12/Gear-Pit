using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCam : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float rotationSpeed = 2.0f;

    private Vector3 rot;



    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        rot.y += Input.GetAxis("Mouse X") * rotationSpeed;
        rot.x -= Input.GetAxis("Mouse Y") * rotationSpeed;
        rot.x = Mathf.Clamp(rot.x, -90, 90);

        transform.eulerAngles = rot;

        Vector3 moveVec = Vector3.zero;
        moveVec += Input.GetAxis("Vertical") * transform.forward * moveSpeed;
        moveVec += Input.GetAxis("Horizontal") * transform.right * moveSpeed;
        transform.position += moveVec;
    }

}
