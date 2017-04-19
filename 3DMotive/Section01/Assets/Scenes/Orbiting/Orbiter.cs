using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Orbiter : MonoBehaviour {

	public Transform Pivot = null;
	public float PivotDistance = 5f;
	public float RotSpeed = 10f;

	private Transform ThisTransform = null;
	private Quaternion DestRot = Quaternion.identity;

	private float RotX = 0f;
	private float RotY = 0f;

	// Use this for initialization
	void Awake () 
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Is the player pressing either "Horizontal" or "Vertical"
		float Horz = CrossPlatformInputManager.GetAxis ("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis ("Vertical");

		// Work out how much we need to move in the specified direction
		RotX += Vert * Time.deltaTime * RotSpeed;
		RotY += Horz * Time.deltaTime * RotSpeed;

		// Make up the Quaternion
		// Remeber addition is actually multiply
		// Quaternion Multiplication MATTERS!
		Quaternion YRot = Quaternion.Euler (0f, RotY, 0f);
		DestRot = YRot * Quaternion.Euler (RotX, 0f, 0f); 

		// Apply the Rotation
		ThisTransform.rotation = DestRot;

		// Adjust Poition to always be "PivotDistance" away from the "Pivot"
		ThisTransform.position = Pivot.position + ThisTransform.rotation * Vector3.forward * -PivotDistance;
	}
}
