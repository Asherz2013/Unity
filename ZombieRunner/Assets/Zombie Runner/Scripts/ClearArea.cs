using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour
{
    private float timeSinceLastTrigger = 0f;
    private bool foundClearArea = false;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTrigger += Time.deltaTime;
        if (timeSinceLastTrigger > 1f && Time.realtimeSinceStartup > 10f && !foundClearArea)
        {
            SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
    }

    void OnTiggerStay(Collider collider)
    {
        if(collider.tag != "Player") timeSinceLastTrigger = 0f;
    }
}
