using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    //float currentTime = 0f;
    //float startingTime = 10f;

    //[SerializeField] Text countdownText;

    public float timeValue = 90;
    public Text timerText;

    void Start()
    {
        //currentTime = startingTime;
    }

    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTime(timeValue);


        //currentTime -= 1 * Time.deltaTime;
        //countdownText.text = currentTime.ToString("0");
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            //SceneManager.LoadScene("Level 2 - GD");
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
