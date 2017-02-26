using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Interaction : MonoBehaviour {
	//<CATEGORY <NAME, GAMEOBJECT>>
	public Dictionary<string, Dictionary<string, GameObject>> inventory = new Dictionary<string, Dictionary<string, GameObject>>();
	private GameObject player;
	private GameObject hierarchy;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("MainCamera") as GameObject;
		hierarchy = GameObject.Find ("UI_Ring_Hierarchy");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.2f, player.transform.position.z);
		float rotationAngle = Quaternion.LookRotation (player.transform.forward.normalized).eulerAngles.y * Mathf.Deg2Rad;
		Vector3 hierarchyPos = hierarchy.transform.position;
		hierarchy.transform.position = new Vector3((transform.position.x + Mathf.Sin(rotationAngle)), 2.25f, (transform.position.z + Mathf.Cos(rotationAngle)));
	}
}
