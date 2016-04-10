using UnityEngine;
using System.Collections;

public class loseCollider : MonoBehaviour {

    private LevelManager m_LevelManager;

    void Start()
    {
        m_LevelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        m_LevelManager.LoadLevel("Loose");
    }
}
