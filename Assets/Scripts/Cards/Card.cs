using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class Card : ScriptableObject {
    public string Name;
    public string Description;

    public EffectTarget Target;
    
    public List<CardEffect> CardEffects;

    public void Use(UseInfo info) {
        foreach (CardEffect cardEffect in CardEffects) {
            switch (Target) {
                case EffectTarget.None:
                    Debug.LogAssertion($"Effect {Name} has no target");
                    break;
                case EffectTarget.Self:
                    cardEffect.ExecutePlayer(info.Caster);
                    break;
                case EffectTarget.Opponent:
                    cardEffect.ExecutePlayer(info.TargetPlayer);
                    break;
                case EffectTarget.Area:
                    cardEffect.ExecuteArea(info.TargetPosition);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}