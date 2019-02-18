using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Effect (Speed)", menuName = "Cards/Card Effects/Speed")]
[Serializable]
public class Speed : CardEffect {
    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription"), Range(-0, 2)]
    public float SpeedMultiplier;

    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
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
        

        // Check if the recipient can recive the modifier
        Modifier modifier = playerModifiers.Modifiers.First(x => x.GetType().Equals(TargetModifier.GetType()));
        if (modifier != null && modifier.isModifying && !modifier.isStackable) return;

        modifier.Modify(playerModifiers, SpeedMultiplier, Duration);

        // Decide if it should be the positive or negative sprite
        if (SpeedMultiplier > 1) {
            playerModifiers.AddStatUI(modifier.PositiveImage, Duration, modifier.PositiveColor);
        }
        else {
            playerModifiers.AddStatUI(modifier.NegativeImage, Duration, modifier.NegativeColor);
        }
    }
}