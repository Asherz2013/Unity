using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGenerator : MonoBehaviour
{

	//public GameObject AmmoPrefab = null;
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			//Instantiate(AmmoPrefab, transform.position, transform.rotation);
			AmmoManager.SpawnAmmo(transform.position, transform.rotation);
		}
	}
}
