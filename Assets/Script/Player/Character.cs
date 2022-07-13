using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oyen.Character
{
    using Photon.Pun;
    /// <summary>
    /// This handle photon related for character controller
    /// </summary>
    public class Character : MonoBehaviour
    {
        #region Private Fields
        private PhotonView photonView;
        [SerializeField] private Camera cameraMain;
        [SerializeField] Cinemachine.CinemachineVirtualCamera CMCamera;
        #endregion

        public void Initialize()
        {
            photonView = GetComponent<PhotonView>();
            if (cameraMain == null)
                cameraMain = Camera.main;
            if (CMCamera == null)
                GameObject.Find("CMVirtualCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();

            if (!CheckPhotonViewMine()) return;

        }

        #region Accessor
        public PhotonView PhotonView => photonView;

        public bool CheckPhotonViewMine()
        {
            bool isMine;
            return isMine = photonView.IsMine ? photonView.IsMine : !photonView.IsMine;
        }
        #endregion
    }
}