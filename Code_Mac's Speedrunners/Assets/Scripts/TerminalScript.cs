using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    public GameObject interactionHud;
    private bool interactionHudBool = false;
    private bool interact;
    public bool insideCollider;
    public GameObject accesTextGranted;
    public GameObject accesTextDenied;

    //Animation
    public Animator animator;
    public bool invertStartupState;

    public bool firstUse = true;
    // Start is called before the first frame update
    void Start()
    {
        //Seaches for a gameobject called Interaction hud
        interactionHud = GameObject.FindGameObjectWithTag("InteractionHud");
        //Presets terminal states
        accesTextGranted.SetActive(false);
        accesTextDenied.SetActive(true);
        //Presets door states
        if (!invertStartupState)
        {
            animator.SetBool("State", false);
        }
        else if (invertStartupState)
        {
            animator.SetBool("State", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Interaction();
    }
    private void OnTriggerEnter(Collider other)
    {
        //Checks if the entered object is the player
        if(other.gameObject.name == "Player")
        {
            //Sets text to active
            interactionHud.SetActive(true);
            interactionHudBool = true;
            insideCollider = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Checks if the leaved object is the player
        if (other.gameObject.name == "Player")
        {
            //Sets text to inactive
            interactionHud.SetActive(false);
            interactionHudBool = false;
            insideCollider = false;
        }
    }
    private void Inputs()
    {
        interact = Input.GetKeyDown(KeyCode.E);
    }
    private void Interaction()
    {
        //Checks if player is inside the collider
        if (insideCollider && interactionHudBool)
        {
            //Checks if the player presses E
            if (interact)
            {
                //Sets text to inactive
                interactionHud.SetActive(false);
                interactionHudBool = false;
                //Switches text to acces granted
                accesTextGranted.SetActive(true);
                accesTextDenied.SetActive(false);

                if (firstUse)
                {
                    ScoreHolder.scoreHolder.terminalsHacked++;
                    firstUse = false;
                }

                if (animator.GetBool("State"))
                {
                    animator.SetBool("State", false);
                }
                else if (!animator.GetBool("State"))
                {
                    animator.SetBool("State", true);
                    ScoreHolder.scoreHolder.doorsOpened++;
                }
                else
                {
                    Debug.Log("Error Boolean Door-State");
                }

            }
        }
    }
}
