using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{
	private Transform ThisTransform = null;

	public float RotSpeed = 90f;
	public Transform Target = null;

	public float Damping = 55f;

	public bool UseDamping = false;

	// Use this for initialization
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (UseDamping)
			RotateTowardsWithDamp();
		else
			RotateTowards();
	}

	void RotateTowards()
	{
		// Get look to rotation
		Quaternion DestRot = Quaternion.LookRotation(Target.position - ThisTransform.position, Vector3.up);

		// Update rotation
		ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation, DestRot, RotSpeed * Time.deltaTime);
	}

	void RotateTowardsWithDamp()
	{
		// Get look to rotation
		Quaternion DestRot = Quaternion.LookRotation(Target.position - ThisTransform.position, Vector3.up);

		// Calc smooth rotate
		Quaternion smoothRot = Quaternion.Slerp(ThisTransform.rotation, DestRot, 1f - (Time.deltaTime * Damping));

		// Update Rotation
		ThisTransform.rotation = smoothRot;
	}
}
