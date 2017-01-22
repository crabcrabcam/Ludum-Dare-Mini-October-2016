using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearResources : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Resources.UnloadUnusedAssets();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
