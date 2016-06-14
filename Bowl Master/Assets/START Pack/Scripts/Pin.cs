using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270f - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}