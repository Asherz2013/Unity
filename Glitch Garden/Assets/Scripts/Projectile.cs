using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float speed, damage;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // have we hit a gameobject with an Attacker Script on it?
        if(collider.gameObject.GetComponent<Attacker>())
        {
            // Ok Does it have a Health Script?
            Health health = collider.gameObject.GetComponent<Health>();
            if (health)
            {
                // Yes so lets apply damage to it.
                health.DealDamage(damage);
                // Destroy the Projectile
                Destroy(gameObject);
            }
        }
    }
}
