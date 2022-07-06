using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Register : MonoBehaviour
{
    public TMP_InputField inputUserName;
    public TMP_InputField firstName;
    public TMP_InputField lastName;
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

    public void RegisterPlayer()
    {
        FindObjectOfType<APISystem>().Register(inputUserName.text, password.text, firstName.text, lastName.text);
        SceneManager.LoadScene("Login");
        //Application.LoadLevel("Login");
    }
}
