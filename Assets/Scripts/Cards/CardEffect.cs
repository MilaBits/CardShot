using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    protected string Description;

    [InfoBox("$Description")]
    [BoxGroup("$name"), LabelWidth(100)]
    public EffectTarget Target;

    private bool IsArea()
    {
        return Target == EffectTarget.Area;
    }

    public abstract void ExecuteArea(UseInfo position);
    public abstract void ExecutePlayer(PlayerModifiers playerModifiers);
}