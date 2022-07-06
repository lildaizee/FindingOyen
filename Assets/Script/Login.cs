using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField inputUserName;
    public TMP_InputField password;
    public APISystem api;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoginPlayer()
    {
        if (string.IsNullOrEmpty(inputUserName.text))
        {
            Debug.Log("Enter username and password");
        }
        else
        {
            PlayerPrefs.SetString("username", inputUserName.text);
            FindObjectOfType<APISystem>().GetPlayer(inputUserName.text);
        }
    }
}
