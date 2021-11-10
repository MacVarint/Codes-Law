using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseFieldScript : MonoBehaviour
{
    public sentryScript sentryScript;
    private bool chaseField;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            sentryScript.chaseField = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            sentryScript.chaseField = false;
            sentryScript.aggroOnPlayer = false;
        }
    }
    /*public void OnTriggerStay(Collider other)
    {
        
    }*/
}
