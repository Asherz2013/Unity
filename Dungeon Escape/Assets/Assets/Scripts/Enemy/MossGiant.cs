using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;

    private Animator _anim;
    private SpriteRenderer _sprite;

    public void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        _currentTarget = PointB.position;
    }

    public override void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;

        if (_currentTarget == PointA.position) _sprite.flipX = true;
        else _sprite.flipX = false;

        if (transform.position == PointA.position)
        {
            _currentTarget = PointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == PointB.position)
        {
            _currentTarget = PointA.position;
            _anim.SetTrigger("Idle");

        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
