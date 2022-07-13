using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oyen.Character
{
    /// <summary>
    /// This handle higher level for character controller
    /// </summary>
    public class CharacterManager : MonoBehaviour
    {
        #region Private Region
        [Header("Settings")]
        [SerializeField] private int characterChoice = 0;
        [SerializeField] private Character character;

        [SerializeField] private List<GameObject> characterList;

        [Header("Animation")]
        [SerializeField] private Animator animator;
        [SerializeField] private List<Avatar> characterAvatar;
        #endregion

        private void Start()
        {
            SetCharacterChoice(0);
        }

        public void SetCharacterChoice(int value)
        {
            CharacterChoice = value;
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