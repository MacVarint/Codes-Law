using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableScript : MonoBehaviour
{
    public Material on;
    public Material off;
    public Transform[] cable;
    public TerminalScript parentTerminal;
    public int count = 0;
    private float timer;
    void Start()
    {
        //Gets all the children
        cable = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            cable[i]  = transform.GetChild(i).transform;
        }
       
    }

    void Update()
    {
        if (parentTerminal.animator.GetBool("State"))
        {
            timer = timer + Time.deltaTime * 10;
            if (timer < (this.transform.childCount))
            {
                count = (int)timer;
                cable[count].gameObject.GetComponent<MeshRenderer>().material = on;
            }
            else
            {
                timer = (this.transform.childCount)-1;
                count = (int)timer;
            }
        }
        else
        { 
            timer = timer - Time.deltaTime * 10;
            if (timer > 0 )
            {
                count = (int)timer;
                cable[count].gameObject.GetComponent<MeshRenderer>().material = off;
            }
            else
            {
                timer = 0;
                count = (int)timer;
            }

        }
        Debug.Log(timer);
    }
}
