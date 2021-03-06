using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    public static ScoreHolder scoreHolder;
    public int minutesPlayed;
    public int secondsPlayed;
    public int millisecondsPlayed;
    public int doorsOpened;
    public int terminalsHacked;
    public bool gameOver;
    public float timer;
    public int level;

    // Start is called before the first frame update
    void Start()
    {

        if (scoreHolder == null)
        {
            scoreHolder = this;
        }
        else if (scoreHolder != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
