using UnityEngine;

namespace Cards {
    public struct UseInfo {
        public int Slot;
        public Player Caster;

        public bool NoPlayer;
        public Player TargetPlayer;

        public bool NoPosition;
        public Vector3 TargetPosition;
    }
}