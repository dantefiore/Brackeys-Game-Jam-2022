using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;

    public GameObject levelChanger;
    public PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            movement.enabled = false;
            levelChanger.GetComponent<LevelChanger>().FadeToLevel(1);
        }
    }

    /*void Die()
    {
        //uncomment if we add a death effect
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        SceneManager.LoadScene("Game Over");
        Destroy(gameObject);
    }*/
}
