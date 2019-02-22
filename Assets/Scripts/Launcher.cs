using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks {
    // Client's version number
    private string gameVersion = "1";

    private bool isConnecting;

    [SerializeField]
    private string loadLevel;

    [Tooltip("The UI Label to inform the user that the connection is in progress")]
    [SerializeField]
    private GameObject progressLabel;

    [Tooltip(
        "The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 2;

    private void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start() {
        progressLabel.SetActive(false);
    }

    public void Connect() {
        isConnecting = true;
        progressLabel.SetActive(true);
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.JoinRandomRoom();
        }
        else {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster() {
        // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()

        if (isConnecting) {
            PhotonNetwork.JoinRandomRoom();
        }
    }


    public override void OnDisconnected(DisconnectCause cause) {
        progressLabel.SetActive(false);
        Debug.LogWarningFormat("CardShot/Launcher: OnDisconnected() was called by PUN with reason {0}",
            cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log(
            "CardShot/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = maxPlayersPerRoom});
    }

    public override void OnJoinedRoom() {
        Debug.Log("CardShot/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        if (PhotonNetwork.CurrentRoom.PlayerCount > 0) {
            PhotonNetwork.LoadLevel(loadLevel);
        }
    }
}