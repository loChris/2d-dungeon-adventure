using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Animator _animator;
    private Vector3 _currentTarget;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        speed = 1;
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
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _currentTarget, 
            speed * Time.deltaTime
            );
    }
}
