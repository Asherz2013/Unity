using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;

    private bool isPaused = false;
    private float initialFixedDelta;

    void Start()
    {
        initialFixedDelta = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButton ("Fire1"))
        {
            recording = false;
        }
        else
        {
            recording = true;
        }

        if (isPaused)
        {
            isPaused = false;
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = initialFixedDelta;
    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
