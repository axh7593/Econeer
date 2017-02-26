using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour 
{
	Object [] inventoryAssets;
	// Use this for initialization
	void Start () 
	{
		inventoryAssets = AssetDatabase.LoadAllAssetsAtPath ("Assets");
		foreach (Object o in inventoryAssets) 
		{
			Debug.Log (o.name);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
