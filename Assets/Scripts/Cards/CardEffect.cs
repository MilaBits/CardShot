using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class CardEffect : ScriptableObject {
    public string Name;
    public string Description;

    [InfoBox("Range in case the card targets an area")]
    public float Range;

    public abstract void ExecuteArea(Vector3 position);
    public abstract void ExecutePlayer(Player player);
}