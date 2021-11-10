using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionZoneScript : MonoBehaviour
{
    private Collider target;
    public sentryScript sentryScript;
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
            target = other;
            sentryScript.target = target;
            sentryScript.aggroOnPlayer = true;
        }
    }
}
