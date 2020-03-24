using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    bool switchPoints = false;

    void Start()
    {
        speed = 1;
    }

    public override void Update()
    {
        if (switchPoints == false)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                pointB.position, 
                speed * Time.deltaTime
            );
        } 
        else if (switchPoints)
        {
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    pointA.position,
                    speed * Time.deltaTime
                );
            }
        }
        
        if (transform.position == pointA.position)
        {
            switchPoints = false;
        }
        else if (transform.position == pointB.position)
        {
            Debug.Log("Im at point B");
            switchPoints = true;
        }
    }
}
