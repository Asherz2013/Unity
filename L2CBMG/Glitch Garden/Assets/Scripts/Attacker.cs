using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    // Vars
    [Tooltip("Average number of seconds between appearances.")]
    public float SeenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        // Obtain the Animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the attacker to the left by speed and time
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        // It we Do NOT have a target (it might have destroyed it self)
        if(!currentTarget)
        {
            // Tell the animation that attacking is False
            animator.SetBool("IsAttacking", false);
        }
    }

    // Used within each animation to control the speed the attackers moves.
    // Might make a getter and setter we'll see
    public void SetSpeed(float Speed)
    {
        currentSpeed = Speed;
    }

    // Called from the animator at the time of actual attack
    public void StrikeCurrentTarget(float damage)
    {
        // If we have a target
        if (currentTarget)
        {
            // Check it has a Health Component
            Health health = currentTarget.GetComponent<Health>();
            if(health)
            {
                // If we do we deal damage to it.
                health.DealDamage(damage);
            }
        }

    }

    // Store the current target to the object passed in
    public void attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
