using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Oyen.Character
{
    /// <summary>
    /// This handle higher level for character controller
    /// </summary>
    public class CharacterManager : MonoBehaviourPunCallbacks
    {
        #region Serialized Field
        [Header("Settings")]
        [SerializeField] private int characterChoice = 0;
        [SerializeField] private Character character;

        [SerializeField] private List<GameObject> characterList;

        [Header("Animation")]
        [SerializeField] private Animator animator;
        [SerializeField] private List<Avatar> characterAvatar;
        #endregion

        #region Private Field
        private Photon.Realtime.Player player;
        #endregion

        private void Start()
        {
            SetCharacterChoice();
        }

        public void SetCharacterChoice()
        {
            player = character.PhotonView.Controller;
            CharacterChoice = (int)player.CustomProperties["CharacterSelected"];

            return;
            if (!character.PhotonView.IsMine)
            {
                CharacterChoice = (int)player.CustomProperties["CharacterSelected"];
                //CharacterChoice = (int)PhotonNetwork.LocalPlayer.CustomProperties["CharacterSelected"];
            }
            else
            {
                //CharacterChoice = PlayerPrefs.GetInt("CharacterSelected");
                CharacterChoice = (int)player.CustomProperties["CharacterSelected"];
            }
        }

        #region Accessor
        private int CharacterChoice
        {
            get
            {
                return characterChoice;
            }
            set
            {
                characterChoice = value;
                foreach (GameObject go in characterList)
                    go.SetActive(false);

                characterList[characterChoice].SetActive(true);
                animator.avatar = characterAvatar[characterChoice];

                character.Initialize();
            }
        }

        #endregion
    }
}