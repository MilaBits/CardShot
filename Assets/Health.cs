using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int health = 100;

    public UnityEvent OnDeath;

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log($"{gameObject.name} health: {health}");

        if (health <= 0) {
            OnDeath.Invoke();
        }
    }

    public void Reset() {
        health = maxHealth;
    }
}