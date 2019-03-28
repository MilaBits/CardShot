using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerNumber;
    public Platform Platform;
    public Camera Camera;

    public MeshRenderer MeshRenderer;
    public CardManager CardManager;

    public Health Health;

    public bool Ready = false;

    public RectTransform HUD;

    public string ControlSuffix;

    public void Reset()
    {
        Ready = false;

        Health.Reset();
        CardManager.Reset();
        GetComponent<CardInput>().enabled = true;
    }

    private void Update()
    {
        if (!Ready)
        {
            if (Input.GetButton($"Shoot{ControlSuffix}"))
            {
                Ready = true;
            }
        }
    }
}