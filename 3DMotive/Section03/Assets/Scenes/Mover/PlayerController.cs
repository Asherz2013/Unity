using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
	private Transform ThisTransform = null;
	private CharacterController ThisController = null;
	private Vector3 Velocity = Vector3.zero;

	public bool UseSimpleControls = true;

	public float MaxSpeed = 10f;
	public float RotSpeed = 5f;
	public float JumpForce = 50f;
	public float GroundDist = 0.1f;
	public bool IsGrounded = false;
	public LayerMask GroundLayer;

	// Use this for initialization
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
		ThisController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	// Physics should be done within Fixed Update
	void FixedUpdate()
	{
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		// Update Rotation
		ThisTransform.rotation *= Quaternion.Euler(0f, RotSpeed * Horz * Time.deltaTime, 0f);

		if (UseSimpleControls)
		{
			// Update motion
			// ThisTransform.position += ThisTransform.forward * MaxSpeed * Vert * Time.deltaTime;
			ThisController.SimpleMove(ThisTransform.forward * MaxSpeed * Vert); // Simple move handles Time.deltaTime

		}
		else
		{
			// Calculate Move Dir
			Velocity.z = Vert * MaxSpeed;

			// Are we grounded?
			IsGrounded = (DistanceToGround() < GroundDist) ? true : false;

			// Should we jump?
			if (CrossPlatformInputManager.GetAxisRaw("Jump") != 0 && IsGrounded)
				Velocity.y = JumpForce;

			// Apply Gravity
			Velocity.y += Physics.gravity.y * Time.deltaTime;

			// Move
			ThisController.Move(ThisTransform.TransformDirection(Velocity) * Time.deltaTime);	
		}
	}

	public float DistanceToGround()
	{
		RaycastHit hit;
		float distanceToGround = 0;
		if (Physics.Raycast(ThisTransform.position, -Vector3.up, out hit, Mathf.Infinity, GroundLayer))
			distanceToGround = hit.distance;
		return distanceToGround;
	}
}
