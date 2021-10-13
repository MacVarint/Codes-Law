using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    public Rigidbody rigidbodyBot;
    //public Vector3 rigidbodyBotRotation;
    public GameObject[] markers;
    public GameObject currentMarker;
    private int markerNumber = 0;
    public float switchDistance = 0;
    public bool aggroOnPlayer = false;
    public bool armsUp = false;
    public Transform screws;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveBot();
    }

    void MoveBot()
    {
        Vector3 forwardDir = 3 * transform.forward; //time.Deltatime?
        rigidbodyBot.velocity = new Vector3(forwardDir.x, rigidbodyBot.velocity.y, forwardDir.z);
        Debug.Log((transform.position - currentMarker.transform.position).magnitude);
        if ((transform.position - currentMarker.transform.position).magnitude < switchDistance)
        {
            markerNumber++;
            if(markerNumber >= markers.Length)
            {
                markerNumber = 0;
            }
            currentMarker = markers[markerNumber];
        }
        if(aggroOnPlayer == true)
        {
            ChasePlayer();
        }
        else
        {
            RotateBot();
            if (armsUp)
            {
                screws.Rotate(0, -90, 0);
                armsUp = false;
            }
        }
    }
    void ChasePlayer()
    {
        //Whrite chase code here
        if (!armsUp)
        {
            screws.Rotate(0, 90, 0);
            armsUp = true;
        }
        
    }
    void RotateBot()
    {
        rigidbodyBot.transform.LookAt(currentMarker.transform);
        //rigidbodyBotRotation = new Vector3(0,45,0);
        //Quaternion deltaRotation = Quaternion.Euler(rigidbodyBotRotation * Time.fixedDeltaTime);
        //rigidbodyBot.MoveRotation(rigidbodyBot.rotation * deltaRotation);
    }
}
