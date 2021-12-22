using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public void Proceed()
    {
        Debug.Log("Proceed");
        SceneManager.LoadScene(1);
    }
    public void Register()
    {
        Debug.Log("Register");
        SceneManager.LoadScene(2);
    }
    public void ConfirmLogin()
    {
        Debug.Log("ConfirmLogin");
        SceneManager.LoadScene(4);
    }
    public void Login()
    {
        Debug.Log("Login");
        SceneManager.LoadScene(3);
    }
    public void SelectionScreen()
    {
        Debug.Log("SelectionScreen");
        SceneManager.LoadScene(4);
    }
    public void LevelSelection()
    {
        Debug.Log("LevelSelection");
        SceneManager.LoadScene(5);
    }
    public void LoadGame()
    {
        Debug.Log("Not working yet");
    }
    public void QuitGameScreen()
    {
        Debug.Log("Quit?");
        SceneManager.LoadScene(6);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene(7);
    }
    public void HideOut()
    {
        Debug.Log("HideOut");
        SceneManager.LoadScene(8);
    }
    public void Level1()
    {
        Debug.Log("Level1");
        SceneManager.LoadScene(9);
    }
    public void Level2()
    {
        Debug.Log("Level2");
    }
    public void Level3()
    {
        Debug.Log("Level3");
    }
}
