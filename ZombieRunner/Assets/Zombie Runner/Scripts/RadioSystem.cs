using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour
{
    public AudioClip initialHeliCall;
    public AudioClip initialCallReply;

    private AudioSource audioSource;
    
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMakeInitialHeliCall()
    {
        audioSource.clip = initialHeliCall;
        audioSource.Play();

        Invoke("InitialReply", initialHeliCall.length + 1f);
    }

    void InitalReply()
    {
        audioSource.clip = initialCallReply;
        audioSource.Play();

        BroadcastMessage("OnDispatchHelicopter");
    }
}
