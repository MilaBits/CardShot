using TMPro;
using UnityEngine;

public class Player : MonoBehaviour {
    public int PlayerNumber;
    public Platform Platform;
    public Camera Camera;

    public bool Ready = false;

    public RectTransform HUD;

    public string ControlSuffix;

    public void Reset() {
        Ready = false;

        GetComponent<Health>().Reset();
        GetComponent<CardManager>().Reset();
        GetComponent<CardInput>().enabled = true;
    }

    private void Update() {
        if (!Ready) {
            if (Input.GetButtonDown($"Jump{ControlSuffix}")) {
                Ready = true;
            }
        }
    }
}