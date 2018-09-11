using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject gemPrefab;

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

    protected bool isHit = false;

    //variable to store the "Player" position
    protected Player player;

    protected bool isDead = false;

    // Initialisation Script
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        currentTarget = PointB.position;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        AnimatorStateInfo animStatInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (animStatInfo.IsName("Idle") && !anim.GetBool("InCombat")) return;

        if(!isDead) Movement();
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

        if (isHit == false) transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        else if (Vector3.Distance(transform.localPosition, player.transform.localPosition) > 2.0f || player.IsDead == true)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }

        // FLip to face the player if we are in "combat mode"
        if (isHit)
        {
            Vector3 direction = player.transform.localPosition - transform.localPosition;
            if (direction.x > 0) sprite.flipX = false;
            else sprite.flipX = true;
        }
    }

}
