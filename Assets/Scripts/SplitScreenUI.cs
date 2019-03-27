using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SplitScreenUI : MonoBehaviour {
    [SerializeField]
    public List<PlayerStateInfo> PlayerStates;

    private void Start() {
        foreach (PlayerStateInfo playerStateInfo in PlayerStates) {
            playerStateInfo.SetState(PlayerState.Joining);
        }
    }
}