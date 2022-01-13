using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ConfirmRegister : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public InputField rePasswordField;
    public InputField eMailField;
    public Button confirm;

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
    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("eMail", eMailField.text);
        UnityWebRequest unityWebRequest = UnityWebRequest.Post("http://localhost/CodesLawPHP/register.php", form);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(unityWebRequest.downloadHandler.text);
        }
        yield return null;
        SceneManager.LoadScene(1);
    }
    public bool VerifyInputs()
    {
        bool checkLengthName = nameField.text.Length >= 1 && nameField.text.Length <= 24;
        bool checkLengthPass = passwordField.text.Length >= 8;
        bool checkEquals = passwordField.text == rePasswordField.text;
        bool checkEmail = (eMailField.text.Length >= 5) && (eMailField.text.IndexOf('@') > -1) && (eMailField.text.IndexOf('.') > -1);
        if (checkLengthName && checkLengthPass && checkEquals && checkEmail)
        {
            return true;
        }
        return false;
    }
}
