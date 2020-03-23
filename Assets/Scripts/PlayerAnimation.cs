using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //need handle to animator
    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        _animator.SetBool("Jump", jump);
    }
    
    //attack method trigger attack
    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
