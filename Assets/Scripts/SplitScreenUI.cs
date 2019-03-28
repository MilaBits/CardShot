using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SplitScreenUI : MonoBehaviour
{
    [SerializeField]
    public List<PlayerStateInfo> PlayerStates;

    [SerializeField]
    private Image image;

    private void Start()
    {
        foreach (PlayerStateInfo playerStateInfo in PlayerStates)
        {
            playerStateInfo.SetState(PlayerState.Joining);
        }
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1, 1f));
    }

    IEnumerator Fade(float target, float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b,
                Mathf.Lerp(image.color.a, target, (elapsedTime / time)));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }
}