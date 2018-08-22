﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected int speed;

    [SerializeField]
    protected int gems;

    [SerializeField]
    protected Transform PointA, pointB;

    public virtual void Attack()
    {
        Debug.Log("My name is:" + gameObject.name);
    }

    // This is Forcing the Child to implement this function
    public abstract void Update();
}