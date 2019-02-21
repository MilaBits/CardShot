using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class StatIconUI : MonoBehaviour {
    [SerializeField, FoldoutGroup("Settings")]
    private Image image;

    [SerializeField, FoldoutGroup("Settings")]
    private Image cooldownImage;

    public void Initialize(Sprite sprite, float duration, Color color) {
        Debug.Log("Buff Start");
        image.sprite = sprite;
        image.color = color;
        StartCoroutine(ShowCooldown(duration));
    }

    IEnumerator ShowCooldown(float duration) {
        float counter = 0f;

        while (counter < duration) {
            counter += Time.deltaTime;
            cooldownImage.fillAmount = 1 - counter / duration;
            yield return null;
        }

        // I know i should probably disable/enable instead of destroy/instantiate
        Destroy(gameObject);
        Debug.Log("Buff End");
    }
}