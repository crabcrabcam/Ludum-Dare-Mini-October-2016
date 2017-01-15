using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("GO!");

        GameObject newPrefab;

        //Should be below
        newPrefab = Resources.Load("SizeTest", typeof(GameObject)) as GameObject;
        Instantiate(newPrefab, new Vector3(transform.position.x - 8, transform.position.y - 5, transform.position.z), Quaternion.identity);

        //Should be above
        newPrefab = Resources.Load("SizeTest", typeof(GameObject)) as GameObject;
        Instantiate(newPrefab, new Vector3(transform.position.x - 8, transform.position.y + 15, transform.position.z), Quaternion.identity);

        //Should be right
        newPrefab = Resources.Load("SizeTest", typeof(GameObject)) as GameObject;
        Instantiate(newPrefab, new Vector3(transform.position.x + 8, transform.position.y + 5, transform.position.z), Quaternion.identity);

        //Should be left
        newPrefab = Resources.Load("SizeTest", typeof(GameObject)) as GameObject;
        Instantiate(newPrefab, new Vector3(transform.position.x - 24, transform.position.y + 5, transform.position.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
