using Boo.Lang;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

public class CardEditor : OdinEditorWindow {
    // Cards
    [FoldoutGroup("data")]
    [AssetList(Path = "PersistentData/Cards/", AutoPopulate = true), SerializeField]
    private List<Card> assetCards = new List<Card>();

    [HorizontalGroup("Lists")]
    [VerticalGroup("Lists/Left")]
    [ValueDropdown("cards", DropdownTitle = "Lists/Effects", ExpandAllMenuItems = true,
         DisableListAddButtonBehaviour = true), SerializeField,
     InlineEditor, PropertyOrder(1)]
    private List<Card> cards = new List<Card>();

    // Effects
    [FoldoutGroup("data")]
    [AssetList(Path = "PersistentData/Effects/", AutoPopulate = true), SerializeField]
    private List<CardEffect> assetEffects = new List<CardEffect>();

    [VerticalGroup("Lists/Right")]
    [ValueDropdown("effects", DropdownTitle = "Lists/Effects", ExpandAllMenuItems = true,
         DisableListAddButtonBehaviour = true), SerializeField,
     InlineEditor, PropertyOrder(1)]
    private List<CardEffect> effects = new List<CardEffect>();

    [MenuItem("CardShot/Card Editor")]
    private static void OpenWindow() {
        GetWindow<CardEditor>().Show();
    }

    [Button("New Card", ButtonStyle.Box)]
    private void AddCard() {
    }

    [Button("Update Lists", ButtonStyle.Box), PropertyOrder(0)]
    private void UpdateCardList() {
        cards.Clear();
        foreach (Card card in assetCards) {
            cards.Add(card);
        }
    }

    [Button("Update Lists", ButtonStyle.Box), PropertyOrder(0)]
    private void UpdateEffectList() {
        effects.Clear();
        foreach (CardEffect effect in assetEffects) {
            effects.Add(effect);
        }
    }
}