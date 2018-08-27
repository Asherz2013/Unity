using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour
{
    private LevelManager levelManager;
    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Use this for initialization
    void OnMouseDown()
    {
        levelManager.LoadLevel("01a Start");
    }
}
