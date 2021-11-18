using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Animator animator;
    public bool activate = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (activate)
        {
            animator.SetBool("State", true);
        }
        else
        {
            animator.SetBool("State", false);
        }
    }
}
