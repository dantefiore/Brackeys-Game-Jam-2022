using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //uncomment if we add a death effect
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
