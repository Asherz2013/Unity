using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();

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
