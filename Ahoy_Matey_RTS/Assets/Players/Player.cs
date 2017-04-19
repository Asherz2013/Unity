using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    private Vector3 inputValue;
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        inputValue.x = CrossPlatformInputManager.GetAxis("Horizontal");
        inputValue.y = 0f;
        inputValue.z = CrossPlatformInputManager.GetAxis("Vertical");

        transform.Translate(inputValue * moveSpeed);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<Camera>().enabled = true;
    }
}
