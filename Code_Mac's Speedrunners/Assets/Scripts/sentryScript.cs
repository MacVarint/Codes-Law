using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentryScript : MonoBehaviour
{
    
    //public Vector3 rigidbodyBotRotation;

    //Markers
    public GameObject[] markers;
    public GameObject currentMarker;
    private int markerNumber = 0;
    //Bot
    public Rigidbody rigidbodyBot;
    public bool armsUp = false;
    public Transform leftArm;
    public Transform rightArm;
    public bool chaseField = false;
    public float damping;
    public bool aggroOnPlayer = false;
    public float switchDistance = 0;

    //Player
    public Collider target;

    //Headlights
    public Transform pole;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        /*var lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);*/
    }
    void headlights()
    {
        pole.Rotate(0, 40 * Time.deltaTime, 0);
    }
    void MoveBot()
    {
        Vector3 forwardDir = 3 * transform.forward; //time.Deltatime?
        rigidbodyBot.velocity = new Vector3(forwardDir.x, rigidbodyBot.velocity.y, forwardDir.z);
        //Debug.Log((transform.position - currentMarker.transform.position).magnitude);
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
        //Whrite chase code here
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
        //rigidbodyBotRotation = new Vector3(0,45,0);
        //Quaternion deltaRotation = Quaternion.Euler(rigidbodyBotRotation * Time.fixedDeltaTime);
        //rigidbodyBot.MoveRotation(rigidbodyBot.rotation * deltaRotation);
    }
}
