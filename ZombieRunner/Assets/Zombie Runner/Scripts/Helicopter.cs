using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour
{
    public AudioClip callSound;

    private bool called = false;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!called && Input.GetButtonDown("CallHeli"))
        {
            called = true;
            audioSource.clip = callSound;
            audioSource.Play();
        }
    }
}
