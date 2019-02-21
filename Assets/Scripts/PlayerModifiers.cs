using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerModifiers : MonoBehaviour {
    [SerializeField, InlineEditor]
    private List<Modifier> modifiersToUse;

    [InlineEditor]
    public List<Modifier> Modifiers;

    [BoxGroup("Stat UI"), SerializeField]
    private RectTransform StatIconContainer;

    [BoxGroup("Stat UI"), SerializeField]
    private StatIconUI StatIconPrefab;

    private void Start() {
        foreach (var modifier in modifiersToUse) {
            Modifiers.Add(Instantiate(modifier));
        }
    }

    public void AddStatUI(Sprite sprite, float duration, Color color) {
        StatIconUI stat = Instantiate(StatIconPrefab, StatIconContainer);
        stat.Initialize(sprite, duration, color);
        
    }
}