using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour
{
    [Tooltip ("Number of minutes per second that pass, try 60")]
    public float minutesPerSecond=60.0f;

    private Quaternion startRotation;

    // Use this for initialization
    void Start()
    {
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
    }
}
