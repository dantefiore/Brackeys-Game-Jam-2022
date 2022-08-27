using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the different states of the enemy
public enum EnemyState { idle, walk, attack, stagger }

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 1;
    [SerializeField] private int dmg = 5;

    [Header("Chase")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target; //player
    public float moveSpeed; //move speed
    [SerializeField] private float rotationSpeed = 5; //speed of turning
    [SerializeField] private bool inArea = false;

    [Header("Way Points")]
    public List<Transform> points;
    public int nextPointIndex = 0;
    public float step;

    //If/ when we add an effect when the enemy dies
    //public GameObject deathEffect;

    public virtual void Start()
    {
        step = moveSpeed;
        transform.position = points[nextPointIndex].position;
    }

    void Update()
    {
        if(!inArea)
            Move();

        //transform.rotation = Quaternion.Slerp(transform.rotation, 
         //   Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
        if(target != null)
        {
            Vector2 direction = new Vector2(
                target.position.x - transform.position.x,
                target.position.y - transform.position.y
            );

            transform.up = direction;

            if (inArea)
                transform.position += transform.up * moveSpeed;
        }
        
    }

    public void Move()
    {
        //moving to waypoint
        transform.position = Vector2.MoveTowards(transform.position, points[nextPointIndex].position, step);

        if (transform.position == points[nextPointIndex].position)
            nextPointIndex += 1;

        if (nextPointIndex >= points.Count)
        {
            nextPointIndex = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //uncomment if we add a death effect
        //Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ChaseRadius")
        {
            inArea = true;
        }

        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ChaseRadius")
        {
            inArea = false;
        }
    }
}
