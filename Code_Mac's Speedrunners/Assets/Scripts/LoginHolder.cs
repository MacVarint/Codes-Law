using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginHolder : MonoBehaviour
{
    public static LoginHolder loginHolder;
    public string idUser;
    // Start is called before the first frame update
    void Start()
    {

        if(loginHolder == null)
        {
            loginHolder = this;
        }
        else if(loginHolder != this)
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
