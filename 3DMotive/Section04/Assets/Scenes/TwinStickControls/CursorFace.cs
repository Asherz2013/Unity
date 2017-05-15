using UnityEngine;
using System.Collections;

public class CursorFace : MonoBehaviour
{
	private Transform ThisTransform = null;
	// Use this for initialization
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
	{
		// Grab the mouse pointer from the screen and cast it into the world
		Vector3 MousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

		// Making sure we are on the same level as the Object
		MousePosWorld = new Vector3(MousePosWorld.x, ThisTransform.position.y, MousePosWorld.z);

		// Get the Vector between the two points
		Vector3 LookDirection = MousePosWorld - ThisTransform.position;

		// Rotate this object to face the point we created.
		ThisTransform.localRotation = Quaternion.LookRotation(LookDirection.normalized, Vector3.up);
	}
}
