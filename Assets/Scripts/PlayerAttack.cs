using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (attacking) 
		{
			Attack();
		}
	}

	bool attacking = false;

	void FixedUpdate() 
	{
		if (Input.GetButtonDown("Fire1"))
		{
			attacking = true;
			stage = "toTop";
		}
	}

	public GameObject swordTop;
	public GameObject swordBottom;
	public GameObject swordHome;

	string stage = "";

	bool reachedTarget;

	void TargetCheck(GameObject target)
	{
		//Checks the distance between 2 objects and returns true if they're closer than 0.1 (UnityUnits?)
		if (Vector3.Distance(transform.position, target.transform.position) < 0.1f) 
		{
			reachedTarget = true;
		}
		else 
		{
			reachedTarget = false;
		}

//		print(target.name);
//		Debug.DrawLine(transform.position, target.transform.position);
//
//		//Returns true when the sword is over the target
//		//Performs a raycast from the sword towards the target and only checks for 0.1 distance. 
//		if (Physics.Raycast(transform.position, target.transform.position, 1)) 
//		{
//			print("True");
//			reachedTarget = true;
//		}
//		else 
//		{
//			reachedTarget = false;
//			print("False");
//		}
	}

	/// <summary>
	/// Use the sword to attack. If more weapons added, will add more functions and call specific ones
	/// Will use the "Fire" check to see what weapon
	/// </summary>
	void Attack() 
	{
		//Go when the "Fire1" button has been pressed

		//Enable hitbox
		GetComponent<BoxCollider2D>().enabled = true;
		reachedTarget = false;
		//Move to the top of the swing
		if (stage == "toTop") 
		{
			TargetCheck(swordTop);
			//Checks if the sword has reached destination
			if (!reachedTarget)
			{
				//Moves sword to destination
				transform.position = Vector3.MoveTowards(transform.position, swordTop.transform.position, 0.05f);
			} else 
			{
				print("toBottom");
				//Move to next stage
				stage = "toBottom";
				//Stops it from being at the target
				reachedTarget = false;
			}
		}
		//Move to bottom of swing
		if (stage == "toBottom") 
		{
			print("Target = tobottom");
			TargetCheck(swordBottom);
			//Checks if sword has reached destination
			if (!reachedTarget) 
			{
				//Moves sword to destination
				transform.position = Vector3.MoveTowards(transform.position, swordBottom.transform.position, 0.05f);
			} else 
			{
				print("toStart");
				//Move to next stage
				stage = "toStart";
				//Stops it from being at the target
				reachedTarget = false;
			}
		} 
		//Move back home
		if (stage == "toStart") 
		{
			TargetCheck(swordHome);
			//Checks if sword has reached destination
			if (!reachedTarget) 
			{
				//Moves sword to destination
				transform.position = Vector3.MoveTowards(transform.position, swordHome.transform.position, 0.05f);
			} else 
			{
				print("Done");
				//Ended state so it can start again
				stage = "ended";
				attacking = false;
			}
		}
		//Disable hitbox
		GetComponent<BoxCollider2D>().enabled = false;
	}


}