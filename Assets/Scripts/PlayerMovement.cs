using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Movement for a platformer
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    //Movement variables
    private float speed = 3f;
    private float jumpHeight = 10;
    //The movex and Movey variables are to make the code easier to read
    public float movex;
    public float movey;

    //Ground variables
    private bool grounded;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    //Sprite list
    public Sprite crouched;
    public Sprite standing;

    public GameObject standingHitbox;
    public GameObject crouchingHitbox;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        //Calling the functions we make below. Used in here because it's better than fixedUpdate.
        //As long as you use Time.deltaTime when dealing with Physics and movement
		ForceMovement();
        GroundCheck();
    }

	void ForceMovement() 
	{
		//Movement axis
		movex = Input.GetAxisRaw("Horizontal");
		movey = Input.GetAxisRaw("Vertical");

//		print(movex);

		//Left and right
		//Moves instantly
		if (movex > 0.1)
		{
			GetComponent<Rigidbody2D>().AddForce(transform.right * speed, mode: ForceMode2D.Impulse);
		}
		if (movex < -0.1)
		{
			GetComponent<Rigidbody2D>().AddForce(transform.right * -speed, mode: ForceMode2D.Impulse);
		}

        if (grounded)
        {
            if (movex == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        //Setting the max speed (velocity)
		float maxVelocity;
		if (!grounded) 
		{
			//Air max speed
			maxVelocity = 5;
		} else 
		{
			//Ground max speed
			maxVelocity = 4;
		}

		if (GetComponent<Rigidbody2D>().velocity.x > maxVelocity) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(maxVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (GetComponent<Rigidbody2D>().velocity.x < -maxVelocity)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-maxVelocity, GetComponent<Rigidbody2D>().velocity.y);
		}



		if (!grounded)
        {
            if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                print("Forcing");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0), mode: ForceMode2D.Impulse);
            }
            if (GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                print("Forcing");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0), mode: ForceMode2D.Impulse);
            }
        }
		
		

		//The code for jumping
		//Checks that the player is grounded
		if (movey > 0.1 && grounded)
		{
			//Takes the velocity of the player along the x axis (horisontally) so that the player keeps being able to move in that direction independant of the jump.
			//Adds a velocity equal to the jump height. 
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

        //Crouch
        //NEED TO ADD A RAYCAST BEFORE POPING BECAUSE BUGS
        if (movey < -0.1)
        {
            if (grounded)
            {
                maxVelocity = 2;
            }
            else
            {
                maxVelocity = 2.5f;
            }
            //Animate the player to the crouch
            GetComponent<SpriteRenderer>().sprite = crouched;

            //Disable the standing, enable the crouched hitbox
            standingHitbox.SetActive(false);
            crouchingHitbox.SetActive(true);
            
        } else
        {
            //Disable the crouched, enable the standing hitbox
            standingHitbox.SetActive(true);
            crouchingHitbox.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = standing;
        }

	}

    /// <summary>
    /// This function checks to see if the player is grounded
    /// </summary>
    /// <returns>Boolean grounded</returns>
    void GroundCheck()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}