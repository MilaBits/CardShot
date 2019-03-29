using System;
using Cards;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Card Effect (Block)", menuName = "Cards/Card Effects/Block")]
[Serializable]
public class Block : CardEffect
{
    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public int HitThreshold;

    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public float Duration;

    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public float Width;

    [BoxGroup("$name")]
    [LabelWidth(100), OnValueChanged("UpdateDescription")]
    public float Height;

    [FormerlySerializedAs("BarrierPrefab")]
    [LabelWidth(97), BoxGroup("$name/reference", false)]
    public Blocker blockerPrefab;

    public override void ExecuteArea(UseInfo info)
    {
        Blocker blocker = Instantiate(blockerPrefab);
        blocker.transform.position = info.TargetPosition;
        blocker.transform.rotation = info.Caster.transform.rotation;
        blocker.transform.localScale = new Vector3(Width, Height, blocker.transform.localScale.z);

        blocker.Init(AssetDatabase.LoadAssetAtPath<Material>(
            $"Assets/Materials/Barrier {info.Caster.GetComponent<Player>().team}.mat"), Duration);

        blocker.GetComponent<BarrierHealth>().SetHealth(HitThreshold);
        Destroy(blocker, Duration);
    }

    public override void ExecutePlayer(PlayerModifiers playerModifiers)
    {
        Blocker blocker = Instantiate(blockerPrefab, playerModifiers.transform, false);
        blocker.transform.localScale = new Vector3(Width, Height, Width);

        blocker.Init(AssetDatabase.LoadAssetAtPath<Material>(
            $"Assets/Materials/Barrier {playerModifiers.GetComponent<Player>().team}.mat"), Duration);

        blocker.GetComponent<BarrierHealth>().SetHealth(HitThreshold);
    }

    private void UpdateDescription()
    {
        string firstbit;
        if (Target == EffectTarget.Area)
        {
            firstbit = $"Place {Width}x{Height} wall that can";
        }
        else
        {
            firstbit = "Personal shield that can";
        }

        Description = $"{firstbit} block up to {HitThreshold} hits in the next {Duration} seconds";
    }
}