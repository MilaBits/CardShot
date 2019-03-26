using System;
using Cards;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[RequireComponent(typeof(CardManager))]
public class CardInput : MonoBehaviour {
    private CardManager cardManager;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private LayerMask levelLayer;

    private void Start() {
        cardManager = GetComponent<CardManager>();
    }

    void Update() {
        switch (player.Platform) {
            case Platform.Keyboard:
                if (Input.GetButtonDown($"Card1{player.ControlSuffix}")) {
                    cardManager.UseCard(GetUseInfo(0));
                }

                if (Input.GetButtonDown($"Card2{player.ControlSuffix}")) {
                    cardManager.UseCard(GetUseInfo(1));
                }

                if (Input.GetButtonDown($"Card3{player.ControlSuffix}")) {
                    cardManager.UseCard(GetUseInfo(2));
                }

                if (Input.GetButtonDown($"Card4{player.ControlSuffix}")) {
                    cardManager.UseCard(GetUseInfo(3));
                }

                break;
            case Platform.Ps4:
            case Platform.Xbox:
//                Debug.Log("dpad x: " + Input.GetAxis($"Card2{player.ControlSuffix}"));
//                Debug.Log("dpad y: " + Input.GetAxis($"Card1{player.ControlSuffix}"));

                if (Input.GetAxis($"Card1{player.ControlSuffix}") == 1) {
                    cardManager.UseCard(GetUseInfo(0));
                }

                if (Input.GetAxis($"Card2{player.ControlSuffix}") == 1) {
                    cardManager.UseCard(GetUseInfo(1));
                }

                if (Input.GetAxis($"Card3{player.ControlSuffix}") == -1) {
                    cardManager.UseCard(GetUseInfo(2));
                }

                if (Input.GetAxis($"Card4{player.ControlSuffix}") == -1) {
                    cardManager.UseCard(GetUseInfo(3));
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private UseInfo GetUseInfo(int slot) {
        UseInfo info = new UseInfo();

        info.Slot = slot;
        info.Caster = GetComponent<PlayerModifiers>();
        info = RaycastPlayer(info);
        info = RaycastLevel(info);

        return info;
    }

    private UseInfo RaycastPlayer(UseInfo info) {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 500f, playerLayer);
        if (hit.collider != null) {
            info.TargetPlayerModifiers = hit.rigidbody.GetComponent<PlayerModifiers>(); // TODO: fix: Always hits self?
            info.NoPlayer = false;
        }
        else {
            info.NoPlayer = true;
        }

        return info;
    }

    private UseInfo RaycastLevel(UseInfo info) {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 500f, levelLayer);
        if (hit.collider != null) {
            info.TargetPosition = hit.point;
            info.NoPosition = false;
        }
        else {
            info.NoPosition = true;
        }

        return info;
    }
}