using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using UnityEngine;

public class WorldBuilder : MonoBehaviour {

    public List<string> openSides;

    List<GameObject> prefabObjects = new List<GameObject>();

    System.Random random = new System.Random();

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
            print("Player!");
            makeLevels();
            Destroy(this);
		}
	}



    void makeLevels()
	{

        if (openSides.Contains("up"))
        {
            //Check bottom is clear
            //Returns true if something is there
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x - 8, transform.position.y + 15), 0.5f, -1))
            {
                //Get list of open bottoms
                getList("Assets/Room Lists/bottom.txt");
                //Make a random number from the list
                int newRoomIndex = random.Next(0, prefabObjects.Count);
                //Get that object
                GameObject newRoom = prefabObjects[newRoomIndex];
                //Place it in the world in the correct position
                Instantiate(newRoom, new Vector3(transform.position.x - 8, transform.position.y + 15, transform.position.z), Quaternion.identity);
            }
        }

        if (openSides.Contains("down"))
        {
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x - 8, transform.position.y - 5), 0.5f, -1))
            {
                //Get list of open tops
                getList("Assets/Room Lists/top.txt");
                //Make a random number from the list
                int newRoomIndex = random.Next(0, prefabObjects.Count);
                //Get that object
                GameObject newRoom = prefabObjects[newRoomIndex];
                //Place it in the world in the correct position
                Instantiate(newRoom, new Vector3(transform.position.x - 8, transform.position.y - 5, transform.position.z), Quaternion.identity);
            }

        }
        if (openSides.Contains("left"))
        {
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x - 24, transform.position.y + 5), 0.5f, -1))
            {
                //Get list of open rights
                getList("Assets/Room Lists/right.txt");
                //Make a random number from the list
                int newRoomIndex = random.Next(0, prefabObjects.Count);
                //Get that object
                GameObject newRoom = prefabObjects[newRoomIndex];
                //Place it in the world in the correct position
                Instantiate(newRoom, new Vector3(transform.position.x - 24, transform.position.y + 5, transform.position.z), Quaternion.identity);
            }

        }
        if (openSides.Contains("right"))
        {
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x + 8, transform.position.y + 5), 0.5f, -1))
            {
                //Get list of open lefts
                getList("Assets/Room Lists/left.txt");
                //Make a random number from the list
                int newRoomIndex = random.Next(0, prefabObjects.Count);
                //Get that object
                GameObject newRoom = prefabObjects[newRoomIndex];
                //Place it in the world in the correct position
                Instantiate(newRoom, new Vector3(transform.position.x + 8, transform.position.y + 5, transform.position.z), Quaternion.identity);
            }
        }
    }


    void getList(string filePath)
    {
        print(filePath);
        prefabObjects.Clear();
        var prefabs = File.ReadAllLines(filePath);
        foreach (var prefab in prefabs)
        {
            print(prefab);
            GameObject newPrefab = Resources.Load(prefab, typeof(GameObject)) as GameObject;
            prefabObjects.Add(newPrefab);
        }
    }

}
