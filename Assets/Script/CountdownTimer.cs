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
    public GameObject gameOverScreen;


    public SaveScore SC;

    void Start()
    {
        timerText = GameObject.Find("Countdown").GetComponent<Text>();
        api = GameObject.Find("API").GetComponent<APISystem>();
        SC = GetComponent<SaveScore>();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_3_-_GD (1)"))
        {
            gameOverScreen = GameObject.Find("GameOverPanel");
            gameOverScreen.SetActive(false);
        }
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
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level_3_-_GD (1)"))
            {
                timeToDisplay = 0;
                StartCoroutine(SC.saveScore());
                SC.saveScore();
                StartCoroutine(SaveScore());
                gameOverScreen.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene("Level_3_-_GD (1)");
            }

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

        FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "myra_endless_scorepoint", "add", GameFlow.totalCoins.ToString());
    }

    public void changeLevel()
    {
        SceneManager.LoadScene("Level_3_-_GD (1)");
    }
}
