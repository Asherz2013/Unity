using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaceObject : MonoBehaviour
{

	public float DisplaceSpeed = 2f;
	private Transform ThisTransform = null;

	public bool IsLocalSpace = true;

	// Forces variables to show inside the inspector
	[SerializeField]
	private Vector3 LocalForward;
	[SerializeField]
	private Vector3 TransformForward;

	// Use this for initialization
	void Awake ()
	{
		ThisTransform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		LocalForward = Vector3.forward;
		TransformForward = ThisTransform.forward;

		if (IsLocalSpace)
		{
			// Local Space
			Vector3 LocalSpaceDisplacement = Vector3.forward * DisplaceSpeed * Time.deltaTime;
			//Vector3 WorldSpaceDisplacement = ThisTransform.TransformDirection (LocalSpaceDisplacement);

			// Quaternion Multiply MUST be done in order. Quaternion first.
			Vector3 WorldSpaceDisplacement = ThisTransform.rotation * LocalSpaceDisplacement;

			ThisTransform.position += WorldSpaceDisplacement;
		}
		else
		{
			// World Space
			ThisTransform.position += ThisTransform.forward * DisplaceSpeed * Time.deltaTime;
		}



	}
}
