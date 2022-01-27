using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCameraRig : MonoBehaviour
{


    public float speed = 10;

    private float pitch = 0;
    private float yaw = 0;

    public float mouseSenseitivityX = 1;
    public float mouseSenseitivityY = 1;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Update Position of camera:
        float v = Input.GetAxis("Vertical"); // Forward & Back
        float h = Input.GetAxis("Horizontal"); // Left & Right (strafe)


        //transform.position += transform.forward * v * Time.deltaTime;
        //transform.position += transform.right * h * Time.deltaTime;

        Vector3 dir = transform.forward * v + transform.right * h;
        if (dir.magnitude > 1) dir.Normalize();

        transform.position += dir * Time.deltaTime * speed;


        //Update rotation of camera:
        float mx = Input.GetAxis("Mouse X"); // yaw (Y)
        float my = Input.GetAxis("Mouse Y"); // pitch (X)

        yaw += mx * mouseSenseitivityX;
        pitch -= my * mouseSenseitivityY;

        pitch = Mathf.Clamp(pitch, -89, 89);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);



    }
}
