using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamagable
{
    public int Health { get; set; }

    //Use for Initialisation
    public override void Init()
    {
        // Call Parent
        base.Init();
        // Do anthing else we need to do here :)

        // Make the Properpty of IDamageable be the same as the health of enemy.cs
        Health = health;
    }

    public override void Movement()
    {
        base.Movement();

        // FLip to face the player if we are in "combat mode"
        if (isHit)
        {
            Vector3 direction = player.transform.localPosition - transform.localPosition;
            if (direction.x > 0) sprite.flipX = false;
            else sprite.flipX = true;
        }
    }

    public void Damage()
    {
        Health--;

        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }
}