using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserID : NetworkBehaviour {
#pragma warning restore 618
    [SyncVar]
    private string playerUniqueIdentity;

    private NetworkInstanceId playerNetworkID;

    public override void OnStartLocalPlayer() {
        GetNetworkIdentity();
        SetIdentity();
    }

    private void SetIdentity() {
        if (!isLocalPlayer) {
            transform.name = playerUniqueIdentity;
        }
        else {
            transform.name = MakeUniqueIdentity();
        }
    }

    private void Update() {
        if (transform.name == "" || transform.name == "Player(Clone)") {
            SetIdentity();
        }
    }

    [Client]
    private void GetNetworkIdentity() {
        playerNetworkID = GetComponent<NetworkIdentity>().netId;
        CmdTellServerPlayerIdentity(MakeUniqueIdentity());
    }

    [Command]
    private void CmdTellServerPlayerIdentity(string name) {
        playerUniqueIdentity = name;
    }

    private string MakeUniqueIdentity() {
        return "Player " + playerNetworkID;
    }
}