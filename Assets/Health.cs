using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField]
    private int health = 100;

    public void TakeDamage(int damage) {
        health -= damage;
    }
}