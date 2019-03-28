using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu(fileName = "New Deck", menuName = "Cards/Deck")]
public class Deck : SerializedScriptableObject
{
    [SerializeField,
     InfoBox("This list gets copied into Cards (to prevent wiping the deck constantly)", InfoMessageType.Warning)]
    private List<Card> PreparedCards;

    [SerializeField, InfoBox("This list gets used at run-time")]
    private Stack<Card> Cards;

    private Random random = new Random();

    public Card Draw()
    {
        return Cards.Pop();
    }

    public void Initialize()
    {
        Cards = new Stack<Card>(PreparedCards);
        Shuffle();
    }

    [Button(ButtonStyle.CompactBox)]
    public void Shuffle()
    {
        var values = Cards.ToArray();

        Cards.Clear();
        foreach (var value in values.OrderBy(x => random.Next()))
            Cards.Push(value);
    }
}