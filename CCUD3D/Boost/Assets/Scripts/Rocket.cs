using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class Rocket : MonoBehaviour
{
    // Public Vars
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] float thrustAmount = 50f;
    [SerializeField] float rotationSpeed = 250f;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    // Private Vars
    Rigidbody rigidBody;
    AudioSource audioSource;

    bool isTransitioning = false;

    bool isCollisionEnabled = true;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransitioning)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }

        // Only work when in "Development Build"
        if (Debug.isDebugBuild) RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            isCollisionEnabled = !isCollisionEnabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || !isCollisionEnabled) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // Do Nothing :)
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();
                break;
        }
    }

    private void StartSuccessSequence()
    {
        // Player has landed on the "Ending Strip"
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        // You WILL BE DEAD
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        deathParticles.Play();
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
        isTransitioning = false;
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        currentSceneIndex = currentSceneIndex % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(currentSceneIndex);
        isTransitioning = false;
    }

    private void RespondToThrustInput()
    {
        // Thrusting
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustAmount * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            mainEngineParticles.Play();
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            mainEngineParticles.Stop();
        }
    }

    private void RespondToRotateInput()
    {
        // Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            RotateManually(rotationSpeed);
        }
        // Rotate Right
        else if (Input.GetKey(KeyCode.D))
        {
            RotateManually(-rotationSpeed);
        }
    }

    private void RotateManually(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true; // Take Manual control of Rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rigidBody.freezeRotation = false; // Resume Physics control of Rotation
    }
}
