using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody),typeof(AudioSource))]
public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField] float thrustAmount = 50f;
    [SerializeField] float rotationSpeed = 250f;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Friendly":
                // Do Nothing :)
                break;
            case "Finish":
                // Player has landed on the "Ending Stip"
                SceneManager.LoadScene(1);
                break;
            default:
                // You WILL BE DEAD
                SceneManager.LoadScene(0);
                break;
        }
    }

    private void Thrust()
    {
        // Thrusting
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustAmount);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // Take Manual control of Rotation

        // Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        // Rotate Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        rigidBody.freezeRotation = false; // Resume Physics control of Rotation
    }
}
