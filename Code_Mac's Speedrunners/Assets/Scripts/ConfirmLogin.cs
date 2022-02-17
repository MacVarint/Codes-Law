using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ConfirmLogin : MonoBehaviour
{
    public InputField passwordField;
    public InputField eMailField;
    public Button confirm;
    public GameObject invalid;

    private void Start()
    {
        invalid = GameObject.FindGameObjectWithTag("Invalid");
    }
    void Update()
    {
        if (VerifyInputs())
        {
            confirm.interactable = true;
        }
        else
        {
            confirm.interactable = false;
        }
    }
    public void CallLogin()
    {
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("password", passwordField.text);
        form.AddField("eMail", eMailField.text);
        UnityWebRequest unityWebRequest = UnityWebRequest.Post("http://localhost/Codes_Law-PHP/login.php", form);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
            LoginHolder.loginHolder.idUser = unityWebRequest.downloadHandler.text;
        } 
        else if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("ConnectionError");
        }
        yield return null;


        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        if (LoginHolder.loginHolder.idUser != "PASS")
        {
            invalid.SetActive(false);
            SceneManager.LoadScene(4);
        }
        else
        {
            invalid.SetActive(true);
        }
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
    public bool VerifyInputs()
    {
        bool checkLengthPass = passwordField.text.Length >= 1;
        bool checkEmail = (eMailField.text.Length >= 5) && (eMailField.text.IndexOf('@') > -1) && (eMailField.text.IndexOf('.') > -1);
        if (checkLengthPass && checkEmail)
        {
            return true;
        }
        return false;
    }
}
