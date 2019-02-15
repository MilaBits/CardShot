using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Effect (Speed)", menuName = "Cards/Card Effects/Speed")]
[Serializable]
public class Speed : CardEffect {
    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription"), Range(-0, 2)]
    public float SpeedMultiplier;

    [BoxGroup("$name")] [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public float Duration;

    [BoxGroup("$name")]
    public Modifier TargetModifier;

    private void Awake() {
        UpdateDescription();
    }

    private void UpdateDescription() {
        string multiplier = string.Empty;
        multiplier = SpeedMultiplier > 1 ? "Increase" : "Decrease";

        Description =
            $"{multiplier} Target's movement speed by {Math.Abs(SpeedMultiplier * 100 - 100)}% for {Duration} seconds";
    }

    public override void ExecuteArea(Vector3 position) {
        Debug.Log($"{name} hit {position}");
    }

    public override void ExecutePlayer(PlayerModifiers playerModifiers) {
        Debug.Log(playerModifiers);
        Modifier modifier = playerModifiers.Modifiers.First(x => x.GetType().Equals(TargetModifier.GetType()));
        modifier.Modify(playerModifiers.gameObject, SpeedMultiplier, Duration);
    }
}