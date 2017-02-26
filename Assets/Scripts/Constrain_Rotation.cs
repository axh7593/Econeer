using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Constrain_Rotation : MonoBehaviour {
    private Quaternion initialRotation;
	public GameObject player;
	// Use this for initialization
	void Start ()
    {
		initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 direction = (player.transform.position - transform.position).normalized;
		Quaternion lookRot = Quaternion.LookRotation (direction * -1);
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRot, Time.deltaTime * 100);
	}
}
