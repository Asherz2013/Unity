using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamagable
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

    // Animation Code
    private PlayerAnimation _playerAnim;

    // Sprites
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;

    private bool _grounded = false;

    // Var for amount of Diamonds
    public int _diamondCount = 0;

    // Is the playe dead?
    private bool _isDead = false;
    public bool IsDead
    {
        get { return _isDead; }
    }

    // Comes from the IDamage Interface
    public int Health { get; set; }

    // Use this for initialization
    void Start()
    {
        // assign the handle of rigidbody
        _rigid = GetComponent<Rigidbody2D>();

        // Assign the handle to Player Animation
        _playerAnim = GetComponent<PlayerAnimation>();

        // Assign the Handle to Sprite Renderer
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded())
        {
            _playerAnim.Attack();
        }
    }

    void Movement()
    {

        // Horizontal input for Left/Right
        // "Raw" input is a constent number between -1, 0, 1
        // Normal GetAxis will do a gradual increase -1, -0.9, -0.8, -0.7, etc
        float move =CrossPlatformInputManager.GetAxisRaw("Horizontal");

        _grounded = IsGrounded();

        // Determine which way the sprite should be facing
        if (move > 0)
        {
            _playerSprite.flipX = false;

            _swordArcSprite.flipY = false;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            _playerSprite.flipX = true;

            _swordArcSprite.flipY = true;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }


        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && _grounded)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _playerAnim.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _moveSpeed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);
        if (HitInfo.collider != null)
        {
            _playerAnim.Jump(false);
            return true;
        }
        return false;
    }

    // Comes from the IDamage Interface
    public void Damage()
    {
        if (_isDead) return;

        Health--;

        // Update the UI Display
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            // DEAD!
            _playerAnim.Death();
            _isDead = true;
        }
    }

    public void AddGems(int amount)
    {
        _diamondCount += amount;
        UIManager.Instance.UpdateGemCount(_diamondCount);
    }
}
