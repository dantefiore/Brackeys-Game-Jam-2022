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

    
    [Header("I Frames")]
    public Color flashColor; //the color the player flashes when hit
    public Color regColor;  //the characters normal colors
    public float flashDur; //how long the flashing lasts
    public int numOfFlash;  //the number of flashes
    public Collider2D triggerCollider; //the players hurt box
    public SpriteRenderer mySprite; //the characters sprite
    public Vector2 facingDir = Vector2.down;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk; //sets the player state
        //anim = GetComponent<Animator>(); //finish setting up the animator

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

        change.x = Input.GetAxisRaw("Horizontal"); //gets the input for the x direction
        change.y = Input.GetAxisRaw("Vertical"); //gets the input for the y direction

        //checks what the player is pressing an attack button and if they are able to attack
        if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo()); //starts the attack function
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimAndMove(); //changes the characters animations
        }

        /*//checks the health to see if it went over the max health
        if (currHealth.RuntimeValue > heartContainers.RuntimeValue * 2f)
        {
            currHealth.RuntimeValue = heartContainers.RuntimeValue * 2f;
        }*/
    }

    //plays the attack animation
    private IEnumerator AttackCo()
    {
        //anim.SetBool("attacking", true);    //to play the attack animation
        currentState = PlayerState.attack;
        yield return null; //waits 1 frame
        //anim.SetBool("attacking", false);
        yield return new WaitForSeconds(0.3f);  //runs for 1/3 of a second

        //if the button is pressed while in the interact state
        if(currentState != PlayerState.interact)
        {
            //changes the player to the walk state
            currentState = PlayerState.walk;
        }
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
            transform.position + change * speed * Time.deltaTime
         );
    }

    //how much damage and how long the player is in knock for
    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));

    }

    //moving the character back
    private IEnumerator KnockCo(float knockTime)
    {
        if (myRigidBody != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;

            currentState = PlayerState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
    }

    //makes the Invulnerability frames
    private IEnumerator FlashCo()
    {
        //turns off the players hurtbox
        triggerCollider.enabled = false;

        //plays the flashing animations
        for (int i = 0; i < numOfFlash; i++)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDur);
            mySprite.color = regColor;
            yield return new WaitForSeconds(flashDur);
        }

        //turns the hurtbox back on
        triggerCollider.enabled = true;
    }
}