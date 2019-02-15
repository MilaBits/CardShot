using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modifier (Speed)", menuName = "Cards/Modifiers/Speed")]
public class SpeedModifier : Modifier {
    [BoxGroup("$name")]
    [SerializeField]
    private vp_FPController FPController;

    [BoxGroup("$name")]
    [SerializeField]
    private bool isModifying;

    [BoxGroup("$name")]
    private float OriginalSpeed;

    [BoxGroup("$name")]
    [SerializeField, ReadOnly]
    private float Duration;

    public override void Modify(GameObject parent, float value, float duration) {
        FPController = parent.GetComponent<vp_FPController>();

        OriginalSpeed = FPController.MotorAcceleration;
        FPController.MotorAcceleration *= value;
        isModifying = true;

        // This feels hacky?????
        FPController.StartCoroutine(LastDuration(duration));
    }

    IEnumerator LastDuration(float duration) {
        Duration = duration;
        yield return new WaitForSeconds(duration);
        FPController.MotorAcceleration = OriginalSpeed;
        isModifying = false;
    }
}