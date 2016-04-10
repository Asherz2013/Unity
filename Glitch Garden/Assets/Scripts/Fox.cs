using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        // Obtain the animator and attacker scripts
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        // Upon collision
        // Get the gameobject
        GameObject obj = collider.gameObject;
        // If it doesn't have a Defender component we just ignore it (E.G Projectiles)
        if (!obj.GetComponent<Defender>()) return;

        // If it has a "Stone" Script
        if(obj.GetComponent<Stone>())
        {
            // We need to Jump over it.
            anim.SetTrigger("JumpTrigger");
        }
        else
        {
            // Otherwise we play the attack anim
            anim.SetBool("IsAttacking", true);
            // Set the "Attacker" to the object we collided with
            attacker.attack(obj);
        }
    }
}
