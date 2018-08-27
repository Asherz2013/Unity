using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float health;
    
    // Deal Damage to this GameObject
    public void DealDamage(float damage)
    {
        // Reduce Health
        health -= damage;

        // If less than zero we kill it off.
        if (health <= 0)
        {
            // Trigger Death anim
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
