using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Get Handle to rigidbody
    private Rigidbody2D _rigid = null;

    // Variable for Jump Force
    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private float _moveSpeed = 3.0f;

    // Handle to Player Animation
    private PlayerAnimation _playerAnim;

    // Handle to Sprite Renderer
    private SpriteRenderer _playerSprite;

    // Use this for initialization
    void Start()
    {
        // assign the handle of rigidbody
        _rigid = GetComponent<Rigidbody2D>();

        // Assign the handle to Player Animation
        _playerAnim = GetComponent<PlayerAnimation>();

        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // Horizontal input for Left/Right
        // "Raw" input is a constent number between -1, 0, 1
        // Normal GetAxis will do a gradual increase -1, -0.9, -0.8, -0.7, etc
        float move = Input.GetAxisRaw("Horizontal");

        // Determine which way the sprite should be facing
        if (move > 0) _playerSprite.flipX = false;
        else if (move < 0) _playerSprite.flipX = true;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
        }

        _rigid.velocity = new Vector2(move * _moveSpeed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);
        if (HitInfo.collider != null)
        {
            return true;
        }
        return false;
    }
}
