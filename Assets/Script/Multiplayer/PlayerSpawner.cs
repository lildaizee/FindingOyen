using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Oyen.Character;

namespace Oyen.Networking
{
    public class PlayerSpawner : MonoBehaviour
    {
        #region Serialized Field
        [Header("Settings")]
        [SerializeField] private bool doRandomSpawn = false;
        [SerializeField] private GameObject characterPrefab;
        #endregion

        #region Private Field
        private int index = 0;
        #endregion

        #region Public Field
        public Transform[] spawnPointsTransform;
        #endregion

        private void Start()
        {
             SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            if (!doRandomSpawn)
            {
                if(spawnPointsTransform.Length == 3)
                {
                    index = PhotonNetwork.LocalPlayer.ActorNumber -1;
                    PhotonNetwork.Instantiate(characterPrefab.name, spawnPointsTransform[index].position, Quaternion.identity);
                }
                else
                {
                    doRandomSpawn = true;
                    RandomSpawn();
                }
            }
        }

        private void RandomSpawn()
        {
            int randomNumber = Random.Range(0, spawnPointsTransform.Length);
            Transform spawnPoint = spawnPointsTransform[randomNumber];
            PhotonNetwork.Instantiate(characterPrefab.name, spawnPoint.position, Quaternion.identity);
        }
    }
}