using UnityEngine;

namespace Cards {
    public struct UseInfo {
        public Player Caster;
        public Player TargetPlayer;
        public Vector3 TargetPosition;

        public UseInfo(Player caster, Player targetPlayer, Vector3 targetPosition) {
            Caster = caster;
            TargetPlayer = targetPlayer;
            TargetPosition = targetPosition;
        }
    }
}