using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSaver : MonoBehaviour
{
	public Vector3 LastPosition = Vector3.zero;
	public Quaternion LastRotation = Quaternion.identity;

	private Transform ThisTransform = null;

	// Use this for initialization
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}

	void Start()
	{
		string JSONString = JsonUtility.ToJson(this);
		Debug.Log(JSONString);
	}

	// Update is called once per frame
	void OnDestroy()
	{
		LastPosition = ThisTransform.position;
		LastRotation = ThisTransform.rotation;


	}


}
