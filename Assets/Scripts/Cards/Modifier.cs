using Sirenix.OdinInspector;
using UnityEngine;

public abstract class Modifier : ScriptableObject {
    [BoxGroup("$name")]
    [PreviewField(ObjectFieldAlignment.Left)]
    public Sprite PositiveImage;

    [BoxGroup("$name")]
    public Color PositiveColor;

    [BoxGroup("$name")]
    [PreviewField(ObjectFieldAlignment.Left)]
    public Sprite NegativeImage;

    [BoxGroup("$name")]
    public Color NegativeColor;

    [BoxGroup("$name")]
    [SerializeField]
    public bool isModifying;

    [BoxGroup("$name")]
    [SerializeField]
    public bool isStackable;

    public abstract void Modify(PlayerModifiers parent, float value, float duration);
    
    public abstract void Cancel();
}