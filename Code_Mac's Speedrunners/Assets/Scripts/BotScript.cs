using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    //Bot
    public Rigidbody rigidbodyBot;
    public bool chaseField = false;
    public bool aggroOnPlayer = false;
    public bool armsUp = false;
    public Transform screws;

    //Markers
    public GameObject[] markers;
    public GameObject currentMarker;
    private int markerNumber = 0;
    public float switchDistance = 0;

    //Player
    public Collider target;

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
    }
    void AggroOnPlayer()
    {
        if (chaseField)
        {
            rigidbodyBot.transform.LookAt(target.transform);
        }
    }
    void MoveBot()
    {
        Vector3 forwardDir = 3 * transform.forward; //time.Deltatime?
        rigidbodyBot.velocity = new Vector3(forwardDir.x, rigidbodyBot.velocity.y, forwardDir.z);
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
    }
}
