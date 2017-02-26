using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerInput : MonoBehaviour {
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;
	public GameObject uiRing;
	private bool UI_Toggle = false;
	private Animator uiAnim;
	private Vector2 padLocation;
	private bool toolTips = true;
	GameObject toolTipsObject;
	// Use this for initialization
	void Start () 
	{
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
		uiAnim = uiRing.GetComponentInParent (typeof(Animator)) as Animator;
		uiAnim.Play ("Collapse_UI");
		Debug.Log ("Started");
		device = SteamVR_Controller.Input ((int)trackedObject.index);
		toolTipsObject = GameObject.Find ("ControllerTooltips");
	}
	// Update is called once per frame
	void Update () 
	{
		padLocation = new Vector2 (device.GetAxis ().x, device.GetAxis ().y);
		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) 
		{
			float midTouchRad = 0.25F;
			if (device.GetAxis ().y < midTouchRad && device.GetAxis ().y > -midTouchRad && device.GetAxis ().x < midTouchRad && device.GetAxis ().x > -midTouchRad) 
			{
				if (UI_Toggle) 
				{
					uiAnim.Play ("Collapse_UI");
				} 
				else 
				{
					uiAnim.Play ("Expand_UI");
				}
				UI_Toggle = !UI_Toggle;
			} 
			else 
			{
				if (device.GetAxis ().y > midTouchRad) 
				{
					Debug.Log ("UP");
				} 
				else if (device.GetAxis ().y < -midTouchRad) 
				{
					Debug.Log ("DOWN");
				}
			}
		} 
		else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) 
		{
			toolTips = !toolTips;
			toolTipsObject.SetActive (toolTips);
		}
		if (device.GetAxis().x != 0 || device.GetAxis().y != 0) 
		{
			uiRing.transform.rotation = Quaternion.AngleAxis (analogRotationAngle(padLocation), new Vector3(0, -1, 0));
		}

	}
	float analogRotationAngle(Vector2 padLoc)
	{
		return Mathf.Atan2 (padLoc.y, padLoc.x) * Mathf.Rad2Deg;
	}
}
