using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is for multiplayer, another script for single player is at another location
/// </summary>
public class StarSinglePlayer : MonoBehaviour
{
    public int totalScore;
    
    public AudioClip scoreSound;

    void Start()
    {
       

        //GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
    }

    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            //GameFlow.totalCoins += 1;
            // Debug.Log(GameFlow.totalCoins);

            Debug.Log("point + 1");
            //ScoreManager.instance.AddPoint();
            AudioSource.PlayClipAtPoint(scoreSound, transform.position);
            GameFlow.totalCoins += 1;
            Debug.Log(GameFlow.totalCoins);
            Destroy(gameObject);
           
        }
    }

    
}
