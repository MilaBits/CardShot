using UnityEngine;

[CreateAssetMenu(fileName = "New Card Effect (Speed)", menuName = "Cards/Card Effects/Speed")]
public class SpeedEffect : CardEffect {

    public float SpeedModifier;
    public float Duration;

    public override void ExecuteArea(Vector3 position) {
        throw new System.NotImplementedException();
    }

    public override void ExecutePlayer(Player player) {
        throw new System.NotImplementedException();
    }
}