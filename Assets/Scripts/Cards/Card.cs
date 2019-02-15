using System;
using System.Collections;
using System.Collections.Generic;
using Cards;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Card")]
public class Card : ScriptableObject {
    [HorizontalGroup("split", .1f)]
    [BoxGroup("split/Image")]
    [PreviewField, HideLabel]
    public Sprite Image;

    [BoxGroup("split/Description")]
    [LabelWidth(70), Multiline(3), HideLabel]
    public string Description;

    [Space]
    [InlineEditor(InlineEditorModes.GUIOnly, InlineEditorObjectFieldModes.Hidden)]
    public List<CardEffect> CardEffects;

    public void Use(UseInfo info) {
        foreach (CardEffect cardEffect in CardEffects) {
            switch (cardEffect.Target) {
                case EffectTarget.None:
                    Debug.LogAssertion($"Effect {name} has no target");
                    break;
                case EffectTarget.Self:
                    cardEffect.ExecutePlayer(info.Caster);
                    break;
                case EffectTarget.Opponent:
                    cardEffect.ExecutePlayer(info.TargetPlayerModifiers);
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