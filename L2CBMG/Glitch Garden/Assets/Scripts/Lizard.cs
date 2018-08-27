using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{

    private Animator anim;
    private Attacker attacker;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.GetComponent<Defender>()) return;
        anim.SetBool("IsAttacking", true);
        attacker.attack(obj);
    }
}
