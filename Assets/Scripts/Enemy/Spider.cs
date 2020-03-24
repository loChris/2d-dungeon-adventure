using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    void Start()
    {
        Attack();
    }

    public override void Update()
    {
        Debug.Log("Spider Updating...");
    }

    public override void Attack()
    {
        base.Attack();
        Debug.Log("spider attack");
    }
}
