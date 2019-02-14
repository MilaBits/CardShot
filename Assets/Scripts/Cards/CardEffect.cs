using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class CardEffect : ScriptableObject {
    protected string Description;

    [InfoBox("$Description")] [BoxGroup("$name"), LabelWidth(100)]
    public EffectTarget Target;

    [LabelWidth(100), BoxGroup("$name")] [ShowIf("IsArea")]
    public float Range;

    private bool IsArea() {
        return Target == EffectTarget.Area;
    }

    public abstract void ExecuteArea(Vector3 position);
    public abstract void ExecutePlayer(Player player);
}