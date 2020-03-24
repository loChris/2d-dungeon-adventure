using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    void Start()
    {
        Attack();
    }

    public override void Update()
    {
        Debug.Log("Moss Giant updating...");
    }
}
