using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 startPosition;
    
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        rigidBody.useGravity = false;

        startPosition = transform.position;
    }

    public void Launch(Vector3 Velocity)
    {
        rigidBody.velocity = Velocity;
        audioSource.Play();

        rigidBody.useGravity = true;

        inPlay = true;
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = startPosition;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}