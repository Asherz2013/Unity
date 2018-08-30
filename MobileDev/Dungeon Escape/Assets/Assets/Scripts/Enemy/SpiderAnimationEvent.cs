using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    // Handle to the Spider
    private Spider _spiderScript;

    public void Start()
    {
        // Assign Handle to Spider
        _spiderScript = GetComponentInParent<Spider>();
    }

    // Called from Animation Controller of Spider on Event
    public void Fire()
    {
        // Tell Spider to Fire
        // Use handle to call Attack Method on spider
        if(_spiderScript)
        {
            _spiderScript.Attack();
        }
    }
}
