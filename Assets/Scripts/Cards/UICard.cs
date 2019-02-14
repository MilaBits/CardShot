using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICard : MonoBehaviour {
    [SerializeField]
    private Image Image;

    public void SetImage(Sprite sprite) {
        Image.sprite = sprite;
    }
}
