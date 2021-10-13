using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    public float mouseXSensitivity = 1f;
    public float mouseYSensitivity = 1f;
    public Transform rotationPoint;
    float mouseX = 0;
    float mouseY = 0;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseXSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseYSensitivity;
        float axisMouseY = Input.GetAxis("Mouse Y");
        /*if (mouseXSensitivity != 100 || mouseYSensitivity != 100)
        {
            Debug.Log("<MouseX.Sensitivity= " + mouseXSensitivity + ">" + "<MouseY.Sensitivity= " + mouseYSensitivity + ">");
        }*/
        
        xRotation -= axisMouseY;
        xRotation = Mathf.Clamp(xRotation, -42, 48);
        rotationPoint.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Debug.Log("xRotation:" + xRotation + " mouseY:" + axisMouseY);
        Vector3 rotation = new Vector3(xRotation, mouseX, 0);
        rotationPoint.eulerAngles = rotation;
    }
}
