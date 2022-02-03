using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuTransform;
    public GameObject OptionsTransform;
    private bool isEnabled = false;
    private bool optionsEnabled = false;
    public PlayerMouse playerMouse;
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
        // Checks if the options menu is open
        if (Input.GetKeyDown(KeyCode.Escape) && optionsEnabled)
        {
            DisableOptions();
        } // Enables escapeMenu
        else if (Input.GetKeyDown(KeyCode.Escape) && !isEnabled)
        {
            PauseGame();
        } // Disables escapeMenu
        else if (Input.GetKeyDown(KeyCode.Escape) && isEnabled)
        {
            Continue();
        }
    }
    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        escapeMenuTransform.SetActive(false);
        Time.timeScale = 1f;
        playerMouse.enabled = true;
        isEnabled = false;
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        escapeMenuTransform.SetActive(true);
        Time.timeScale = 0f;
        playerMouse.enabled = false;
        isEnabled = true;
    }
    public void EnableOptions()
    {
        escapeMenuTransform.SetActive(false);
        OptionsTransform.SetActive(true);
        optionsEnabled = true;
    }
    public void DisableOptions()
    {
        escapeMenuTransform.SetActive(true);
        OptionsTransform.SetActive(false);
        optionsEnabled = false;
    }
}
