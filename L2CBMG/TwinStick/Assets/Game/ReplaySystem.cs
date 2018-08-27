using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{

    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager manager;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        int frameNumber = Time.frameCount % bufferFrames;
        keyFrames[frameNumber] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frameNumber = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frameNumber].position;
        transform.rotation = keyFrames[frameNumber].rotation;
    }
}

/// <summary>
/// A structure for storing time, rotation and position
/// </summary>
public class MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}