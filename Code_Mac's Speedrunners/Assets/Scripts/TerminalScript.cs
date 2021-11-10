using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalScript : MonoBehaviour
{
    public GameObject interactionHud;
    private bool interact;
    private bool activated = true;
    public bool insideCollider;
    public GameObject accesTextGranted;
    public GameObject accesTextDenied;
    // Start is called before the first frame update
    void Start()
    {
        interactionHud = GameObject.FindGameObjectWithTag("InteractionHud");
        accesTextGranted.SetActive(false);
        accesTextDenied.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        if (insideCollider)
        {
            if (interact)
            {
                interactionHud.SetActive(false);
                accesTextGranted.SetActive(true);
                accesTextDenied.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (accesTextDenied && activated)
            {
                interactionHud.SetActive(true);
                insideCollider = true;
                activated = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            interactionHud.SetActive(false);
            insideCollider = false;
        }
    }
    private void Inputs()
    {
        interact = Input.GetKeyDown(KeyCode.E);
    }
}
