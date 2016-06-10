using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    public Vector3 launchVelocity;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = launchVelocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
