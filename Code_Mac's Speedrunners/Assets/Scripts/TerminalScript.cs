using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    public GameObject interactionHud;
    private bool interact;
    private GameObject accesTextGranted;
    private GameObject accesTextDenied;
    // Start is called before the first frame update
    void Start()
    {
        interactionHud = GameObject.FindGameObjectWithTag("InteractionHud");
        interactionHud.SetActive(false);
        accesTextGranted = GameObject.FindGameObjectWithTag("Acces text g");
        accesTextGranted.SetActive(false);
        accesTextDenied = GameObject.FindGameObjectWithTag("Acces text d");

        Debug.Log("vibecheck");
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            interactionHud.SetActive(true);
            if (interact)
            {
                
            }
        }
    }
    private void Inputs()
    {
        interact = Input.GetKeyDown(KeyCode.E);
    }
}
