using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour 
{
	private Transform ThisTransform = null;

	public bool RotateOnSpot = true;
	public bool InstantLoop = true;

	public float RotSpeed = 90f;
	public Transform Target = null;

	// Use this for initialization
	void Awake () 
	{
		ThisTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (RotateOnSpot) 
		{
			// Quarternion "addition" is actually "Multiply"
			ThisTransform.rotation *= Quaternion.AngleAxis (RotSpeed * Time.deltaTime, Vector3.up);
		} 
		else if (InstantLoop) 
		{
			// Look at the target cube
			ThisTransform.rotation = Quaternion.LookRotation (Target.position - ThisTransform.position, Vector3.up);
		} 
		else 
		{
			// Store the location of the Cube (same as above)
			Quaternion DestRot = Quaternion.LookRotation (Target.position - ThisTransform.position, Vector3.up);
			// Rotato to the above rotation at a particular speed
			ThisTransform.rotation = Quaternion.RotateTowards (ThisTransform.rotation, DestRot, RotSpeed * Time.deltaTime);
		}
	}
}
