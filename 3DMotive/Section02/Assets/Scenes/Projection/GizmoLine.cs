using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoLine : MonoBehaviour
{

	public Transform LineStart = null;
	public Transform LineEnd = null;

	void OnDrawGizmos()
	{
		if (LineStart == null || LineEnd == null)
			return;

		Gizmos.color = Color.green;
		Gizmos.DrawLine(LineStart.position, LineEnd.position);
	}
}
