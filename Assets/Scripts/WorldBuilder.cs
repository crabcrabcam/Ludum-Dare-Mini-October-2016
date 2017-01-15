using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;

public class WorldBuilder : MonoBehaviour {

    public List<string> openSides;

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

	void makeLevels()
	{
		if (openSides.Contains("up"))
        {
            //Check bottom is clear
            if (Physics.CheckSphere(new Vector2(transform.position.x, transform.position.y + 12), 0.1f))
            {
                //Returns true if something is there

                //Get list of open bottoms
                getList("Assets/Room Lists/bottom.txt");
                //Make a random number from the list
                int newRoomIndex = new System.Random().Next(0, prefabObjects.Count);
                //Get that object
                GameObject newRoom = prefabObjects[newRoomIndex];
                //Place it in the world in the correct position
                Instantiate(newRoom, new Vector3(transform.position.x, transform.position.y + 12, transform.position.z), Quaternion.identity);
            }
            
        }
        if (openSides.Contains("down"))
        {
            //Get list of open tops
            getList("Assets/Room Lists/top.txt");
        }
        if (openSides.Contains("left"))
        {
            //Get list of open rights
            getList("Assets/Room Lists/right.txt");
        }
        if (openSides.Contains("right"))
        {
            //Get list of open lefts
            getList("Assets/Room Lists/left.txt");
        }
	}

    List<GameObject> prefabObjects;
    void getList(string filePath)
    {
        var prefabs = File.ReadAllLines(filePath);
        foreach (var prefab in prefabs)
        {
            GameObject newPrefab = Resources.Load(prefab, typeof(GameObject)) as GameObject;
            prefabObjects.Add(newPrefab);
        }
    }

}
