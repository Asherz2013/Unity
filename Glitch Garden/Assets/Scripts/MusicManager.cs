using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] LevelMusicChangeArray;

    private AudioSource m_audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    void OnLevelWasLoaded(int level)
    {
        AudioClip clip = LevelMusicChangeArray[level];
        if (clip)
        {
            m_audioSource.clip = clip;
            m_audioSource.loop = true;
            m_audioSource.Play();
        }
    }

    public void SetVolume(float volume)
    {
        m_audioSource.volume = volume;
    }
}
