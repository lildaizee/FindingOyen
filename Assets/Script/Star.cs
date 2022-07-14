using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Star : MonoBehaviourPunCallbacks
{
    public int totalScore;
    PhotonView starPV;
    //public AudioClip scoreSound;

    void Start()
    {
        starPV = GetComponent<PhotonView>();

        //GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 5, 0);
    }

    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Photon.Pun.PhotonView photonView = other.GetComponent<Photon.Pun.PhotonView>();
            
            if (!photonView.IsMine)
            {
                return;

            }
            //GameFlow.totalCoins += 1;
            // Debug.Log(GameFlow.totalCoins);

            Debug.Log("point + 1");
            //ScoreManager.instance.AddPoint();
            //AudioSource.PlayClipAtPoint(scoreSound, transform.position);
            GameFlow.totalCoins += 1;
            Debug.Log(GameFlow.totalCoins);
            //Destroy(gameObject);
            starPV.RPC(nameof(DestroyStars), RpcTarget.All);
        }
    }

    [PunRPC]
    private void DestroyStars()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.Destroy(gameObject);
    }
}
