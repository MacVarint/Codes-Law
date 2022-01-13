using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadZone : MonoBehaviour
{
    public TimerScript timerScript;
    public int scene;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ScoreHolder.scoreHolder.secondsPlayed = timerScript.seconds;
            ScoreHolder.scoreHolder.minutesPlayed = timerScript.minutes;
            ScoreHolder.scoreHolder.millisecondsPlayed = timerScript.miliSeconds;
            ScoreHolder.scoreHolder.timer = timerScript.timer;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(scene);
        }
    }
}
