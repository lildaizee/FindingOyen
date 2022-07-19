using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Badges : MonoBehaviour
{

    public APISystem api;

    float score;

    public GameObject badgeIcon1;
    public GameObject badgeIcon2;
    public GameObject badgeIcon3;
    public GameObject badgeIcon4;

    private void Start()
    {
        StartCoroutine(badges());
    }
    private IEnumerator badges()
    {
        api.GetPlayer(PlayerPrefs.GetString("username"));

        yield return new WaitUntil(() => api.containerA.status == "1");

        score = float.Parse(api.containerA.message.score[0].value);
        Debug.Log("score ini");
        Debug.Log(score);
        //score = GameFlow.totalCoins;

        if (score < 30)
        {
            badgeIcon1.SetActive(true);
        }
        else if (score > 30 && score <50)
        {
            badgeIcon2.SetActive(true);
        }
        else if (score > 50 && score < 80)
        {
            badgeIcon3.SetActive(true);
        }
        else if (score > 80 )
        {
            badgeIcon4.SetActive(true);
        }
        
    }
}
