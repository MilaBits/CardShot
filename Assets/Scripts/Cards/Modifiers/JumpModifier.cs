using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modifier (Jump)", menuName = "Cards/Modifiers/Jump")]
public class JumpModifier : Modifier
{
    [BoxGroup("$name")]
    [SerializeField]
    private PlayerCharacterController Controller;

    private float originalJumpForce;

    [BoxGroup("$name")]
    [SerializeField, ReadOnly]
    private float Duration;

    private IEnumerator coroutine;

    public override void Modify(PlayerModifiers modifiers, float value, float duration)
    {
        Controller = modifiers.GetComponent<PlayerCharacterController>();

        originalJumpForce = Controller.JumpForce;
        Controller.JumpForce *= value;
        isModifying = true;

        coroutine = WaitForReset(duration);
        // This feels hacky?????
        Controller.StartCoroutine(coroutine);

        Debug.Log(modifiers.gameObject.name + " hit by " + name);
    }

    public override void Cancel()
    {
        Controller.StopCoroutine(coroutine);
        ResetModifier();
    }

    private void ResetModifier()
    {
        Controller.JumpForce = originalJumpForce;
        isModifying = false;
    }

    IEnumerator WaitForReset(float duration)
    {
        Duration = duration;
        yield return new WaitForSeconds(duration);
        ResetModifier();
    }
}