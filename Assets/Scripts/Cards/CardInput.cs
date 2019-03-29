using System;
using Cards;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[RequireComponent(typeof(CardManager))]
public class CardInput : MonoBehaviour
{
    private CardManager cardManager;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Camera camera;

    [FormerlySerializedAs("playerLayer")]
    [SerializeField]
    private LayerMask targetLayer;

    [SerializeField]
    private LayerMask levelLayer;
    
    

    private bool released;

    private void Start()
    {
        cardManager = GetComponent<CardManager>();
    }


    void Update()
    {
        if (!released &&
            Input.GetAxis($"Card1{player.ControlSuffix}") == 0 &&
            Input.GetAxis($"Card2{player.ControlSuffix}") == 0) released = true;

        if (!released)
            return;

        switch (player.Platform)
        {
            case Platform.Keyboard:
                if (Input.GetButtonDown($"Card1{player.ControlSuffix}")) cardManager.UseCard(GetUseInfo(0));
                if (Input.GetButtonDown($"Card2{player.ControlSuffix}")) cardManager.UseCard(GetUseInfo(1));
                if (Input.GetButtonDown($"Card3{player.ControlSuffix}")) cardManager.UseCard(GetUseInfo(2));
                if (Input.GetButtonDown($"Card4{player.ControlSuffix}")) cardManager.UseCard(GetUseInfo(3));

                break;
            case Platform.Ps4:
            case Platform.Xbox:
                if (Input.GetAxis($"Card1{player.ControlSuffix}") == 1)
                {
                    cardManager.UseCard(GetUseInfo(0));
                    released = false;
                }

                if (Input.GetAxis($"Card2{player.ControlSuffix}") == 1)
                {
                    cardManager.UseCard(GetUseInfo(1));
                    released = false;
                }

                if (Input.GetAxis($"Card3{player.ControlSuffix}") == -1)
                {
                    cardManager.UseCard(GetUseInfo(2));
                    released = false;
                }

                if (Input.GetAxis($"Card4{player.ControlSuffix}") == -1)
                {
                    cardManager.UseCard(GetUseInfo(3));
                    released = false;
                }

                break;
        }
    }

    private UseInfo GetUseInfo(int slot)
    {
        UseInfo info = new UseInfo();

        info.Slot = slot;
        info.Caster = GetComponent<PlayerModifiers>();
        info = RaycastPlayer(info);
        info = RaycastLevel(info);

        return info;
    }

    private UseInfo RaycastPlayer(UseInfo info)
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 500f, targetLayer);
        if (hit.collider != null)
        {
            Debug.Log("hit: " + hit.collider.gameObject.name);

            info.TargetPlayerModifiers = hit.rigidbody.GetComponentInParent<PlayerModifiers>();
            info.NoPlayer = false;
        }
        else
        {
            info.NoPlayer = true;
        }

        return info;
    }

    private UseInfo RaycastLevel(UseInfo info)
    {
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 500f, levelLayer);
        if (hit.collider != null)
        {
            info.TargetPosition = hit.point;
            info.NoPosition = false;
        }
        else
        {
            info.NoPosition = true;
        }

        return info;
    }
}