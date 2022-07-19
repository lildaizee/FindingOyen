using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public APISystem api;

    // Start is called before the first frame update
    void Start()
    {
        api = GameObject.Find("API").GetComponent<APISystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public IEnumerator saveScore()
    {
        yield return new WaitForSeconds(.1f);

        Time.timeScale = 0;

        Debug.Log("Game Over");
        PlayerManager.isGameOver = true;
        //FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "Score_Point_Endless", "add", ScoreManager.instance.ToString());
        FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "myra_endless_scorepoint", "add", GameFlow.totalCoins.ToString());


        //Time.timeScale = 0;

        //Debug.Log("Game Over");
        //PlayerManager.isGameOver = true;
        //gameObject.SetActive(false);
    }
}
