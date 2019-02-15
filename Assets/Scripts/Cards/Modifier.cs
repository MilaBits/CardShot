using UnityEngine;public abstract class Modifier : ScriptableObject {

    public abstract void Modify(GameObject parent, float value, float duration);
}