using Photon.Pun; // 유니티용 포톤 컴포넌트들
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;

// Match maker gets players from lobby screen
public class LobbyManager : MonoBehaviourPunCallbacks {
    private string gameVersion = "1";

    public Text connectionInfoText; 
    public Button joinButton; 

  
    private void Start() {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        connectionInfoText.text = "Connecting to Master Server...";
    }

    public override void OnConnectedToMaster() {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Connected to Master Server";
    }

    public override void OnDisconnected(DisconnectCause cause) {
        joinButton.interactable = false;
        connectionInfoText.text = "Offline : Not connected to Master Server\nReconnecting...";

        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect() {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Connecting to Room...";
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "Offline : Not connected to Master Server\nReconnecting...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        connectionInfoText.text = "No empyt room, Creating room...";
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 4});
    }

    public override void OnJoinedRoom() {
        connectionInfoText.text = "Joining room... Successful";
        PhotonNetwork.LoadLevel("Main");
    }
}