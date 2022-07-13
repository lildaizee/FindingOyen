using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

   // public CharacterController controller;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Masuk");
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }

    //void OnTriggerEnter(Collider other)
    //{


    //    controller.enabled = false;  //Prevents Char controller from overiding transform
    //    player.transform.position = respawnPoint.transform.position;
    //    Debug.Log("Triggered \n");
    //    controller.enabled = true; // Gives control back to char controller


    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    player.transform.position = respawnPoint.transform.position;

    //}
}
