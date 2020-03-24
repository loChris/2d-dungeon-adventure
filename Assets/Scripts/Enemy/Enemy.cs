using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Vector3 currentTarget;
    [SerializeField] protected Transform pointA, pointB;
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    public virtual void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) 
        {
            return;
        }
        
        Movement();
    }
    public virtual void Init()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    public virtual void Movement()
    {
        spriteRenderer.flipX = currentTarget == pointA.position;

        if (transform.position == pointA.position)
        {
            animator.SetTrigger("Idle");
            currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            animator.SetTrigger("Idle");
            currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget, 
            speed * Time.deltaTime
        );
    }
}
