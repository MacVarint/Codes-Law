using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorListener : MonoBehaviour
{
    public Animator thisAnimator;
    public Animator animator;

    public bool active = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("State") && active == false)
        {
            thisAnimator.SetBool("State", true);
            ScoreHolder.scoreHolder.doorsOpened++;
            active = true; 
        }
        else if (!animator.GetBool("State") && active == true)
        {
            thisAnimator.SetBool("State", false);
            active = false;
        }
    }
}
