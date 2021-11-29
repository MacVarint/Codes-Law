using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseFieldScript : MonoBehaviour
{
    public sentryScript sentryScript;
    public BotScript botScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (this.gameObject.tag == "Sentry")
            {
                sentryScript.chaseField = true;
            }
            else if (this.gameObject.tag == "Bot")
            {
                botScript.chaseField = true;
            }
            else
            {
                Debug.Log("Error enter chasefield");
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        //Is it the player?
        if (other.gameObject.name == "Player")
        {
            //Is this a sentry?
            if (this.gameObject.tag == "Sentry")
            {
                sentryScript.chaseField = false;
                sentryScript.aggroOnPlayer = false;
            }//Is this a bot?
            else if (this.gameObject.tag == "Bot")
            {
                botScript.chaseField = false;
                botScript.aggroOnPlayer = false;
            }
            else
            {
                Debug.Log("Error exit chasefield");
            }
        }
    }
}