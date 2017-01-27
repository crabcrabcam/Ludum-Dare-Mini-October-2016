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
			Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y + 10), Color.white, 50);
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 10), 0.5f, -1))
            {
                //Get list of open bottoms
                getList("bottom");
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
			print("Contains down");
			Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - 10), Color.white, 50);
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 10), 0.5f, -1))
            {
                //Get list of open tops
                getList("top");
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
			Debug.DrawLine(transform.position, new Vector2(transform.position.x - 16, transform.position.y), Color.white, 50);
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x - 16, transform.position.y), 0.5f, -1))
            {
                //Get list of open rights
                getList("right");
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
			Debug.DrawLine(transform.position, new Vector2(transform.position.x + 16, transform.position.y), Color.white, 50);
            if (!Physics2D.OverlapCircle(new Vector2(transform.position.x + 16, transform.position.y), 0.5f, -1))
            {
                //Get list of open lefts
                getList("left");
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
        prefabObjects.Clear();
		//Read all the lines from the file. File loaded from resources

		print((Resources.Load(filePath, typeof(TextAsset)) as TextAsset).text);

		List<string> prefabs = new List<string>((Resources.Load(filePath, typeof(TextAsset)) as TextAsset).text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None));

        foreach (var prefab in prefabs)
        {
            print(prefab);
			print(prefabs.Count);
            GameObject newPrefab = Resources.Load(prefab, typeof(GameObject)) as GameObject;
            prefabObjects.Add(newPrefab);
        }
    }

}
