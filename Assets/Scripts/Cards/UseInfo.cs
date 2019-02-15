using UnityEngine;

namespace Cards {
    public struct UseInfo {
        public int Slot;
        public PlayerModifiers Caster;

        public bool NoPlayer;
        public PlayerModifiers TargetPlayerModifiers;

        public bool NoPosition;
        public Vector3 TargetPosition;
    }
}