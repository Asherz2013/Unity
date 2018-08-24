using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected float speed = 1.0f;

    [SerializeField]
    protected int gems;

    [SerializeField]
    protected Transform PointA, PointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;

    // Initialisation Script
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        currentTarget = PointB.position;
    }

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

        Movement();
    }

    // Movement code - Shared with all Children :)
    public virtual void Movement()
    {
        if (currentTarget == PointA.position) sprite.flipX = true;
        else sprite.flipX = false;

        if (transform.position == PointA.position)
        {
            currentTarget = PointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == PointB.position)
        {
            currentTarget = PointA.position;
            anim.SetTrigger("Idle");

        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }
}
