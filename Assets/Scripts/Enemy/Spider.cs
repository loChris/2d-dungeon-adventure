using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _currentTarget;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speed = 2;
    }

    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) 
        {
            return;
        }
        
        Movement();
    }

    void Movement()
    {
        _spriteRenderer.flipX = _currentTarget == pointA.position;

        if (transform.position == pointA.position)
        {
            _animator.SetTrigger("Idle");
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _animator.SetTrigger("Idle");
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _currentTarget, 
            speed * Time.deltaTime
        );
    }
}
