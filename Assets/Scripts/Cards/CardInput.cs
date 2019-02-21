using Cards;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[RequireComponent(typeof(CardManager))]
public class CardInput : MonoBehaviour {
    private CardManager cardManager;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private LayerMask levelLayer;

    [FormerlySerializedAs("networkPlayer")]
    [SerializeField]
    private NetworkIdentity userId;

    private void Start() {
        cardManager = GetComponent<CardManager>();
    }

    void Update() {
        // Don't cehck any input this isn't on the local player
        if (!userId.isLocalPlayer) return;

        if (Input.GetButtonDown("Card1")) {
            cardManager.UseCard(GetUseInfo(0));
        }

        if (Input.GetButtonDown("Card2")) {
            cardManager.UseCard(GetUseInfo(1));
        }

        if (Input.GetButtonDown("Card3")) {
            cardManager.UseCard(GetUseInfo(2));
        }

        if (Input.GetButtonDown("Card4")) {
            cardManager.UseCard(GetUseInfo(3));
        }

        if (Input.GetButtonDown("Card5")) {
            cardManager.UseCard(GetUseInfo(4));
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