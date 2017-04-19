using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float MaxSpeed = 1.0f;
	private Transform MyTransform = null;

	// Use this for initialization
	void Awake () {
		MyTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		MyTransform.position += MyTransform.forward * MaxSpeed * Time.deltaTime;
	}
}
