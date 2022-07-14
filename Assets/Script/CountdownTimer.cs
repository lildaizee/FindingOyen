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
    public APISystem api;


    SaveScore SC;

    void Start()
    {
        //currentTime = startingTime;
        timerText = GameObject.Find("Countdown").GetComponent<Text>();
        api = GameObject.Find("API").GetComponent<APISystem>();
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
            //StartCoroutine(saveScore());

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
            SceneManager.LoadScene("Level_3_-_GD (1)");
            StartCoroutine(SC.saveScore());
            SC.saveScore();
            StartCoroutine(SaveScore());
            //changeLevel();
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator SaveScore()
    {
        yield return new WaitForSeconds(.1f);

        Time.timeScale = 0;

        Debug.Log("Game Over");
        PlayerManager.isGameOver = true;

        //FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "Score_Point_Endless", "add", ScoreManager.instance.ToString());
        FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "myra_endless_scorepoint", "add", GameFlow.totalCoins.ToString());



        //gameObject.SetActive(false);
    }

    public void changeLevel()
    {
        SceneManager.LoadScene("Level_3_-_GD (1)");
    }
}
