using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public ScoreHolder scoreHolder;
    public GameObject scoreHolderGO;
    public void Start()
    {

    }

    public void Update()
    {
        if (ScoreHolder.scoreHolder != null)
        {
            scoreHolder = ScoreHolder.scoreHolder;
            scoreHolderGO = scoreHolder.transform.gameObject;
        }
    }

    public void Proceed()
    {
        SceneManager.LoadScene(1);
    }
    public void Register()
    {
    
        SceneManager.LoadScene(2);
    }
    public void ConfirmLogin()
    {
    
        SceneManager.LoadScene(4);
    }
    public void Login()
    {
    
        SceneManager.LoadScene(3);
    }
    public void SelectionScreen()
    {
    
        SceneManager.LoadScene(4);
    }
    public void LevelSelection()
    {
        ScoreHolder.scoreHolder = null;
        Destroy(scoreHolder);
        SceneManager.LoadScene(5);
    }
    public void LoadGame()
    {
        
    }
    public void QuitGameScreen()
    {
     
        SceneManager.LoadScene(6);
    }
    public void QuitGame()
    {
        Application.Quit();
     
    }
    public void Credits()
    {
    
        SceneManager.LoadScene(7);
    }
    public void HideOut()
    {
    
        SceneManager.LoadScene(8);
    }
    public void Level1()
    {
    
        SceneManager.LoadScene(9);
    }
    public void Level2()
    {
    
    }
    public void Level3()
    {
    
    }
}
