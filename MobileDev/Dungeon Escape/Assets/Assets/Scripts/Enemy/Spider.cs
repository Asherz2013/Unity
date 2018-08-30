using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    public int Health { get; set; }

    public GameObject _acidEffectPrefab;

    public override void Init()
    {
        base.Init();

        // Make the Properpty of IDamageable be the same as the health of enemy.cs
        Health = health;
    }

    public override void Update()
    {
        // Stops errors happening.
    }

    public override void Movement()
    {
        // DO nothing and Sit still
    }

    public void Damage()
    {
        if (isDead) return;

        Health--;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");

            // Spawn a Diamond
            GameObject gem = Instantiate(gemPrefab, transform.position, Quaternion.identity) as GameObject;
            Diamond diamond = gem.GetComponent<Diamond>();
            if (diamond)
            {
                diamond._diamondsToAdd = gems;
            }
        }
    }

    public void Attack()
    {
        // instanciate the acid effect
        if (_acidEffectPrefab)
        {
            Instantiate(_acidEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}