using UnityEngine;
using System.Collections;

/// <summary>
/// Movement for a platformer
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    //Movement variables
    private float speed = 1f;
    private float jumpHeight = 5;
    //The movex and Movey variables are to make the code easier to read
    public float movex;
    public float movey;

    //Ground variables
    private bool grounded;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    public Transform groundCheck;


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
		movex = Input.GetAxis("Horizontal");
		movey = Input.GetAxis("Vertical");

//		print(movex);

		//Left and right
		//Moves instantly
		if (movex > 0.1)
		{
			//Maxes movex for a binary movement feel
			movex = 10;
			GetComponent<Rigidbody2D>().AddForce(transform.right * speed, mode: ForceMode2D.Impulse);
		}
		if (movex < -0.1)
		{
			//Maxes movex for a binary movement feel
			movex = -10;
			GetComponent<Rigidbody2D>().AddForce(transform.right * -speed, mode: ForceMode2D.Impulse);
		}

		//Stops instantly on left and right
		if (movex < 9.9 && movex >= 0 && GetComponent<Rigidbody2D>().velocity.x != 0 && grounded) 
		{
			movex = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (movex > -9.9 && movex <= 0 && GetComponent<Rigidbody2D>().velocity.x != 0 && grounded) 
		{
			movex = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}

//		print(GetComponent<Rigidbody2D>().velocity.x);
		int maxVelocity;

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