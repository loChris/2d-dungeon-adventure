using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _swordSlashSpriteRenderer;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpHeight = 10.0f;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private bool _resetJumpCooldown = false;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordSlashSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
        
        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnimation.Attack();
        }
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * _speed;
        _isGrounded = IsGrounded();
        FlipSrite(moveHorizontal);
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpHeight);
            StartCoroutine(ResetJumpCooldown());
            _playerAnimation.Jump(true);
        }
        
        _rigidbody2D.velocity = new Vector2(moveHorizontal, _rigidbody2D.velocity.y);
        
        _playerAnimation.Move(moveHorizontal);
    }

    bool IsGrounded ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(
            transform.position, 
            Vector2.down, 
            1f, 
            _groundLayer.value
            );
        
        if (hitInfo.collider != null)
        {
            if (_resetJumpCooldown == false)
            {
                _playerAnimation.Jump(false);
                return true;   
            }
        }
        return false;
    }

    void FlipSrite(float move)
    {
        if (_playerSpriteRenderer != null)
        {
            if (move > 0)
            {
                _playerSpriteRenderer.flipX = false;
                _swordSlashSpriteRenderer.flipY = false;
            }
            else if (move < 0)
            {
                _playerSpriteRenderer.flipX = true;
                _swordSlashSpriteRenderer.flipY = true;
            }
        }
    }

    IEnumerator ResetJumpCooldown()
    {
        _resetJumpCooldown = true;
        yield return new WaitForSeconds(.1f);
        _resetJumpCooldown = false;
    }
}
