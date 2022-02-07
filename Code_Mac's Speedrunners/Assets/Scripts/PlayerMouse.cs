using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : CameraController
{
    public float mouseXSensitivity = 1f;
    public float mouseYSensitivity = 1f;
    public Transform rotationPoint;
    float mouseX = 0;
    float mouseY = 0;
    private float xRotation = 0f;

    public float backDistance;

    public Transform mainCamera;
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
        xRotation = Mathf.Clamp(xRotation, -48, 48);
        rotationPoint.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Debug.Log("xRotation:" + xRotation + " mouseY:" + axisMouseY);
        Vector3 rotation = new Vector3(xRotation, mouseX, 0);
        rotationPoint.eulerAngles = rotation;

        Vector3 tempDirection = mainCamera.position - transform.position ;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position + Vector3.Normalize(tempDirection), tempDirection, out hit, 4f))
        {
            Debug.Log(hit.point);
           mainCamera.position = hit.point - Vector3.Normalize(tempDirection) *  0.05f;
        }

    }
    void OnDrawGizmosSelected()
    {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.red;
        Vector3 tempDirection =  mainCamera.position - transform.position ;
        Gizmos.DrawLine(transform.position + Vector3.Normalize(tempDirection), transform.position + tempDirection * 100f);

        // Gizmos.DrawLine(transform.position, transform.position - tempDirection * 100);


    }
}
