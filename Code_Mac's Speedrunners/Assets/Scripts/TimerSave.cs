using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSave : MonoBehaviour
{
    public Text milisecondsText;
    public Text secondsText;
    public Text minutesText;
    public ScoreHolder scoreHolder;
    // Start is called before the first frame update
    void Start()
    {
        scoreHolder = ScoreHolder.scoreHolder;
        Converter();

    }

    public void Converter()
    {
        milisecondsText.text = scoreHolder.milisecondsPlayed.ToString("000");
        secondsText.text = scoreHolder.secondsPlayed.ToString("00");
        minutesText.text = scoreHolder.minutesPlayed.ToString("00");
    }
}