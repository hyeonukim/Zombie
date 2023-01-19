using Cinemachine; 
using Photon.Pun; 
using UnityEngine;

// For Cinemachine camera to follow local player
public class CameraSetup : MonoBehaviourPun {
    void Start() {
        if (photonView.IsMine)
        {
            CinemachineVirtualCamera followCam =
                FindObjectOfType<CinemachineVirtualCamera>();
            followCam.Follow = transform;
            followCam.LookAt = transform;
        }
    }
}