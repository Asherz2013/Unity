using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour
{

    private MusicManager m_musicManager;

    // Use this for initialization
    void Start()
    {
        m_musicManager = FindObjectOfType<MusicManager>();
        if (m_musicManager) m_musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
        else Debug.LogWarning("No Music Manger found in Scene.");
    }
}
