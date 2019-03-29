using System;
using System.Linq;
using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Effect (Jump)", menuName = "Cards/Card Effects/Jump")]
[Serializable]
public class Jump : CardEffect
{
    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription"), Range(-0, 2)]
    public float JumpMultiplier;

    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public float Duration;

    [BoxGroup("$name")]
    public Modifier TargetModifier;

    private void Awake()
    {
        UpdateDescription();
    }

    private void UpdateDescription()
    {
        Description = $"Increase Jump height by {JumpMultiplier}% for {Duration} seconds";
    }

    public override void ExecuteArea(UseInfo info)
    {
        Debug.Log($"{name} hit {info.TargetPosition}");
    }

    public override void ExecutePlayer(PlayerModifiers playerModifiers)
    {
        Debug.Log("Executing on: " + playerModifiers.gameObject.name);

        // Check if the recipient can recive the modifier
        Modifier modifier = playerModifiers.Modifiers.OfType<JumpModifier>().First();
        if (modifier != null && modifier.isModifying && !modifier.isStackable) return;

        modifier.Modify(playerModifiers, JumpMultiplier, Duration);

        playerModifiers.AddStatUI(modifier.PositiveImage, Duration, modifier.PositiveColor);
    }
}