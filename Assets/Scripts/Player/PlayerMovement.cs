using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the states the player can be in
 public enum PlayerState { idle, walk, attack, interact, stagger, ability }

public class PlayerMovement : MonoBehaviour
{
    [Header("Character Movement")]
    public float speed; //the speed of the player
    public Rigidbody2D myRigidBody; //the rigid body object on the player
    private Vector3 change; //the change in position for the player
    //public Animator anim; //controls what animations play
    public PlayerState currentState;
    public Vector2 facingDir = Vector2.down;
    public bool walking;

    [Header("Crouching")]
    [SerializeField] private CircleCollider2D chaseRadius;
    [SerializeField] private float radius;
    private float origRadius;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk; //sets the player state
        //anim = GetComponent<Animator>(); //finish setting up the animator

        origRadius = chaseRadius.radius;
        //speed *= Time.deltaTime;

        //for the animations and which way the character should be facing
        //anim.SetFloat("moveX", 0);
        //anim.SetFloat("moveY", -1);

        myRigidBody = GetComponent<Rigidbody2D>(); //finish setting up the rigid body
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == PlayerState.interact)
        {
            return;
        }

        faceMouse();

        if (!Input.anyKey)
        {
            myRigidBody.velocity = Vector3.zero;
        }
        else
        {
            change.x = Input.GetAxisRaw("Horizontal"); //gets the input for the x direction
            change.y = Input.GetAxisRaw("Vertical"); //gets the input for the y direction

            if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                UpdateAnimAndMove(); //changes the characters animations
            }

        }
        
    }

    void faceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x, 
            mousePos.y - transform.position.y
        );

        transform.up = direction;
    }

    //Changes the animations for what should be played when
    void UpdateAnimAndMove()
    {
        if (change != Vector3.zero) //if change is anything but 0
        {
            MoveCharacter();

            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);

            //plays the animation depending on what number is entered
            //anim.SetFloat("moveX", change.x); 
            //anim.SetFloat("moveY", change.y);
            //anim.SetBool("moving", true);
            facingDir = change;
        }
        else
        {
            //anim.SetBool("moving", false); //idle positions
        }
    }

    //changes the position of the character
    void MoveCharacter()
    {
        change.Normalize();
        myRigidBody.MovePosition(
            transform.position + change * speed
         );
    }
}