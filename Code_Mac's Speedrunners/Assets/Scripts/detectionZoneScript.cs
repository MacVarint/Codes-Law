using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionZoneScript : MonoBehaviour
{
    private Collider target;
    public sentryScript sentryScript;
    public BotScript botScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (this.gameObject.tag == "Sentry")
            {
                target = other;
                sentryScript.target = target;
                sentryScript.aggroOnPlayer = true;
            }
            else if (this.gameObject.tag == "Bot")
            {
                target = other;
                botScript.target = target;
                botScript.aggroOnPlayer = true;
            }
            else
            {
                Debug.Log("Error enter detectionzone");
            }
        }
    }
}
