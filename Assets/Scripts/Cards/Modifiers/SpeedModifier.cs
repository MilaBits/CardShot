﻿using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modifier (Speed)", menuName = "Cards/Modifiers/Speed")]
public class SpeedModifier : Modifier
{
    [BoxGroup("$name")]
    [SerializeField]
    private PlayerCharacterController Controller;

    private float OriginalSpeed;

    [BoxGroup("$name")]
    [SerializeField, ReadOnly]
    private float Duration;

    private IEnumerator coroutine;

    public override void Modify(PlayerModifiers modifiers, float value, float duration)
    {
        Controller = modifiers.GetComponent<PlayerCharacterController>();

        OriginalSpeed = Controller.Speed;
        Controller.Speed *= value;
        isModifying = true;

        coroutine = LastDuration(duration);
        // This feels hacky?????
        Controller.StartCoroutine(coroutine);

        Debug.Log(modifiers.gameObject.name + " hit by " + name);
    }

    public override void Cancel()
    {
        Controller.StopCoroutine(coroutine);
        ResetModifier();
    }

    private void ResetModifier()
    {
        Controller.Speed = OriginalSpeed;
        isModifying = false;
    }

    IEnumerator LastDuration(float duration)
    {
        Duration = duration;
        yield return new WaitForSeconds(duration);
        ResetModifier();
    }
}