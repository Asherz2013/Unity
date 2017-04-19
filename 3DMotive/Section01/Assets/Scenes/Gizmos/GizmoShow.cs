using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoShow : MonoBehaviour {

	// Show we display gizmos for object?
	public bool ShowGizmos = true;

	// Icon to draw
	public string MyIcon = string.Empty;

	// Object range of sight
	[Range(0f,100f)]
	public float Range = 10f;

	// Display forward vector - Unity defined event
	void OnDrawGizmos()
	{
		// Exit if gizmo drawing is disabled
		if(!ShowGizmos) return;

		// Draw selected icon
		Gizmos.DrawIcon(transform.position, MyIcon, true);

		// Draw colout wire sphere
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, Range);

		// Draw forward vector
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * Range);
	}
}
