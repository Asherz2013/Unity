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

    public void Damage()
    {
        if (isDead) return;

        Health--;

        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");

            // Spawn a Diamond
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            Diamond diamond = gem.GetComponent<Diamond>();
            if(diamond)
            {
                diamond._diamondsToAdd = gems;
            }
        }
    }
}