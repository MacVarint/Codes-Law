using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuTransform;
    private bool isEnabled = false;
    public void Start()
    {
        escapeMenuTransform = GameObject.FindGameObjectWithTag("EscapeMenu");
    }
    private void Update()
    {
        Escape();
    }
    public void Escape()
    {
        // Enables escapeMenu
        if (Input.GetKeyDown(KeyCode.Escape) && isEnabled == false)
        {
            Cursor.lockState = CursorLockMode.None;
            escapeMenuTransform.SetActive(true);
            isEnabled = true;
        } // Disables escapeMenu
        else if (Input.GetKeyDown(KeyCode.Escape) && isEnabled == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            escapeMenuTransform.SetActive(false);
            isEnabled = false;
        }
    }
    public void Continue()
    {

    }
}
