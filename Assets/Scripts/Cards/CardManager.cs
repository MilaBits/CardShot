using System;
using Cards;
using Sirenix.OdinInspector;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [InlineEditor]
    public Deck Deck;

    [SerializeField]
    private Player player;

    [SerializeField]
    [OnValueChanged("UpdateHandSize")]
    private int HandSize;

    [SerializeField]
    public Card[] Hand;

    [SerializeField, PropertyOrder(2)]
    private RectTransform SlotContainer;

    private UISlot[] UISlots;

    [SerializeField, PropertyOrder(3)]
    private UISlot UISlotPrefab;

    private void UpdateHandSize()
    {
        Hand = new Card[HandSize];
    }

    public void UseCard(UseInfo info)
    {
        if (info.Slot > HandSize) return; // Card won't exist if higher than hand size.

        Debug.Log(info.Slot + ", " + Hand.Length);
        Hand[info.Slot].Use(info);
        UISlots[info.Slot].RemoveCard();
    }

    private void Start()
    {
        Deck.Initialize();

        UISlots = new UISlot[HandSize];
        for (int i = 0; i < HandSize; i++)
        {
            UISlot slot = Instantiate(UISlotPrefab, SlotContainer);
            switch (player.Platform)
            {
                case Platform.Keyboard:
                    slot.SetSubText((i + 1).ToString());
                    break;
                case Platform.Ps4:
                case Platform.Xbox:
                    slot.SetSubText(Enum.GetName(typeof(Directions), i));
                    break;
            }

            UISlots[i] = slot;
        }

        FillHand();
    }

    [Button("Fill Hand", ButtonStyle.CompactBox), PropertyOrder(1)]
    public void FillHand()
    {
        for (var i = 0; i < Hand.Length; i++)
        {
            Card card = Hand[i];
            if (card == null) Hand[i] = Deck.Draw();
        }

        UpdateHandUI();
    }

    private void UpdateHandUI()
    {
        for (var i = 0; i < UISlots.Length; i++)
        {
            UISlot slot = UISlots[i];
            if (Hand[i] != null)
            {
                slot.SetCard(Hand[i]);
            }
        }
    }

    private enum Directions
    {
        Up,
        Right,
        Down,
        Left
    }

    public void Reset()
    {
        Deck.Initialize();
        FillHand();
    }
}