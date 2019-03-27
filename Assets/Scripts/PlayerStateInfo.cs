using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerStateInfo {
    [SerializeField]
    private PlayerState state;

    [SerializeField]
    private TextMeshProUGUI joinText;

    [SerializeField]
    private TextMeshProUGUI readyText;

    [SerializeField]
    private Image crosshair;

    public void SetState(PlayerState state) {
        this.state = state;
        switch (state) {
            case PlayerState.Joining:
                readyText.gameObject.SetActive(false);
                crosshair.gameObject.SetActive(false);
                joinText.gameObject.SetActive(true);
                break;
            case PlayerState.Readying:
                readyText.gameObject.SetActive(true);
                crosshair.gameObject.SetActive(true);
                joinText.gameObject.SetActive(false);
                break;
            case PlayerState.Playing:
                readyText.gameObject.SetActive(false);
                crosshair.gameObject.SetActive(true);
                joinText.gameObject.SetActive(false);
                break;
        }
    }
}