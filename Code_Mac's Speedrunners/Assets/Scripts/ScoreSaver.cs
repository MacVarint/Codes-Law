using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScoreSaver : MonoBehaviour
{
    public Text millisecondsText;
    public Text secondsText;
    public Text minutesText;
    public Text terminalsHackedText;
    public Text doorsOpenedText;
    public Text score;
    private float scoreFloat;
    private int scoreInt;
    private float timer;
    private float milliseconds;
    private float seconds;
    private float minutes;
    private float terminalsHacked;
    private float doorsOpened;
    public ScoreHolder scoreHolder;
    // Start is called before the first frame update
    void Start()
    {
        scoreHolder = ScoreHolder.scoreHolder;
        timer = scoreHolder.timer;
        milliseconds = scoreHolder.millisecondsPlayed;
        seconds = scoreHolder.secondsPlayed;
        minutes = scoreHolder.minutesPlayed;
        terminalsHacked = scoreHolder.terminalsHacked;
        doorsOpened = scoreHolder.doorsOpened;
        Calculator();
        Converter();
        CallNetworkConnection();
    }
    public void Calculator()
    {
        scoreFloat = 1500 + ((terminalsHacked * 500) + (doorsOpened * -100) - timer);
        scoreInt = (int)scoreFloat;
    }
    public void Converter()
    {
        millisecondsText.text = scoreHolder.millisecondsPlayed.ToString("000");
        secondsText.text = scoreHolder.secondsPlayed.ToString("00");
        minutesText.text = scoreHolder.minutesPlayed.ToString("00");
        terminalsHackedText.text = scoreHolder.terminalsHacked.ToString();
        doorsOpenedText.text = scoreHolder.doorsOpened.ToString();
        score.text = scoreInt.ToString();
    }

    //send to database. Make php file that does that. make function
    public void CallNetworkConnection()
    {
        StartCoroutine(NetworkConnection());
    }
    IEnumerator NetworkConnection()
    {
        Debug.Log(" idUser-" + LoginHolder.loginHolder.idUser + " milliseconds-" + milliseconds + " seconds-" + seconds + " minutes-" + minutes + " terminalsHacked-" + terminalsHacked + " doorsOpened-" + doorsOpened + " scoreHolder-" + scoreHolder.level);
        WWWForm form = new WWWForm();
        form.AddField("account_idaccount", "" + LoginHolder.loginHolder.idUser);
        form.AddField("milliseconds", "" + milliseconds);
        form.AddField("seconds", "" + seconds);
        form.AddField("minutes", "" + minutes);
        form.AddField("terminalsHacked", "" + terminalsHacked);
        form.AddField("doorsOpened", "" + doorsOpened);
        form.AddField("level", "" + scoreHolder.level);

        UnityWebRequest unityWebRequest = UnityWebRequest.Post("http://localhost/CodesLawPHP/Save.php", form);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
        }
        else
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
        }
        yield return null;
    }
}