using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharController : MonoBehaviour
{
	private Animator ThisAnimator = null;

	// Integers are faster in an update, rather than useing Strings. So we can HASH to values to Int's
	private int VertHash = Animator.StringToHash("Vertical");
	private int HorzHash = Animator.StringToHash("Horizontal");

	// Use this for initialization
	void Awake()
	{
		ThisAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		ThisAnimator.SetFloat(HorzHash, Horz, 0.1f, Time.deltaTime);
		ThisAnimator.SetFloat(VertHash, Vert, 0.1f, Time.deltaTime);
	}
}

