using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISlot : MonoBehaviour {

    [SerializeField]
    private TMP_Text subText;

    private Card card;

    [SerializeField]
    private UICard UICard;
    
    public void SetSubText(string value) {
        subText.text = value;
    }

    public void SetCard(Card card) {
        UICard.gameObject.SetActive(true);
        UICard.SetImage(card.Image);
    }

    public void RemoveCard() {
        UICard.gameObject.SetActive(false);
    }
}
