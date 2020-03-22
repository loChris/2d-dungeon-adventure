using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpHeight = 10.0f;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private bool _resetJumpCooldown = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * _speed;
        _rigidbody2D.velocity = new Vector2(moveHorizontal, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("you jumped");
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpHeight);
            StartCoroutine(ResetJumpCooldown());
        }
    }

    bool IsGrounded ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 
            0.6f, 
            _groundLayer.value
            );
        
        if (hitInfo.collider != null)
        {
            if (_resetJumpCooldown == false)
                return true;
        }
        return false;
    }

    IEnumerator ResetJumpCooldown()
    {
        _resetJumpCooldown = true;
        yield return new WaitForSeconds(.1f);
        _resetJumpCooldown = false;
    }
}
