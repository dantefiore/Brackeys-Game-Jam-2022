using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunEnemy : Enemy
{
    [SerializeField] private IntVal counter;

    public override void Start()
    {
        counter.currentVal = counter.initialVal;
        step = moveSpeed;
        transform.position = points[nextPointIndex].position;
    }

    public override void Die()
    {
        //uncomment if we add a death effect
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        counter.currentVal--;

        Destroy(gameObject);
    }
}
