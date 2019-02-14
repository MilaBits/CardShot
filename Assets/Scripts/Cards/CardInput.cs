using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cards;
using UnityEngine;

[RequireComponent(typeof(CardManager))]
public class CardInput : MonoBehaviour {
    private CardManager cardManager;

    [SerializeField]
    private Camera camera;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask levelLayer;

    private void Start() {
        cardManager = GetComponent<CardManager>();
    }

    void FixedUpdate() {
        if (Input.GetButtonDown("Card1")) {
            cardManager.UseCard(GetUseInfo(1));
        }

        if (Input.GetButtonDown("Card2")) {
            cardManager.UseCard(GetUseInfo(2));
        }

        if (Input.GetButtonDown("Card3")) {
            cardManager.UseCard(GetUseInfo(3));
        }

        if (Input.GetButtonDown("Card4")) {
            cardManager.UseCard(GetUseInfo(4));
        }

        if (Input.GetButtonDown("Card5")) {
            cardManager.UseCard(GetUseInfo(5));
        }
    }

    private UseInfo GetUseInfo(int slot) {
        UseInfo info = new UseInfo();

        info.Slot = slot;
        info.Caster = GetComponent<Player>();
        RaycastPlayer(info);
        RaycastLevel(info);

        return info;
    }

    private void RaycastPlayer(UseInfo info) {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, playerLayer);
        if (hit.collider != null) {
            info.TargetPlayer = hit.collider.GetComponent<Player>();
            info.NoPlayer = false;
        }

        info.NoPlayer = true;
    }

    private void RaycastLevel(UseInfo info) {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, levelLayer);
        if (hit.collider != null) {
            info.TargetPosition = hit.point;
            info.NoPosition = false;
        }

        info.NoPosition = true;
    }
}