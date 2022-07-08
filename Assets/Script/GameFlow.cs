using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public static int totalCoins = 0;
    public Transform star;

    public Text scoreText;
    public int score = 0;

    void Start()
    {
        //nilaiMarkah = GetComponent<TMP_Text>();
        scoreText.text = totalCoins.ToString() + " POINTS";
    }

    void Update()
    {
        scoreText.text = totalCoins.ToString() + " POINTS";
    }

    
    
}
