using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    protected  int health = 100;

    public UnityEvent OnDeath;
    public UnityEvent OnDamage;

    public int getHealth() {
        return health;
    }

    public virtual void TakeDamage(int damage) {
        health -= damage;
        
        OnDamage.Invoke();

        if (health <= 0)
        {
            health = maxHealth;
            OnDeath.Invoke();
        }
    }

    public void Reset() {
        health = maxHealth;
    }
}