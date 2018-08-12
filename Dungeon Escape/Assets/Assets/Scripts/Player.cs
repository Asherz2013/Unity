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
    // Variable for grounded = false
    private bool _grounded = false;
    [SerializeField]
    private LayerMask _groundLayer;

    private bool _resetJumpNeeded = false;

    // Use this for initialization
    void Start()
    {
        // assign the handle of rigidbody
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal input for Left/Right
        // "Raw" input is a constent number between -1, 0, 1
        // Normal GetAxis will do a gradual increase -1, -0.9, -0.8, -0.7, etc
        float move = Input.GetAxisRaw("Horizontal");




        // If Space Key && grounded == true
        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            // current velocity = new velocity ( x, jumpforce)
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            //breath
            _resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

        // 2D raycast to the ground
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.red);

        // If hitinfo != null
        if (hitinfo.collider != null)
        {
            Debug.Log("Hit: " + hitinfo.collider.name);
            // grounded = true
            if(_resetJumpNeeded == false) _grounded = true;
        }



        // current velocity = new velocity (x, current velocity.y);
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }
}
