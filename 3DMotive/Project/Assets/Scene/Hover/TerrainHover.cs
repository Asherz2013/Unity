using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour
{
	private Transform ThisTransform = null;
	private Vector3 DestUp = Vector3.zero;

	public float MaxSpeed = 10f;
	public float DistanceFromGround = 2f;
	public float AngleSpeed = 5;

	// Use this for initialization
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
	{
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		Vector3 NewPos = ThisTransform.position;
		NewPos += ThisTransform.forward * Vert * MaxSpeed * Time.deltaTime;
		NewPos += ThisTransform.right * Horz * MaxSpeed * Time.deltaTime;

		// Ray Cast to hit the Ground
		RaycastHit Hit;
		// From This Position in the downward direction
		if (Physics.Raycast(ThisTransform.position, Vector3.down, out Hit))
		{
			// The new way is: The point at which we hit the terrain + "up" * Distance
			NewPos.y = (Hit.point + Vector3.up * DistanceFromGround).y;

			// Record the Normal
			DestUp = Hit.normal;
		}

		ThisTransform.position = NewPos;
		// Interpolate the UP of the transform to match the current Normal Up.
		ThisTransform.up = Vector3.Slerp(ThisTransform.up, DestUp, AngleSpeed * Time.deltaTime);
	}
}
