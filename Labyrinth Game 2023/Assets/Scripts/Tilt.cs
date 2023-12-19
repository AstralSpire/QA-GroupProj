using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 currentRot;
    public float speed = 50;
    public float tiltMax = 30;
    public Camera skyCamera;

    private float x;
    private float z;

    private bool tiltable;
    void Start()
    {
        tiltable = false;
    }
    public void turnontilt()
    {
        tiltable = true;
    }


    // Update is called once per frame
    void Update()   
    {
        if (tiltable)
        {
            currentRot = transform.eulerAngles;

            //Debug.Log(Input.GetAxis("Horizontal"));
            if (Input.GetAxis("Horizontal") > 0.2f && (currentRot.z >= (360 - tiltMax) || currentRot.z <= tiltMax + 1)) // Left tilt. -0.2f is for deadzone on analogue sticks. This also Limits max tilt
            {

                z -= speed * Time.deltaTime;
            }

            if (Input.GetAxis("Horizontal") < -0.2f && (currentRot.z <= tiltMax || currentRot.z >= (359 - tiltMax))) // Right tilt with max tilt
            {
                z += speed * Time.deltaTime;
            }

            if (Input.GetAxis("Horizontal") == 0 && z != 0) // Returns Left/Right tilt to middle when nothing is pressed
            {
                z = Mathf.Lerp(z, 0, 1 * Time.deltaTime);

            }

            if (Input.GetAxis("Vertical") < -0.2f && (currentRot.x <= tiltMax || currentRot.x >= (359 - tiltMax))) //Up tilt with max tilt
            {
                x -= speed * Time.deltaTime;
            }

            if (Input.GetAxis("Vertical") > 0.2f && (currentRot.x >= (360 - tiltMax) || currentRot.x <= tiltMax + 1)) //Down tilt with max tilt
            {
                x += speed * Time.deltaTime;
            }

            if (Input.GetAxis("Vertical") == 0 && x != 0) // Returns Up/Down tilt to middle tilt to middle when nothing is pressed
            {
                x = Mathf.Lerp(x, 0, 1 * Time.deltaTime); ;
            }


            transform.localRotation = Quaternion.Euler(x, 0, z); // Updates platform rotation

            SkyCameraRotation(); // Tilts background using 2nd camera
        }
    }

    public void SkyCameraRotation()
    {
        skyCamera.transform.rotation = Quaternion.Euler(x / 5, 0, z / 5); 
    }
}
