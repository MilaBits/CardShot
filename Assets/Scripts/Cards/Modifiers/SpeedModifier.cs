using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modifier (Speed)", menuName = "Cards/Modifiers/Speed")]
public class SpeedModifier : Modifier {
    [BoxGroup("$name")]
    [SerializeField]
    private CharacterController Controller;

    [BoxGroup("$name")]
    [SerializeField]
    private bool isModifying;

    [BoxGroup("$name")]
    private float OriginalSpeed;

    [BoxGroup("$name")]
    [SerializeField, ReadOnly]
    private float Duration;

    public override void Modify(GameObject parent, float value, float duration) {
        Controller = parent.GetComponent<CharacterController>();

        OriginalSpeed = Controller.speed;
        Controller.speed *= value;
        isModifying = true;

        // This feels hacky?????
        Controller.StartCoroutine(LastDuration(duration));
    }

    IEnumerator LastDuration(float duration) {
        Duration = duration;
        yield return new WaitForSeconds(duration);
        Controller.speed= OriginalSpeed;
        isModifying = false;
    }
}