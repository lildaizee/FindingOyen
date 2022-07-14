using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oyen.Character
{
    using Photon.Pun;
    using StarterAssets;
    using UnityEngine.InputSystem;

    /// <summary>
    /// This handle photon related for character controller
    /// </summary>
    public class Character : MonoBehaviour
    {
        #region Private Fields
        [SerializeField] private PhotonView photonView;
        [SerializeField] private Camera cameraMain;
        [SerializeField] Cinemachine.CinemachineVirtualCamera CMCamera;
        [SerializeField] private Transform cameraFollowTransform;

        [Space(20)]
        [SerializeField] private ThirdPersonController thirdPersonController;
        [SerializeField] private BasicRigidBodyPush basicRigidBodyPush;
        [SerializeField] private StarterAssetsInputs assetsInputs;
        [SerializeField] private PlayerInput playerInput;
        #endregion

        public void Initialize()
        {
            if(photonView == null)
                photonView = GetComponent<PhotonView>();
            if (cameraMain == null)
                cameraMain = Camera.main;
            if (CMCamera == null)
               CMCamera = GameObject.Find("CMVirtualCamera").GetComponent<Cinemachine.CinemachineVirtualCamera>();

            if (!photonView.IsMine) 
            {
                Destroy(basicRigidBodyPush);
                Destroy(assetsInputs);
                Destroy(thirdPersonController);
                Destroy(playerInput);

                basicRigidBodyPush = null;
                assetsInputs = null;
                thirdPersonController = null;
                playerInput = null;
            }
            else
                CMCamera.Follow = cameraFollowTransform;
        }

        #region Accessor
        public PhotonView PhotonView => photonView;
        #endregion
    }
}