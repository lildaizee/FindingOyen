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
        [SerializeField] private bool isMine;
        [SerializeField] private Transform cameraFollowTransform;
        #endregion

        public void Initialize()
        {
            photonView = GetComponent<PhotonView>();
            if (cameraMain == null)
                cameraMain = Camera.main;
            if (CMCamera == null)
               CMCamera = GameObject.Find("CMVirtualCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();

            if (!photonView.IsMine) return;

            CMCamera.Follow = cameraFollowTransform;
        }

        #region Accessor
        public PhotonView PhotonView => photonView;
        #endregion
    }
}