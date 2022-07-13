using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Oyen.Character;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;

    [Space(10)]
    [SerializeField] private GameObject characterPrefab;

    private void Start()
    {
        SpawnCharacter();
    }

    /// <summary>
    /// Not in used. Please delete this in future
    /// </summary>
    private void SpawnAvatar()
    {
        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }

    private void SpawnCharacter()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("Spawn point is 0. Please add at least one spawn point");
            return;
        }

        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject go = PhotonNetwork.Instantiate(characterPrefab.name, spawnPoint.position, Quaternion.identity);
        //go.GetComponent<CharacterManager>().SetCharacterChoice();
    }
}
