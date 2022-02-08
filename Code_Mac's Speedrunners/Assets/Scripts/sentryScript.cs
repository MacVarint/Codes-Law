using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryScript : MonoBehaviour
{
    //Bot
    public Rigidbody rigidbodyBot;
    public bool armsUp = false;
    public Transform leftArm;
    public Transform rightArm;
    public bool chaseField = false;
    public bool aggroOnPlayer = false;
    public float switchDistance = 0;

    //Markers
    public GameObject[] markers;
    public GameObject currentMarker;
    private int markerNumber = 0;

    //Player
    public Collider target;

    //Headlights
    public Transform pole;

    void Update()
    {
        if (aggroOnPlayer)
        {
            AggroOnPlayer();
        }
        MoveBot();
        
        headlights();
    }
    void AggroOnPlayer()
    {
        if (chaseField)
        {
            rigidbodyBot.transform.LookAt(target.transform);
        }
    }
    void headlights()
    {
        pole.Rotate(0, 40 * Time.deltaTime, 0);
    }
    void MoveBot()
    {
        Vector3 forwardDir = 3 * transform.forward;
        rigidbodyBot.velocity = new Vector3(forwardDir.x, rigidbodyBot.velocity.y, forwardDir.z);
        if ((transform.position - currentMarker.transform.position).magnitude < switchDistance)
        {
            markerNumber++;
            if (markerNumber >= markers.Length)
            {
                markerNumber = 0;
            }
            currentMarker = markers[markerNumber];
        }
        if (aggroOnPlayer == true)
        {
            ChasePlayer();
        }
        else
        {
            RotateBot();
            if (armsUp)
            {
                leftArm.Rotate(90, 0, 0);
                rightArm.Rotate(90, 0, 0);
                armsUp = false;
            }
        }
    }
    void ChasePlayer()
    {
        if (!armsUp)
        {
            leftArm.Rotate(-90, 0, 0);
            rightArm.Rotate(-90, 0, 0);
            armsUp = true;
        }

    }
    void RotateBot()
    {
        rigidbodyBot.transform.LookAt(currentMarker.transform);
    }
}
