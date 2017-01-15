using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;

public class WorldBuilder : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player") 
		{
			
		}
	}

	void makeLevels(List<string> openSides) 
	{
		if (openSides.Contains("up"))
        {
            //Get list of open bottoms
        }
        if (openSides.Contains("down"))
        {
            //Get list of open tops
        }
        if (openSides.Contains("left"))
        {
            //Get list of open rights
        }
        if (openSides.Contains("right"))
        {
            //Get list of open lefts
        }
	}

    public List<GameObject> getLists(string filePath)
    {
        var prefabs = File.ReadAllLines("");
        return Objects;
    }

}
