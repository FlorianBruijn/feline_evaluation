using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_look : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform body;

    float xRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set valeus
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        //rotate x
        body.Rotate(Vector3.up * -mouseX);
        //rotate y
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -100f, -60);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        
    }
}
