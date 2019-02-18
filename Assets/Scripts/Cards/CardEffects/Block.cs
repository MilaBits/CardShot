using System;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Effect (Block)", menuName = "Cards/Card Effects/Block")]
[Serializable]
public class Block : CardEffect {
    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public int HitThreshold;

    [BoxGroup("$name")] [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public float Duration;

    private void UpdateDescription() {
        string firstbit;
        if (Target == EffectTarget.Area) {
            firstbit = "Place wall that can";
        }
        else {
            firstbit = "Personal shield that can";
        }
        
        Description = $"{firstbit} block up to {HitThreshold} hits in the next {Duration} seconds";
    }

    public override void ExecuteArea(Vector3 position) {
        Debug.Log($"{name} hit {position}");
    }

    public override void ExecutePlayer(PlayerModifiers playerModifiers) {
        Debug.Log($"{name} hit {playerModifiers.name}");
    }
}