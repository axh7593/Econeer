using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class EyeRaycasting : MonoBehaviour {

    public float maxDist;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit seen;
        Ray direction = new Ray(transform.position, transform.forward);
        Debug.DrawLine(transform.position, transform.forward * 3, Color.green);
        if(Physics.Raycast(direction, out seen, maxDist))
        {
            if(seen.collider.tag == "UIElement")
            {
                Debug.Log("UI Element");
            }
        }
	}
}
