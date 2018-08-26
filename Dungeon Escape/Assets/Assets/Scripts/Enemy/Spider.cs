using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamagable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();

        // Make the Properpty of IDamageable be the same as the health of enemy.cs
        Health = health;
    }

    public void Damage()
    {

    }
}